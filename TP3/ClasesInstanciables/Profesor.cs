using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        #region CONSTRUCTORES
        static Profesor()
        {
            Profesor.random = new Random();
        }

        public Profesor()
        { }

        /// <summary>
        /// Se inicializará ClasesDelDia y se asignarán dos clases al azar al Profesor mediante el método randomClases. 
        /// Las dos clases pueden o no ser la misma.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();

            for (int i = 0; i < 2; i++)
            {
                this._randomClases();
                //System.Threading.Thread.Sleep(300);
            }
        }
        #endregion

        #region METODOS
        private void _randomClases()
        {
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(1, 4));
        }

        /// <summary>
        /// Muestra todos los datos del profesor.
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.MostrarDatos());
            sb.Append(this.ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// Retorna la cadena "CLASES DEL DÍA" junto al nombre de la clases que da.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Universidad.EClases item in this.clasesDelDia)
            {
                sb.AppendLine("CLASES DEL DIA: " + item.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// ToString hará públicos los datos del Profesor.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region SOBRECARGAS
        /// <summary>
        /// Un Profesor será igual a un EClase si da esa clase.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            foreach (Universidad.EClases item in i.clasesDelDia)
            {
                if (item == clase)
                    return true;
            }
            return false;
        }

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        #endregion
    }
}