using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eManager.Web.Models;
using eManager.Domain;

namespace eManager.Web.Controllers
{
    [Authorize(Roles="Admin")]
    public class EmployeeController : Controller
    {

        IDepartmentDataSource _db;
        public EmployeeController(IDepartmentDataSource db)
        {
            _db = db;
        }


        [HttpGet]
       public ActionResult Create(int departmentId)
       {
           var model = new CreateEmployeeViewModel();
           model.DepartmentId = departmentId;

           return View(model);
       }

        [HttpPost]
        public ActionResult Create(CreateEmployeeViewModel model )
        {
            if (ModelState.IsValid)
            {
                var department = _db.Departments.Single(d => d.Id == model.DepartmentId);
                Employee employee = new Employee()
                {
                    HireDate = model.HireDate,
                    Name = model.Name
                };
                department.Employees.Add(employee);
                _db.Save();
                return RedirectToAction("detail", "department", new { depatmentId = model.DepartmentId });
            }
            else
            {
                return View(model);
            }

        }

    }
}
