using Models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebInterface.Controllers
{
    [RoutePrefix("change-employee-salary")]
    public class EmployeeSalaryChangerController : Controller
    {
        private HumanResourceService Service { get; }

        public EmployeeSalaryChangerController()
        {
            Service = new HumanResourceService();
        }

        // GET: EmployeeSalaryChanger

        [Route("index")]
        public ActionResult Index()
        {
            return View(Service.FetchAllEmployeeSalary);
        }

        // GET: EmployeeSalaryChanger/Details/5
        [Route("details/{id}", Name = "EmployeeDetails")]
        public ActionResult Details(int id) => View(Service.FetchEmployeeSalaryById(id: id));

        // GET: EmployeeSalaryChanger/Create
        public ActionResult Create()
        {
            return View();
        }

        [Route("undo/{id}", Name = "EmployeeSalaryUndo")]
        public ActionResult Undo(int id)
        {
            Service.RestoreEmployeeSalary(id: id);
            return RedirectToAction("Index");
        }

        // POST: EmployeeSalaryChanger/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeSalaryChanger/Edit/5
        [Route("edit/{id}", Name = "EmployeeSalaryEdit")]
        public ActionResult Edit(int id) => View(Service.FetchEmployeeSalaryById(id: id));

        // POST: EmployeeSalaryChanger/Edit/5
        [HttpPost]
        [Route("edit/{id}", Name = "EmployeeSalaryEditPost")]
        public ActionResult Edit(int id, EmployeeSalary employeeSalary)
        {
            Service.ChangeEmployeeSalary(employeeSalary: employeeSalary);
            return RedirectToAction("Index");
        }

        // GET: EmployeeSalaryChanger/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeeSalaryChanger/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
