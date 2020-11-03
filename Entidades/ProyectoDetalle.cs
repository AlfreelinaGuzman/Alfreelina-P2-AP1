using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alfreelina_P2_AP1.Entidades
{
    public class ProyectoDetalle{
        [Key]
        public int ID { get; set; }
        public int ProyectoID { get; set; }
        public int TareaID { get; set; }
        public string Requerimiento { get; set; }
        public double Tiempo { get; set; }
    

       [ForeignKey("TareaID")]

        public Tareas tareas{get; set;}= new Tareas();

       
    }
}