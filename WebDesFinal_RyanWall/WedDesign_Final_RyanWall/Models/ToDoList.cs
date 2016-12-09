using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WedDesign_Final_RyanWall.Models
{
    public class ToDoList
    {
        [Key]
        public int ToDoListId { get; set; }

        [Required(ErrorMessage = "Name is Requried")]
        [Display(Name = "Name of Duty")]
        [StringLength(128, ErrorMessage = "Name is limited to 32 characters")]
        public string NameOfDuty { get; set; }

        [Required(ErrorMessage = "Date is Requried")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date")]
        public string Date { get; set; }

        [Required(ErrorMessage = "EndDate is Requried")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date To Finish")]
        public string DateToFinish { get; set; }


        [Display(Name = "Have You Finished?")]
        public bool IsChecked { get; set; }


        public virtual List<Person> people { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }

    }
    
}