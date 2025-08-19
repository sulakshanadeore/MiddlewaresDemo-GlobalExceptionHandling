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
            List<EmployeeModel> dept10Emps = emplist.Where(p => p.Deptno == 10).ToList();
            return dept10Emps;

        }

        [HttpGet("GetEmployeesByDeptno")]
        public List<EmployeeModel> GetEmployees(int deptno)
        {
            List<EmployeeModel> deptEmps = emplist.Where(p => p.Deptno == deptno).ToList();
            return deptEmps;

        }

        [HttpGet("GetEmployeeByEmpid")]
        //   [ProducesResponseType(StatusCodes.Status204NoContent)]
        public EmployeeModel GetEmployeesByEmpID(int empid)
        {
            EmployeeModel EmpObj = null;
            if (empid != 0)
            {
                EmpObj = emplist.Where(p => p.Empid == empid).SingleOrDefault();
                if (EmpObj == null)
                {
                    throw new EmployeeNotFoundExceptionException("This empid is not found in the records.....");
                }
            }
            else
            {
                throw new Exception("Empid doesn't exists");
            }
            return EmpObj;


        }


        [HttpPost("addemp")]
        public IActionResult NewEmployee(EmployeeModel emp)
        {
            if (emp != null)
            {
                emplist.Add(emp);
            }
            else
            {
                throw new Exception("Employee cannot be null");
            }
              return Ok("Employee created..");
            //return CreatedAtAction(nameof(GetEmployeesByEmpID), new { empid = emp.Empid }, emp);

        }

        [HttpPost("upload")]
        public IActionResult UploadFile(IFormFile file)
        {
            if (file.Length>0)
            {
                return Ok("Upload successful...");
            }
            else
            {
                return NotFound("File not found to upload, its empty..");
            }
        
        }




        [HttpPut]
        public IActionResult UpdateEmployee(int empid, EmployeeModel emp)
        {
            if (emp != null && empid != 0)
            {
                EmployeeModel? obj = emplist.Find(edata => edata.Empid == empid);
                if (obj != null)
                {
                    obj.EmpName = emp.EmpName;
                    obj.Deptno = emp.Deptno;
                }
                else
                {
                    throw new Exception("Employee cannot be null");
                }
            }
            else
            {
                throw new Exception("Employee cannot be null");
            }
            return Ok("Employee details updated..");



        }

        [HttpDelete]
        public IActionResult RemoveEmployee(int empid)
        {
            EmployeeModel? obj = emplist.Find(edata => edata.Empid == empid);
            if (obj != null)
            {
                emplist.Remove(obj);
            }
            else
            {
                //throw new Exception("Employee cannot be null");
                return NotFound();
                //return NoContent(); //use NoContent when u don't want to return anything
            }
           return  Ok("Employee deleted successfully..");

        }



    }
}
