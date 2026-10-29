using System;
using System.Data;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using EquipmentManage;   // DBClass
using System.Collections.Generic;

namespace project
{
    public partial class infoForm : Form
    {
        private DBClass dbc = new DBClass();
        private string sql;

        public infoForm()
        {
            InitializeComponent();

            // DB 연결
            dbc.DB_Open();

        }


        private void InitializeSearchControls()
        {
            cboDivision.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDivision.Items.Clear();
            cboDivision.Items.Add("전체");
            cboDivision.Items.Add("지급중 병력(미회수)");
            cboDivision.Items.Add("최근 지급/회수 내역");
            cboDivision.Items.Add("고장/수리중");
            cboDivision.SelectedIndex = -1;
            cboDivision.Text = "구분";

            cboDateMode.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDateMode.Items.Clear();
            cboDateMode.Items.Add("전체(날짜 무관)");
            cboDateMode.Items.Add("지급일 기준");
            cboDateMode.Items.Add("회수일 기준");
            cboDateMode.Items.Add("지급/회수 전체");
            cboDateMode.SelectedIndex = -1;
            cboDateMode.Text = "날짜 기준";



            // ▼ DateTimePicker 기본 설정
            dtpDateStart.Format = DateTimePickerFormat.Short;
            dtpDateEnd.Format = DateTimePickerFormat.Short;

            // 기본적으로 날짜 조건 안 쓰므로 비활성화
            dtpDateStart.Enabled = false;
            dtpDateEnd.Enabled = false;


            // ▼ 검색기준 라디오 기본값 (장비명 검색 기준)
            rdoSearchByName.Checked = true;
        }



