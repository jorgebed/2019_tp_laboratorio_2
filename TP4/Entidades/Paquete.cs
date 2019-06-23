using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entidades
{
    public class Paquete : IMostrar <Paquete>
    {
        public enum EEstado { Ingresado, EnViaje, Entregado }

        public delegate void DelegadoEstado(object sender, EventArgs e);
        public event DelegadoEstado InformarEstado;
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        #region CONSTRUCTORES
        public Paquete(string direccionEntrega, string trakingID)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trakingID;
            this.Estado = EEstado.Ingresado;
        }
        #endregion

        #region PROPIEDADES
        public string DireccionEntrega 
        {
            get { return this.direccionEntrega; }
            set { this.direccionEntrega = value; } 
        }

        public EEstado Estado
        {
            get { return this.estado; }
            set { this.estado = value; }
        }

        public string TrackingID
        {
            get { return this.trackingID; }
            set { this.trackingID = value; }
        }
        #endregion

        #region METODOS
        public void MockCicloDeVida()
        {
            while (this.Estado != EEstado.Entregado)
            {
                this.InformarEstado.Invoke(this, null);
                // Espera 4 segundos.
                System.Threading.Thread.Sleep(4000);
                // Pasa al próximo enumerado.
                int estado = (int)this.Estado + 1;
                // Le asigno el nuevo estado.
                this.Estado = (EEstado)estado;                
            }            
            this.InformarEstado.Invoke(this, null);

            try
            {
                PaqueteDAO.Insertar(this);
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR al insertar el dato en la Base de Datos");
            }            
        }

        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return String.Format("{0} para {1} ", ((Paquete)elemento).TrackingID, ((Paquete)elemento).DireccionEntrega);
        }

        /// <summary>
        /// Retornará la información del paquete
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }
        #endregion

        #region SOBRECARGAS
        /// <summary>
        /// Serán iguales siempre y cuando su Tracking ID sea el mismo.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return p1.TrackingID == p2.TrackingID;
        }

        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
        #endregion
    }
}
