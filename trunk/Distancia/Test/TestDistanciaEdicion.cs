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
        public void TestObtenerDistanciaEdicionUno()
        {
            String alicia = "ALICIA";
            String escobas = "ESCOBAS";

            DistanciaEdicion distanciaEdicion = new DistanciaEdicion(alicia, escobas, 1, 2, 3, 4, 5, 6);
            Assert.AreEqual(21, distanciaEdicion.calcularDistanciaEdicion());

        }

    }
}
