
using BusinessLayer.Interfaces;
using CommonLayer.EmployeeModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace DapperPractice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        IEmpBL iEmpBL;
        public EmployeesController(IEmpBL iEmpBL)
        {
            this.iEmpBL = iEmpBL;
        }
        [HttpPost("AddEmployee")]
        public IActionResult AddEmp(EmpPostModel emp)
        {
            try
            {
                var result = iEmpBL.AddEmp(emp);
                if (result == 0)
                {
                    return this.BadRequest(new { sucess = false, Message = "Invalid Employee data" });
                }
                return this.Ok(new { sucess = true, Message = "Employee Added Successfully" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet("GetAllEmployee")]
        public IActionResult getAllEmp()
        {
            try
            {
                List<EmpGetModel> empList = new List<EmpGetModel>();
                var EmpList = iEmpBL.GetAllEmp();
                return Ok(new { sucess = true, Message = "Retrieve Employee data Successfully ", data = EmpList });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPut("UpdateEmployee")]
        public IActionResult UpdateEmployee(int id, EmpPostModel emp)
        {
            try
            {
                var result = iEmpBL.UpdateEmployee(id, emp);
                if (result == 0)
                {
                    return this.BadRequest(new { sucess = false, Message = "Something went wrong while Updating Employee Details " });
                }
                return this.Ok(new { sucess = true, Message = "Upadate Sucessfully..." });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpDelete("DeleteEmployee")]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                var result = iEmpBL.DeleteEmployee(id);
                if (result == 0)
                {
                    return this.BadRequest(new { sucess = false, Message = "Something went wrong while Deleting Employee Record " });
                }
                return this.Ok(new { sucess = true, Message = $"Employee Data Deleted Sucessfully id={id}" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
