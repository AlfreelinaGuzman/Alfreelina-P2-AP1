using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alfreelina_P2_AP1.Entidades
{

    public class Tareas
    {
        [Key]
        public int TareaID { get; set; }
        public string TipoTarea { get; set; }
    }

}