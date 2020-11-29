using System.ComponentModel.DataAnnotations;

namespace ToDoWebApp.Models
{
    public class Category
    {
        [ScaffoldColumn(false)]
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
    }
}