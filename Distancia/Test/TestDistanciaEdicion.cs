using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using TDATP2;

namespace Test
{
    [TestFixture]
    public class TestDistanciaEdicionEdicion
    {

        [Test]
        public void TestObtenerDistanciaEdicionEjemplo()
        {
            char[] palabraInicio = "ALGORITMO".ToCharArray();
            char[] palabraFin = "ALTRUISTA".ToCharArray();

            DistanciaEdicion distanciaEdicion = new DistanciaEdicion(palabraInicio, palabraFin, 1, 2, 3, 4, 5, 6);

            Assert.AreEqual(15, distanciaEdicion.ObtenerDistanciaEdicion());
            Assert.AreEqual(palabraFin, distanciaEdicion.Resultado);

            Assert.AreEqual(DistanciaEdicion.IdOperacion.Copiar, distanciaEdicion.Operaciones[0].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Copiar, distanciaEdicion.Operaciones[1].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Reemplazar, distanciaEdicion.Operaciones[2].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Reemplazar, distanciaEdicion.Operaciones[3].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Reemplazar, distanciaEdicion.Operaciones[4].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Copiar, distanciaEdicion.Operaciones[5].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Reemplazar, distanciaEdicion.Operaciones[6].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Reemplazar, distanciaEdicion.Operaciones[7].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Reemplazar, distanciaEdicion.Operaciones[8].Id);

        }

        [Test]
        public void TestObtenerDistanciaEdicionEjemplo2()
        {
            char[] palabraInicio = "COSA".ToCharArray();
            char[] palabraFin = "CASCO".ToCharArray();

            DistanciaEdicion distanciaEdicion = new DistanciaEdicion(palabraInicio, palabraFin, 1, 2, 3, 4, 5, 6);

            Assert.AreEqual(11, distanciaEdicion.ObtenerDistanciaEdicion());
            Assert.AreEqual(palabraFin, distanciaEdicion.Resultado);

            Assert.AreEqual(DistanciaEdicion.IdOperacion.Copiar, distanciaEdicion.Operaciones[0].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Reemplazar, distanciaEdicion.Operaciones[1].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Copiar, distanciaEdicion.Operaciones[2].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Reemplazar, distanciaEdicion.Operaciones[3].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Insertar, distanciaEdicion.Operaciones[4].Id);

        }
        [Test]
        public void TestObtenerDistanciaEdicionEjemplo3()
        {
            char[] palabraInicio = "CASA".ToCharArray();
            char[] palabraFin = "ACA".ToCharArray();

            DistanciaEdicion distanciaEdicion = new DistanciaEdicion(palabraInicio, palabraFin, 1, 2, 3, 4, 5, 6);


            Assert.AreEqual(8, distanciaEdicion.ObtenerDistanciaEdicion());
            Assert.AreEqual(palabraFin, distanciaEdicion.Resultado);

            Assert.AreEqual(DistanciaEdicion.IdOperacion.Intercambiar, distanciaEdicion.Operaciones[0].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Borrar, distanciaEdicion.Operaciones[1].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Copiar, distanciaEdicion.Operaciones[2].Id);

        }

        [Test]
        public void TestObtenerDistanciaEdicionEjemplo4()
        {
            char[] palabraInicio = "JULIAN".ToCharArray();
            char[] palabraFin = "NICOLAS".ToCharArray();

            DistanciaEdicion distanciaEdicion = new DistanciaEdicion(palabraInicio, palabraFin, 1, 2, 3, 4, 5, 6);

            Assert.AreEqual(16, distanciaEdicion.ObtenerDistanciaEdicion());
            Assert.AreEqual(palabraFin, distanciaEdicion.Resultado);

            Assert.AreEqual(DistanciaEdicion.IdOperacion.Reemplazar, distanciaEdicion.Operaciones[0].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Reemplazar, distanciaEdicion.Operaciones[1].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Reemplazar, distanciaEdicion.Operaciones[2].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Reemplazar, distanciaEdicion.Operaciones[3].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Insertar, distanciaEdicion.Operaciones[4].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Copiar, distanciaEdicion.Operaciones[5].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Reemplazar, distanciaEdicion.Operaciones[6].Id);


        }

