using BusinessLayer.Interfaces;
using CommonLayer.EmployeeModels;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class EmpBL:IEmpBL
    {
        IEmpRL iEmpRL;
        public EmpBL(IEmpRL iEmpRL)
        {
            this.iEmpRL = iEmpRL;
        }
        public int AddEmp(EmpPostModel emp)
        {
            try
            {
                return iEmpRL.AddEmp(emp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<EmpGetModel> GetAllEmp()
        {
            try
            {
                return iEmpRL.GetAllEmp();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

