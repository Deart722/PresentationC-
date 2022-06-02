using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Infrastructure_MDX; //realizar referencia a la infraestructura de la BASE DE DATOS

namespace Datos.Repositories
{
    public class PruebaDeConexiones
    {

        public Boolean ProbarConexion()
        {
            try
            {
                // contexto va a obtener toda los objetos de los registros que conforman la base de datos
                using (var contexto = new BibliotecaEntities())
                {
                    List<Libro> listaLibro = contexto.Libros.ToList();
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

    }
}
