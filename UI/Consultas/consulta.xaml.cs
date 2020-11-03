using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Alfreelina_P2_AP1.BLL;
using Alfreelina_P2_AP1.Entidades;

namespace  Alfreelina_P2_AP1.UI.Consultas
{
    /// <summary>
    /// Interaction logic for consulta.xaml
    /// </summary>
    public partial class consulta : Window
    {

        public consulta ()
        {
            InitializeComponent();
        }

         private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Proyectos>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        listado = ProyectosBLL.GetList(p => p.ProyectoID == this.ToInt(CriterioTextBox.Text));
                        break;

                    case 1:
                        listado = ProyectosBLL.GetList().Where(p => p.Descripcion.Contains(CriterioTextBox.Text)).ToList();
                        break;
                }
            }
            else
            {
                listado = ProyectosBLL.GetList(c => true);
            }

            DetalleDataGrid.ItemsSource = null;
            DetalleDataGrid.ItemsSource = listado;
        }

          public int ToInt(string value)
        {
            int retorno = 0;

            int.TryParse(value, out retorno);

            return retorno;
        }
    }
}