        private void ReloadEquipList()
        {
            try
            {
                //----------------------------------------
                // 0) 공통: 구분, 날짜 모드, 키워드, 기간 준비
                //----------------------------------------
                // ─ 구분 (cboDivision)
                string div;
                if (cboDivision.SelectedIndex < 0 || cboDivision.SelectedItem == null)
                    div = "전체";   // 아직 '구분' 안내문구 상태 → 내부적으로 전체 처리
                else
                    div = cboDivision.SelectedItem.ToString();

                // ─ 날짜 모드 (cboDateMode)
                int dateModeIndex = cboDateMode.SelectedIndex;
                if (dateModeIndex < 0)
                    dateModeIndex = 0;  // 아직 '날짜 기준' 안내문구 상태 → 전체(날짜 무관) 취급

                // index 의미:
                // 0 : 전체(날짜 무관)
                // 1 : 지급일 기준
                // 2 : 회수일 기준
                // 3 : 지급/회수 전체
                bool hasDate = (dateModeIndex >= 1);

                // ─ 키워드
                string keyword = txtFind1.Text.Trim();
                bool hasKeyword = !string.IsNullOrEmpty(keyword);

                // ─ 기간
                DateTime start = dtpDateStart.Value.Date;
                DateTime end = dtpDateEnd.Value.Date;
                DateTime endInclusive = end.AddDays(1).AddSeconds(-1); // 하루 끝까지 포함

                string sql = "";
                var parameters = new List<OracleParameter>();

                //----------------------------------------
                // 1) 구분별 SELECT / WHERE 구성
                //----------------------------------------
                if (div == "전체")
                {
                    sql = @"
                SELECT
                    equip_code       AS 장비코드,
                    equip_name       AS 장비명,
                    equip_type       AS 구분,
                    equip_status     AS 상태,
                    status           AS 내부상태,
                    total_qty        AS 총수량,
                    stock_qty        AS 가용수량,
                    avail_rate       AS 가용률,
                    last_issue_date  AS 최근지급일,
                    remark           AS 비고
                FROM equipment
                WHERE 1 = 1
            ";

                    // 키워드 (장비코드 / 장비명)
                    if (hasKeyword)
                    {
                        if (rdoSearchByName.Checked)
                            sql += " AND equip_name LIKE :pKeyword";
                        else
                            sql += " AND equip_code LIKE :pKeyword";

                        parameters.Add(new OracleParameter("pKeyword", "%" + keyword + "%"));
                    }

                    // 날짜 (last_issue_date 기준)
                    if (hasDate)
                    {
                        sql += " AND last_issue_date BETWEEN :pStart AND :pEnd";
                        parameters.Add(new OracleParameter("pStart", start));
                        parameters.Add(new OracleParameter("pEnd", endInclusive));
                    }

                    sql += " ORDER BY equip_code";
                }
                else if (div == "지급중 병력(미회수)")
                {
                    // v_active_issue : issue_date 기준, return_date 없음
                    sql = @"
                SELECT
                    issue_id     AS 지급번호,
                    soldier_no       AS 군번,
                    name         AS 성명,
                    rank         AS 계급,
                    unit         AS 소속,
                    equip_code   AS 장비코드,
                    equip_name   AS 장비명,
                    issue_date   AS 지급일
                FROM v_active_issue
                WHERE 1 = 1
            ";

                    if (hasKeyword)
                    {
                        if (rdoSearchByName.Checked)
                            sql += " AND equip_name LIKE :pKeyword";
                        else
                            sql += " AND equip_code LIKE :pKeyword";

                        parameters.Add(new OracleParameter("pKeyword", "%" + keyword + "%"));
                    }

                    if (hasDate)
                    {
                        sql += " AND issue_date BETWEEN :pStart AND :pEnd";
                        parameters.Add(new OracleParameter("pStart", start));
                        parameters.Add(new OracleParameter("pEnd", endInclusive));
                    }

                    sql += " ORDER BY issue_date DESC";
                }
                else if (div == "최근 지급/회수 내역")
                {
                    sql = @"
                SELECT
                    issue_date   AS 지급일,
                    action_type  AS 구분,
                    soldier_no       AS 군번,
                    name         AS 성명,
                    unit         AS 소속,
                    equip_code   AS 장비코드,
                    equip_name   AS 장비명,
                    return_date  AS 회수일
                FROM v_recent_hist
                WHERE 1 = 1
            ";

                    if (hasKeyword)
                    {
                        if (rdoSearchByName.Checked)
                            sql += " AND equip_name LIKE :pKeyword";
                        else
                            sql += " AND equip_code LIKE :pKeyword";

                        parameters.Add(new OracleParameter("pKeyword", "%" + keyword + "%"));
                    }

                    // 날짜 모드: 0=무관, 1=지급, 2=회수, 3=둘 다
                    if (hasDate)
                    {
                        switch (dateModeIndex)
                        {
                            case 1: // 지급일 기준
                                sql += " AND issue_date BETWEEN :pStart AND :pEnd";
                                break;

                            case 2: // 회수일 기준
                                sql += " AND return_date BETWEEN :pStart AND :pEnd";
                                break;

                            case 3: // 지급/회수 전체
                                sql += @"
                            AND (
                                    issue_date  BETWEEN :pStart AND :pEnd
                                 OR return_date BETWEEN :pStart AND :pEnd
                                )
                        ";
                                break;
                        }

                        parameters.Add(new OracleParameter("pStart", start));
                        parameters.Add(new OracleParameter("pEnd", endInclusive));
                    }

                    sql += " ORDER BY issue_date DESC";
                }
                else if (div == "고장/수리중")
                {
                    sql = @"
                SELECT
                    equip_code       AS 장비코드,
                    equip_name       AS 장비명,
                    equip_type       AS 구분,
                    equip_status     AS 상태,
                    total_qty        AS 총수량,
                    stock_qty        AS 가용수량,
                    last_issue_date  AS 최근지급일,
                    remark           AS 비고
                FROM equipment
                WHERE status IN ('BROKEN','SERVICE')
            ";

                    if (hasKeyword)
                    {
                        if (rdoSearchByName.Checked)
                            sql += " AND equip_name LIKE :pKeyword";
                        else
                            sql += " AND equip_code LIKE :pKeyword";

                        parameters.Add(new OracleParameter("pKeyword", "%" + keyword + "%"));
                    }

                    if (hasDate)
                    {
                        sql += " AND last_issue_date BETWEEN :pStart AND :pEnd";
                        parameters.Add(new OracleParameter("pStart", start));
                        parameters.Add(new OracleParameter("pEnd", endInclusive));
                    }

                    sql += " ORDER BY equip_code";
                }
                else
                {
                    MessageBox.Show("알 수 없는 구분 값입니다: " + div);
                    return;
                }

                //----------------------------------------
                // 2) 실제 실행 + 그리드 바인딩
                //----------------------------------------
                using (OracleCommand cmd = new OracleCommand(sql, dbc.Con))
                {
                    foreach (var p in parameters)
                        cmd.Parameters.Add(p);

                    using (OracleDataAdapter da = new OracleDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvEquipList.DataSource = dt;
                        dgvEquipList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("장비 목록 로딩/검색 중 오류: " + ex.Message);
            }
        }



        private void infoForm_Load(object sender, EventArgs e)
        {
            try
            {
                InitializeSearchControls(); // 🔹 새로 추가할 메서드
                LoadSummaryCards();         // 상단 카드
                //ReloadEquipList();          // 하단 목록 + 검색/필터
            }
            catch (Exception ex)
            {
                MessageBox.Show("정보창 로딩 중 오류: " + ex.Message);
            }
        }

        // ================== 1. 상단 4개 카드 채우기 ==================
        private void LoadSummaryCards()
        {
            // ---------- 1) 장비 현황: 총/가용/열외 ----------
            int totalQty = 0;
            int stockQty = 0;
            double totalRate = 0;

            sql = @"
        SELECT
            NVL(SUM(total_qty), 0) AS sum_total,
            NVL(SUM(stock_qty), 0) AS sum_stock,
            CASE
                WHEN NVL(SUM(total_qty),0) = 0 THEN 0
                ELSE ROUND(NVL(SUM(stock_qty),0) / SUM(total_qty) * 100, 2)
            END AS sum_rate
        FROM equipment";

            using (OracleCommand cmd = new OracleCommand(sql, dbc.Con))
            using (OracleDataReader dr = cmd.ExecuteReader())
            {
                if (dr.Read())
                {
                    totalQty = Convert.ToInt32(dr["sum_total"]);
                    stockQty = Convert.ToInt32(dr["sum_stock"]);
                    totalRate = Convert.ToDouble(dr["sum_rate"]);
                }
            }

            int outQty = totalQty - stockQty;
            if (outQty < 0) outQty = 0;

            // ---------- 2) 지급 현황: 지급중 장비 / 장비 보유 병력 ----------
            int issuedCount = 0;
            int issuedSoldierCount = 0;

            sql = @"
        SELECT
            NVL(COUNT(*), 0) AS cnt_issue,
            NVL(COUNT(DISTINCT soldier_no), 0) AS cnt_soldier
        FROM v_active_issue";

            using (OracleCommand cmd = new OracleCommand(sql, dbc.Con))
            using (OracleDataReader dr = cmd.ExecuteReader())
            {
                if (dr.Read())
                {
                    issuedCount = Convert.ToInt32(dr["cnt_issue"]);
                    issuedSoldierCount = Convert.ToInt32(dr["cnt_soldier"]);
                }
            }

            // ---------- 3) 결함 장비: 고장/수리중 ----------
            int brokenCnt = 0;
            int serviceCnt = 0;

            sql = @"
        SELECT
            SUM(CASE WHEN status = 'BROKEN'  THEN 1 ELSE 0 END) AS cnt_broken,
            SUM(CASE WHEN status = 'SERVICE' THEN 1 ELSE 0 END) AS cnt_service
        FROM equipment";

            using (OracleCommand cmd = new OracleCommand(sql, dbc.Con))
            using (OracleDataReader dr = cmd.ExecuteReader())
            {
                if (dr.Read())
                {
                    brokenCnt = dr["cnt_broken"] == DBNull.Value ? 0 : Convert.ToInt32(dr["cnt_broken"]);
                    serviceCnt = dr["cnt_service"] == DBNull.Value ? 0 : Convert.ToInt32(dr["cnt_service"]);
                }
            }

            int defectKinds = brokenCnt + serviceCnt;

            // ---------- 4) 라벨에 값 넣기 ----------

            // (1) 장비 현황
            lblEquipMain.Text = $"총 {totalQty}개 / 가용 {stockQty}개";
            lblEquipSub.Text = $"열외 {outQty}개 (지급중 {issuedCount}개 / 고장 {brokenCnt}종 / 수리 {serviceCnt}종)";

            // (2) 지급 현황
            lblIssueMain.Text = $"지급중 장비 {issuedCount}개";
            lblIssueSub.Text = $"장비 보유 병력 {issuedSoldierCount}명";

            // (3) 결함 장비
            lblBrokenMain.Text = $"고장 {brokenCnt}종 / 수리중 {serviceCnt}종";
            lblBrokenSub.Text = $"총 {defectKinds}종 사용 불가";

            // (4) 전체 가용률
            lblRateMain.Text = $"{totalRate:0.##} %";

            string comment;
            if (totalRate >= 80) comment = "준비태세 양호";
            else if (totalRate >= 60) comment = "주의 필요";
            else comment = "정비 긴급";

            lblRateSub.Text = comment;
        }

        // ================== 2. 하단 장비 목록 그리드 ==================
        private void LoadEquipListGrid()
        {
            sql = @"
                SELECT
                    equip_code,
                    equip_name,
                    equip_type,
                    total_qty,
                    stock_qty,
                    (total_qty - stock_qty) AS out_qty,
                    equip_status,
                    status,
                    remark
                FROM equipment
                ORDER BY equip_code";

            using (OracleDataAdapter da = new OracleDataAdapter(sql, dbc.Con))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvEquipList.DataSource = dt;

                if (dgvEquipList.Columns.Count > 0)
                {
                    dgvEquipList.Columns["EQUIP_CODE"].HeaderText = "코드";
                    dgvEquipList.Columns["EQUIP_NAME"].HeaderText = "장비명";
                    dgvEquipList.Columns["EQUIP_TYPE"].HeaderText = "구분";
                    dgvEquipList.Columns["TOTAL_QTY"].HeaderText = "총보유";
                    dgvEquipList.Columns["STOCK_QTY"].HeaderText = "가용";
                    dgvEquipList.Columns["OUT_QTY"].HeaderText = "외부지급";
                    dgvEquipList.Columns["EQUIP_STATUS"].HeaderText = "상태(표시)";
                    dgvEquipList.Columns["STATUS"].HeaderText = "상태(코드)";
                    dgvEquipList.Columns["REMARK"].HeaderText = "비고";
                }
            }
        }
        private void LoadEquipList()
        {
            try
            {
                string sql = @"
            SELECT
                equip_code       AS 장비코드,
                equip_name       AS 장비명,
                equip_type       AS 구분,
                equip_status     AS 상태,
                status           AS 내부상태,
                total_qty        AS 총수량,
                stock_qty        AS 가용수량,
                avail_rate       AS 가용률,
                last_issue_date  AS 최근지급일,
                remark           AS 비고
            FROM equipment
            ORDER BY equip_code
        ";

                OracleDataAdapter da = new OracleDataAdapter(sql, dbc.Con);
                DataSet ds = new DataSet();
                da.Fill(ds, "equip");

                dgvEquipList.DataSource = ds.Tables["equip"];

                // 컬럼 자동 크기 조정 (가독성↑)
                dgvEquipList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show("장비 목록 로딩 중 오류: " + ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ReloadEquipList();   // 조건(키워드/구분/날짜) 다 반영해서 다시 조회
        }


        private void txtFind1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;   // 삑 소리, 줄바꿈 방지
                btnSearch.PerformClick();      // 검색 버튼 대신 실행
            }
        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void radioEqName_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cboDateMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 🔹 날짜 기준 인덱스
            // 0 : 전체(날짜 무관)
            // 1 : 지급일 기준
            // 2 : 회수일 기준
            // 3 : 지급/회수 전체

            // 1 이상부터는 기간이 필요하다고 보는 게 자연스럽습니다.
            bool needRange = (cboDateMode.SelectedIndex >= 1);
            dtpDateStart.Enabled = needRange;
            dtpDateEnd.Enabled = needRange;

            // ❌ 여기서 ReloadEquipList() 호출하던 거 삭제
            // ReloadEquipList();
        }



        private void cboDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ❌ 구분 바뀐다고 바로 조회하지 않게 비워둡니다.
            // 이전에는 여기서 ReloadEquipList()를 호출하고 있었음.
            // ReloadEquipList();
        }


        // 콤보박스 첫 DropDown 때 기본값 잡기
        // 콤보박스 첫 DropDown 때 기본값 잡기
        private bool _divisionFirstOpen = true;
        private bool _dateFirstOpen = true;

        private void cboDivision_DropDown(object sender, EventArgs e)
        {
            // 더 이상 첫 드롭다운 시 강제 선택 안 함
        }

        private void cboDateMode_DropDown(object sender, EventArgs e)
        {
            // 더 이상 첫 드롭다운 시 강제 선택 안 함
        }



    }
}