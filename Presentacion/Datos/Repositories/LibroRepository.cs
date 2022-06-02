using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Repositories;
using Datos.Infrastructure_MDX;


namespace Datos.Repositories
{
    public class LibroRepository
    {

        //Consultar la tabla libros

        public List<Libro> obtenerLibrosDTO()
        {
            List<Libro> listadoRetorno = new List<Libro>();

            try
            {

                
                //abrir la base de datos y cojer los objetos mappeados                
                using(var contexto = new BibliotecaEntities())
                {
                    listadoRetorno =  contexto.Libros.ToList();

                }
                return listadoRetorno;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return listadoRetorno;
            }

        }
        //Consultar la tabla UNIDADES_libros

        public List<ObtenerLibrosConUnidades_Result> obtenerLibrosConUnidadesDTO()
        {
            List<ObtenerLibrosConUnidades_Result> listadoRetorno = new List<ObtenerLibrosConUnidades_Result>();

            try
            {


                //abrir la base de datos y cojer los objetos mappeados                
                using (var contexto = new BibliotecaEntities())
                {

                    //Cojer el procedimiento almacenado
                    listadoRetorno = contexto.ObtenerLibrosConUnidades().ToList();

                }
                return listadoRetorno;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return listadoRetorno;
            }

        }
        //Obtener las categorias
        public List<Categoria> obtenerCategoriasDTO()
        {
            List<Categoria> listadoRetorno = new List<Categoria>();

            try
            {
                //abrir la base de datos y cojer los objetos mappeados                
                using (var contexto = new BibliotecaEntities())
                {
                    listadoRetorno = contexto.Categorias.ToList();

                }
                return listadoRetorno;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return listadoRetorno;
            }

        }
        public void AltaLibro(Libro l)
        {
            using (var contexto = new BibliotecaEntities())
            {

                contexto.Libros.Add(l);
                //Completar la transaccion
                contexto.SaveChanges();
            }
        }

        public void ModificarLibro(Libro nuevoLibro)
        {
            try
            {

                using (var contexto = new BibliotecaEntities())
                {

                    Libro libroOriginalBD =  contexto.Libros.Where(b => b.idLibro == nuevoLibro.idLibro).First();

                    libroOriginalBD.Nombre = nuevoLibro.Nombre;
                    libroOriginalBD.Autor = nuevoLibro.Autor;
                    libroOriginalBD.idCategoria = nuevoLibro.idCategoria;
                    //Completar la transaccion
                    contexto.Entry(libroOriginalBD).State = System.Data.Entity.EntityState.Modified;
                    contexto.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw;            
            }
        }

        public void EliminarLibro(Int32 idLibro)
        {
            using (var contexto = new BibliotecaEntities())
            {

                //Comprobar que no esta relacionado con otras entidades 
                Libro libroEliminar = contexto.Libros.Where(x => x.idLibro == idLibro).First();

                List<LibrosUnidade> librosUnidade = contexto.LibrosUnidades.Where(x => x.idLibro == idLibro).ToList();

                if(librosUnidade.Count() > 0)
                {
                    contexto.LibrosUnidades.RemoveRange(librosUnidade);
                    contexto.Entry(libroEliminar).State = System.Data.Entity.EntityState.Deleted;
                    contexto.SaveChanges();

                }
                else
                {
                    contexto.Entry(libroEliminar).State = System.Data.Entity.EntityState.Deleted;
                    contexto.SaveChanges();
                }
                


            }
        }


        public bool verificarUnidades(Int32 idLibro)
        {
            List<LibrosUnidade> librosConUnidades = new List<LibrosUnidade>();
            using(var contexto = new BibliotecaEntities())
            {
                librosConUnidades = contexto.LibrosUnidades.Where(x => x.idLibro == idLibro).ToList();
            }
            if (librosConUnidades.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
