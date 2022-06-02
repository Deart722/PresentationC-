using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio.Entities_DTO;
using Negocio.Management;


namespace Presentacion.View
{
    public partial class AltasLibro : Form
    {

        public LibrosDTO libroMOD { get; set; }
        public AltasLibro(LibrosDTO libro)
        {
            libroMOD = libro;
            InitializeComponent();


        }

        public AltasLibro()
        {
            InitializeComponent();
        }

        private void btnAcceptar_Click(object sender, EventArgs e)
        {


            if (libroMOD is null != true)
            {
                libroMOD.Nombre = textBox1.Text;
                libroMOD.Autor = textBox2.Text;
                libroMOD.idCategoria = new Negocio.Management.LibrosManagement().ObtenerCategorias().Where(b => b.Nombre == cmbCategoria.Text).First().idCategoria;
                libroMOD.FechaPublicacion = DateTime.Now;

                new Negocio.Management.LibrosManagement().ModificarLibrosDTO(libroMOD);
            }
            else
            {
                LibrosDTO libro = new LibrosDTO();
                libro.Nombre = textBox1.Text;
                libro.Autor = textBox2.Text;

                //filtrado de la lista de las categorias y cojer el primer id categoria que se se seleccciona
                libro.idCategoria = new Negocio.Management.LibrosManagement().ObtenerCategorias().Where(b => b.Nombre == cmbCategoria.Text).First().idCategoria;
                libro.FechaPublicacion = DateTime.Now;

                new Negocio.Management.LibrosManagement().AltaLibroManagement(libro);

              

            }
            this.Close();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); //para cerrar el formulario
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AltasLibro_Load(object sender, EventArgs e)
        {
            //se le asigna al combo todas las categorias

            //se hace un filtrado de todos los datos de la categoria que contienen varios datos y solo se sacan los nombres
            cmbCategoria.DataSource =   new Negocio.Management.LibrosManagement().ObtenerCategorias().Select(b => b.Nombre).ToList();
               
            if (libroMOD is null != true)
            {

                 textBox1.Text = libroMOD.Nombre;
                 textBox2.Text = libroMOD.Autor;
                 cmbCategoria.Text = new Negocio.Management.LibrosManagement().ObtenerCategorias().Where(b => b.Nombre == cmbCategoria.Text).First().Nombre;
                //libroMOD.FechaPublicacion = DateTime.Now;
            
            }

        }
    }
}
