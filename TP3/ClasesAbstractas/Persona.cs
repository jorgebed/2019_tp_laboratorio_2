using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;

        public enum ENacionalidad { Argentino, Extranjero }

        #region CONSTRUCTORES
        public Persona()
        { }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

        #region PROPIEDADES
        public string Apellido
        {
            get { return this.apellido; }
            set { this.apellido = this.ValidarNombreApellido(value); }
        }

        public int DNI
        {
            get { return this.dni; }
            set { this.dni = this.ValidarDni(this.Nacionalidad, value); }
        }

        public ENacionalidad Nacionalidad
        {
            get { return this.nacionalidad; }
            set { this.nacionalidad = value; }
        }

        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = this.ValidarNombreApellido(value); }
        }

        public string StringToDNI
        {
            set { this.dni = ValidarDni(this.Nacionalidad, value); }
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Retorna los datos de la Persona.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("NOMBRE COMPLETO: " + this.Apellido + ", " + this.Nombre);
            sb.AppendLine("NACIONALIDAD: " + this.Nacionalidad);
            sb.AppendLine("DNI: " + this.DNI);

            return sb.ToString();
        }

        /// <summary>
        /// Valida que el DNI sea correcto, teniendo en cuenta su nacionalidad. 
        /// Argentino entre 1 y 89999999 y Extranjero entre 90000000 y 99999999. 
        /// Caso contrario, lanzará la excepción NacionalidadInvalidaException.
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (nacionalidad == ENacionalidad.Argentino && (dato >= 1 && dato <= 89999999))
                return dato;
            else if (nacionalidad == ENacionalidad.Extranjero && (dato >= 90000000 && dato <= 99999999))
                return dato;
            else
                throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI");
        }

        /// <summary>
        /// Si el DNI presenta un error de formato (más caracteres de los permitidos, letras, etc.) lanzará DniInvalidoException.
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dni = 0;

            if (int.TryParse(dato, out dni))
                return ValidarDni(nacionalidad, dni);
            else
                throw new DniInvalidoException("El formato del documento no es válido");
        }

        /// <summary>
        /// Valida que los nombres sean cadenas con caracteres válidos para nombres. Caso contrario, no se cargará.
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {
            for (int i = 0; i < dato.Length; i++)
            {
                if (!char.IsLetter(dato, i))
                {
                    dato = string.Empty;
                    break;
                }
            }
            return dato;
        }
        #endregion
    }
}