using CommonLayer.EmployeeModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IEmpRL
    {
        public int AddEmp(EmpPostModel emp);
        public List<EmpGetModel> GetAllEmp();
    }
}
