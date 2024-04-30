using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wPrendas
{
    public partial class Form1 : Form
    {
        private List<clsRegistroPrendas> prendas = new List<clsRegistroPrendas>();

        public Form1()
        {
            InitializeComponent();

            // Agregar tipos de prenda al ComboBox cboTipoRopa
            cboTipoRopa.Items.Add("Camisa");
            cboTipoRopa.Items.Add("Pantalón");
            cboTipoRopa.Items.Add("Falda");
            cboTipoRopa.Items.Add("Vestido");
            cboTipoRopa.Items.Add("Chaqueta");

            // Agregar marcas al ComboBox cboMarca
            cboMarca.Items.Add("Nike");
            cboMarca.Items.Add("Adidas");
            cboMarca.Items.Add("Levi's");
            cboMarca.Items.Add("Zara");
            cboMarca.Items.Add("Gucci");
            cboMarca.Items.Add("Dolce Gabbana");
            cboMarca.Items.Add("Calvin Klein");

            //Agregar los encabezados al DataGridView
            dgvPrendas.Columns.Add("TipoRopa", "Tipo de Ropa");
            dgvPrendas.Columns[0].Width = 140;
            dgvPrendas.Columns.Add("Marca", "Marca");
            dgvPrendas.Columns[1].Width = 140;
            dgvPrendas.Columns.Add("Talla", "Talla");
            dgvPrendas.Columns[2].Width = 140;
            dgvPrendas.Columns.Add("Precio", "Precio");
            dgvPrendas.Columns[3].Width = 140;
        }
        private void btnIngresar_Click_1(object sender, EventArgs e)
        {
            // Validar los datos ingresados en los controles
            if (cboTipoRopa.SelectedIndex == -1 || cboMarca.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txtTalla.Text) || string.IsNullOrWhiteSpace(txtPrecio.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            // Convertir el precio a decimal
            if (!decimal.TryParse(txtPrecio.Text, out decimal precio))
            {
                MessageBox.Show("Por favor, ingrese un precio válido.");
                return;
            }

            // Usar el método Registrar para agregar la nueva prenda a la lista
            clsRegistroPrendas.Registrar(prendas, cboTipoRopa.Text, cboMarca.Text, txtTalla.Text, precio);

            // Agregar los datos de la última prenda agregada a la lista al DataGridView
            clsRegistroPrendas ultimaPrenda = prendas.Last();
            dgvPrendas.Rows.Add(ultimaPrenda.TipoRopa, ultimaPrenda.Marca, ultimaPrenda.Talla, ultimaPrenda.Precio.ToString());

            // Limpiar los controles para un nuevo ingreso
            cboTipoRopa.SelectedIndex = -1;
            cboMarca.SelectedIndex = -1;
            txtTalla.Clear();
            txtPrecio.Clear();
        }

        private void btnCargar_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Application.StartupPath;
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamReader file = new StreamReader(openFileDialog.FileName))
                    {
                        string line;
                        while ((line = file.ReadLine()) != null)
                        {
                            string[] valores = line.Split(';');
                            if (valores.Length == 4)
                            {
                                dgvPrendas.Rows.Add(valores[0], valores[1], valores[2], valores[3]);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al leer el archivo: " + ex.Message);
                }
            }
        }
    }
}

