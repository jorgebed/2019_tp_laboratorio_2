using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;
using EntidadesAbstractas;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        public bool Guardar(string archivo, T datos)
        {
            try
            {
                XmlTextWriter XmlTw = new XmlTextWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + archivo, Encoding.UTF8);
                XmlSerializer XmlSer = new XmlSerializer(typeof(T));

                XmlSer.Serialize(XmlTw, datos);
                XmlTw.Close();
                return true;
            }

            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }

        public bool Leer(string archivo, out T datos)
        {
            throw new NotImplementedException();
        }
    }
}