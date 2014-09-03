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
    /// Summary description for RoleHandler
    /// </summary>
    public class RoleHandler
    {
        public RoleHandler()
        {

        }
        private static Role MapData(SqlDataReader reader)
        {
            Role _Role = new Role();
            _Role.RoleId = Convert.ToInt32(reader["RoleId"]);
            _Role.RoleName = reader["RoleName"].ToString();
            return _Role;

        }
        public static RoleList GetAll(string _OrderBy = null)
        {
            RoleList _Rolelist = new RoleList();
            ConnectionManager _Manager = new ConnectionManager();
            _Manager.Open();
            string sql = "Select * from Role";

            if (_OrderBy != null)
            {
                sql += " Order By " + _OrderBy;
            }

            SqlDataReader reader = _Manager.ExecuteQuery(sql);

            while (reader.Read())
            {
                Role _Role = MapData(reader);
                _Rolelist.Add(_Role);
            }
            _Manager.Close();
            return _Rolelist;
        }

        public static Role GetById(int Id)
        {
            Role _Role = null;
            ConnectionManager _Manager = new ConnectionManager();
            _Manager.Open();
            string sql = "Select * from Role WHERE RoleId='" + Id + "' ";


            SqlDataReader reader = _Manager.ExecuteQuery(sql);

            while (reader.Read())
            {
                _Role = MapData(reader);
            }
            _Manager.Close();
            return _Role;
        }

        public static int Insert(Role _Role)
        {
            ConnectionManager _Manager = new ConnectionManager();
            _Manager.Open();
            string sql = "INSERT INTO Role(RoleName) values('" + _Role.RoleName + "')";
            int result = _Manager.ExecuteNonQuery(sql);
            _Manager.Close();
            return result;
        }
        public static int Update(Role _Role)
        {
            ConnectionManager _Manager = new ConnectionManager();
            _Manager.Open();
            string sql = "UPDATE Role SET RoleName='" + _Role.RoleName + "'";
            int result = _Manager.ExecuteNonQuery(sql);
            _Manager.Close();
            return result;
        }

        public static int Delete(int Id)
        {
            ConnectionManager _Manager = new ConnectionManager();
            _Manager.Open();
            string sql = "Delete From Role WHERE RoleId='" + Id + "' ";
            int result = _Manager.ExecuteNonQuery(sql);
            _Manager.Close();
            return result;
        }

    }
}