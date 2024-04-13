using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Lógica de interacción para registrar.xaml
    /// </summary>
    public partial class registrar : Window
    {
        string connectionString = "Data Source=LAB1504-10\\SQLEXPRESS;Initial Catalog=NeptunoDB;User Id=vane;Password=123456";

        public registrar()
        {
            InitializeComponent();
        }
        private static int lastId = 11;

        public static int GenerateNextId()
        {
            // Incrementar el último ID y devolverlo
            return ++lastId;
        }

        private void RegisterEmployee(object sender, RoutedEventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("AddEmployee", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    //Valores

                    cmd.Parameters.AddWithValue("@IdEmployee", GenerateNextId());
                    cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                    cmd.Parameters.AddWithValue("@FIrstName", txtFirstName.Text);
                    cmd.Parameters.AddWithValue("@Position", txtPosition.Text);
                    cmd.Parameters.AddWithValue("@Treatment", txtTreatment.Text);
                    cmd.Parameters.AddWithValue("@BornDate", DateTime.Parse(BornDate.Text));
                    cmd.Parameters.AddWithValue("@HiringDate", DateTime.Parse(txtHiringDate.Text));
                    cmd.Parameters.AddWithValue("@Direccion", txtDireccion.Text);
                    cmd.Parameters.AddWithValue("@City", txtCity.Text);
                    cmd.Parameters.AddWithValue("@Region", txtRegion.Text);
                    cmd.Parameters.AddWithValue("@PostalCod", txtPostalCode.Text);
                    cmd.Parameters.AddWithValue("@Country", txtCountry.Text);
                    cmd.Parameters.AddWithValue("@DireccionTel", txtDireccionTel.Text);
                    cmd.Parameters.AddWithValue("@Extension", txtExtension.Text);
                    cmd.Parameters.AddWithValue("@Notes", txtNotes.Text);
                    cmd.Parameters.AddWithValue("@Boss", string.IsNullOrEmpty(txtBoss.Text) ? (object)DBNull.Value : int.Parse(txtBoss.Text));
                    cmd.Parameters.AddWithValue("@BasicSalary", decimal.Parse(txtBasicSalary.Text));

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Empleado registrado correctamente :D");


                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            listar list = new listar();
            list.ShowDialog();
        }
    }
}
