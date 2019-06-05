using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using System.IO;
using Excepciones;

namespace ClasesInstanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        #region CONSTRUCTORES
        /// <summary>
        /// Se inicializa la lista de alumnos en el constructor por defecto.
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor)
            : this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }
        #endregion

        #region PROPIEDADES
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        public Universidad.EClases Clase
        {
            get { return this.clase; }
            set { this.clase = value; }
        }

        public Profesor Instructor
        {
            get { return this.instructor; }
            set { this.instructor = value; }
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Guarda los datos de la Jornada en un archivo de texto.
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto texto = new Texto();
            return texto.Guardar("Jornada.txt", jornada.ToString());
        }

        /// <summary>
        /// Retorna los datos de la Jornada como texto.
        /// </summary>
        /// <returns></returns>
        public string Leer()
        {
            Texto texto = new Texto();
            string datos = string.Empty;

            if (texto.Leer("Jornada.txt", out datos))
                return datos;

            else
                return "sin datos";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("CLASE DE " + this.Clase);
            sb.AppendLine(" POR : " + this.Instructor);
            sb.AppendLine("ALUMNOS: ");
            sb.AppendLine("<------------------------------------------------>");
            foreach (Alumno item in this.Alumnos)
            {
                sb.Append(item.ToString());
                sb.AppendLine("<------------------------------------------------>");
            }

            return sb.ToString();
        }
        #endregion

        #region SOBRECARGAS
        /// <summary>
        /// Agrega Alumnos a la clase por medio del operador +, validando que no estén previamente cargados.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            bool flag = false;

            if (!object.Equals(j, null))
            {
                foreach (Alumno item in j.Alumnos)
                {
                    if (item == a)
                        flag = true;
                }

                if (!flag)
                    j.alumnos.Add(a);
            }
            return j;
        }

        /// <summary>
        /// Una Jornada será igual a un Alumno si el mismo participa de la clase.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            return a == j.Clase;
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        #endregion
    }
}