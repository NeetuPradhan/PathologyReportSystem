using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.DAL;
using Project.BO;
using System.Data.SqlClient;


namespace Project.BLL
{

    /// <summary>
    /// Summary description for TestHandler
    /// </summary>
    public class TestHandler
    {
        public TestHandler()
        {

        }
        private static Test MapData(SqlDataReader reader)
        {
            Test _Test = new Test();
            _Test.TestId = Convert.ToInt32(reader["TestId"]);
            _Test.TestName = reader["TestName"].ToString();
            _Test.TestPrice = reader["TestPrice"].ToString();
   
            return _Test;

        }
        public static TestList GetAll(string _OrderBy = null)
        {
            TestList _Testlist = new TestList();
            ConnectionManager _Manager = new ConnectionManager();
            _Manager.Open();
            string sql = "Select * from Tests";

            if (_OrderBy != null)
            {
                sql += " Order By " + _OrderBy;
            }

            SqlDataReader reader = _Manager.ExecuteQuery(sql);

            while (reader.Read())
            {
                Test _Test = MapData(reader);
                _Testlist.Add(_Test);
            }
            _Manager.Close();
            return _Testlist;
        }

        public static Test GetById(int Id)
        {
            Test _Test = null;
            ConnectionManager _Manager = new ConnectionManager();
            _Manager.Open();
            string sql = "Select * from Tests WHERE TestId='" + Id + "' ";


            SqlDataReader reader = _Manager.ExecuteQuery(sql);

            while (reader.Read())
            {
                _Test = MapData(reader);
            }
            _Manager.Close();
            return _Test;
        }

        public static int Insert(Test _Test)
        {
            ConnectionManager _Manager = new ConnectionManager();
            _Manager.Open();
            string sql = "INSERT INTO Tests(TestName,TestPrice) values('" + _Test.TestName + "','" + _Test.TestPrice + "')";
            int result = _Manager.ExecuteNonQuery(sql);
            _Manager.Close();
            return result;
        }
        public static int Update(Test _Test)
        {
            ConnectionManager _Manager = new ConnectionManager();
            _Manager.Open();
            string sql = "UPDATE Tests SET TestName='" + _Test.TestName + "', Password='" + _Test.TestPrice + "' WHERE TestId='" + _Test.TestId + "'";
            int result = _Manager.ExecuteNonQuery(sql);
            _Manager.Close();
            return result;
        }

        public static int Delete(int Id)
        {
            ConnectionManager _Manager = new ConnectionManager();
            _Manager.Open();
            string sql = "Delete From Tests WHERE TestId='" + Id + "' ";
            int result = _Manager.ExecuteNonQuery(sql);
            _Manager.Close();
            return result;
        }

    }
}