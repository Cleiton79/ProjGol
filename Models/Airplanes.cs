using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TesteGolCleiton.Models
{
    public class Airplanes
    {
        public int CodAviao { get; set; }
        [Required]
        [Key]
     
        public string Modelo { get; set; }
        
        public int QtdePsg { get; set; }

        public DateTime DataCriacao { get; set; }
    }
}
