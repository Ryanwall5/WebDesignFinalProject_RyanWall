using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WedDesign_Final_RyanWall.Models;

namespace WedDesign_Final_RyanWall.Data
{
    public class EfDataRepository : IDataRepository
    {

        private readonly DBContext _databaseContext = new DBContext();


        public void AddPerson(Person person)
        {
            foreach (var item in person.shoppinglists)
            {
                _databaseContext.ShoppingLists.Attach(item);
            }
            foreach (var todoitem in person.todolists)
            {
                _databaseContext.ToDoLists.Attach(todoitem);
            }

            _databaseContext.People.Add(person);         
            _databaseContext.SaveChanges();
        }

        public Person GetPerson(int id)
        {
            return _databaseContext.People.Find(id);
        }

        public void RemovePerson(Person id)
        {
            _databaseContext.People.Remove(id);
            _databaseContext.SaveChanges();
        }

        public void UpdatePerson(Person id)
        {
            _databaseContext.Entry(id).State = EntityState.Modified;
            _databaseContext.SaveChanges();
        }

        public List<Person> GetAllPeople()
        {
            return _databaseContext.People.ToList();
        }


    
        public List<ToDoList> GetAllToDoList()
        {
            return _databaseContext.ToDoLists.ToList();
        }




        public List<ShoppingList> getshoppinglist()
        {
            return _databaseContext.ShoppingLists.ToList();
        }

 
    }
}