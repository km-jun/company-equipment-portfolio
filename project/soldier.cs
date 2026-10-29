using EquipmentManage;
using Oracle.DataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;

namespace project
{
    public partial class soldier : Form
    {
        private string sqlstr;
        private DBClass dbc = new DBClass();

        private DataTable soldierTable;

        // 실제 DB 테이블/컬럼명
        private const string TABLE_NAME = "soldier";
//        private const string COL_ID = "mil_no";     // 군번
        private const string COL_ID = "soldier_no";     // 군번
//        private const string COL_SID = "soldier_no";     // 군번
        private const string COL_NAME = "name";     // 성명
        private const string COL_RANK = "rank";     // 계급
        private const string COL_POS = "position";  // 직책
        private const string COL_UNIT = "unit";     // 소속

        private enum EditMode { None, Insert, Update }
        private EditMode currentMode = EditMode.None;

        private string selectedKey = "";  // 선택된 군번

        public string SelectedMilNo { get; private set; }
        public soldier()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
        }
        

        // ===== 인원 수 갱신 =====
        private void SoldierCounter()
        {
            // "총 000명" 라벨은 label6 사용
            label6.Text = "총 " + dataGridView1.RowCount + "명";
        }

        // 예외처리
        private string GetUserFriendlyErrorMessage(OracleException ex)
        {
            // ORA-00001은 1, ORA-02292는 2292 등
            switch (ex.Number)
            {
                case 2291: 
                    return "입력하신 [계급] 또는 [직책]이 존재하지 않습니다.\n\n";

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


        // ===== 헤더 설정 =====
        private void SoldierHeader()
        {
            if (dataGridView1.Columns.Count < 5) return;

            dataGridView1.Columns[0].HeaderText = "군번";
            dataGridView1.Columns[1].HeaderText = "성명";
            dataGridView1.Columns[2].HeaderText = "계급";
            dataGridView1.Columns[3].HeaderText = "직책";
            dataGridView1.Columns[4].HeaderText = "소속";

            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 75;
            dataGridView1.Columns[2].Width = 60;
            dataGridView1.Columns[3].Width = 90;
            dataGridView1.Columns[4].Width = 120;
        }

        // ===== 편집 모드 전환 =====
        private void SetEditMode(EditMode mode)
        {
            currentMode = mode;

            bool edit = (mode != EditMode.None); //non으로 들어오면 false
            if (mode == EditMode.Update)
            {
                txtId.ReadOnly = edit;
                txtName.Focus();
            }
            else
            {
                txtId.ReadOnly = !edit;
            }
            txtName.ReadOnly = !edit;
            txtRank.ReadOnly = !edit;
            textPosition.ReadOnly = !edit;
            txtUnit.ReadOnly = !edit;

            btnAdd.Enabled = !edit;
            btnEdit.Enabled = !edit;
            btnDel.Enabled = !edit;
            btnSave.Enabled = edit;
            btnCancel.Enabled = edit;

            dataGridView1.Enabled = !edit;
        }

        // ===== 텍스트박스 초기화 =====
        private void ClearTextBoxes()
        {
            txtId.Clear();
            txtName.Clear();
            txtRank.Clear();
            textPosition.Clear();
            txtUnit.Clear();
        }

        // ===== 그리드 → 텍스트박스 =====
        private void FillTextBoxesFromRow(DataGridViewRow row)
        {
            if (row == null) return;

            txtId.Text = Convert.ToString(row.Cells[COL_ID].Value);
            txtName.Text = Convert.ToString(row.Cells[COL_NAME].Value);
            txtRank.Text = Convert.ToString(row.Cells[COL_RANK].Value);
            textPosition.Text = Convert.ToString(row.Cells[COL_POS].Value);
            txtUnit.Text = Convert.ToString(row.Cells[COL_UNIT].Value);

            selectedKey = txtId.Text;
        }

        // ===== 폼 로드 =====
        private void Soldier_Load(object sender, EventArgs e)
        {
            try
            {
                dbc.DB_ObjCreate();
                dbc.DB_Open();
                dbc.DB_Access();

                LoadSoldierList();
                SetEditMode(EditMode.None);               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // ===== soldier 목록 불러오기 =====
        private void LoadSoldierList()
        {
            sqlstr =
                $"SELECT {COL_ID}, {COL_NAME}, {COL_RANK}, {COL_POS}, {COL_UNIT} " +
                $"FROM {TABLE_NAME} ORDER BY {COL_ID} ASC";

            dbc.DCom.CommandText = sqlstr;
            dbc.DA.SelectCommand = dbc.DCom;

            if (dbc.DS.Tables.Contains(TABLE_NAME))
                dbc.DS.Tables[TABLE_NAME].Clear();

            dbc.DA.Fill(dbc.DS, TABLE_NAME);

            soldierTable = dbc.DS.Tables[TABLE_NAME];
            dataGridView1.DataSource = soldierTable.DefaultView;

            SoldierHeader();
            SoldierCounter();

            if (dataGridView1.RowCount > 0)
                FillTextBoxesFromRow(dataGridView1.Rows[0]);
            else
                ClearTextBoxes();
        }

        // ===== DataGridView 클릭 =====
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dataGridView1.RowCount) return;

            FillTextBoxesFromRow(dataGridView1.Rows[e.RowIndex]);
        }

        // ===== 추가 =====
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
            selectedKey = "";
            SetEditMode(EditMode.Insert);                 
            txtId.Focus();
        }

        // ===== 수정 =====
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(selectedKey))
            {
                MessageBox.Show("수정할 병사를 선택하세요.");
                return;
            }

