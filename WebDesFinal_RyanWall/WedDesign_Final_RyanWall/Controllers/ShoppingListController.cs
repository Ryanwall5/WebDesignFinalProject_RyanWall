using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using WedDesign_Final_RyanWall.Models;
using Microsoft.AspNet.Identity.Owin;
using WedDesign_Final_RyanWall.Data;

namespace WedDesign_Final_RyanWall.Controllers
{
    [Authorize]
    public class ShoppingListController : Controller
    {
        private DBContext db = new DBContext();
        //private ApplicationUserManager _userManager;

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

        //public ShoppingListController(IDataRepository dataRepository)
        //{
        //    _dataRepository = dataRepository;
        //}


        // GET: ShoppingList
        public ActionResult Index()
        {

            var userId = User.Identity.GetUserId();
            return View(db.ShoppingLists.Where(g => g.Id == userId).ToList());

            //return View(db.ShoppingLists.ToList());
        }

        // GET: ShoppingList/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingList shoppingList = db.ShoppingLists.Find(id);

            if (shoppingList == null)
            {
                return HttpNotFound();
            }
            return View(shoppingList);
        }

        // GET: ShoppingList/Create
        public ActionResult Create()
        {
            //ViewBag.Id = new SelectList(db.ApplicationUsers, "Id", "Email");
            return View();
        }

        // POST: ShoppingList/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShoppingId,Item,Category,Quantity,Price,IsItFrozen,Id")] ShoppingList shoppingList)
        {
            if (ModelState.IsValid)
            {
                shoppingList.Id = User.Identity.GetUserId();
                db.ShoppingLists.Add(shoppingList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

           
            return View(shoppingList);
        }

        // GET: ShoppingList/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingList shoppingList = db.ShoppingLists.Find(id);
            if (shoppingList == null)
            {
                return HttpNotFound();
            }
            
            return View(shoppingList);
        }

        // POST: ShoppingList/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShoppingId,Item,Category,Quantity,Price,IsItFrozen,Id")] ShoppingList shoppingList)
        {
            if (ModelState.IsValid)
            {
                shoppingList.Id = User.Identity.GetUserId();
                db.Entry(shoppingList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(shoppingList);
        }

        // GET: ShoppingList/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ShoppingList shoppingList = db.ShoppingLists.Find(id);

            if (shoppingList == null)
            {
                return HttpNotFound();
            }
            return View(shoppingList);
        }

        // POST: ShoppingList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShoppingList shoppingList = db.ShoppingLists.Find(id);
            db.ShoppingLists.Remove(shoppingList);
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
