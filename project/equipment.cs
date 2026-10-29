using System;
using System.Data;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using EquipmentManage;   // DBClass 가 여기 있다고 가정

namespace project
{
    public partial class equipment : Form
    {
        // ================== 필드 ==================
        private string sqlstr;                // 쿼리문 저장
        private DBClass dbc = new DBClass();  // 공통 DBClass

        // 현재 모드 : VIEW / ADD / EDIT
        private string currentMode = "VIEW";

        public string SelectedEquipCode { get; private set; }
        public equipment()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
        }

        // ================== 공통 함수 ==================
        
        // 예외처리 
        private string GetUserFriendlyErrorMessage(OracleException ex)
        {
            // ORA-00001은 1, ORA-02292는 2292 등
            switch (ex.Number)
            {
                case 2292:
                    return "삭제 오류: 다른 테이블에서 이 데이터를 참조하고 있습니다. 관련 기록을 먼저 삭제/수정해야 합니다.";

                case 1:
                    return "오류: 입력한 값이 이미 존재합니다. (중복 불가)";

                case 2290:
                    return "오류: 입력된 값이 허용된 조건 범위(룰)를 벗어납니다.";

                case 1400:
                case 1407: // NOT NULL 관련 오류
                    return "오류: 필수 입력 항목을 비워둘 수 없습니다.";

                default:
                    // ORA-코드와 원본 메시지 반환
                    return $"데이터베이스 오류 발생: [ORA-{ex.Number}] {ex.Message}";
            }
        }

        // 그리드 행 개수 → "총 000개"
        private void EquipCounter()
        {
            int i = dataGridView1.RowCount;
            label1.Text = "총 " + i + " 개";
        }

       

        // DataGridView 헤더/폭 설정
        private void EquipHeader()
        {
            if (dataGridView1.Columns.Count < 6) return;

            dataGridView1.Columns[0].HeaderText = "장비코드";
            dataGridView1.Columns[1].HeaderText = "장비명";
            dataGridView1.Columns[2].HeaderText = "장비구분";
            dataGridView1.Columns[3].HeaderText = "현재상태";
            dataGridView1.Columns[4].HeaderText = "총 보유수량";
            dataGridView1.Columns[5].HeaderText = "비고";

            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 120;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 90;
            dataGridView1.Columns[4].Width = 90;
            dataGridView1.Columns[5].Width = 150;
        }

        private void ClearTextBoxes()
        {
            txtCode.Clear();
            txtName.Clear();
            txtType.Clear();
            txtStatus.Clear();
            txtTotal.Clear();
            txtRemark.Clear();
        }

        // 선택된 행 내용을 오른쪽 텍스트박스에 표시
        private void BindRowToTextBoxes(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= dataGridView1.RowCount) return;

            DataGridViewRow row = dataGridView1.Rows[rowIndex];

