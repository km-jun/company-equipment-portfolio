using System;
using System.Data;
using Oracle.DataAccess.Client;

namespace EquipmentManage   // ← 프로젝트 네임스페이스에 맞게 변경
{
    public class DBClass
    {
        // ----------------- 필드 -----------------
        private string ret;
        private string sql;

        private OracleConnection con;
        private OracleCommand dcom;
        private OracleDataAdapter da;
        private DataSet ds;
        private OracleDataReader dr;
        private OracleCommandBuilder myCommandBuilder;
        private DataTable mainTable;

        // ----------------- 연결문자열 -----------------
        private string connectionString =
            Environment.GetEnvironmentVariable("EQUIPMENT_DB_CONNECTION_STRING");

        

        // ----------------- 프로퍼티 -----------------
        public string Ret { get { return ret; } set { ret = value; } }
        public string SQL { get { return sql; } set { sql = value; } }
        public OracleConnection Con { get { return con; } set { con = value; } }
        public OracleCommand DCom { get { return dcom; } set { dcom = value; } }
        public OracleDataAdapter DA { get { return da; } set { da = value; } }
        public OracleDataReader DR { get { return dr; } set { dr = value; } }
        public DataSet DS { get { return ds; } set { ds = value; } }
        public OracleCommandBuilder MyCommandBuilder { get { return myCommandBuilder; } set { myCommandBuilder = value; } }
        public DataTable MainTable { get { return mainTable; } set { mainTable = value; } }

        // ----------------- 메서드 -----------------

        /// <summary>
        /// DB 연결 열기
        /// </summary>
        public void DB_Open()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(connectionString))
                    throw new InvalidOperationException("EQUIPMENT_DB_CONNECTION_STRING 환경변수를 설정해 주세요.");

                if (con == null)
                    con = new OracleConnection(connectionString);

                if (con.State != ConnectionState.Open)
                    con.Open();

                ret = "OK";
            }
            catch (Exception ex)
            {
                ret = "DB_Open 오류: " + ex.Message;
            }
        }

        /// <summary>
        /// SELECT 문 실행 → DataSet/DataTable 준비
        /// </summary>
        public void DB_ObjCreate()
        {
            if (con == null || con.State != ConnectionState.Open)
                DB_Open();

            try
            {
                dcom = new OracleCommand(sql, con);

                da = new OracleDataAdapter(dcom);
                myCommandBuilder = new OracleCommandBuilder(da);

                ds = new DataSet();
                da.Fill(ds, "MainTable");

                mainTable = ds.Tables["MainTable"];
                ret = "OK";
            }
            catch (Exception ex)
            {
                ret = "DB_ObjCreate 오류: " + ex.Message;
            }
        }

        /// <summary>
        /// INSERT / UPDATE / DELETE 실행
        /// </summary>
        public void DB_Access()
        {
            if (con == null || con.State != ConnectionState.Open)
                DB_Open();

            try
            {
                dcom = new OracleCommand(sql, con);
                int affected = dcom.ExecuteNonQuery();
                ret = affected.ToString();  // 예: "1"
            }
            catch (Exception ex)
            {
                ret = "DB_Access 오류: " + ex.Message;
            }
        }

        /// <summary>
        /// DataAdapter를 통한 UPDATE 기능
        /// (DataSet 변경사항 → DB 반영)
        /// </summary>
        public void DB_Update()
        {
            if (da == null || ds == null)
            {
                ret = "DB_Update 오류: DataAdapter 또는 DataSet 없음";
                return;
            }

            try
            {
                myCommandBuilder = new OracleCommandBuilder(da);
                int affected = da.Update(ds, "MainTable");
                ret = affected.ToString();
            }
            catch (Exception ex)
            {
                ret = "DB_Update 오류: " + ex.Message;
            }
        }

        /// <summary>
        /// 연결 닫기
        /// </summary>
        public void DB_Close()
        {
            try
            {
                if (con != null && con.State != ConnectionState.Closed)
                    con.Close();
            }
            catch { }
        }

        public OracleConnection DBCON { get { return con; } }

    }
}
