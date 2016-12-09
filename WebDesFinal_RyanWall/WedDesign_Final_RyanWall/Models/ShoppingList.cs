using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WedDesign_Final_RyanWall.Models
{
    public class ShoppingList
    {

        [Key]
        public int ShoppingId { get; set; }

        [Required(ErrorMessage = "Item is Requried")]
        [Display(Name = "Shopping Item")]
        [StringLength(128, ErrorMessage = "Item is limited to 32 characters")]
        public string Item { get; set; }

        [Required(ErrorMessage = "Category is Requried")]
        [Display(Name = "Produce, Dairy, Meat, etc")]
        [StringLength(128, ErrorMessage = "category is limited to 32 characters")]
        public string Category { get; set; }

        [Required(ErrorMessage = "QTY is Requried")]
        [Display(Name = "QTY")]
        public float Quantity { get; set; }

        [Required(ErrorMessage = "Price is Requried")]
        [Display(Name = "Item Price")]
        public float Price { get; set; }

        public bool IsItFrozen { get; set; }

        
        public virtual List<Person> people { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }

    }
}