            SetEditMode(EditMode.Update);                  
        }

        // ===== 삭제 =====
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(selectedKey))
            {
                MessageBox.Show("삭제할 병사를 선택하세요.");
                return;
            }

            if (MessageBox.Show("선택한 병사를 삭제하시겠습니까?",
                                "삭제 확인", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            try
            {
                sqlstr = $"DELETE FROM {TABLE_NAME} WHERE {COL_ID} = :id";

                dbc.DCom.CommandText = sqlstr;
                dbc.DCom.Parameters.Clear();
                dbc.DCom.Parameters.Add("id", OracleDbType.Varchar2).Value = selectedKey;

                dbc.DCom.ExecuteNonQuery();

                MessageBox.Show("병사가 성공적으로 삭제되었습니다.", "삭제 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadSoldierList();
                SetEditMode(EditMode.None);           
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

        // ===== 저장 =====
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtId.Text.Trim() == "" || txtName.Text.Trim() == "")
            {
                MessageBox.Show("군번과 성명은 반드시 입력해야 합니다.");
                return;
            }

            try
            {
                dbc.DCom.Parameters.Clear();

                if (currentMode == EditMode.Insert)
                {
                    sqlstr =
                        $"INSERT INTO {TABLE_NAME} " +
                        $"({COL_ID}, {COL_NAME}, {COL_RANK}, {COL_POS}, {COL_UNIT}) " +
                        $"VALUES (:sid, :name, :rank, :pos, :unit)";

                    dbc.DCom.CommandText = sqlstr;
//                    dbc.DCom.Parameters.Add("id", OracleDbType.Varchar2).Value = txtId.Text.Trim();
                    dbc.DCom.Parameters.Add("sid", OracleDbType.Varchar2).Value = txtId.Text.Trim();
                    dbc.DCom.Parameters.Add("name", OracleDbType.Varchar2).Value = txtName.Text.Trim();
                    dbc.DCom.Parameters.Add("rank", OracleDbType.Varchar2).Value = txtRank.Text.Trim();
                    dbc.DCom.Parameters.Add("pos", OracleDbType.Varchar2).Value = textPosition.Text.Trim();
                    dbc.DCom.Parameters.Add("unit", OracleDbType.Varchar2).Value = txtUnit.Text.Trim();

                    dbc.DCom.ExecuteNonQuery();
                }
                else if (currentMode == EditMode.Update)
                {
                    sqlstr =
                        $"UPDATE {TABLE_NAME} SET " +
                        $"{COL_NAME} = :name, " +
                        $"{COL_RANK} = :rank, " +
                        $"{COL_POS}  = :pos, " +
                        $"{COL_UNIT} = :unit " +
                        $"WHERE {COL_ID} = :id";

                    dbc.DCom.CommandText = sqlstr;
                    dbc.DCom.Parameters.Add("name", OracleDbType.Varchar2).Value = txtName.Text.Trim();
                    dbc.DCom.Parameters.Add("rank", OracleDbType.Varchar2).Value = txtRank.Text.Trim();
                    dbc.DCom.Parameters.Add("pos", OracleDbType.Varchar2).Value = textPosition.Text.Trim();
                    dbc.DCom.Parameters.Add("unit", OracleDbType.Varchar2).Value = txtUnit.Text.Trim();
                    dbc.DCom.Parameters.Add("id", OracleDbType.Varchar2).Value = txtId.Text.Trim();

                    dbc.DCom.ExecuteNonQuery();
                }

                LoadSoldierList();
                SetEditMode(EditMode.None);             
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

        // ===== 취소 =====
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (selectedKey != "" && dataGridView1.RowCount > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (Convert.ToString(row.Cells[COL_ID].Value) == selectedKey)
                    {
                        FillTextBoxesFromRow(row);
                        break;
                    }
                }
            }
            else
            {
                ClearTextBoxes();
            }

            SetEditMode(EditMode.None);            
        }
        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // 컬럼이 실제로 존재하는지 확인 (인덱스 0이 유효한지 확인)
            if (dataGridView1.Columns.Count == 0 || dataGridView1.Rows.Count == 0) return;

            var row = dataGridView1.Rows[e.RowIndex];

            // soldier 테이블에서 0번 열이 soldier_no (군번)
            var val = row.Cells[0].Value;
            if (val == null || val == DBNull.Value) return;

            SelectedMilNo = val.ToString();

            this.DialogResult = DialogResult.OK;   // 선택 완료 신호
            this.Close();
        }

    }
}
