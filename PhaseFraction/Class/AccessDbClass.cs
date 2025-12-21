using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;



namespace PhaseFraction
{
    class AccessDbClass
    {
       
        public static AccessDbClass m_instance = null;
        public static AccessDbClass instance()
        {
            if (null == m_instance)
                m_instance = new AccessDbClass();
            return m_instance;
        }
        public  bool funExecuteRead(string Con, string str)
        {
            bool ret = false;
            try
            {
                OleDbConnection dbconn = new OleDbConnection(Con);
                if (dbconn.State == ConnectionState.Open)
                {
                    dbconn.Close();//关闭连接
                }
                dbconn.Open();  //打开连接
                OleDbCommand sqlcmd = new OleDbCommand(str, dbconn);  //sql语句
                OleDbDataReader reader = sqlcmd.ExecuteReader();
                dbconn.Close();
                reader.Close();
                ret = true;
            }
            catch (Exception e)
            {
                MessageBox.Show("數據庫連接失敗" + e.Message);
                ret = false;
            }
            return ret;
        }

        public  DataSet funExecuteRead(string Con, string str, bool _bOverView)
        {
            DataSet ds = new DataSet();
            try
            {
                OleDbConnection dbconn = new OleDbConnection(Con);
                if (dbconn.State == ConnectionState.Open)
                {
                    dbconn.Close();//关闭连接
                }
                dbconn.Open();//建立连接
                OleDbDataAdapter inst = new OleDbDataAdapter(str, dbconn);//选择全部内容
                inst.Fill(ds);//用inst填充ds
                dbconn.Close();//关闭连接
            }
            catch (Exception e)
            {
                MessageBox.Show("數據庫連接失敗" + e.Message);
            }
            return ds;
        }

        public  void funExecuteInsert(string Con, string str)
        {
            using (OleDbConnection connection = new OleDbConnection(Con))
            {
                using (OleDbCommand cmd = new OleDbCommand(str, connection))
                {
                    try
                    {
                        connection.Open();
                        int rows = cmd.ExecuteNonQuery();

                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("數據庫連接失敗" + e.Message);
                    }
                    finally
                    {
                        cmd.Dispose();
                        connection.Close();
                    }
                }
            }
        }

        public  void funExecuteUpdate(string Con, string str, DataTable dt)
        {
            try
            {
                OleDbConnection dbconn = new OleDbConnection(Con);
                dbconn.Open();//建立连接
                OleDbDataAdapter inst = new OleDbDataAdapter(str, dbconn);//选择全部内容
                OleDbCommandBuilder cmd = new OleDbCommandBuilder(inst);
                dt.PrimaryKey = new DataColumn[] { dt.Columns["Num"] };
                cmd.GetUpdateCommand();//执行更新指令;
                inst.Update(dt);
                dbconn.Close();//关闭连接
            }
            catch (Exception e)
            {
                
                MessageBox.Show("數據庫連接失敗" + e.Message);
            }

        }


    }
}
