using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WedDesign_Final_RyanWall.Models
{
    public class Person
    {

        [Key]
        public int PersonId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Display(Name = "Nickname for yourself")]
        public string NickName { get; set; }

        [Required]
        [Display(Name = "House Address")]
        public string HouseAddress { get; set; }

        [Required]
        [Display(Name = "Description about yourself")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Do you play video games?")]
        public bool DoYouPlayVG { get; set; }

        public virtual List<ToDoList> todolists { get; set; }
        public virtual List<ShoppingList> shoppinglists { get; set; }

        [NotMapped]
        public bool Cool { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }


    }
}