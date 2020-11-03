using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alfreelina_P2_AP1.Entidades
{
    public class Proyectos{
        [Key]
        public int ProyectoID { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string Descripcion { get; set; }
        public double TiempoTotal{get; set; }

        [ForeignKey("ProyectoID")]
        public virtual List<ProyectoDetalle> ProyectoDetalle {get; set;} = new List<ProyectoDetalle>();

    }
}