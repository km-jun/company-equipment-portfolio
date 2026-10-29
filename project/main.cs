using EquipmentManage;   // DBClass 가 있는 네임스페이스
using Oracle.DataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;

namespace project
{
    public partial class main : Form
    {
        // ====== 공통 필드 ======
        private DBClass dbc = new DBClass();
        private string sql;

        // 회수 시 사용할 선택 정보 (지급중 병력 그리드에서 가져옴)
        private int lastIssueId = -1;
        private string lastMilNo = null;
        private string lastEquipCode = null;
        private DateTime lastIssueDate;

        // ====== 지급용 캐시 (LoadSoldierInfo / LoadEquipInfo 에서 채움) ======
        private string curSoldierNo;
        private string curSoldierName;
        private string curSoldierRank;
        private string curSoldierUnit;

        private string curEquipCode;
        private string curEquipName;
        private string curEquipType;
        private string curEquipStatus;   // 정상/고장/수리중
        private string curEquipState;    // READY/OUT/BROKEN/SERVICE
        private int curTotalQty;
        private int curStockQty;
        private double curAvailRate;


        public main()
        {
            InitializeComponent();

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            // DB 연결만 열어 두면 됨
            dbc.DB_Open();
        }

        // ========== 폼 로드 ==========
        private void main_Load(object sender, EventArgs e)
        {
            try
            {
                LoadBrokenEquip();
                LoadActiveIssue();
                LoadRecentHist();

                // 회수 탭 기본 설정
                rdoReturnNormal.Checked = true;
                lblReturnInfo.Text = "선택된 지급 내역: -";

                InitActiveSearchUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show("초기 로딩 중 오류: " + ex.Message);
            }
        }

        // ================== 지급중 병력 검색 UI 초기화 ==================
        private void InitActiveSearchUI()
        {
            // 기본값: 장비 검색 선택
            radioEqName.Checked = true;
            radioSolName.Checked = false;

            UpdateSearchFieldItems();
        }

        // 라디오버튼에 따라 검색 기준 콤보박스 항목 채우기
        private void UpdateSearchFieldItems()
        {
            cboSearchField.Items.Clear();

            if (radioEqName.Checked)
            {
                // 장비 선택 시
                cboSearchField.Items.Add("장비명");
                cboSearchField.Items.Add("장비코드");
            }
            else if (radioSolName.Checked)
            {
                // 병력 선택 시
                cboSearchField.Items.Add("이름");
                cboSearchField.Items.Add("군번");
            }

            if (cboSearchField.Items.Count > 0)
                cboSearchField.SelectedIndex = 0;
        }

        // ========== 1. 고장/수리중 장비 로딩 ==========
        private void LoadBrokenEquip()
        {
            sql = "SELECT * FROM v_broken_equip";

            OracleDataAdapter da = new OracleDataAdapter(sql, dbc.DBCON);
            DataSet ds = new DataSet();
            da.Fill(ds, "broken");

            dgvBroken.DataSource = ds.Tables["broken"];

            if (dgvBroken.Columns.Count > 0)
            {
                dgvBroken.Columns["EQUIP_CODE"].HeaderText = "장비코드";
                dgvBroken.Columns["EQUIP_NAME"].HeaderText = "장비명";
                dgvBroken.Columns["EQUIP_TYPE"].HeaderText = "구분";
                dgvBroken.Columns["EQUIP_STATUS"].HeaderText = "상태";
                dgvBroken.Columns["TOTAL_QTY"].HeaderText = "총수량";
                dgvBroken.Columns["STOCK_QTY"].HeaderText = "가용수량";
                dgvBroken.Columns["REMARK"].HeaderText = "비고";
            }

            UpdateBrokenCount();
        }

