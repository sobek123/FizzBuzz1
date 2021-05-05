using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace FizzBuzz.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Liczba:")]
        [Required(ErrorMessage = "Podaj liczbę!")]
        [Range(1, 1000, ErrorMessage = "Nie jest to liczba z zakresu 1-1000!")]
        public int Number { get; set; }

        [Column(TypeName = "datetime")]
        [NotMapped]
        public  string Date { get; set; }
        [Column(TypeName ="varchar(60)")]
        public string Message { get; set; }
    }
}
