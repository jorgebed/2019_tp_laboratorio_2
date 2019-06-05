using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;
using Archivos;

namespace ClasesInstanciables
{
    public class Universidad
    {
        private List<Alumno> alumnos;
        private List<Jornada> jornadas;
        private List<Profesor> profesores;

        public enum EClases { Programacion, Laboratorio, Legislacion, SPD }

        #region CONSTRUCTORES
        public Universidad()
        {
            this.Alumnos = new List<Alumno>();
            this.Jornadas = new List<Jornada>();
            this.Instructores = new List<Profesor>();
        }
        #endregion

        #region PROPIEDADES
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        public List<Profesor> Instructores
        {
            get { return this.profesores; }
            set { this.profesores = value; }
        }

        public List<Jornada> Jornadas
        {
            get { return this.jornadas; }
            set { this.jornadas = value; }
        }

        public Jornada this[int i]
        {
            get
            {
                if (i < 0)
                    return null;
                else
                    return this.jornadas[i];
            }
            set
            {
                if (i >= 0)
                {
                    this.jornadas[i] = value;
                }
            }
        }
        #endregion

        #region METODOS
        public static bool Guardar(Universidad uni)
        {
            //XmlTextWriter XmlTw = new XmlTextWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Universidad.xml", Encoding.UTF8);
            //XmlSerializer XmlSer = new XmlSerializer(typeof(Universidad));

            //XmlSer.Serialize(XmlTw, uni);
            //XmlTw.Close();
            //return true;
            Xml<Universidad> DatosXml = new Xml<Universidad>();
            return DatosXml.Guardar("Universidad.xml", uni);
        }

        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("JORNADAS: ");
            foreach (Jornada item in uni.Jornadas)
            {
                sb.Append(item.ToString());
            }

            sb.AppendLine("ALUMNOS: ");
            foreach (Alumno item in uni.Alumnos)
            {
                sb.Append(item.ToString());
            }

            

            sb.AppendLine("PROFESORES: ");
            foreach (Profesor item in uni.Instructores)
            {
                sb.Append(item.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Los datos del Universidad se harán públicos mediante ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }
        #endregion

        #region SOBRECARGAS
        /// <summary>
        /// Un Universidad será igual a un Alumno si el mismo está inscripto en él
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach (Alumno item in g.Alumnos)
            {
                if (item == a)
                    return true;
            }
            return false;
        }

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Un Universidad será igual a un Profesor si el mismo está dando clases en él.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor item in g.Instructores)
            {
                if (item == i)
                    return true;
            }
            return false;
        }

        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Retorna el primer Profesor capaz de dar esa clase. 
        /// Sino, lanzará la Excepción SinProfesorException.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor item in u.Instructores)
            {
                if (item == clase)
                    return item;
            }
            throw new SinProfesorException();
        }

        /// <summary>
        /// Retorna el primer Profesor que no pueda dar la clase.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            foreach (Profesor item in u.Instructores)
            {
                if (item != clase)
                    return item;
            }
            throw new SinProfesorException();
        }

        /// <summary>
        /// Al agregar una clase a un Universidad se deberá generar y agregar una nueva Jornada indicando la clase, 
        /// un Profesor que pueda darla (según su atributo ClasesDelDia) y la lista de alumnos que la toman (todos los que coincidan en su campo ClaseQueToma).
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada jornada = new Jornada(clase, g == clase);

            // Agrego la nueva jornada a la lista de jornadas.
            g.Jornadas.Add(jornada);

            // Recorro todos los alumnos de la universidad y si toman esa clase, los ingreso a la nueva jornada.
            foreach (Alumno item in g.Alumnos)
            {
                if (item == clase)
                    jornada.Alumnos.Add(item);
            }

            return g;
        }

        /// <summary>
        /// Agrega Alumnos mediante el operador +, validando que no estén previamente cargados.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            // Si el alumno se encuentra en la lista de Alumnos entonces lanzo la excepción AlumnoRepetidoException.
            if (u == a)
                throw new AlumnoRepetidoException();

            // Si el alumno no está en la lista de alumnos lo agrego.
            else
                u.Alumnos.Add(a);

            return u;
        }

        /// <summary>
        /// Agrega Profesores mediante el operador +, validando que no estén previamente cargados.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
                u.profesores.Add(i);

            return u;
        }
        #endregion
    }
}