using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        #region CONSTRUCTORES
        public Universitario()
        { }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region METODOS
        public override bool Equals(object obj)
        {
            return obj is Universitario;
        }

        /// <summary>
        /// Retorna todos los datos del Universitario.
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendLine("LEGAJO: " + this.legajo);

            return sb.ToString(); ;
        }

        protected abstract string ParticiparEnClase();

        #endregion

        #region SOBRECARGAS
        /// <summary>
        /// Dos Universitario son iguales si y sólo si son del mismo Tipo y su Legajo o DNI son iguales.
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            //return ((pg1.Nacionalidad == pg2.Nacionalidad) && (pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI));
            return ((pg1.GetType() == pg2.GetType()) && (pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI));
        }

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        #endregion
    }
}