using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Valida y realiza la operación pedida entre ambos números.
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        public static double operar(Numero num1, Numero num2, string operador)
        {
            double numero = 0;

            switch (Calculadora.ValidarOperador(operador))
            {
                case "+":
                    numero = num1 + num2;
                    break;
                case "-":
                    numero = num1 - num2;
                    break;
                case "*":
                    numero = num1 * num2;
                    break;
                case "/":
                    numero = num1 / num2;
                    break;
            }
            return numero;
        }

        /// <summary>
        /// Valida que el operador recibido sea "+", "-", "/" o "*". Caso contrario retornará "+".
        /// </summary>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static string ValidarOperador(string operador)
        {
            if (operador == "+" || operador == "-" || operador == "*" || operador == "/")
                return operador;
            else
                return "+";
        }
    }
}
