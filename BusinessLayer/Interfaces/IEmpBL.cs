using CommonLayer.EmployeeModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IEmpBL
    {
        public int AddEmp(EmpPostModel emp);
        public List<EmpGetModel> GetAllEmp();
    }
}
