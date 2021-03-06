using Microsoft.EntityFrameworkCore;
using P2_AP1_Felix_20180570.DAL;
using P2_AP1_Felix_20180570.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace P2_AP1_Felix_20180570.BLL
{
   public class TiposTareasBLL
    {
        public static bool Guardar(TiposTareas Ttareas)
        {
            if (!Existe(Ttareas.TipoTareaID))
            {
                return Insertar(Ttareas);
            }
            else
            {
                return Modificar(Ttareas);
            }
                
        }
        private static bool Insertar(TiposTareas Ttareas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
               
                contexto.TiposTareas.Add(Ttareas);
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
        private static bool Modificar(TiposTareas Ttareas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Database.ExecuteSqlRaw($"Delete FROM GruposDetalle Where TipoTareaID={Ttareas.TipoTareaID}");
                contexto.Entry(Ttareas).State = EntityState.Modified;
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
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var tipotarea = TiposTareasBLL.Buscar(id);

                if (tipotarea != null)
                {
                    contexto.TiposTareas.Remove(tipotarea);
                    paso = contexto.SaveChanges() > 0;
                }

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
        public static TiposTareas Buscar(int id)
        {
            TiposTareas Ttarea = new TiposTareas();
            Contexto contexto = new Contexto();

            try
            {
                Ttarea = contexto.TiposTareas.Include(x => x.TipoTareaID)
                    .Where(x => x.TipoTareaID == id)
                    .SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Ttarea;
        }
        public static List<TiposTareas> GetList(Expression<Func<TiposTareas, bool>> criterio)
        {
            List<TiposTareas> Lista = new List<TiposTareas>();
            Contexto contexto = new Contexto();

            try
            {
                Lista = contexto.TiposTareas.Where(criterio).ToList();
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
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.TiposTareas.Any(e => e.TipoTareaID == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }

        public static List<TiposTareas> GetTipoTarea()
        {
            List<TiposTareas> Lista = new List<TiposTareas>();
            Contexto contexto = new Contexto();
            try
            {
                Lista = contexto.TiposTareas.ToList();

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
