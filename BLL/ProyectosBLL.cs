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
    public class ProyectosBLL
    {
        public static bool Guardar(Proyectos proyectos)
        {
            if (!Existe(proyectos.ProyectoID))
                return Insertar(proyectos);
            else
                return Modificar(proyectos);
        }
        private static bool Insertar(Proyectos proyectos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Proyectos.Add(proyectos);

                foreach (var detalle in proyectos.DetalleTarea)
                {
                    contexto.Entry(detalle.TipoTareas).State = EntityState.Modified;
                }

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
        private static bool Modificar(Proyectos proyectos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var ProyectoAnterior = contexto.Proyectos
                    .Where(x => x.ProyectoID == proyectos.ProyectoID)
                    .Include(x => x.DetalleTarea).ThenInclude(x => x.TipoTareas)
                    .AsNoTracking()
                    .SingleOrDefault();

                contexto.Database.ExecuteSqlRaw($"Delete FROM TareasDetalle Where ID={proyectos.ProyectoID}");

                foreach (var detalle in ProyectoAnterior.DetalleTarea)
                {
                    contexto.Entry(detalle.TipoTareas).State = EntityState.Modified;

                }

                contexto.Entry(proyectos).State = EntityState.Modified;
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
                var proyecto = ProyectosBLL.Buscar(id);

                if (proyecto != null)
                {
                    contexto.Proyectos.Remove(proyecto); 
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
        public static Proyectos Buscar(int id)
        {
            Proyectos proyecto = new Proyectos();
            Contexto contexto = new Contexto();

            try
            {
                    proyecto = contexto.Proyectos.Include(x => x.DetalleTarea)
                    .Where(x => x.ProyectoID == id).Include(x => x.DetalleTarea).ThenInclude(x => x.TipoTareas)
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
            return proyecto;
        }
        public static List<Proyectos> GetList(Expression<Func<Proyectos, bool>> criterio)
        {
            List<Proyectos> Lista = new List<Proyectos>();

            Contexto contexto = new Contexto();

            try
            {
                //obtener la lista y filtrarla según el criterio recibido por parametro.
                Lista = contexto.Proyectos.Where(criterio).ToList();
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
                encontrado = contexto.Proyectos.Any(e => e.ProyectoID == id);
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

        
    }
}
