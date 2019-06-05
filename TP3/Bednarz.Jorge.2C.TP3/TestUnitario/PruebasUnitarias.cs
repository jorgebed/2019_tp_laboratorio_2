using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClasesInstanciables;
using EntidadesAbstractas;
using Excepciones;

namespace TestUnitario
{
    [TestClass]
    public class PruebasUnitarias
    {
        [TestMethod]
        // Validamos número erróneo de documento para la Nacionalidad Argentino.
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void NacionalidadInvalidaArgentino()
        {
            Alumno a1 = new Alumno(1020, "Alberto", "Alonso", "90000789", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);
        }

        [TestMethod]
        // Validamos número erróneo de documento para la Nacionalidad Extranjero.
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void NacionalidadInvalidaExtranjero()
        {
            Alumno a1 = new Alumno(1020, "Alberto", "Alonso", "20557789", Persona.ENacionalidad.Extranjero, Universidad.EClases.Programacion);
        }

        [TestMethod]
        // Validamos número de documento cuyo formato es erróneo.
        [ExpectedException(typeof(DniInvalidoException))]
        public void DniInvalidoCaracteresNoPermitidos()
        {
            Alumno a1 = new Alumno(1020, "Alberto", "Alonso", "205rt43778", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);
        }

        [TestMethod]
        // Validamos que el número de documento se encuentre en el rango establecido.
        [ExpectedException(typeof(DniInvalidoException))]
        public void DniInvalidoNumeroIncorrecto()
        {
            Alumno a2 = new Alumno(1020, "Gabriel", "Perez", "205222222243778", Persona.ENacionalidad.Extranjero, Universidad.EClases.SPD);
        }

        [TestMethod]
        // Validamos el ingreso de un Alumno repetido.
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void AlumnoRepetido()
        {
            Universidad u = new Universidad();
            Alumno a1 = new Alumno(1020, "Gabriel", "Perez", "25547852", Persona.ENacionalidad.Argentino, Universidad.EClases.SPD);
            Alumno a2 = new Alumno(1020, "Gabriel", "Perez", "25547852", Persona.ENacionalidad.Argentino, Universidad.EClases.SPD);
            u += a1;
            u += a2;
        }

        [TestMethod]
        // Validamos un Alumno puede tomar esa clase.
        public void AlumnnoClase()
        {
            Profesor p = new Profesor(2, "Roberto", "Juarez", "32234456", EntidadesAbstractas.Persona.ENacionalidad.Argentino);
            Jornada j = new Jornada(Universidad.EClases.SPD, p);
            Alumno a1 = new Alumno(1020, "Martín", "López", "75587863", Persona.ENacionalidad.Argentino, Universidad.EClases.SPD);
            //Alumno a2 = new Alumno(1020, "Gabriel", "Perez", "25547852", Persona.ENacionalidad.Argentino, Universidad.EClases.SPD);
            j += a1;
            Assert.AreEqual(true, j == a1);
        }

        [TestMethod]
        // Validamos un Alumno NO puede tomar esa clase.
        public void AlumnnoNoClase()
        {
            Profesor p = new Profesor(2, "Roberto", "Juarez", "32234456", EntidadesAbstractas.Persona.ENacionalidad.Argentino);
            Jornada j = new Jornada(Universidad.EClases.SPD, p);
            Alumno a1 = new Alumno(1020, "Martín", "López", "75587863", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            j += a1;
            Assert.AreEqual(false, j == a1);
        }

        [TestMethod]
        // Validamos que se instancien la lista de Alumnos en el contructor de Universidad.
        public void AlumnnoNoNull()
        {
            Universidad u = new Universidad();
            Assert.IsNotNull(u.Alumnos);
        }

        [TestMethod]
        // Validamos que se instancien la lista de Jornadas en el contructor de Universidad.
        public void JornadaNoNull()
        {
            Universidad u = new Universidad();
            Assert.IsNotNull(u.Jornadas);
        }

        [TestMethod]
        // Validamos que se instancien la lista de Profesores en el contructor de Universidad.
        public void ProfesorNoNull()
        {
            Universidad u = new Universidad();
            Assert.IsNotNull(u.Instructores);
        }
    }
}
