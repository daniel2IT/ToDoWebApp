using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ToDoWebApp.Models
{
    public class TodoItem
    {

        /*   [ScaffoldColumn(false)] */
        /* for Details is can be True*/
        public int TodoItemId
        {
            get;
            set;
        }
        /**/
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Prasome Ivesti Varda"), MaxLength(30)]
        public string Name
        {
            get;
            set;
        }
        /**/
        [DataType(DataType.Text)]
        public string Description
        {
            get;
            set;
        }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Create Date")]
        public DateTime CreatedDate { get; set; }
/*        public DateTime ModifiedDate { get; set; }*/

        public TodoItem()
        {
            this.CreatedDate = DateTime.UtcNow;
        /*    this.ModifiedDate = DateTime.UtcNow;*/
        }


        [DataType(DataType.Date)]
        [Display(Name = "DeadLine Date")]
        public DateTime? DeadLineDate /* ? - make field nullable */
        {
            get;
            set;
        }

        /**/
        [DefaultValue(3)]
        [Required(ErrorMessage = "Pasirinkite Nuo 1 iki 5 ")]
        [Range(1.00, 5.00, ErrorMessage = "Priority turi buti tarp 1 and 5")]
        /* Not Working, but i will just create Validation in CreateView... */
        public int priority
        {
            get;
            set;
        }

 

        public Status status { get; set; }

        public override string ToString()
        {
            return $"TodoItem(Id:{TodoItemId},Name:{Name},Description:{Description}, CreatedDate:{CreatedDate},DeadLineDate:{DeadLineDate},totalPriority:{priority}, Status:{status})";
        }
        /*
        Id
        Name[no null]
        Description[null]
        CreationDate[no null]
        DeadLineDate[null]
        Priority(int 1-5)[no null] Default = 3, 1 = highest priority.
        Status enum (Backlog, Wip, Done, Archived) Default = Backlog*/
    }

    [DefaultValue(Backlog)]
    public enum Status
    {
        [Display(Name = "Backlog")]
        Backlog, //default value 
        [Display(Name = "Wip")]
        Wip,
        [Display(Name = "Done")]
        Done,
        [Display(Name = "Archived")]
        Archived
    }
}