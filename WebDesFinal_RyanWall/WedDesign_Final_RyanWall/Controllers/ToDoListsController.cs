using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using WedDesign_Final_RyanWall.Models;
using WedDesign_Final_RyanWall.Data;

namespace WedDesign_Final_RyanWall.Controllers
{
    [Authorize]
    public class ToDoListsController : Controller
    {
        private DBContext db = new DBContext();
        //private ApplicationUserManager _userManager;
        //private readonly IDataRepository _dataRepository;

        //public ApplicationUserManager UserManager
        //{
        //    get
        //    {
        //        return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
        //    }
        //    private set
        //    {
        //        _userManager = value;
        //    }
        //}

        //public ToDoListsController(IDataRepository dataRepository)
        //{
        //    _dataRepository = dataRepository;
        //}

        // GET: ToDoLists
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            return View(db.ToDoLists.Where(g => g.Id == userId).ToList());
            //return View(db.ToDoLists.ToList());
        }

        // GET: ToDoLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDoList toDoList = db.ToDoLists.Find(id);
            if (toDoList == null)
            {
                return HttpNotFound();
            }
            return View(toDoList);
        }

        // GET: ToDoLists/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: ToDoLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ToDoListId,NameOfDuty,Date,DateToFinish,IsChecked,Id")] ToDoList toDoList)
        {
            if (ModelState.IsValid)
            {
                toDoList.Id = User.Identity.GetUserId();
                db.ToDoLists.Add(toDoList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

           
            return View(toDoList);
        }

        // GET: ToDoLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDoList toDoList = db.ToDoLists.Find(id);
            if (toDoList == null)
            {
                return HttpNotFound();
            }
            
            return View(toDoList);
        }

        // POST: ToDoLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ToDoListId,NameOfDuty,Date,DateToFinish,IsChecked,Id")] ToDoList toDoList)
        {
            if (ModelState.IsValid)
            {
                toDoList.Id = User.Identity.GetUserId();
                db.Entry(toDoList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           
            return View(toDoList);
        }

        // GET: ToDoLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDoList toDoList = db.ToDoLists.Find(id);
            if (toDoList == null)
            {
                return HttpNotFound();
            }
            return View(toDoList);
        }

        // POST: ToDoLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ToDoList toDoList = db.ToDoLists.Find(id);
            db.ToDoLists.Remove(toDoList);
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
