using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Core.Entidades
{
    public class Empleado
    {
        [Key]
        public int Id { get; set; }
        public string Apellido { get; set; }
        public string Nombres { get; set; } 
        public string Cargo { get; set; }   
        public int CompaniaId { get; set; }
        [ForeignKey("CompaniaId")]
        public Compania Compania { get; set; }

    }
}