using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ML
{
    public class Materia
    {
        public Materia()
        {

        }
        public int IdMateria { get; set; }

        [MaxLength(100)]        
        [Required(ErrorMessage="El nombre es requerido")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "Los créditos son requerido")]
        public byte Creditos { get; set; } //0-255

        
        [Required(ErrorMessage = "El costo es requerido")]
        public decimal Costo { get; set; }     
   
        [Required(ErrorMessage="Seleccione un semestre")]
        public ML.Semestre Semestre { get; set; }
        public List<object> Materias { get; set; }

    }
}
