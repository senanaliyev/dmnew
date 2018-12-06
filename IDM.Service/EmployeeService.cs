using IDM.DTO;
using IDM.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDM.Service
{
    public class EmployeeService
    {
        EmployeeRepository empRep = new EmployeeRepository();


        public int Insert(EmployeeDTO entity)
        {
            empRep.AddInputParameters("@usrID", entity.usrID);
            empRep.AddInputParameters("@empName", entity.empName);
            empRep.AddInputParameters("@empSurname", entity.empSurname);
            empRep.AddInputParameters("@empMiddleName", entity.empMiddleName);
            empRep.AddInputParameters("@empMail", entity.empMail);
            empRep.AddInputParameters("@empPhone", entity.empPhone);
            return empRep.IUD("sp_Employee_Insert", CommandType.StoredProcedure);
        }

        public int Update(EmployeeDTO entity)
        {
            empRep.AddInputParameters("@id", entity.usrID);
            empRep.AddInputParameters("@empName", entity.empName);
            empRep.AddInputParameters("@empSurname", entity.empSurname);
            empRep.AddInputParameters("@empMiddleName", entity.empMiddleName);
            empRep.AddInputParameters("@empMail", entity.empMail);
            empRep.AddInputParameters("@empPhone", entity.empPhone);
            return empRep.IUD("sp_Employee_UpdateByID", CommandType.StoredProcedure);
        }

        public Custom_UserDTO GetByUserID(int usrID)
        {
            empRep.AddInputParameters("@usrID", usrID);
            DataTable dt = empRep.GetList("sp_Employee_GetByUserID", CommandType.StoredProcedure);
            Custom_UserDTO employee = new Custom_UserDTO();
            employee.usrID = Convert.ToInt32(dt.Rows[0]["usrID"]);
            employee.empID = Convert.ToInt32(dt.Rows[0]["empID"]);
            employee.empName = dt.Rows[0]["empName"].ToString();
            employee.empSurname = dt.Rows[0]["empSurname"].ToString();
            employee.empMiddleName = dt.Rows[0]["empMiddleName"].ToString();
            employee.empMail = dt.Rows[0]["empMail"].ToString();
            employee.usrName = dt.Rows[0]["usrName"].ToString();
            employee.usrPassword = dt.Rows[0]["usrPassword"].ToString();
            employee.positionTitle = dt.Rows[0]["positionTitle"].ToString();
            return employee;
        }

        public List<Custom_UserDTO> GetList()
        {
            DataTable dt = empRep.GetList("sp_User_GetList", CommandType.StoredProcedure);
            if (dt != null)
            {
                List<Custom_UserDTO> userList = new List<Custom_UserDTO>();
                foreach (DataRow dr in dt.Rows)
                {
                    userList.Add(new Custom_UserDTO
                    {
                        usrID = Convert.ToInt32(dr["usrID"]),
                        empID = Convert.ToInt32(dr["empID"]),
                        usrName = dr["usrName"].ToString(),
                        empName = dr["empName"].ToString(),
                        empSurname = dr["empSurname"].ToString(),
                        empFullName = dr["empName"].ToString() + " " + dr["empSurname"].ToString(),
                        structureTitle = dr["structureTitle"].ToString(),
                        positionTitle = dr["positionTitle"].ToString()
                    });
                }
                //SqlDataReader dr = empRep.GetList("sp_Employee_GetList", CommandType.StoredProcedure);
                //if (dr.HasRows)
                //{
                //    List<EmployeeDTO> employeeList = new List<EmployeeDTO>();
                //    while (dr.Read())
                //    {
                //        EmployeeDTO employee = new EmployeeDTO();
                //        employee.empID = Convert.ToInt32(dr["empID"].ToString());
                //        employee.empName = dr["empName"].ToString();
                //        employee.empSurname = dr["empSurname"].ToString();
                //        employeeList.Add(employee);
                //    }
                //    dr.Close();
                return userList;
            }
            else
            {
                return null;
            }
        }

        public List<Custom_UserDTO> GetEmployeeList()
        {
            DataTable dt = empRep.GetList("sp_Employee_GetList", CommandType.StoredProcedure);
            if (dt != null)
            {
                List<Custom_UserDTO> userList = new List<Custom_UserDTO>();
                foreach (DataRow dr in dt.Rows)
                {
                    userList.Add(new Custom_UserDTO
                    {
                        usrID = Convert.ToInt32(dr["usrID"]),
                        empID = Convert.ToInt32(dr["empID"]),
                        empName = dr["empName"].ToString(),
                        empSurname = dr["empSurname"].ToString(),
                        empFullName = dr["empName"].ToString() + " " + dr["empSurname"].ToString()
                    });
                }
                //SqlDataReader dr = empRep.GetList("sp_Employee_GetList", CommandType.StoredProcedure);
                //if (dr.HasRows)
                //{
                //    List<EmployeeDTO> employeeList = new List<EmployeeDTO>();
                //    while (dr.Read())
                //    {
                //        EmployeeDTO employee = new EmployeeDTO();
                //        employee.empID = Convert.ToInt32(dr["empID"].ToString());
                //        employee.empName = dr["empName"].ToString();
                //        employee.empSurname = dr["empSurname"].ToString();
                //        employeeList.Add(employee);
                //    }
                //    dr.Close();
                return userList;
            }
            else
            {
                return null;
            }
        }

        public List<Custom_UserDTO> GetUserListByPositionStatus()
        {
            DataTable dt = empRep.GetList("sp_GetUserListByPositionStatus", CommandType.StoredProcedure);
            if (dt != null)
            {
                List<Custom_UserDTO> userList = new List<Custom_UserDTO>();
                foreach (DataRow dr in dt.Rows)
                {
                    userList.Add(new Custom_UserDTO
                    {
                        usrID = Convert.ToInt32(dr["userID"]),
                        empFullName = dr["surname"].ToString() + " " + dr["name"].ToString() + " " + dr["middleName"].ToString()
                    });
                }
                return userList;
            }
            else
            {
                return null;
            }
        }
    }
}
