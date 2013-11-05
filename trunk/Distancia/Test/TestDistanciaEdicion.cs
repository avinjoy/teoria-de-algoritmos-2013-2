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
            const string palabraInicio = "ALGORITMO";
            const string palabraFin = "ALTRUISTA";

            DistanciaEdicion distanciaEdicion = new DistanciaEdicion(palabraInicio, palabraFin, 1, 2, 3, 4, 5, 6);

            
            Assert.AreEqual(41, distanciaEdicion.CalcularDistanciaEdicion());
     
        }

        [Test]
        public void TestObtenerDistanciaEdicionEjemplo2()
        {
            const string palabraInicio = "COSA";
            const string palabraFin = "CASCO";

            DistanciaEdicion distanciaEdicion = new DistanciaEdicion(palabraInicio, palabraFin, 1, 2, 3, 4, 5, 6);


            Assert.AreEqual(24, distanciaEdicion.CalcularDistanciaEdicion());

        }
        [Test]
        public void TestObtenerDistanciaEdicionEjemplo3()
        {
            const string palabraInicio = "CASA";
            const string palabraFin = "ACA";

            DistanciaEdicion distanciaEdicion = new DistanciaEdicion(palabraInicio, palabraFin, 1, 2, 3, 4, 5, 6);


            Assert.AreEqual(21, distanciaEdicion.CalcularDistanciaEdicion());

        }

        [Test]
        public void TestObtenerDistanciaEdicionEjemplo4()
        {
            const string palabraInicio = "JULIAN";
            const string palabraFin = "NICOLAS";

            DistanciaEdicion distanciaEdicion = new DistanciaEdicion(palabraInicio, palabraFin, 1, 2, 3, 4, 5, 6);


            Assert.AreEqual(33, distanciaEdicion.CalcularDistanciaEdicion());

        }

    }
}
