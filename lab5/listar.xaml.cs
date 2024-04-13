using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.Windows.Shapes;

namespace lab5
{
    /// <summary>
    /// Lógica de interacción para listar.xaml
    /// </summary>
    public partial class listar : Window
    {
        string connectionString = "Data Source=LAB1504-10\\SQLEXPRESS;Initial Catalog=NeptunoDB;User Id=vane;Password=123456";

        public listar()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Empleado> empleados = new List<Empleado>();
                //Cadena de conexión
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                //Comandos de TRANSACT SQL
                SqlCommand command = new SqlCommand("GetEmployees", connection);
                command.CommandType = CommandType.StoredProcedure;

                //CONECTADA
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string Apellidos = reader.GetString("Apellidos");
                    string Nombres = reader.GetString("Nombre");
                    string Tratamiento = reader.GetString("Tratamiento");
                    string Cargo = reader.GetString("cargo");
                    empleados.Add(new Empleado { Apellidos = Apellidos, Nombre = Nombres, Tratamiento = Tratamiento, cargo = Cargo });


                }
                connection.Close();

                ListarEmpleados.ItemsSource = empleados;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                //throw;
            }
        }
    }
}
