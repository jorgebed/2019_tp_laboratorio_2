using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        // El constructor por defecto (sin parámetros) asignará valor 0 al atributo numero.
        public Numero()
        {
            this.numero = 0;
        }

        public Numero(double numero)
            : this(numero.ToString())
        {
        }

        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        /// <summary>
        /// Asigna un valor al atributo número, previa validación. 
        /// </summary>
        public string SetNumero
        {
            set { this.numero = Numero.ValidarNumero(value); }
        }

        /// <summary>
        /// Convierte un número binario a decimal, en caso de ser posible. Caso contrario retornará "Valor inválido".
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
        public string BinarioDecimal(string binario)
        {
            double resultado = 0;
            int cantidad = binario.Length;
            double numero;
            string aux = string.Empty;
            bool flag = true;

            // Verifico que el dato ingresado sea binario
            for (int i = 0; i < cantidad; i++)
            {
                aux = binario.Substring(i, 1);
                if (aux != "0" && aux != "1")
                {
                    flag = false;
                    break;
                }
            }

            // Si es binario realiza el cálculo
            if (flag)
            {
                aux = string.Empty;
                for (int i = 0; i < cantidad; i++)
                {
                    // Paso a double el caracter del dato ingresado en esa posición.
                    numero = double.Parse(binario.Substring(i, 1));
                    resultado += numero * Math.Pow(2, cantidad - (i + 1));
                }
                return resultado.ToString();
            }
            return "Valor inválido";
        }

        /// <summary>
        /// Convierte un número decimal a binario en caso de ser posible. Caso contrario retorna "Valor inválido".
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public string DecimalBinario(double numero)
        {
            int resultado, resto;
            string binario = string.Empty;

            // Si el número es negativo lo transformo en positivo.
            if (numero < 0)
                numero = numero * -1;

            do
            {
                // Tomo el valor absoluto del doble.
                resultado = (int)numero / 2;
                resto = (int)numero % 2;
                binario = resto.ToString() + binario;
                numero = resultado;

            } while (resultado >= 2);

            return binario = resultado + binario;
        }

        /// <summary>
        /// Convierte un número decimal a binario en caso de ser posible. Caso contrario retorna "Valor inválido".
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public string DecimalBinario(string numero)
        {
            double aux;

            if (double.TryParse(numero, out aux))
                return DecimalBinario(aux);
            return "Valor inválido";
        }

        /// <summary>
        /// Comprueba que el valor recibido sea numérico, y lo retorna en formato double. Caso contrario, retorna 0.
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns></returns>
        private static double ValidarNumero(string strNumero)
        {
            double numero = 0;

            if (double.TryParse(strNumero, out numero))
                return numero;
            else
                return 0;
        }

        /// <summary>
        /// Realiza la resta entre dos números.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Realiza la multiplicación entre dos números.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Realiza la división entre dos números.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator /(Numero n1, Numero n2)
        {
            // Si se tratara de una división por 0, retornará double.MinValue.
            if (n2.numero == 0)
                return double.MinValue;
            return n1.numero / n2.numero;
        }

        /// <summary>
        /// Realiza la suma entre dos números.
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
    }
}
