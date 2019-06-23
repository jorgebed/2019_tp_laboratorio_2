using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Entidades
{
    public static class GuardaString
    {
        public static bool Guardar(this string texto, string archivo)
        {
            bool retorno = false;
            try
            {
                using (StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + archivo, true))
                {
                    sw.WriteLine(texto);
                }
                retorno = true;
            }

            catch (Exception e)
            {
                MessageBox.Show("Se produjo un ERROR al guardar el archivo de texto");
            }
            return retorno;
        }
    }
}