            txtCode.Text = row.Cells[0].Value?.ToString();
            txtName.Text = row.Cells[1].Value?.ToString();
            txtType.Text = row.Cells[2].Value?.ToString();
            txtStatus.Text = row.Cells[3].Value?.ToString();
            txtTotal.Text = row.Cells[4].Value?.ToString();
            txtRemark.Text = row.Cells[5].Value?.ToString();
        }

        private void SetMode(string mode)
        {
            currentMode = mode;   // "VIEW", "ADD", "EDIT"

            bool editable = (mode != "VIEW"); 
            if(mode == "EDIT")
            {
                txtCode.ReadOnly = editable; // 수정 시 PK는 잠그기
            }
            else
            {
                txtCode.ReadOnly = !editable; // 수정 시 PK는 잠그기

            }
            txtName.ReadOnly = !editable;
            txtType.ReadOnly = !editable;
            txtStatus.ReadOnly = !editable;
            txtTotal.ReadOnly = !editable;
            txtRemark.ReadOnly = !editable;

            btnAdd.Enabled = !editable;
            btnEdit.Enabled = !editable;
            btnDel.Enabled = !editable;
            btnSave.Enabled = editable;
            btnCancel.Enabled = editable;
        }

        // DB에서 equipment 전체 로딩
        private void LoadEquipment()
        {
            sqlstr =
                "SELECT equip_code, equip_name, equip_type, equip_status, total_qty, remark " +
                "FROM equipment " +
                "ORDER BY equip_code ASC";

            dbc.DCom.CommandText = sqlstr;
            dbc.DA.SelectCommand = dbc.DCom;

            // 기존 데이터 초기화
            if (dbc.DS.Tables["equipment"] != null)
                dbc.DS.Tables["equipment"].Clear();

            dbc.DA.Fill(dbc.DS, "equipment");

            dataGridView1.DataSource = dbc.DS.Tables["equipment"].DefaultView;

            EquipCounter();
            EquipHeader();

            if (dataGridView1.RowCount > 0)
                BindRowToTextBoxes(0);

            SetMode("VIEW");
        }

        // ================== 폼 로드 ==================
        // 디자이너에서 this.Load += EquipForm_Load 로 걸려 있어서
        // 메서드 이름을 EquipForm_Load 로 맞춰 줍니다.
        private void EquipForm_Load(object sender, EventArgs e)
        {
            try
            {
                // DB 연결 준비
                dbc.DB_ObjCreate();
                dbc.DB_Open();
                dbc.DB_Access();

                LoadEquipment();
                dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            }
            catch (DataException de)
            {
                MessageBox.Show(de.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // ================== 그리드 클릭 ==================
        // CellContentClick 이벤트 핸들러
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            BindRowToTextBoxes(e.RowIndex);
            SetMode("VIEW");
        }

        // ================== 버튼 이벤트 ==================

        // 추가
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
            SetMode("ADD");
            txtCode.Focus();
        }

        // 수정
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                MessageBox.Show("수정할 장비를 먼저 선택하세요.");
                return;
            }

            SetMode("EDIT");
            txtName.Focus();
        }

        // 삭제
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                MessageBox.Show("삭제할 장비를 먼저 선택하세요.");
                return;
            }

            if (MessageBox.Show("정말 삭제하시겠습니까?", "삭제 확인",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.No)
                return;

            try
            {
                dbc.DCom.Parameters.Clear();
                dbc.DCom.CommandText =
                    "DELETE FROM equipment WHERE equip_code = :p_code";

                dbc.DCom.Parameters.Add("p_code", OracleDbType.Varchar2).Value =
                    txtCode.Text.Trim();

                dbc.DCom.ExecuteNonQuery();

                LoadEquipment();
                ClearTextBoxes();
            }
            catch (Oracle.DataAccess.Client.OracleException ex)
            {
                string userMessage = GetUserFriendlyErrorMessage(ex);

                MessageBox.Show(userMessage, "데이터베이스 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 저장 (추가 / 수정 공용)
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (currentMode == "VIEW")
            {
                MessageBox.Show("추가 또는 수정을 먼저 선택하세요.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCode.Text) ||
                string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("장비코드와 장비명은 필수입니다.");
                return;
            }

            try
            {
                dbc.DCom.Parameters.Clear();

                if (currentMode == "ADD")
                {
                    dbc.DCom.CommandText =
                        "INSERT INTO equipment " +
                        "(equip_code, equip_name, equip_type, equip_status, total_qty, stock_qty,remark) " +
                        "VALUES (:p_code, :p_name, :p_type, :p_status, :p_total, :p_stock, :p_remark)";
                }
                else if (currentMode == "EDIT")
                {
                    dbc.DCom.CommandText =
                        "UPDATE equipment SET " +
                        " equip_name   = :p_name, " +
                        " equip_type   = :p_type, " +
                        " equip_status = :p_status, " +
                        " total_qty    = :p_total, " +
                        " stock_qty    = :p_stock, " +
                        " remark       = :p_remark " +
                        "WHERE equip_code = :p_code";
                }

                dbc.DCom.Parameters.Add("p_code", OracleDbType.Varchar2).Value = txtCode.Text.Trim();
                dbc.DCom.Parameters.Add("p_name", OracleDbType.Varchar2).Value = txtName.Text.Trim();
                dbc.DCom.Parameters.Add("p_type", OracleDbType.Varchar2).Value = txtType.Text.Trim();
                dbc.DCom.Parameters.Add("p_status", OracleDbType.Varchar2).Value = txtStatus.Text.Trim();
                dbc.DCom.Parameters.Add("p_total", OracleDbType.Int32).Value =
                    string.IsNullOrWhiteSpace(txtTotal.Text) ? 0 : int.Parse(txtTotal.Text);
                dbc.DCom.Parameters.Add("p_total", OracleDbType.Int32).Value =
                    string.IsNullOrWhiteSpace(txtTotal.Text) ? 0 : int.Parse(txtTotal.Text);
                dbc.DCom.Parameters.Add("p_remark", OracleDbType.Varchar2).Value = txtRemark.Text.Trim();

                dbc.DCom.ExecuteNonQuery();

                LoadEquipment();
                SetMode("VIEW");
            }
            catch (Oracle.DataAccess.Client.OracleException ex)
            {
                string userMessage = GetUserFriendlyErrorMessage(ex);

                MessageBox.Show(userMessage, "데이터베이스 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException)
            {
                MessageBox.Show("총 보유수량은 숫자로 입력하세요.");
                txtTotal.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 취소
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                BindRowToTextBoxes(dataGridView1.CurrentRow.Index);
            }
            else if (dataGridView1.RowCount > 0)
            {
                BindRowToTextBoxes(0);
            }
            else
            {
                ClearTextBoxes();
            }

            SetMode("VIEW");
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // 컬럼이 실제로 존재하는지 확인 (인덱스 0이 유효한지 확인)
            if (dataGridView1.Columns.Count == 0 || dataGridView1.Rows.Count == 0) return;

            var row = dataGridView1.Rows[e.RowIndex];

            var val = row.Cells[0].Value;    // equip_code

            if (val == null || val == DBNull.Value) return;

            SelectedEquipCode = val.ToString();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
