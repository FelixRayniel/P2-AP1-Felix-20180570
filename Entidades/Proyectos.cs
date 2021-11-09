using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_AP1_Felix_20180570.Entidades
{
   public class Proyectos
    {
        [Key]
        public int ProyectoID { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string Descripcion { get; set; }
        public int TiempoTotal { get; set; }

        [ForeignKey("ProyectoID")]
        public List<TareasDetalle> DetalleTarea { get; set; } = new List<TareasDetalle>();

    }
}
