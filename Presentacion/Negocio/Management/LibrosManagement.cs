using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Repositories;
using Datos.Infrastructure_MDX;
using Negocio.Entities_DTO;


namespace Negocio.Management
{
    public class LibrosManagement
    {
        public List<LibrosDTO> ObtenerLibros()
        {
           List<Libro> librosDatos = new Datos.Repositories.LibroRepository().obtenerLibrosDTO();
           List<LibrosDTO> listadoRetorno = new List<LibrosDTO>();

           foreach (var item in librosDatos)
            {
                var dto = new LibrosDTO();
               
                //Usign reflection

                Negocio.Utils.parse(item,ref dto);



                //dto.Nombre = item.Nombre;
                //dto.idCategoria = item.idCategoria;
                //dto.FechaPublicacion = item.FechaPublicacion;
                //dto.Autor = item.Autor;
                //dto.idLibro = item.idLibro;

                //agregar los datos obtenidos de la base de datos en el objeto libro mapeado
                listadoRetorno.Add(dto);
            }
           
            return listadoRetorno;

        }

        public List<LibrosConUnidadesDTO> ObtenerLibrosUnidades()
        {
            List<ObtenerLibrosConUnidades_Result> librosDatos = new Datos.Repositories.LibroRepository().obtenerLibrosConUnidadesDTO();
            List<LibrosConUnidadesDTO> listadoRetorno = new List<LibrosConUnidadesDTO>();

            foreach (var item in librosDatos)
            {
                var dto = new LibrosConUnidadesDTO();

                Negocio.Utils.parse(item, ref dto);


                //dto.Autor = item.Autor;
                //dto.UNIDADES = item.UNIDADES;
                //dto.Nombre = item.Nombre;
                //agregar los datos obtenidos de la base de datos en el objeto libro mapeado
                listadoRetorno.Add(dto);
            }

            return listadoRetorno;

        }
        public List<CategoriaDTO> ObtenerCategorias()
        {
            List<Categoria> librosDatos = new Datos.Repositories.LibroRepository().obtenerCategoriasDTO();
            List<CategoriaDTO> listadoRetorno = new List<CategoriaDTO>();

            foreach (var item in librosDatos)
            {
                var dto = new CategoriaDTO();


                Negocio.Utils.parse(item, ref dto);


                //dto.Nombre = item.Nombre;
                //dto.idCategoria = item.idCategoria;
                //agregar los datos obtenidos de la base de datos en el objeto libro mapeado
                listadoRetorno.Add(dto);
            }

            return listadoRetorno;

        }

        public void AltaLibroManagement(LibrosDTO lDto)
        {
            Libro libroDB = new Libro();
            Negocio.Utils.parse(lDto, ref libroDB);
            
            //libroDB.idLibro = lModificado.idLibro;
            //libroDB.idCategoria = lModificado.idCategoria;
            //libroDB.Nombre = lModificado.Nombre;
            //libroDB.Autor = lModificado.Autor;
            //libroDB.FechaPublicacion = lDto.FechaPublicacion;

            new Datos.Repositories.LibroRepository().AltaLibro(libroDB);


        }
        public void ModificarLibrosDTO(LibrosDTO lModificado)
        {
            Libro libroDB = new Libro();

            Negocio.Utils.parse(lModificado, ref libroDB);


            //libroDB.idLibro = lModificado.idLibro;
            //libroDB.idCategoria = lModificado.idCategoria;
            //libroDB.Nombre = lModificado.Nombre;
            //libroDB.Autor = lModificado.Autor;
            //libroDB.FechaPublicacion = lModificado.FechaPublicacion;
            new Datos.Repositories.LibroRepository().ModificarLibro(libroDB);

        }
        public void ELiminarLibroDTO(LibrosDTO libroEliminar)
        {
            new Datos.Repositories.LibroRepository().EliminarLibro(libroEliminar.idLibro);
        }
        public bool VerificarUnidades(Int32 idLibro)
        {
            return new Datos.Repositories.LibroRepository().verificarUnidades(idLibro);
       
        }

       
    }
}
