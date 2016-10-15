using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCDemo.Models;
using System.Data.Entity.Infrastructure;

namespace MVCDemo.Controllers
{
    public class DepartmentsController : Controller
    {
        private SchoolContext db = new SchoolContext();

        [ChildActionOnly]
        public ActionResult GetDepartments()
        {
            var departments = db.Departments.ToList();
            return PartialView(departments);
        }

        // GET: Departments
        public ActionResult Index()
        {
            var departments = db.Departments.Include(d => d.Administator);
            return View(departments.ToList());
        }



        // GET: Departments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new HttpException(404, "Bad request");
            }
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                throw new Exception("No matched department found");
            }
            return View(department);
        }

        // GET: Departments/Create
        public ActionResult Create()
        {
            ViewBag.PersonId = new SelectList(db.People, "PersonId", "LastName");
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DepartmentId,Name,Budget,StartDate,stamp,PersonId")] Department department)
        {
            if (ModelState.IsValid)
            {
                db.Departments.Add(department);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonId = new SelectList(db.People, "PersonId", "LastName", department.PersonId);
            return View(department);
        }

        // GET: Departments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonId = new SelectList(db.People, "PersonId", "LastName", department.PersonId);
            return View(department);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DepartmentId,Name,Budget,StartDate,stamp,PersonId")] Department department)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(department).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateException ex)
            {
                var entry = ex.Entries.Single();
                var clientValues = (Department)entry.Entity;
                var databaseEntry = entry.GetDatabaseValues(); 

                if(databaseEntry == null)
                {
                    ModelState.AddModelError(string.Empty, "Unable to save changes. The department was deleted by another user");
                }
                else
                {
                    var databaseValues = (Department)databaseEntry.ToObject();

                    if(databaseValues.Name != clientValues.Name)
                    {
                        ModelState.AddModelError("Name", "Current value: " + databaseValues.Name);
                    }
                    if(databaseValues.Budget != clientValues.Budget)
                    {
                        ModelState.AddModelError("Budget", "Current value: " + string.Format("{0:c}", databaseValues.Budget));

                    }
                    if (databaseValues.StartDate != clientValues.StartDate)
                    {
                        ModelState.AddModelError("StartDate", "Current value: " + string.Format("{0:d}", databaseValues.StartDate));

                    }
                    if (databaseValues.PersonId != clientValues.PersonId)
                    {
                        ModelState.AddModelError("PersonId", "Current value: " + databaseValues.PersonId);

                    }

                    ModelState.AddModelError(string.Empty, "The record you attempted to edit was modified by another"
                        + " after you gotthe original value. The edit operation was canceled"
                        + " and the current values in the database have been displayed. if you "
                        + "still want to edit the record, click the save button again");

                    department.stamp = databaseValues.stamp;
                  

                }
            }
            ViewBag.PersonId = new SelectList(db.People, "PersonId", "LastName", department.PersonId);
            return View(department);
        }

        // GET: Departments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Department department = db.Departments.Find(id);
            db.Departments.Remove(department);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
