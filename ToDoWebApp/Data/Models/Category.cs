using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToDoWebApp.Models
{
    public class Category
    {
        [Key]
        /* for Details is can be True*/
        public int CategoryId
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

        /* one to many tarp Category ir CategoryId*/
        public virtual ICollection<TodoItem> TodoItems { get; set; }

    }
}