using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WedDesign_Final_RyanWall.Models;


namespace WedDesign_Final_RyanWall.Data
{
    public interface IDataRepository
    {
        List<Person> GetAllPeople();
        void AddPerson(Person person);
        Person GetPerson(int id);
        void UpdatePerson(Person id);
        void RemovePerson(Person id);

        List<ShoppingList> getshoppinglist();
        

        List<ToDoList> GetAllToDoList();
      
    }
}