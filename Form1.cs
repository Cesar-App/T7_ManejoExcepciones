using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManejoExcepciones
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar nombre
                string nombre = txtName.Text.Trim();
                if (string.IsNullOrEmpty(nombre))
                    throw new FormatException("El nombre completo es obligatorio.");
                if (nombre.Any(char.IsDigit))
                    throw new FormatException("El nombre completo no puede contener números.");

                // Validar edad
                string edadText = txtAge.Text.Trim();
                if (string.IsNullOrEmpty(edadText))
                    throw new FormatException("La edad es obligatoria.");
                if (!int.TryParse(edadText, out int edad))
                    throw new FormatException("La edad debe ser un número entero válido.");
                if (edad <= 0 || edad > 120)
                    throw new ArgumentOutOfRangeException("edad", "La edad debe estar entre 1 y 120.");

                // Validar correo (simple)
                string correo = txtEmail.Text.Trim();
                if (string.IsNullOrEmpty(correo))
                    throw new FormatException("El correo es obligatorio.");
                if (!correo.Contains("@") || !correo.Contains("."))
                    throw new FormatException("El correo no tiene un formato válido.");

                // Si todo está bien, simular guardado
                MessageBox.Show("Estudiante guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message, "Error de rango", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Text = string.Empty;
            txtAge.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtName.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("¿Desea salir de la aplicación?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
                Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtAge_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
