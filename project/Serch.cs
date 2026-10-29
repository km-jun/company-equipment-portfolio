using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class Serch : Form
    {
        public struct SearchCriteria
        {
            public string SearchTerm { get; set; }
            public string SearchColumn { get; set; }
            public string TargetTable { get; set; }
        }

        // MainForm으로 최종 검색 조건을 넘길 프로퍼티
        public SearchCriteria Criteria { get; private set; }

        public Serch()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. 검색어 추출
            string searchTerm = txtSearchTerm.Text.Trim();
            string column = "";
            string table = "";

            // 2. 검색 기준(라디오버튼) 선택 여부 확인
            if (!radioEqCode.Checked && !radioEqName.Checked)
            {
                MessageBox.Show(
                    "검색 기준(장비코드/장비명)을 먼저 선택해 주세요.",
                    "검색 기준 선택",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // 3. 검색어 유효성 검사
            if (string.IsNullOrEmpty(searchTerm))
            {
                MessageBox.Show(
                    "검색어를 입력해 주세요.\n예) 헬멧, 방탄복, 101-01 등",
                    "검색어 입력",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                txtSearchTerm.Focus();
                return;
            }

            // 4. 라디오버튼에 따른 컬럼/테이블 결정
            if (radioEqCode.Checked)
            {
                column = "EQUIP_CODE";
                table = "EQUIPMENT";
            }
            else if (radioEqName.Checked)
            {
                column = "EQUIP_NAME";
                table = "EQUIPMENT";
            }

            // 5. Criteria 구조체에 값 저장 (MainForm으로 전달)
            Criteria = new SearchCriteria
            {
                SearchTerm = searchTerm,
                SearchColumn = column,
                TargetTable = table
            };

            // 6. 폼 닫기 및 결과 반환
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // 🔹 Enter 키로 바로 검색 실행
        private void txtSearchTerm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;   // 삑 소리, 줄바꿈 방지
                button1.PerformClick();      // 검색 버튼 클릭과 동일 동작
            }
        }

        private void Serch_Load(object sender, EventArgs e)
        {

        }
    }
}
