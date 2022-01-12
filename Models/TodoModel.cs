using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    [Table("Todos")]
    public class TodoModel
    {
        [Key]
        public int TodoId { get; set; }
        [Display(Name = "Nazwa")]
        public string Name { get; set; }
        [Display(Name = "Opis")]
        public string Description { get; set; }
        [Display(Name = "Zrobione")]
        public bool Done { get; set; }
        public bool Hide { get; set; }
    }
}
