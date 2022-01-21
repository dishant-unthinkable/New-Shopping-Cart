using Dapper;
using Dapperintro.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dapperintro.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult Index()
        {
            return View(DapperORM.ReturnList<Employee>("EmployeeViewAll"));
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if(id==0)
                return View();
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@EmployeeId", id);
                return View(DapperORM.ReturnList<Employee>("EmployeeViewById", param).FirstOrDefault<Employee>());
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(Employee emp)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@EmployeeID",emp.EmployeeID);
            param.Add("@Name", emp.Name);
            param.Add("@Position", emp.Position);
            param.Add("@Age", emp.Age);
            param.Add("@Salary",emp.Salary);
            DapperORM.ExecuteWithoutReturn("EmployeeAddOrEdit", param);
            return RedirectToAction("Index");   
        }

        public ActionResult Delete(int id)
        {
            DynamicParameters param=new DynamicParameters();
            param.Add("@EmployeeId", id);
            DapperORM.ExecuteWithoutReturn("EmployeeDeleteById",param);
            return RedirectToAction("Index");
        }
    }
}
