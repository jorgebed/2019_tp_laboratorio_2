using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        #region CONSTRUCTORES
        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }
        #endregion        
        
        #region PROPIEDADES
        public List<Paquete> Paquetes
        {
            get { return this.paquetes; }
            set { this.paquetes = value; }
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Cierra todos los hilos activos
        /// </summary>
        public void FinEntregas()
        {
            // Recorro lista de hilos.
            foreach (Thread item in this.mockPaquetes)
            {
                // Si el hilo está vivo lo cierro.
                if (item.IsAlive)
                {
                    item.Abort();
                }
            }
        }

        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder sb = new StringBuilder();
            if (elementos is Correo)
            {
                foreach (Paquete item in ((Correo)elementos).Paquetes)
                {
                    sb.AppendFormat("{0} para {1} ({2})", item.TrackingID, item.DireccionEntrega, item.Estado.ToString());
                    sb.AppendLine();
                }
            }
            
            return sb.ToString();
        }
        #endregion

        #region SOBRECARGAS
        // Controla si el paquete ya está en la lista, sino lo agrega
        public static Correo operator +(Correo c, Paquete p)
        {
            foreach (Paquete item in c.Paquetes)
            {
                if (item == p)
                    throw new TrackingIdRepetidoException(String.Format("El Tracking ID {0} ya figura en la lista de envios.", p.TrackingID));
            }
            // Agrega el paquete.
            c.paquetes.Add(p);
            // Creo el hilo.
            Thread hilo = new Thread(p.MockCicloDeVida);
            // Agrego el hilo a la lista.
            c.mockPaquetes.Add(hilo);
            // Inicio el hilo.
            hilo.Start();
            return c;
        }
        #endregion        
    }
}
