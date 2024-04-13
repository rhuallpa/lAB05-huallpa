using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;

namespace lAB05
{
    public partial class InsertarCliente : Window
    {
        public InsertarCliente()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "Data Source=LAB1504-15\\SQLEXPRESS; Initial Catalog=neptuno; User Id=UserHuallpa; Password=1234567";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("InsertarCliente", connection);


                    command.CommandType = System.Data.CommandType.StoredProcedure;


                    command.Parameters.AddWithValue("@ID", txtidCliente.Text);
                    command.Parameters.AddWithValue("@NombreC", txtNombreCompañia.Text);
                    command.Parameters.AddWithValue("@NombreCo", txtNombreContacto.Text);
                    command.Parameters.AddWithValue("@CargoCo", txtCargoContacto.Text);
                    command.Parameters.AddWithValue("@Direccion", txtDireccion.Text);
                    command.Parameters.AddWithValue("@Ciudad", txtCiudad.Text);
                    command.Parameters.AddWithValue("@Region", txtRegion.Text);
                    command.Parameters.AddWithValue("@CodPostal", txtCodPostal.Text);
                    command.Parameters.AddWithValue("@Pais", txtPais.Text);
                    command.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
                    command.Parameters.AddWithValue("@Fax", txtFax.Text);

                    int rowsAffected = command.ExecuteNonQuery();

                    MessageBox.Show("Cliente insertado correctamente.");

                    ListarClientes lista = new ListarClientes();
                    lista.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al insertar cliente: " + ex.Message);
                }
            }
        }
    }
}
