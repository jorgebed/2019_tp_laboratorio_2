using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        public bool Guardar(string archivo, string datos)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + archivo, false))
                {
                    sw.WriteLine(datos);
                }
                return true;
            }

            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }

        public bool Leer(string archivo, out string datos)
        {
            try
            {
                using (System.IO.StreamReader file = new System.IO.StreamReader(AppDomain.CurrentDomain.BaseDirectory + archivo, Encoding.UTF8))
                {
                    datos = file.ReadToEnd();
                }
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }
    }
}