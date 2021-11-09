using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_AP1_Felix_20180570.Entidades
{
    public class TareasDetalle
    {
        [Key]
        public int ID { get; set; }
        public int TipoTareaID { get; set; }
        public string Requerimiento { get; set; }
        public int Tiempo { get; set; }
        
        [ForeignKey ("TipoTareaID")]
        public TiposTareas TipoTareas { get; set; }

        public TareasDetalle()
        {
            ID = 0;
            TipoTareaID = 0;
            Requerimiento = " ";
            Tiempo = 0;
            TipoTareas = null;

        }

        public TareasDetalle(int tipoTareaID, string requerimiento, int tiempo, TiposTareas tipo)
        {
            ID = 0;
            TipoTareaID = tipoTareaID;
            Requerimiento = requerimiento;
            Tiempo = tiempo;
            TipoTareas = tipo;

        }
    }
}
