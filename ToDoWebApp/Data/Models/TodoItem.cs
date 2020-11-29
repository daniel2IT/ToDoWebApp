using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoWebApp.Models
{
    public class TodoItem
    {

      /*   [ScaffoldColumn(false)] *//* for Details is can be True*/
        public int TodoItemId { get; set; } /**/
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Prasome Ivesti Varda"), MaxLength(30)]
        public string Name { get; set; }/**/
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Prasome Ivesti Aprasa"), MaxLength(30)]
        public string Description { get; set; }/**/

        [Required(ErrorMessage = "Pasirinkite Nuo 1 iki 5 ")]
        [Range(1.00, 5.00, ErrorMessage = "Priority turi buti tarp 1 and 5")] /* Not Working, but i will just create Validation in CreateView... */
        public int priority { get; set; }/**/

        public override string ToString()
        {
                return $"TodoItem(Id:{TodoItemId},Name:{Name},Description:{Description},totalPriority:{priority})"; /**/
        }
      

    }
}
