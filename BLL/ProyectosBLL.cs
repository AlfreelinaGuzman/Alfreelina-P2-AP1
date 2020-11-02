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
    public class ProyectosBLL
    {

        public static bool Guardar(Proyectos proyectos)
        {
            if (!Existe(proyectos.ProyectoID))
                return Insertar(proyectos);
            else
                return Modificar(proyectos);
        }

        private static bool Existe(int id)
        {
            bool existe;
            Contexto contexto = new Contexto();
            try{
                existe = contexto.Proyectos.Any(o => o.ProyectoID== id);
            }
            catch(Exception){
                throw;

            } finally{
                contexto.Dispose();
            }
            return existe;
        }
        
        private static bool Insertar(Proyectos proyectos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Proyectos.Add(proyectos);
                paso = contexto.SaveChanges() > 0;
                
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Modificar(Proyectos proyectos){
            bool Modificado = false;
            Contexto contexto = new Contexto();
            try{
                contexto.Entry(proyectos).State = EntityState.Modified;
                Modificado = (contexto.SaveChanges()>0);
            }
            catch(Exception){
                throw;
               
            } finally{
                contexto.Dispose();
            }
            return Modificado;
        }

        public static bool Eliminar(int id){
            bool Eliminado = false;
            Contexto contexto = new Contexto();
            try{
                var proyectos = contexto.Proyectos.Find(id);
                contexto.Entry(proyectos).State = EntityState.Deleted;
                Eliminado = contexto.SaveChanges()>0;
            }

            catch(Exception){
                throw;
               
            } finally{
                contexto.Dispose();
            }
            return Eliminado;
        }

        public static Proyectos Buscar(int id){
            Proyectos proyectos;
            Contexto contexto = new Contexto();
            try{
                proyectos = contexto.Proyectos.Include(x => x.ProyectoDetalle).Where(p => p.ProyectoID  == id).SingleOrDefault();
            }
            catch(Exception){
                throw;
               
            } finally{
                contexto.Dispose();
            }
            return proyectos;
        }

    public static List <Proyectos> GetList(Expression<Func<Proyectos, bool>> proyectos)
        {
            List<Proyectos> Lista = new List<Proyectos>();
            Contexto contexto = new Contexto();

            try
            {
                Lista = contexto.Proyectos.Where(proyectos).ToList();
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

    public static List <Proyectos> GetList()
        {
            List<Proyectos> Lista = new List<Proyectos>();
            Contexto contexto = new Contexto();

            try
            {
                Lista = contexto.Proyectos.ToList();
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