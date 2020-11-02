using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;
using Alfreelina_P2_AP1.DAL;
using Alfreelina_P2_AP1.Entidades;

namespace Alfreelina_P2_AP1.BLL
{
    public class TareasBLL
    {
        public static List <Tareas> GetList(Expression<Func<Tareas, bool>> tareas)
        {
            List<Tareas> Lista = new List<Tareas>();
            Contexto contexto = new Contexto();

            try
            {
                Lista = contexto.Tareas.Where(tareas).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Lista;
    }

    public static List <Tareas> GetList()
        {
            List<Tareas> Lista = new List<Tareas>();
            Contexto contexto = new Contexto();

            try
            {
                Lista = contexto.Tareas.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Lista;
        }

    }
}