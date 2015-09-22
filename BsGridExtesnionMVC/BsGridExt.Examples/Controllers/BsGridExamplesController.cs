using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BsGridExt.Examples.Controllers
{
    public class BsGridExamplesController : Controller
    {
        public ActionResult Basic()
        {
            return View();
        }

        public ActionResult Editable()
        {
            return View();
        }

        public JsonResult GetData()
        {
            List<Employee> empList = new List<Employee>();
            for (int index = 0; index < 500; index++)
			{
                empList.Add(new Employee(index, "Name " + index, DateTime.Now.AddDays(index), "Address " + index));
			 
			}
            return Json(empList, JsonRequestBehavior.AllowGet);
        }
	}

    public class Employee
    {
        public Employee(int empId, string empName, DateTime dob, string address)
        {
            this.EmployeeId = empId;
            this.EmployeeName = empName;
            this.EmployeeDOB = dob;
            this.EmployeeAddress = address;
        }
        public int EmployeeId { get; set; }
        public String EmployeeName { get; set; }
        public DateTime EmployeeDOB { get; set; }
        public String EmployeeAddress { get; set; }
    }
}