using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitario
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void TrackingIDRepetido()
        {
            Correo correo = new Correo();
            Paquete p1 = new Paquete("Mitre 123", "444");
            Paquete p2 = new Paquete("Alsina 987", "444");
            correo += p1;
            correo += p2;            
        }            

        [TestMethod]
        public void ListaCorreoInstanciada()
        {
            Correo correo = new Correo();
            Assert.IsNotNull(correo.Paquetes);
        }
    }
}
