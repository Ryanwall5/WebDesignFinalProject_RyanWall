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
using WedDesign_Final_RyanWall.Data;
using WedDesign_Final_RyanWall.Models;
using WedDesign_Final_RyanWall.Services;

namespace WedDesign_Final_RyanWall.Controllers
{
    [Authorize]
    public class PersonController : Controller
    {
        //private DBContext db = new DBContext();
        private readonly IDataRepository _dataRepository;
        //private ApplicationUserManager _userManager;
        private readonly IUserService _userservice;


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



        public PersonController(IDataRepository dataRepository, IUserService userservice)
        {
            this._dataRepository = dataRepository;
           this._userservice = userservice;

        }


        // GET: Person
        public ActionResult Index()
        {
            //var user = UserManager.FindById(User.Identity.GetUserId());
            var persons = _dataRepository.GetAllPeople();

            foreach (var person in persons)
            {
                person.Cool = _userservice.UserIsCool(person);
            }

            return View(persons);
        }

        // GET: Person/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = _dataRepository.GetPerson(id.Value);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            GetshoppingList();
            GettodoList();
            return View();
        }

        // POST: Person/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonId,FirstName,LastName,EmailAddress,NickName,HouseAddress,Description,DoYouPlayVG")] Person person, List<int> shoppingids, List<int> todoids)
        {
            if (ModelState.IsValid)
            {

                person.shoppinglists = new List<ShoppingList>();
                person.todolists = new List<ToDoList>();

                if (shoppingids != null)
                {
                    foreach (var shopid in shoppingids)
                    {
                        person.shoppinglists.Add(new ShoppingList
                        {
                            ShoppingId = shopid
                        });
                    }
                }

                if (todoids != null)
                {
                    foreach (var todoid in todoids)
                    {
                        person.todolists.Add(new ToDoList
                        {
                            ToDoListId = todoid
                        });
                    }
                }

                //var user = UserManager.FindById(User.Identity.GetUserId());
                //person.ApplicationUser = new ApplicationUser();

                _dataRepository.AddPerson(person);

                return RedirectToAction("Index");
            }

            return View(person);
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person person = _dataRepository.GetPerson(id.Value);

            if (person == null)
            {
                return HttpNotFound();
            }
           
            return View(person);
        }

        // POST: Person/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonId,FirstName,LastName,EmailAddress,NickName,HouseAddress,Description,DoYouPlayVG")] Person person)
        {
            if (ModelState.IsValid)
            {
                _dataRepository.UpdatePerson(person);
                return RedirectToAction("Index");
            }
            
            return View(person);
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Person person = _dataRepository.GetPerson(id.Value);

            if (person == null)
            {
                return HttpNotFound();
            }
            _dataRepository.RemovePerson(person);
            return View(person);
        }

        // POST: Person/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Person person = _dataRepository.GetPerson(id);
            return RedirectToAction("Index");
        }



        private void GettodoList()
        {
            //var user = UserManager.FindById(User.Identity.GetUserId());
            var todolists = _dataRepository.GetAllToDoList();
            ViewBag.ToDoList = new MultiSelectList(todolists, "ToDoListId", "NameOfDuty ", "Date", "DateToFinish", "IsChecked");
        }

        private void GetshoppingList()
        {
            //var user = UserManager.FindById(User.Identity.GetUserId());
            var shoppinglist = _dataRepository.getshoppinglist();
            ViewBag.ShoppingList = new MultiSelectList(shoppinglist, "ShoppingId", "Item", "Category", "Quantity", "Price", "IsItFrozen");
        }
    }
}