        [Test]
        public void TestObtenerDistanciaEdicionEjemplo5()
        {
            char[] palabraInicio = "ANALISIS".ToCharArray();
            char[] palabraFin = "TEORIA".ToCharArray();

            DistanciaEdicion distanciaEdicion = new DistanciaEdicion(palabraInicio, palabraFin, 1, 2, 3, 4, 5, 6);

            Assert.AreEqual(19, distanciaEdicion.ObtenerDistanciaEdicion());
            Assert.AreEqual(palabraFin, distanciaEdicion.Resultado);

            Assert.AreEqual(DistanciaEdicion.IdOperacion.Reemplazar, distanciaEdicion.Operaciones[0].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Reemplazar, distanciaEdicion.Operaciones[1].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Reemplazar, distanciaEdicion.Operaciones[2].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Reemplazar, distanciaEdicion.Operaciones[3].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Copiar, distanciaEdicion.Operaciones[4].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Reemplazar, distanciaEdicion.Operaciones[5].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Borrar, distanciaEdicion.Operaciones[6].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Borrar, distanciaEdicion.Operaciones[7].Id);


        }

        [Test]
        public void TestObtenerDistanciaEdicionEjemplo6()
        {
            char[] palabraInicio = "ARCHIPIELAGO".ToCharArray();
            char[] palabraFin = "VAMPIRO".ToCharArray();

            DistanciaEdicion distanciaEdicion = new DistanciaEdicion(palabraInicio, palabraFin, 1, 2, 3, 4, 5, 6);

            Assert.AreEqual(31, distanciaEdicion.ObtenerDistanciaEdicion());
            Assert.AreEqual(palabraFin, distanciaEdicion.Resultado);

            Assert.AreEqual(DistanciaEdicion.IdOperacion.Reemplazar, distanciaEdicion.Operaciones[0].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Reemplazar, distanciaEdicion.Operaciones[1].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Reemplazar, distanciaEdicion.Operaciones[2].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Borrar, distanciaEdicion.Operaciones[3].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Borrar, distanciaEdicion.Operaciones[4].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Copiar, distanciaEdicion.Operaciones[5].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Copiar, distanciaEdicion.Operaciones[6].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Reemplazar, distanciaEdicion.Operaciones[7].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Borrar, distanciaEdicion.Operaciones[8].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Borrar, distanciaEdicion.Operaciones[9].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Borrar, distanciaEdicion.Operaciones[10].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Copiar, distanciaEdicion.Operaciones[11].Id);


        }


        [Test]
        public void TestADN()
        {
            char[] palabraInicio = "GATCGGCAT".ToCharArray();
            char[] palabraFin = "CAATGTGAATC".ToCharArray();

            DistanciaEdicion distanciaEdicion = new DistanciaEdicion(palabraInicio, palabraFin, -5, 10, 500, 10, 10, 500);

            Assert.AreEqual(30, distanciaEdicion.ObtenerDistanciaEdicion());
            Assert.AreEqual(palabraFin, distanciaEdicion.Resultado);

            Assert.AreEqual(DistanciaEdicion.IdOperacion.Reemplazar, distanciaEdicion.Operaciones[0].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Copiar, distanciaEdicion.Operaciones[1].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Insertar, distanciaEdicion.Operaciones[2].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Copiar, distanciaEdicion.Operaciones[3].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Borrar, distanciaEdicion.Operaciones[4].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Copiar, distanciaEdicion.Operaciones[5].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Insertar, distanciaEdicion.Operaciones[6].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Copiar, distanciaEdicion.Operaciones[7].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Reemplazar, distanciaEdicion.Operaciones[8].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Copiar, distanciaEdicion.Operaciones[9].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Copiar, distanciaEdicion.Operaciones[10].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Insertar, distanciaEdicion.Operaciones[11].Id);

        }
    }
}
