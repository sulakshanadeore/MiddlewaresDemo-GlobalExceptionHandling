using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiddlewaresDemo.Models;

namespace MiddlewaresDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        static List<EmployeeModel> emplist = new List<EmployeeModel> { 
        new EmployeeModel{Empid=1,EmpName="Jack",Deptno=10 },
        new EmployeeModel { Empid=2,EmpName="Jayesh",Deptno=20},
        new EmployeeModel{Empid=3,EmpName="Kamlesh",Deptno=30 },
        new EmployeeModel{Empid=4,EmpName="Sima",Deptno=10 },
        new EmployeeModel{ Empid=5,EmpName="Amruta",Deptno=10}
        
        };


        [HttpGet("AllEmployees")]
        public List<EmployeeModel> GetEmpList()
        { 
            return emplist;
               
        }

        [HttpGet("Deptno10Employees")]
        public List<EmployeeModel> GetEmpList10()
        {
            List<EmployeeModel> dept10Emps=emplist.Where(p => p.Deptno == 10).ToList();
            return dept10Emps;
        
        }

        [HttpGet("GetEmployeesByDeptno")]
        public List<EmployeeModel> GetEmployees(int deptno)
        {
            List<EmployeeModel> deptEmps = emplist.Where(p => p.Deptno == deptno).ToList();
            return deptEmps;

        }
    }
}