        // ========== 2. 지급중 병력(미회수) 로딩 ==========
        private void LoadActiveIssue()  //여기만 해보자
        {
            sql = "SELECT * FROM v_active_issue ORDER BY issue_date DESC";

            OracleDataAdapter da = new OracleDataAdapter(sql, dbc.DBCON);
            DataSet ds = new DataSet();
            da.Fill(ds, "active");

            dgvActive.DataSource = ds.Tables["active"];

            if (dgvActive.Columns.Count > 0)
            {
                dgvActive.Columns["ISSUE_ID"].HeaderText = "지급번호";
                dgvActive.Columns["SOLDIER_NO"].HeaderText = "군번";
                dgvActive.Columns["NAME"].HeaderText = "이름";
                dgvActive.Columns["RANK"].HeaderText = "계급";
                dgvActive.Columns["UNIT"].HeaderText = "소속";
                dgvActive.Columns["EQUIP_CODE"].HeaderText = "장비코드";
                dgvActive.Columns["EQUIP_NAME"].HeaderText = "장비명";
                dgvActive.Columns["ISSUE_DATE"].HeaderText = "지급일";
            }

            UpdateActiveCount();
        }

        // ========== 3. 최근 지급/회수 내역 로딩 ==========
        private void LoadRecentHist()
        {
            sql = "SELECT * FROM v_recent_hist";

            OracleDataAdapter da = new OracleDataAdapter(sql, dbc.DBCON);
            DataSet ds = new DataSet();
            da.Fill(ds, "recent");

            // [변경점 2] DataSource 연결을 끊고, 기존 아이템을 비웁니다.
            // dgvRecent.DataSource = ds.Tables["recent"]; (삭제)
            lvRecent.Items.Clear();

            // [변경점 3] 컬럼(헤더)을 코드로 만들어줍니다. 
            // (디자이너에서 미리 만들어뒀다면 이 부분은 생략 가능합니다)
            if (lvRecent.Columns.Count == 0)
            {
                lvRecent.Columns.Add("지급일", 100);
                lvRecent.Columns.Add("구분", 80);
                lvRecent.Columns.Add("군번", 100);
                lvRecent.Columns.Add("이름", 80);
                lvRecent.Columns.Add("소속", 120);
                lvRecent.Columns.Add("장비코드", 100);
                lvRecent.Columns.Add("장비명", 150);
                lvRecent.Columns.Add("회수일", 100);
            }

            // [변경점 4] 반복문을 돌며 데이터를 한 줄씩 꽂아넣습니다.
            lvRecent.BeginUpdate(); // 속도 향상을 위해 화면 갱신 잠시 중지

            foreach (DataRow row in ds.Tables["recent"].Rows)
            {
                // 1. 첫 번째 컬럼(Main Item) 생성 - 지급일
                // DB에서 null일 경우를 대비해 .ToString() 사용
                ListViewItem item = new ListViewItem(row["ISSUE_DATE"].ToString());

                // 2. 나머지 컬럼(SubItems) 추가
                item.SubItems.Add(row["ACTION_TYPE"].ToString()); // 구분
                item.SubItems.Add(row["SOLDIER_NO"].ToString());  // 군번
                item.SubItems.Add(row["NAME"].ToString());        // 이름
                item.SubItems.Add(row["UNIT"].ToString());        // 소속
                item.SubItems.Add(row["EQUIP_CODE"].ToString());  // 장비코드
                item.SubItems.Add(row["EQUIP_NAME"].ToString());  // 장비명

                // 날짜 같은 경우 null일 수 있으므로 체크 (선택사항)
                string returnDate = row["RETURN_DATE"] == DBNull.Value ? "" : row["RETURN_DATE"].ToString();
                item.SubItems.Add(returnDate);                    // 회수일

                // 3. 리스트뷰에 완성된 줄 추가
                lvRecent.Items.Add(item);
            }

            lvRecent.EndUpdate(); // 화면 갱신 재개

            UpdateRecentCount();
        }
        // ============================================================
        // [지급 탭] - 지급 버튼 (최종 정리본)
        // ============================================================
        private void btnIssue_Click(object sender, EventArgs e)
        {
            // 0) 기본 입력 + 병사/장비 정보 로딩
            if (!LoadSoldierInfo()) return;
            if (!LoadEquipInfo()) return;

            // 장비 상태 체크 (고장/수리중 등)
            if (curEquipStatus == "고장" || curEquipStatus == "수리중" ||
                curEquipState == "BROKEN" || curEquipState == "SERVICE")
            {
                MessageBox.Show("고장 또는 수리중 장비는 지급할 수 없습니다.",
                    "지급 불가", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 가용 수량 체크 (1개도 없으면 지급 불가)
            if (curStockQty <= 0)
            {
                MessageBox.Show("해당 장비의 가용 수량이 없습니다.",
                    "지급 불가", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OracleConnection conn = dbc.DBCON;
            OracleTransaction tran = null;

            try
            {
                tran = conn.BeginTransaction();

                // 1) 새 issue_id 생성
                int newIssueId = 0;
                using (OracleCommand cmd = new OracleCommand(
                    "SELECT NVL(MAX(issue_id), 0) + 1 FROM issue_history", conn))
                {
                    cmd.Transaction = tran;
                    newIssueId = Convert.ToInt32(cmd.ExecuteScalar());
                }

                // 2) issue_history INSERT
                using (OracleCommand cmd = new OracleCommand(
                    @"INSERT INTO issue_history(issue_id, soldier_no, equip_code, issue_date, return_date)
                      VALUES (:p_issue_id, :p_soldier_no, :p_equip_code, SYSDATE, NULL)", conn))
                {
                    cmd.Transaction = tran;
                    cmd.Parameters.Add(":p_issue_id", newIssueId);
                    cmd.Parameters.Add(":p_soldier_no", curSoldierNo);
                    cmd.Parameters.Add(":p_equip_code", curEquipCode);
                    cmd.ExecuteNonQuery();
                }

                // 3) 새 trans_id 생성
                int newTransId = 0;
                using (OracleCommand cmd = new OracleCommand(
                    "SELECT NVL(MAX(trans_id), 0) + 1 FROM transaction_history", conn))
                {
                    cmd.Transaction = tran;
                    newTransId = Convert.ToInt32(cmd.ExecuteScalar());
                }

                // 4) transaction_history INSERT (지급)
                using (OracleCommand cmd = new OracleCommand(
                    @"INSERT INTO transaction_history(trans_id, soldier_no, equip_code, issue_date, return_date)
                      VALUES (:p_trans_id, :p_soldier_no, :p_equip_code, SYSDATE, NULL)", conn))
                {
                    cmd.Transaction = tran;
                    cmd.Parameters.Add(":p_trans_id", newTransId);
                    cmd.Parameters.Add(":p_soldier_no", txtIssueMilNo.Text.Trim());
                    cmd.Parameters.Add(":p_equip_code", curEquipCode);
                    cmd.ExecuteNonQuery();
                }

                // 5) equipment 재고/상태 업데이트 (1개 감소)
                using (OracleCommand cmd = new OracleCommand(
                    @"UPDATE equipment
                          SET stock_qty      = stock_qty - 1,
                              last_issue_date = SYSDATE,
                              avail_rate      = CASE
                                                  WHEN total_qty = 0 THEN 0
                                                  ELSE ROUND((stock_qty - 1) / total_qty * 100, 2)
                                                END,
                              status          = CASE
                                                  WHEN (stock_qty - 1) <= 0 THEN 'OUT'
                                                  ELSE status
                                                END
                        WHERE equip_code = :p_equip_code", conn))
                {
                    cmd.Transaction = tran;
                    cmd.Parameters.Add(":p_equip_code", curEquipCode);
                    cmd.ExecuteNonQuery();
                }

                tran.Commit();

                MessageBox.Show("지급이 완료되었습니다.", "지급",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 그리드 갱신
                LoadBrokenEquip();
                LoadActiveIssue();
                LoadRecentHist();
                txtIssueMilNo.Clear();
                txtIssueEquipCode.Clear();
            }
            catch (Exception ex)
            {
                if (tran != null) tran.Rollback();
                MessageBox.Show("지급 처리 중 오류: " + ex.Message,
                    "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================================
        // [회수 탭] - 지급중 병력 그리드 클릭 이벤트 (안전 버전)
        // ============================================================
        private void dgvActive_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvActive.Rows.Count == 0) return;

            DataGridViewRow row = dgvActive.Rows[e.RowIndex];

            // v_active_issue 컬럼 기준
            lastIssueId = GetCellInt(row, "ISSUE_ID", 0);
            lastMilNo = GetCellString(row, "SOLDIER_NO", 1);
            string name = GetCellString(row, "NAME", 2);
            string rank = GetCellString(row, "RANK", 3);
            string unit = GetCellString(row, "UNIT", 4);
            lastEquipCode = GetCellString(row, "EQUIP_CODE", 5);
            string equip = GetCellString(row, "EQUIP_NAME", 6);
            lastIssueDate = GetCellDate(row, "ISSUE_DATE", 7);

            if (lastIssueId <= 0 || string.IsNullOrEmpty(lastMilNo) || string.IsNullOrEmpty(lastEquipCode))
            {
                lblReturnInfo.Text = "선택된 지급 내역: -";
                return;
            }

            lblReturnInfo.Text =
                $"[지급번호 {lastIssueId}] {lastMilNo} {name} ({rank}, {unit})\n" +
                $"장비: {lastEquipCode} {equip}\n" +
                $"지급일: {lastIssueDate:yyyy-MM-dd}";

            // 자동으로 회수 탭으로 전환
            tabIssueReturn.SelectedTab = tabReturn;
        }

        // ============================================================
        // [회수 탭] - 회수 처리 버튼
        // ============================================================
        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (lastIssueId <= 0 || string.IsNullOrEmpty(lastMilNo) || string.IsNullOrEmpty(lastEquipCode))
            {
                MessageBox.Show("먼저 '지급중 병력(미회수)' 목록에서 회수할 대상을 선택하세요.",
                    "회수", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool isBroken = rdoReturnBroken.Checked;
            bool toService = chkReturnService.Checked;

            OracleConnection conn = dbc.DBCON;
            OracleTransaction tran = null;

            try
            {
                tran = conn.BeginTransaction();

                // 1) issue_history 회수 처리
                using (OracleCommand cmd = new OracleCommand(
                    @"UPDATE issue_history
                          SET return_date = SYSDATE
                        WHERE issue_id = :p_issue_id", conn))
                {
                    cmd.Transaction = tran;
                    cmd.Parameters.Add(":p_issue_id", lastIssueId);
                    cmd.ExecuteNonQuery();
                }

                // 2) transaction_history 회수 처리
                using (OracleCommand cmd = new OracleCommand(
                    @"UPDATE transaction_history
                          SET return_date = SYSDATE
                        WHERE soldier_no     = :p_soldier_no
                          AND equip_code = :p_equip_code
                          AND issue_date = :p_issue_date
                          AND return_date IS NULL", conn))
                {
                    cmd.Transaction = tran;
                    cmd.Parameters.Add(":p_soldier_no", lastMilNo);
                    cmd.Parameters.Add(":p_equip_code", lastEquipCode);
                    cmd.Parameters.Add(":p_issue_date", lastIssueDate);
                    cmd.ExecuteNonQuery();
                }

                // 3) 장비 재고 / 상태 갱신
                if (isBroken)
                {
                    if (toService)
                    {
                        // 수리 의뢰
                        using (OracleCommand cmd = new OracleCommand(
                            @"UPDATE equipment
                                  SET equip_status = '수리중',
                                      status       = 'SERVICE',
                                      remark       = NVL(remark, '') 
                                                     || ' / '
                                                     || TO_CHAR(SYSDATE, 'MM-DD')
                                                     || ' 수리 의뢰',
                                      avail_rate   = CASE
                                                       WHEN total_qty = 0 THEN 0
                                                       ELSE ROUND(stock_qty / total_qty * 100, 2)
                                                     END
                                WHERE equip_code = :p_equip_code", conn))
                        {
                            cmd.Transaction = tran;
                            cmd.Parameters.Add(":p_equip_code", lastEquipCode);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        // 고장으로만 처리
                        using (OracleCommand cmd = new OracleCommand(
                            @"UPDATE equipment
                                  SET equip_status = '고장',
                                      status       = 'BROKEN',
                                      remark       = NVL(remark, '') 
                                                     || ' / '
                                                     || TO_CHAR(SYSDATE, 'MM-DD')
                                                     || ' 고장 반납',
                                      avail_rate   = CASE
                                                       WHEN total_qty = 0 THEN 0
                                                       ELSE ROUND(stock_qty / total_qty * 100, 2)
                                                     END
                                WHERE equip_code = :p_equip_code", conn))
                        {
                            cmd.Transaction = tran;
                            cmd.Parameters.Add(":p_equip_code", lastEquipCode);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                else
                {
                    // 정상 회수
                    using (OracleCommand cmd = new OracleCommand(
                        @"UPDATE equipment
                              SET stock_qty    = stock_qty + 1,
                                  avail_rate  = CASE
                                                  WHEN total_qty = 0 THEN 0
                                                  ELSE ROUND((stock_qty + 1) / total_qty * 100, 2)
                                                END,
                                  status      = 'READY',
                                  equip_status = '정상'
                        WHERE equip_code = :p_equip_code", conn))
                    {
                        cmd.Transaction = tran;
                        cmd.Parameters.Add(":p_equip_code", lastEquipCode);
                        cmd.ExecuteNonQuery();
                    }
                }

                tran.Commit();

                MessageBox.Show("회수 처리가 완료되었습니다.", "회수",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                lastIssueId = -1;
                lastMilNo = null;
                lastEquipCode = null;
                lblReturnInfo.Text = "선택된 지급 내역: -";

                LoadBrokenEquip();
                LoadActiveIssue();
                LoadRecentHist();
            }
            catch (Exception ex)
            {
                if (tran != null) tran.Rollback();
                MessageBox.Show("회수 처리 중 오류: " + ex.Message,
                    "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrev_Click(object sender, EventArgs e) { }
        private void btnSearchCode_Click(object sender, EventArgs e)
        {
            // 1) 데이터 소스 확인
            DataTable dt = dgvActive.DataSource as DataTable;
            if (dt == null)
            {
                MessageBox.Show("데이터가 로드되지 않았습니다.", "오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2) 검색어 읽기
            string keyword = txtFind1.Text.Trim();

            // 검색어가 비어 있으면 필터 해제 = 전체 보기
            if (string.IsNullOrEmpty(keyword))
            {
                dt.DefaultView.RowFilter = string.Empty;
                UpdateActiveCount();
                return;
            }

            // 작은따옴표 이스케이프 (RowFilter 문법 오류 방지)
            keyword = keyword.Replace("'", "''");

            // 3) 콤보박스 선택값 → 실제 컬럼명 매핑
            string selectedField = cboSearchField.SelectedItem as string;
            string columnName = "";

            switch (selectedField)
            {
                case "장비명":
                    columnName = "EQUIP_NAME";
                    break;
                case "장비코드":
                    columnName = "EQUIP_CODE";
                    break;
                case "이름":
                    columnName = "NAME";
                    break;
                case "군번":
                    columnName = "SOLDIER_NO";
                    break;
                default:
                    MessageBox.Show("검색 기준을 선택하세요.", "검색",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
            }

            string filterExpression = $"{columnName} LIKE '%{keyword}%'";

            // 4) 필터 적용
            try
            {
                dt.DefaultView.RowFilter = filterExpression;
                UpdateActiveCount();
            }
            catch (Exception ex)
            {
                MessageBox.Show("검색 필터 적용 중 오류: " + ex.Message,
                    "필터 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== 예전 버튼용 더미 이벤트 핸들러들 ====================
        private void btnSortByCode_Click(object sender, EventArgs e) { }
        private void btnSortByDate_Click(object sender, EventArgs e) { }
        private void btnSortByRate_Click(object sender, EventArgs e) { }
        private void btnSotrByName_Click(object sender, EventArgs e) { }

        // ------------ DataGridViewRow에서 안전하게 값 꺼내는 도우미 ------------
        private string GetCellString(DataGridViewRow row, string columnName, int fallbackIndex)
        {
            object val = null;

            if (row.DataGridView.Columns.Contains(columnName))
                val = row.Cells[columnName].Value;
            else if (fallbackIndex >= 0 && fallbackIndex < row.Cells.Count)
                val = row.Cells[fallbackIndex].Value;

            return (val == null || val == DBNull.Value) ? "" : val.ToString();
        }

        private int GetCellInt(DataGridViewRow row, string columnName, int fallbackIndex)
        {
            string s = GetCellString(row, columnName, fallbackIndex);
            int result;
            return int.TryParse(s, out result) ? result : 0;
        }

        private DateTime GetCellDate(DataGridViewRow row, string columnName, int fallbackIndex)
        {
            string s = GetCellString(row, columnName, fallbackIndex);
            DateTime dt;
            return DateTime.TryParse(s, out dt) ? dt : DateTime.MinValue;
        }

        // ================== 지급용: 병사 정보 로딩 ==================
        private bool LoadSoldierInfo()
        {
            string milNo = txtIssueMilNo.Text.Trim();
            if (string.IsNullOrEmpty(milNo))
            {
                MessageBox.Show("군번을 입력하세요.", "지급",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            using (OracleCommand cmd = new OracleCommand(
                "SELECT soldier_no, name, rank, unit FROM soldier WHERE soldier_no = :p_milno",
                dbc.DBCON))
            {
                cmd.Parameters.Add(":p_milno", milNo);

                using (OracleDataReader dr = cmd.ExecuteReader())
                {
                    if (!dr.Read())
                    {
                        MessageBox.Show("해당 군번의 병사를 찾을 수 없습니다.", "지급",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        curSoldierNo = null;
                        //lblIssueSoldierInfo.Text = "이름 / 계급 / 소속";
                        return false;
                    }

                    curSoldierNo = dr.GetString(0);
                    curSoldierName = dr.GetString(1);
                    curSoldierRank = dr.IsDBNull(2) ? "" : dr.GetString(2);
                    curSoldierUnit = dr.IsDBNull(3) ? "" : dr.GetString(3);

                    //lblIssueSoldierInfo.Text =
                    //    $"{milNo} {curSoldierName} / {curSoldierRank} / {curSoldierUnit}";
                    return true;
                }
            }
        }

        // ================== 지급용: 장비 정보 로딩 ==================
        private bool LoadEquipInfo()
        {
            string equipCode = txtIssueEquipCode.Text.Trim();
            if (string.IsNullOrEmpty(equipCode))
            {
                MessageBox.Show("장비 코드를 입력하세요.", "지급",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            using (OracleCommand cmd = new OracleCommand(
                @"SELECT equip_name, equip_type, equip_status, status,
                         total_qty, stock_qty, avail_rate
                  FROM equipment
                  WHERE equip_code = :p_code",
                dbc.DBCON))
            {
                cmd.Parameters.Add(":p_code", equipCode);

                using (OracleDataReader dr = cmd.ExecuteReader())
                {
                    if (!dr.Read())
                    {
                        MessageBox.Show("해당 장비 코드를 찾을 수 없습니다.", "지급",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtIssueEquipCode.Clear();
                        curEquipCode = null;
                        return false;
                    }

                    curEquipName = dr.GetString(0);
                    curEquipType = dr.IsDBNull(1) ? "" : dr.GetString(1);
                    curEquipStatus = dr.IsDBNull(2) ? "" : dr.GetString(2);
                    curEquipState = dr.IsDBNull(3) ? "" : dr.GetString(3);

                    object oTotal = dr.GetValue(4);
                    object oStock = dr.GetValue(5);
                    object oRate = dr.GetValue(6);

                    curTotalQty = (oTotal == null || oTotal == DBNull.Value) ? 0 : Convert.ToInt32(oTotal);
                    curStockQty = (oStock == null || oStock == DBNull.Value) ? 0 : Convert.ToInt32(oStock);
                    curAvailRate = (oRate == null || oRate == DBNull.Value) ? 0.0 : Convert.ToDouble(oRate);

                    curEquipCode = equipCode; //이게 있어야 그리드 초기화 가능

                    //                    txtIssueEquipCode.Text = $"{equipCode} / ({curEquipName})";

                    return true;
                }
            }
        }

        // ================== 그리드 Row 개수 → "총 000개/명/건" 표시 ==================
        private void UpdateBrokenCount()
        {
            int cnt = dgvBroken.RowCount;
            if (dgvBroken.AllowUserToAddRows) cnt--;
            if (cnt < 0) cnt = 0;
            lblBrokenCount.Text = "총 " + cnt + "개";
        }

        private void UpdateActiveCount()
        {
            int cnt = dgvActive.RowCount;
            if (dgvActive.AllowUserToAddRows) cnt--;
            if (cnt < 0) cnt = 0;
            lblActiveCount.Text = "총 " + cnt + "명";
        }

        private void UpdateRecentCount()
        {
            // [변경점 1] RowCount 대신 Items.Count를 사용합니다.
            int cnt = lvRecent.Items.Count;

            // ListView는 "새 행 추가" 옵션 개념이 없으므로 -1 처리가 필요 없습니다.
            lblRecentCount.Text = "총 " + cnt + "건";
            //int cnt = dgvRecent.RowCount;
            //if (dgvRecent.AllowUserToAddRows) cnt--;
            //if (cnt < 0) cnt = 0;
            //lblRecentCount.Text = "총 " + cnt + "건";
        }

        // ===== 군번/장비코드 확인 버튼 & 엔터키 =====
        private void btnIssueMilConfirm_Click(object sender, EventArgs e)
        {//확인 버튼 누르면 상세보기 뜨게
         // 1. TextBox에서 값을 가져와 공백을 제거합니다.
            string milNo = txtIssueMilNo.Text.Trim();
            using (OracleCommand cmd = new OracleCommand(
    "SELECT soldier_no, name, rank, unit FROM soldier WHERE soldier_no = :p_milno",
    dbc.DBCON))
            {
                cmd.Parameters.Add(":p_milno", milNo);

                using (OracleDataReader dr = cmd.ExecuteReader())
                {
                    dr.Read();
                    curSoldierName = dr.GetString(1);
                    curSoldierRank = dr.IsDBNull(2) ? "" : dr.GetString(2);
                }
                MessageBox.Show(curSoldierRank + " " + curSoldierName);


            }
        }

        private void btnIssueEquipConfirm_Click(object sender, EventArgs e)
        {
            string equipCode = txtIssueEquipCode.Text.Trim();
            using (OracleCommand cmd = new OracleCommand(
                @"SELECT equip_name, equip_type, equip_status, status,
                         total_qty, stock_qty, avail_rate
                  FROM equipment
                  WHERE equip_code = :p_code",
                dbc.DBCON))
            {
                cmd.Parameters.Add(":p_code", equipCode);

                using (OracleDataReader dr = cmd.ExecuteReader())
                {
                    dr.Read();
                    curEquipName = dr.GetString(0);
                    curEquipType = dr.IsDBNull(1) ? "" : dr.GetString(1);
                    curEquipStatus = dr.IsDBNull(2) ? "" : dr.GetString(2);
                    curEquipState = dr.IsDBNull(3) ? "" : dr.GetString(3);

                    object oTotal = dr.GetValue(4);
                    object oStock = dr.GetValue(5);
                    object oRate = dr.GetValue(6);

                    curTotalQty = (oTotal == null || oTotal == DBNull.Value) ? 0 : Convert.ToInt32(oTotal);
                    curStockQty = (oStock == null || oStock == DBNull.Value) ? 0 : Convert.ToInt32(oStock);
                    curAvailRate = (oRate == null || oRate == DBNull.Value) ? 0.0 : Convert.ToDouble(oRate);
                }
            }
            MessageBox.Show(curEquipName + " " + curTotalQty + "개");
        }

        private void txtIssueMilNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                LoadSoldierInfo();
            }
        }

        private void txtIssueEquipCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                LoadEquipInfo();
            }
        }

        // 군번 텍스트박스 클릭 → 병사 검색 폼
        private void txtIssueMilNo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;   // 왼쪽 버튼만

            using (soldier frm = new soldier())
            {
                // (선택) 중앙에 띄7우고 싶으면:
                frm.StartPosition = FormStartPosition.CenterParent;

                var result = frm.ShowDialog(this);   // this = main 폼을 owner 로
                if (result == DialogResult.OK && !string.IsNullOrEmpty(frm.SelectedMilNo))
                {
                    txtIssueMilNo.Text = frm.SelectedMilNo;
                    LoadSoldierInfo();  // 선택된 군번으로 병사 정보 로딩
                }
            }
        }
        // 장비코드 텍스트박스 클릭 → 장비 검색 폼
        private void txtIssueEquipCode_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            using (equipment frm = new equipment())
            {
                frm.StartPosition = FormStartPosition.CenterParent;
                var result = frm.ShowDialog(this);
                if (result == DialogResult.OK && !string.IsNullOrEmpty(frm.SelectedEquipCode))
                {
                    txtIssueEquipCode.Text = frm.SelectedEquipCode;
                    LoadEquipInfo();
                }
            }
        }

        // 필요하면 TextChanged 이벤트는 디자이너에서 연결 해제해도 됨
        private void txtIssueMilNo_TextChanged(object sender, EventArgs e) { }
        private void txtIssueEquipCode_TextChanged(object sender, EventArgs e) { }

        private void txtIssueMilNo_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void 검색ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Serch frm = new Serch())
            {
                frm.StartPosition = FormStartPosition.CenterParent;

                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    var criteria = frm.Criteria;

                    // 1) 메인 그리드(dgvBroken)에 바인딩된 DataTable 가져오기
                    DataTable dt = dgvBroken.DataSource as DataTable;
                    if (dt == null)
                    {
                        MessageBox.Show(
                            "화면에 불러온 장비 데이터가 없습니다.\n먼저 전체 목록을 조회해 주세요.",
                            "데이터 없음",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                        return;
                    }

                    // 2) 검색어 / 컬럼 이름 준비
                    string term = criteria.SearchTerm.Trim();
                    string column = criteria.SearchColumn;   // EQUIP_CODE / EQUIP_NAME 등

                    // 작은따옴표 이스케이프 (RowFilter 문법 오류 방지)
                    term = term.Replace("'", "''");

                    string filterExpression = $"{column} LIKE '%{term}%'";

                    try
                    {
                        // 3) 필터 적용
                        dt.DefaultView.RowFilter = filterExpression;

                        // 4) 필터 적용 후 결과 개수 확인
                        int resultCount = dt.DefaultView.Count;

                        if (resultCount == 0)
                        {
                            MessageBox.Show(
                                "입력하신 조건에 해당하는 장비가 없습니다.\n" +
                                "검색어와 검색 기준을 다시 한 번 확인해 주세요.",
                                "검색 결과 없음",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            "검색 필터 적용 중 오류가 발생했습니다.\n\n" + ex.Message,
                            "검색 오류",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
            }
        }
        private void 수리완료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvBroken.CurrentCell == null)
            {
                MessageBox.Show("선택된 장비가 없습니다.", "알림");
                return;
            }

            int rowIndex = dgvBroken.CurrentCell.RowIndex;
            string equipCode = dgvBroken.Rows[rowIndex].Cells["EQUIP_CODE"].Value?.ToString();

            if (string.IsNullOrEmpty(equipCode))
            {
                MessageBox.Show("장비 코드를 가져올 수 없습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show($"장비 [{equipCode}]의 수리를 완료 처리하시겠습니까?",
                                "확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            string updateSql = @"
        UPDATE EQUIPMENT
           SET EQUIP_STATUS = '정상',
               STATUS = 'READY',
               STOCK_QTY = STOCK_QTY + 1,
               AVAIL_RATE = CASE 
                               WHEN TOTAL_QTY = 0 THEN 0
                               ELSE ROUND((STOCK_QTY + 1) / TOTAL_QTY * 100, 2)
                            END,
               REMARK = NULL
         WHERE EQUIP_CODE = :p_code";

            try
            {
                if (dbc.DBCON.State != ConnectionState.Open)
                    dbc.DB_Open();

                using (OracleCommand cmd = new OracleCommand(updateSql, dbc.DBCON))
                {
                    cmd.Parameters.Add(":p_code", OracleDbType.Varchar2).Value = equipCode;

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("수리 완료 처리되었습니다.", "완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadBrokenEquip(); // 최신화 👍
                        LoadActiveIssue();
                        LoadRecentHist();
                    }
                    else
                    {
                        MessageBox.Show("변경할 데이터가 없습니다.", "실패", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB 오류 : " + ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void 필터해제ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 필터 해제 로직
            DataTable dt = dgvBroken.DataSource as DataTable;
            if (dt != null)
            {
                dt.DefaultView.RowFilter = string.Empty;
            }
        }

        private void radioEqName_CheckedChanged(object sender, EventArgs e)
        {
            if (radioEqName.Checked)
            {
                UpdateSearchFieldItems();
            }
        }

        private void radioSolName_CheckedChanged(object sender, EventArgs e)
        {
            if (radioSolName.Checked)
            {
                UpdateSearchFieldItems();
            }
        }


        private void txtFind1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;   // 삑 소리, 줄바꿈 방지
                btnSearchCode.PerformClick(); // 검색 버튼과 동일 동작
            }
        }
        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // 필요하면 나중에 내용 채우고,
            // 지금은 비워둬도 됩니다.
        }

        private void dgvBroken_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // 이 이벤트도 현재는 특별한 동작 없으면 비워둬도 됩니다.
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tabIssue_Click(object sender, EventArgs e)
        {

        }

        private void rdoReturnBroken_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lvRecent_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}