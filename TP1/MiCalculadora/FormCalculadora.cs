using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }        

        private void btnOperar_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = (FormCalculadora.Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text)).ToString();
        }        

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            double numero;
            // Valido que en lblResultado exista dato sino que no realice ninguna operación.
            if (double.TryParse(this.lblResultado.Text, out numero))
            {
                Numero num1 = new Numero(this.lblResultado.Text);
                this.lblResultado.Text = num1.DecimalBinario(this.lblResultado.Text);
            }
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            double numero;
            // La Validación de ser un número positivo se encuentra en el método BinarioDecimal de la Clase Numero
            // Valido que en lblResultado exista dato sino que no realice ninguna operación
            if (double.TryParse(this.lblResultado.Text, out numero))
            {
                Numero num1 = new Numero(this.lblResultado.Text);
                this.lblResultado.Text = num1.BinarioDecimal(this.lblResultado.Text);
            }
        }

        private static double Operar(string numero1, string numero2, string operador)
        {
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);
            return Calculadora.operar(num1, num2, operador);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }        

        private void Limpiar()
        {
            this.lblResultado.ResetText();
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.cmbOperador.ResetText();
        }
    }
}
