using p1BC13Crud.Entidades;
using p1BC13Crud.Servicios;

namespace WFAlumnos
{
    public partial class Form1 : Form
    {
        ServicioAlumno srvAlumno = new();
        MdAlumno oAlumno = new();



        public Form1()
        {
            InitializeComponent();
        }


        void respuestas()
        {

            int resppuesta = 1;
            if (resppuesta > 0)
            {

                MessageBox.Show(" REALIZADO ");
                LimpiarFormulario();
                cargaGrid();
            }
            else
            {
                MessageBox.Show("Lo lamento hubo un clavo");
            }
            
        }

        void cargaGrid()
        {
            var resultado = srvAlumno.ConsultaSQL("select * from tb_alumnos");
            dataGridViewAlumno.DataSource = resultado;

        }

        private void button1Conexion_Click(object sender, EventArgs e)
        {
            cargaGrid();
        }


        void MapeoDatosFormalio (MdAlumno _alumnos)
        {
           

            int idalum = _alumnos.idAlumno;
            textBoxIdalum.Text = Convert.ToString(idalum);

            textBoxCarnet.Text = _alumnos.carnet;
            textBoxNombre.Text = _alumnos.nombre;
            textBoxCorreo.Text = _alumnos.correo;
            comboBoxClase.Text = _alumnos.clase;
            comboBoxSeccion.Text = _alumnos.seccion;

            int parci1 = _alumnos.parcial1;
            textBoxParcial1.Text = Convert.ToString(parci1);
            int parci2 = _alumnos.parcial2;
            textBoxParcial2.Text = Convert.ToString(parci2);
            int parci3 = _alumnos.parcial3;
            textBoxParcial3.Text = Convert.ToString(parci3);
            


        }

        void buscaAlumno(string carnet)
        {
            oAlumno = null;
            oAlumno = srvAlumno.ObtenerAlumno(carnet);

            if (oAlumno == null)
            {
                MessageBox.Show("este cuate no esta");
                LimpiarFormulario();
            } else
            {
                MapeoDatosFormalio(oAlumno);
            }

            
        }


        private void buttonConsulta_Click(object sender, EventArgs e)
        {
            string carnet = textBoxCarnet.Text;
            buscaAlumno(carnet);
        }


        void LimpiarFormulario()
        {
            string blanco = textBoxNombre.Text;
           

            oAlumno = new();
            MapeoDatosFormalio(oAlumno);
            // MapeoDatosFormalio(new());

            textBoxNombre.Text="";

        }

        

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }


        private MdAlumno DatosForumulario()
        {
            MdAlumno _alumnos = new();

            

           
            _alumnos.carnet = textBoxCarnet.Text.Trim();
            _alumnos.nombre = textBoxNombre.Text.Trim();
            _alumnos.correo = textBoxCorreo.Text.Trim();
            _alumnos.clase = comboBoxClase.Text;
            _alumnos.seccion = comboBoxSeccion.Text;


            _alumnos.parcial1 = Convert.ToInt32(textBoxParcial1.Text);
            _alumnos.parcial2 = Convert.ToInt32(textBoxParcial2.Text);
            _alumnos.parcial3 = Convert.ToInt32(textBoxParcial3.Text);

            

            return _alumnos;
        }

        private void Valnota()
        {
            MessageBox.Show("NOTA 1 y 2: 20 pts max \nNOTA 3: 30 pts max");
            oAlumno = DatosForumulario();
        }

        private void Validacionombre()
        {
            MessageBox.Show("Nombre vacio");
            
            oAlumno = DatosForumulario();
        }

        
        private void crearalumno() {

            int respusta = srvAlumno.crearAlumno(oAlumno);

            if (respusta > 0)
            {
                MessageBox.Show("Se Realizo con exito");
                LimpiarFormulario();
                cargaGrid();
            }

            else
            {
                MessageBox.Show("Carnert Repetido");
            }
        }

        private void Actualizacion()
        {

            int respusta = srvAlumno.actualizarAlumno(oAlumno);

            if (respusta > 0)
            {
                MessageBox.Show("Se Realizo con exito");
                LimpiarFormulario();
                cargaGrid();
            }

            else
            {
                MessageBox.Show("Lo lamento hubo un clavo");
            }
        }

        private void eliminacion()
        {
            DialogResult DialogResult = MessageBox.Show("Seguro Quiere Eliminar?", "Eliminado", MessageBoxButtons.YesNo);
            if (DialogResult == DialogResult.Yes)
            {

                oAlumno = DatosForumulario();
                int respuesta = srvAlumno.EliminarAlumno(oAlumno);
                respuestas();

            }
            else if (DialogResult == DialogResult.No) ; 

        }
       


        private void buttonInsertar_Click(object sender, EventArgs e)
        {
            oAlumno = DatosForumulario();

            if (oAlumno.parcial1 > 20)
            {
                Valnota();
            }
            else if (oAlumno.parcial2 > 20)
            {
                Valnota(); 
            }
            else if (oAlumno.parcial3 > 35)
            {
                Valnota();
            }
            else if (oAlumno.nombre == ""|| oAlumno.nombre== "Fulanito")
            {

                Validacionombre();
            }
            else
            {
               
                crearalumno();

            }

        }

        private void buttonActualizar_Click(object sender, EventArgs e)
        {
            oAlumno = DatosForumulario();

            if (oAlumno.parcial1 > 20)
            {
                Valnota();
            }
            else if (oAlumno.parcial2 > 20)
            {
                Valnota();
            }
            else if (oAlumno.parcial3 > 35)
            {
                Valnota();
            }
            else if (oAlumno.nombre == "" || oAlumno.nombre == "Fulanito")
            {

                Validacionombre();
            }
            else
            {

                Actualizacion();

            }

        }

        private void buttonImportar_Click(object sender, EventArgs e)
        {
            string archivo = @"C:\Users\DELL\Desktop\ejercicios\p1BC13Crud\alumnos.txt";
            ClsImportExport im = new();
            MessageBox.Show(im.importar(archivo));
        }

        private void buttonExportar_Click(object sender, EventArgs e)
        {
            string archivo = @"C:\Users\DELL\Desktop\ejercicios\p1BC13Crud\nuevo.csv";
            ClsImportExport im = new();
            MessageBox.Show(im.exportar("select * from tb_alumnos ", archivo));
        }



        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            eliminacion();

            
        }

      

        private void textBoxNombre_Validated_1(object sender, EventArgs e)
        {
           
            if ( textBoxNombre.Text.Trim() == "" )
            {

                epError.SetError(textBoxNombre, "Ingresa el Nombre");
                textBoxNombre.Focus();

            }
            else
            {
                epError.Clear();
            }
        }
    }
}