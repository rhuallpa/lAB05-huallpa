using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace lAB05
{
    public partial class ListarClientes : Window
    {
        private string connectionString = "Data Source=LAB1504-15\\SQLEXPRESS; Initial Catalog=neptuno; User Id=UserHuallpa; Password=1234567";
        public ListarClientes()
        {
            InitializeComponent();
            CargarClientes();
        }

        private void CargarClientes()
        {
            List<Cliente> clientes = new List<Cliente>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("ListarCliente", connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string idCliente = reader.IsDBNull(reader.GetOrdinal("idCliente")) ? null : reader.GetString(reader.GetOrdinal("idCliente"));
                        string NombreCompañia = reader.IsDBNull(reader.GetOrdinal("NombreCompañia")) ? null : reader.GetString(reader.GetOrdinal("NombreCompañia"));
                        string NombreContacto = reader.IsDBNull(reader.GetOrdinal("NombreContacto")) ? null : reader.GetString(reader.GetOrdinal("NombreContacto"));
                        string CargoContacto = reader.IsDBNull(reader.GetOrdinal("CargoContacto")) ? null : reader.GetString(reader.GetOrdinal("CargoContacto"));
                        string Direccion = reader.IsDBNull(reader.GetOrdinal("Direccion")) ? null : reader.GetString(reader.GetOrdinal("Direccion"));
                        string Ciudad = reader.IsDBNull(reader.GetOrdinal("Ciudad")) ? null : reader.GetString(reader.GetOrdinal("Ciudad"));
                        string Region = reader.IsDBNull(reader.GetOrdinal("Region")) ? null : reader.GetString(reader.GetOrdinal("Region"));
                        string CodPostal = reader.IsDBNull(reader.GetOrdinal("CodPostal")) ? null : reader.GetString(reader.GetOrdinal("CodPostal"));
                        string Pais = reader.IsDBNull(reader.GetOrdinal("Pais")) ? null : reader.GetString(reader.GetOrdinal("Pais"));
                        string Telefono = reader.IsDBNull(reader.GetOrdinal("Telefono")) ? null : reader.GetString(reader.GetOrdinal("Telefono"));
                        string Fax = reader.IsDBNull(reader.GetOrdinal("Fax")) ? null : reader.GetString(reader.GetOrdinal("Fax"));

                        clientes.Add(new Cliente
                        {
                            idCliente = idCliente,
                            NombreCompañia = NombreCompañia,
                            NombreContacto = NombreContacto,
                            CargoContacto = CargoContacto,
                            Direccion = Direccion,
                            Ciudad = Ciudad,
                            Region = Region,
                            CodPostal = CodPostal,
                            Pais = Pais,
                            Telefono = Telefono,
                            Fax = Fax
                        });
                    }
                }
                dataGridClientes.ItemsSource = clientes;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window ventanaActual = Window.GetWindow(this);
            ventanaActual.Close();
        }

        public class Cliente
        {
            public string idCliente { get; set; }
            public string NombreCompañia { get; set; }
            public string NombreContacto { get; set; }
            public string CargoContacto { get; set; }
            public string Direccion { get; set; }
            public string Ciudad { get; set; }
            public string Region { get; set; }
            public string CodPostal { get; set; }
            public string Pais { get; set; }
            public string Telefono { get; set; }
            public string Fax { get; set; }
        }
    }
}
