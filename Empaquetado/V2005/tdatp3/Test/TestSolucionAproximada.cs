using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using tdatp3;

namespace Test
{
    [TestFixture]
    public class TestSolucionExacta
    {

        [Test]
        public void TestEncontrarSolucion()
        {

            List<Objeto> objetos = new List<Objeto>();
            objetos.Add(new Objeto(0.4));
            objetos.Add(new Objeto(0.8));
            objetos.Add(new Objeto(0.5));
            objetos.Add(new Objeto(0.1));
            objetos.Add(new Objeto(0.7));
            objetos.Add(new Objeto(0.6));
            objetos.Add(new Objeto(0.1));
            objetos.Add(new Objeto(0.4));
            objetos.Add(new Objeto(0.2));
            objetos.Add(new Objeto(0.2));


            SolucionAproximada solucionAprox = new SolucionAproximada(objetos);

            solucionAprox.EncontrarSolucion();

            const int cantidadEnvases = 6;
            const double tamanioEsperadoEnvase1 = 0.4;
            const double tamanioEsperadoEnvase2 = 0.8;
            const double tamanioEsperadoEnvase3 = 0.6;
            const double tamanioEsperadoEnvase4 = 0.7;
            const double tamanioEsperadoEnvase5 = 0.7;
            const double tamanioEsperadoEnvase6 = 0.8;

            Assert.AreEqual(cantidadEnvases, solucionAprox.Envases.Count);
            Assert.AreEqual(tamanioEsperadoEnvase1, solucionAprox.Envases[1]);
            Assert.AreEqual(tamanioEsperadoEnvase2, solucionAprox.Envases[2]);
            Assert.AreEqual(tamanioEsperadoEnvase3, solucionAprox.Envases[3]);
            Assert.AreEqual(tamanioEsperadoEnvase4, solucionAprox.Envases[4]);
            Assert.AreEqual(tamanioEsperadoEnvase5, solucionAprox.Envases[5]);
            Assert.AreEqual(tamanioEsperadoEnvase6, solucionAprox.Envases[6]);

        }
    }
}
