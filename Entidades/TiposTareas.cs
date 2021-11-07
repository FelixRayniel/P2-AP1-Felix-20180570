using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_AP1_Felix_20180570.Entidades
{
    public class TiposTareas
    {
        [Key]
        public int TipoTareaID { get; set; }
        public string TipoTarea { get; set; }

    }
}
