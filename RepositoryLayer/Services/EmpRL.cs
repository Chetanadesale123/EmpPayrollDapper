using CommonLayer.EmployeeModels;
using Dapper;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Services
{
    public class EmpRL:IEmpRL
    {
        private readonly string connetionString;
        public EmpRL(IConfiguration configuration)
        {
            connetionString = configuration.GetConnectionString("EmpPayrollData");
        }
        public int AddEmp(EmpPostModel emp)
        {
            SqlConnection sqlConnection = new SqlConnection(connetionString);
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    var sql = "insert into tbl_Employees(FirstName,LastName,Address,Mobile) values(@FirstName,@LastName,@Address,@Mobile)";
                    var result = sqlConnection.Execute(sql, emp);
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public List<EmpGetModel> GetAllEmp()
        {
            List<EmpGetModel> listOfUsers = new List<EmpGetModel>();
            SqlConnection sqlConnection = new SqlConnection(connetionString);
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    var sql = "select * from tbl_Employees";
                    var result = sqlConnection.Query<EmpGetModel>(sql);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public int UpdateEmployee(int id, EmpPostModel emp)
        {
            SqlConnection sqlConnection = new SqlConnection(connetionString);
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    var sql = $"Update tbl_Employees SET FirstName=@FirstName,LastName=@LastName,Address=@Address,Mobile=@Mobile where id={id}";
                    var result = sqlConnection.Execute(sql, emp);
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public int DeleteEmployee(int id)
        {
            SqlConnection sqlConnection = new SqlConnection(connetionString);
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    var sql = $"delete from tbl_Employees Where id={id}";
                    var result = sqlConnection.Execute(sql);
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}

