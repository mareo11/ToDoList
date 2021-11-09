using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    [Table("Zadania")]
    public class ZadaniaModelcs
    {
        [Key]
        public int ZadaniaId { get; set; }
        [DisplayName("Nazwa")]
        [Required(ErrorMessage ="Pole nazwa jest wymagane")]
        [MaxLength(50)]
        public string Nazwa { get; set; }
        [DisplayName("Opis")]
        [MaxLength(1000)]
        public string Szczegóły { get; set; }
        [DisplayName("Termin zadania")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Pole Data jest wymagane")]
        public DateTime Data { get; set; }

        public bool Gotowe { get; set; }

    }
}
