using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Presentacion.View; //para llevar otro form 



namespace Presentacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.Text = "MANAGEMENT LIBRARY";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (new Negocio.Management.PruebaDeConexion().pruebaConexion())
            {
                label1.Text = "La conexion es Correcta";
                label1.BackColor = Color.LightGreen;
                label1.Visible = true;

            }
            else
            {
                label1.Text = "Error en la conexion";
                label1.BackColor = Color.Red;

                label1.Visible = true;
            }
        }

        private  void label1_Click(object sender, EventArgs e)
        {
            List<int> list = new List<int>();

            list.Skip(10).Take(5).Where(x => x > 0).ToList();
          
        }

        //ALTA LIBROS
        private void button2_Click(object sender, EventArgs e)
        {
            AltasLibro pantallaAlta =  new Presentacion.View.AltasLibro();
            pantallaAlta.ShowDialog(); //este metodo abrira la pestaña de altas (1), pero  bloqueando la pantalla padre
                                       // pantallaAlta.Show();//lo mismo que el primero sin bloquear la pantalla padre
            dataGridView1.DataSource = new Negocio.Management.LibrosManagement().ObtenerLibros();

        }

        //MODIFICACION LIBROS   
        private void button3_Click(object sender, EventArgs e)
        {

            Negocio.Entities_DTO.LibrosDTO libroSeleccionado = dataGridView1.CurrentRow.DataBoundItem as Negocio.Entities_DTO.LibrosDTO;
            AltasLibro pantallaAlta = new Presentacion.View.AltasLibro(libroSeleccionado);
            pantallaAlta.Text = "MODIFICACION LIBRO";            
            pantallaAlta.ShowDialog();

            //actualizar la vista 
            dataGridView1.DataSource = new Negocio.Management.LibrosManagement().ObtenerLibros();



        }

        //ELIMINACION DE LIBROS
        private void button4_Click(object sender, EventArgs e)
        {
            
            if(dataGridView1.Rows.Count > 0)
            {

                Negocio.Entities_DTO.LibrosDTO libroSeleccionado = dataGridView1.CurrentRow.DataBoundItem as Negocio.Entities_DTO.LibrosDTO;

                if(new Negocio.Management.LibrosManagement().VerificarUnidades(libroSeleccionado.idLibro))
                {
                   DialogResult result =  MessageBox.Show("ESTE LIBRO CONTIENE UNIDADES"+ System.Environment.NewLine+ "¿Estas seguro de querer eliminarlo?","Validacion",MessageBoxButtons.YesNoCancel);
                    
                   if(result.Equals(DialogResult.Yes))
                    {
                        new Negocio.Management.LibrosManagement().ELiminarLibroDTO(libroSeleccionado);
                    }
                }
                else
                {
                    new Negocio.Management.LibrosManagement().ELiminarLibroDTO(libroSeleccionado);

                }
                dataGridView1.DataSource = new Negocio.Management.LibrosManagement().ObtenerLibros();

            }







        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
                
              dataGridView1.DataSource = new Negocio.Management.LibrosManagement().ObtenerLibros();

            
        }

        private void btnConsultaLibrosUnd_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new Negocio.Management.LibrosManagement().ObtenerLibrosUnidades();

        }

    }
}
