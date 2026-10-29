using System;
using System.Windows.Forms;

namespace project
{
    public partial class MDIForm : Form
    {
        private main mainForm;
        private equipment equipForm;
        private soldier soldierForm;
        private infoForm infoForm;

        public MDIForm()
        {
            InitializeComponent();

            // ★ MDI 부모 설정
            this.IsMdiContainer = true;

            // ★ 여기서 직접 Load 이벤트 연결 (디자이너에서 안 걸렸을 수도 있어서)
            this.Load += MDIForm_Load;
        }

        // ★ MDIForm 처음 실행 시 기본 메인 화면 띄우기
        private void MDIForm_Load(object sender, EventArgs e)
        {
            OpenMainForm();
        }

        // -------------------------------
        // 공통 : 메인 화면 열기
        // -------------------------------
        private void OpenMainForm()
        {
            if (mainForm == null || mainForm.IsDisposed)
            {
                mainForm = new main();
                mainForm.MdiParent = this;

                // ★ 화면 안에서 확실히 보이게
                mainForm.WindowState = FormWindowState.Maximized;
                // 혹시 모를 위치 문제 방지용
                mainForm.StartPosition = FormStartPosition.Manual;
                mainForm.Location = new System.Drawing.Point(0, 0);

                mainForm.Show();
            }
            else
            {
                mainForm.Activate();
                mainForm.BringToFront();
            }
        }

        // -------------------------------
        // 메뉴 : 메인 화면
        // -------------------------------
        private void 메인ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenMainForm();
        }

        // -------------------------------
        // 메뉴 : 장비 관리
        // -------------------------------
        private void 장비관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (equipForm == null || equipForm.IsDisposed)
            {
                equipForm = new equipment();
                equipForm.MdiParent = this;
                equipForm.StartPosition = FormStartPosition.CenterParent;
                equipForm.Show();
            }
            else
            {
                equipForm.Activate();
                equipForm.BringToFront();
            }
        }

        // -------------------------------
        // 메뉴 : 병력 관리
        // -------------------------------
        private void 병력관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (soldierForm == null || soldierForm.IsDisposed)
            {
                soldierForm = new soldier();
                soldierForm.MdiParent = this;
                soldierForm.StartPosition = FormStartPosition.CenterParent;
                soldierForm.Show();
            }
            else
            {
                soldierForm.Activate();
                soldierForm.BringToFront();
            }
        }

        // -------------------------------
        // 메뉴 : 정보창
        // -------------------------------
        private void 정보ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (infoForm == null || infoForm.IsDisposed)
            {
                infoForm = new infoForm();
                infoForm.MdiParent = this;
                infoForm.StartPosition = FormStartPosition.CenterParent;
                infoForm.Show();
            }
            else
            {
                infoForm.Activate();
                infoForm.BringToFront();
            }
        }
        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 모든 자식 폼 닫기
            foreach (Form child in this.MdiChildren)
            {
                child.Close();
            }

            // 메인 화면 다시 띄우기
            OpenMainForm();
        }
    }
}
