
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
    }
}
