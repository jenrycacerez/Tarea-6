using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TareaRepository.BLL;
using TareaRepository.Entidades;

namespace TareaRepository.UI.Registros
{
    public partial class REmpleado : Form
    {
        public REmpleado()
        {
            InitializeComponent();
        }

        public void limpiar()
        {
            ID.Value = 0;
            FechadateTimePicker.Value = DateTime.Now;
            NombretextBox.Text = string.Empty;
            DirecciontextBox.Text = string.Empty;
            TelefonotextBox.Text = string.Empty;
            CelulartextBox.Text = string.Empty;
            CedulatextBox.Text = string.Empty;
            SueldotextBox.Text = string.Empty;
            IncentivotextBox.Text = string.Empty;

            MyErrorProvider.Clear();

        }

        private Empleado LlenaClase()
        {
            Empleado empleado = new Empleado();
            empleado.EmpleadoId = (int)ID.Value;
            empleado.Fecha = FechadateTimePicker.Value;
            empleado.Nombre = NombretextBox.Text;
            empleado.Direccion = DirecciontextBox.Text;
            empleado.Telefono = TelefonotextBox.Text;
            empleado.Celular = CelulartextBox.Text;
            empleado.Cedula = CedulatextBox.Text;
            empleado.Sueldo = Convert.ToDecimal(SueldotextBox.Text);
            empleado.Incentivo = Convert.ToDecimal(IncentivotextBox.Text);


            return empleado;
        }

        private Empleado LlenaClase(Empleado empleado)
        {

            ID.Value = empleado.EmpleadoId;
            FechadateTimePicker.Value = empleado.Fecha;
            NombretextBox.Text = empleado.Nombre;
            DirecciontextBox.Text = empleado.Telefono;
            TelefonotextBox.Text = empleado.Telefono;
            CelulartextBox.Text = empleado.Telefono;
            CedulatextBox.Text = empleado.Cedula;
            SueldotextBox.Text = empleado.Sueldo.ToString("N2");
            IncentivotextBox.Text = empleado.Incentivo.ToString("N2");



            return empleado;
        }
        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id;
            Empleado empleado = new Empleado();
            int.TryParse(ID.Text, out id);

            limpiar();
            RepositorioBase<Empleado> oEmpleado = new RepositorioBase<Empleado>();

            empleado = oEmpleado.Buscar(id);

            if (empleado != null)
            {
                //  MessageBox.Show("Persona Encontrada");
                LlenaClase(empleado);
            }
            else
            {
                MessageBox.Show("Persona no Encontada");
            }
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            Empleado empleado = new Empleado();

            if (!Validar())
                return;
            RepositorioBase<Empleado> oEmpleado = new RepositorioBase<Empleado>();


            empleado = LlenaClase();

            if (ID.Value == 0)
                paso = oEmpleado.Guardar(empleado);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar un registro que no existe", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = oEmpleado.Modificar(empleado);
            }

            if (paso)
            {
                limpiar();
                MessageBox.Show("Guardado", "Existe", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No Guardado", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Empleado> oEmpleado = new RepositorioBase<Empleado>();
            Empleado empleado = oEmpleado.Buscar(Convert.ToInt32(ID.Value));

            return (empleado != null);
        }

        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrWhiteSpace(Convert.ToString(FechadateTimePicker.Value)))
            {
                MyErrorProvider.SetError(FechadateTimePicker, "El campo Fecha no puede estar vacio");

                paso = false;
            }


            if (string.IsNullOrWhiteSpace(NombretextBox.Text))
            {
                MyErrorProvider.SetError(NombretextBox, "El campo Estudiante no puede estar vacio");

                paso = false;
            }
            else
            {
                MyErrorProvider.SetError(NombretextBox, "");
            }

            if (string.IsNullOrWhiteSpace(DirecciontextBox.Text))
            {
                MyErrorProvider.SetError(DirecciontextBox, "El campo Estudiante no puede estar vacio");

                paso = false;
            }
            else
            {
                MyErrorProvider.SetError(DirecciontextBox, "");
            }


            if (string.IsNullOrWhiteSpace(TelefonotextBox.Text))
            {
                MyErrorProvider.SetError(TelefonotextBox, "El campo Estudiante no puede estar vacio");

                paso = false;
            }
            else
            {
                MyErrorProvider.SetError(TelefonotextBox, "");
            }


            if (string.IsNullOrWhiteSpace(CelulartextBox.Text))
            {
                MyErrorProvider.SetError(CelulartextBox, "El campo Valor no puede estar vacio");

                paso = false;
            }
            else
            {
                MyErrorProvider.SetError(CelulartextBox, "");
            }


            if (string.IsNullOrWhiteSpace(CedulatextBox.Text))
            {
                MyErrorProvider.SetError(CedulatextBox, "El campo Valor no puede estar vacio");

                paso = false;
            }
            else
            {
                MyErrorProvider.SetError(CedulatextBox, "");
            }

            ////////////////
            if (string.IsNullOrWhiteSpace(SueldotextBox.Text))
            {
                MyErrorProvider.SetError(SueldotextBox, "El campo Logrado no puede estar vacio");

                paso = false;
            }
            else
            {
                MyErrorProvider.SetError(SueldotextBox, "");
            }

            if (string.IsNullOrWhiteSpace(IncentivotextBox.Text))
            {
                MyErrorProvider.SetError(IncentivotextBox, "El campo Logrado no puede estar vacio");

                paso = false;
            }
            else
            {
                MyErrorProvider.SetError(IncentivotextBox, "");
            }


            return paso;
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Empleado> oEmpleado = new RepositorioBase<Empleado>();
            MyErrorProvider.Clear();
            int id;
            int.TryParse(ID.Text, out id);
            limpiar();
            if (oEmpleado.Eliminar(id))
                MessageBox.Show("Eliminado");
            else
                MyErrorProvider.SetError(ID, "No se puede eliminar una persona que no existe");
        }
    }
}
