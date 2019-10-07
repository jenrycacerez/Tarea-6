using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TareaRepository.Entidades;
using TareaRepository.BLL;

namespace TareaRepository.UI.Consultas
{
    public partial class CEmpleados : Form
    {
        public CEmpleados()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Consultabutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Empleado> oEmpleado = new RepositorioBase<Empleado>();
            var listado = new List<Empleado>();

            if (CriterioTextBox.Text.Trim().Length > 0 || FiltrarComboBox.SelectedIndex == 3)
            {
                switch (FiltrarComboBox.SelectedIndex)
                {
                    case 0://todo
                        listado = oEmpleado.GetList(p => true);
                        break;

                    case 1://ID
                        int id = Convert.ToInt32(CriterioTextBox.Text);
                        listado = oEmpleado.GetList(p => p.EmpleadoId == id);
                        break;

                    case 2://Nombre
                        listado = oEmpleado.GetList(p => p.Nombre.Contains(CriterioTextBox.Text));
                        break;
                    case 3://Fecha
                        listado = oEmpleado.GetList(p => p.Fecha >= DesdeDateTimePicker.Value.Date && p.Fecha <= HastaDateTimePicker.Value);
                        break;

                }
            }
            else
            {
                listado = oEmpleado.GetList(p => true);
            }


            ConsultaDataGridView.DataSource = null;
            ConsultaDataGridView.DataSource = listado;
        }
    }
}
