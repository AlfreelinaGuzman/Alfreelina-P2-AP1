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
using Alfreelina_P2_AP1.DAL;
using Alfreelina_P2_AP1.Entidades;
using Alfreelina_P2_AP1.UI;

namespace  Alfreelina_P2_AP1.UI.Registros
{
    /// <summary>
    /// Interaction logic for rProyecto.xaml
    /// </summary>
    public partial class rProyecto : Window
    {
        private Proyectos proyectos = new Proyectos ();
        public rProyecto()
        {
           InitializeComponent();

            TipoTareaComboBox.ItemsSource = TareasBLL.GetList();
            TipoTareaComboBox.SelectedValuePath = "TareaID";
            TipoTareaComboBox.DisplayMemberPath = "TipoTarea";

        }

        private void Limpiar()
        {
            proyectos = new Proyectos();
            this.DataContext = proyectos;
        }

           private void Actualizar() 
        {
            this.DataContext = null;
            this.DataContext = proyectos;
        }

        private bool ExisteDB(){
            proyectos= ProyectosBLL.Buscar(Convert.ToInt32(ProyectoIDTextBox.Text));
            return (proyectos != null);
        }
        private bool Validar() 
        { 
            bool Validado = true;  

            if (ProyectoIDTextBox.Text.Length == 0) 
            {
                 Validado = false; 
                 MessageBox.Show("Transaccion Fallida", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return Validado; 
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
           /// bool paso = false;
            if (ProyectosBLL.Guardar(proyectos))
            {
                Limpiar();
                MessageBox.Show("Guardado!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Fallo al guardar", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            id = Convert.ToInt32(ProyectoIDTextBox.Text);

            Limpiar();

            if(ProyectosBLL.Eliminar(id))
                MessageBox.Show("Se elimino Correctamente");
            else
                MessageBox.Show(ProyectoIDTextBox.Text,"No se pudo eliminar!");
        }
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Proyectos anterior = ProyectosBLL.Buscar(Convert.ToInt32(ProyectoIDTextBox.Text));

            if(anterior != null)
            {
                proyectos = anterior;
                this.DataContext = proyectos;
            }
            else
            {
                MessageBox.Show("No se encontro");
            }
        }
        
    private void AgregarButton_Click(object sender, RoutedEventArgs e) {
       
       var filaDetalle = new ProyectoDetalle 
     { 
        ProyectoID = this.proyectos.ProyectoID,
        TareaID = Convert.ToInt32(TipoTareaComboBox.SelectedValue.ToString()),
        tareas = ((Tareas)TipoTareaComboBox.SelectedItem),
        Requerimiento = (RequerimientoTextBox.Text), 
        Tiempo = Convert.ToSingle(TiempoTextBox.Text) 
      };

      proyectos.TiempoTotal += Convert.ToDouble(TiempoTextBox.Text.ToString());
      this.proyectos.ProyectoDetalle.Add(filaDetalle); 
      Actualizar();
      TipoTareaComboBox.SelectedIndex = -1; 
      RequerimientoTextBox.Clear(); 
      TiempoTextBox.Clear();
    }


    private void RemoverButton_Click(object sender, RoutedEventArgs e) 
    { 
        try { 
            double total = Convert.ToDouble(TiempoTotalTextBox.Text); 
         if (DetalleDataGrid.Items.Count >= 1 && DetalleDataGrid.SelectedIndex <= DetalleDataGrid.Items.Count - 1)
          { 
            proyectos.ProyectoDetalle.RemoveAt(DetalleDataGrid.SelectedIndex);
            proyectos.TiempoTotal -= total; 
             Actualizar(); 
         } 
        } 
        catch
        { 
         MessageBox.Show("Por favor seleccione una Fila\n\nElija la Fila a Remover."); 
        }
   }


    private bool Existe()
        {
            Proyectos esValido = ProyectosBLL.Buscar(proyectos.ProyectoID);

            return (esValido != null);
        }

    private void TiempoTextBox_TextChanged(object sender, TextChangedEventArgs e) { 
        try 
        { 
            if (TiempoTextBox.Text.Trim() != "") {
                 double resultado = double.Parse(TiempoTextBox.Text);
        }
        } catch { 
            MessageBox.Show($"Porfavor, digite un numero.");
            TiempoTextBox.Clear();
            TiempoTextBox.Focus(); 
            } }
    }
    }