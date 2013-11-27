using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            decimal[] objetos = new decimal[10];
            objetos[0] = 0.4m;
            objetos[1] = 0.8m;
            objetos[2] = 0.5m;
            objetos[3] = 0.1m;
            objetos[4] = 0.7m;
            objetos[5] = 0.6m;
            objetos[6] = 0.1m;
            objetos[7] = 0.4m;
            objetos[8] = 0.2m;
            objetos[9] = 0.2m;

            SolucionAproximada solucionAprox = new SolucionAproximada(objetos);

            solucionAprox.EncontrarSolucion();

            const int cantidadEnvases = 6;
            const decimal tamanioEsperadoEnvase1 = 0.4m;
            const decimal tamanioEsperadoEnvase2 = 0.8m;
            const decimal tamanioEsperadoEnvase3 = 0.6m;
            const decimal tamanioEsperadoEnvase4 = 0.7m;
            const decimal tamanioEsperadoEnvase5 = 0.7m;
            const decimal tamanioEsperadoEnvase6 = 0.8m;

            Assert.AreEqual(cantidadEnvases, solucionAprox.Envases.Count);
            Assert.AreEqual(tamanioEsperadoEnvase1, solucionAprox.Envases[1]);
            Assert.AreEqual(tamanioEsperadoEnvase2, solucionAprox.Envases[2]);
            Assert.AreEqual(tamanioEsperadoEnvase3, solucionAprox.Envases[3]);
            Assert.AreEqual(tamanioEsperadoEnvase4, solucionAprox.Envases[4]);
            Assert.AreEqual(tamanioEsperadoEnvase5, solucionAprox.Envases[5]);
            Assert.AreEqual(tamanioEsperadoEnvase6, solucionAprox.Envases[6]);

        }

        [Test]
        public void TestEncontrarSolucion10Items()
        {
            decimal[] objetos = new decimal[10];
            objetos[0] = 0.9m;
            objetos[1] = 0.3m;
            objetos[2] = 0.5m;
            objetos[3] = 0.5m;
            objetos[4] = 0.5m;
            objetos[5] = 0.6m;
            objetos[6] = 1.0m;
            objetos[7] = 0.6m;
            objetos[8] = 0.4m;
            objetos[9] = 0.7m;

            SolucionAproximada solucionAprox = new SolucionAproximada(objetos);

            solucionAprox.EncontrarSolucion();

            const int cantidadEnvases = 7;
            const decimal tamanioEsperadoEnvase1 = 0.9m;
            const decimal tamanioEsperadoEnvase2 = 0.8m;
            const decimal tamanioEsperadoEnvase3 = 1.0m;
            const decimal tamanioEsperadoEnvase4 = 0.6m;
            const decimal tamanioEsperadoEnvase5 = 1.0m;
            const decimal tamanioEsperadoEnvase6 = 1.0m;
            const decimal tamanioEsperadoEnvase7 = 0.7m;

            Assert.AreEqual(cantidadEnvases, solucionAprox.Envases.Count);
            Assert.AreEqual(tamanioEsperadoEnvase1, solucionAprox.Envases[1]);
            Assert.AreEqual(tamanioEsperadoEnvase2, solucionAprox.Envases[2]);
            Assert.AreEqual(tamanioEsperadoEnvase3, solucionAprox.Envases[3]);
            Assert.AreEqual(tamanioEsperadoEnvase4, solucionAprox.Envases[4]);
            Assert.AreEqual(tamanioEsperadoEnvase5, solucionAprox.Envases[5]);
            Assert.AreEqual(tamanioEsperadoEnvase6, solucionAprox.Envases[6]);
            Assert.AreEqual(tamanioEsperadoEnvase7, solucionAprox.Envases[7]);


        }


        [Test]
        public void TestEncontrarSolucion11Items()
        {
            decimal[] objetos = new decimal[11];
            objetos[0] = 0.6m;
            objetos[1] = 0.9m;
            objetos[2] = 0.5m;
            objetos[3] = 0.9m;
            objetos[4] = 0.1m;
            objetos[5] = 0.4m;
            objetos[6] = 0.7m;
            objetos[7] = 0.9m;
            objetos[8] = 0.6m;
            objetos[9] = 0.2m;
            objetos[10] = 0.3m;

            SolucionAproximada solucionAprox = new SolucionAproximada(objetos);

            solucionAprox.EncontrarSolucion();

            const int cantidadEnvases = 9;
            const decimal tamanioEsperadoEnvase1 = 0.6m;
            const decimal tamanioEsperadoEnvase2 = 0.9m;
            const decimal tamanioEsperadoEnvase3 = 0.5m;
            const decimal tamanioEsperadoEnvase4 = 1.0m;
            const decimal tamanioEsperadoEnvase5 = 0.4m;
            const decimal tamanioEsperadoEnvase6 = 0.7m;
            const decimal tamanioEsperadoEnvase7 = 0.9m;
            const decimal tamanioEsperadoEnvase8 = 0.8m;
            const decimal tamanioEsperadoEnvase9 = 0.3m;

            Assert.AreEqual(cantidadEnvases, solucionAprox.Envases.Count);
            Assert.AreEqual(tamanioEsperadoEnvase1, solucionAprox.Envases[1]);
            Assert.AreEqual(tamanioEsperadoEnvase2, solucionAprox.Envases[2]);
            Assert.AreEqual(tamanioEsperadoEnvase3, solucionAprox.Envases[3]);
            Assert.AreEqual(tamanioEsperadoEnvase4, solucionAprox.Envases[4]);
            Assert.AreEqual(tamanioEsperadoEnvase5, solucionAprox.Envases[5]);
            Assert.AreEqual(tamanioEsperadoEnvase6, solucionAprox.Envases[6]);
            Assert.AreEqual(tamanioEsperadoEnvase7, solucionAprox.Envases[7]);
            Assert.AreEqual(tamanioEsperadoEnvase8, solucionAprox.Envases[8]);
            Assert.AreEqual(tamanioEsperadoEnvase9, solucionAprox.Envases[9]);


        }

        [Test]
        public void TestEncontrarSolucion12Items()
        {
            decimal[] objetos = new decimal[12];
            objetos[0] = 0.8m;
            objetos[1] = 0.4m;
            objetos[2] = 0.5m;
            objetos[3] = 0.1m;
            objetos[4] = 0.2m;
            objetos[5] = 0.9m;
            objetos[6] = 0.7m;
            objetos[7] = 0.1m;
            objetos[8] = 0.6m;
            objetos[9] = 0.7m;
            objetos[10] = 0.7m;
            objetos[11] = 0.8m;

            SolucionAproximada solucionAprox = new SolucionAproximada(objetos);

            solucionAprox.EncontrarSolucion();

            const int cantidadEnvases = 9;
            const decimal tamanioEsperadoEnvase1 = 0.8m;
            const decimal tamanioEsperadoEnvase2 = 1.0m;
            const decimal tamanioEsperadoEnvase3 = 0.2m;
            const decimal tamanioEsperadoEnvase4 = 0.9m;
            const decimal tamanioEsperadoEnvase5 = 0.8m;
            const decimal tamanioEsperadoEnvase6 = 0.6m;
            const decimal tamanioEsperadoEnvase7 = 0.7m;
            const decimal tamanioEsperadoEnvase8 = 0.7m;
            const decimal tamanioEsperadoEnvase9 = 0.8m;

            Assert.AreEqual(cantidadEnvases, solucionAprox.Envases.Count);
            Assert.AreEqual(tamanioEsperadoEnvase1, solucionAprox.Envases[1]);
            Assert.AreEqual(tamanioEsperadoEnvase2, solucionAprox.Envases[2]);
            Assert.AreEqual(tamanioEsperadoEnvase3, solucionAprox.Envases[3]);
            Assert.AreEqual(tamanioEsperadoEnvase4, solucionAprox.Envases[4]);
            Assert.AreEqual(tamanioEsperadoEnvase5, solucionAprox.Envases[5]);
            Assert.AreEqual(tamanioEsperadoEnvase6, solucionAprox.Envases[6]);
            Assert.AreEqual(tamanioEsperadoEnvase7, solucionAprox.Envases[7]);
            Assert.AreEqual(tamanioEsperadoEnvase8, solucionAprox.Envases[8]);
            Assert.AreEqual(tamanioEsperadoEnvase9, solucionAprox.Envases[9]);


        }


        [Test]
        public void TestEncontrarSolucion13Items()
        {
            decimal[] objetos = new decimal[13];
            objetos[0] = 0.8m;
            objetos[1] = 0.2m;
            objetos[2] = 0.6m;
            objetos[3] = 0.1m;
            objetos[4] = 0.6m;
            objetos[5] = 0.2m;
            objetos[6] = 0.6m;
            objetos[7] = 0.8m;
            objetos[8] = 0.3m;
            objetos[9] = 0.8m;
            objetos[10] = 0.9m;
            objetos[11] = 0.6m;
            objetos[12] = 1.0m;

            SolucionAproximada solucionAprox = new SolucionAproximada(objetos);

            solucionAprox.EncontrarSolucion();

            const int cantidadEnvases = 10;
            const decimal tamanioEsperadoEnvase1 = 1.0m;
            const decimal tamanioEsperadoEnvase2 = 0.7m;
            const decimal tamanioEsperadoEnvase3 = 0.8m;
            const decimal tamanioEsperadoEnvase4 = 0.6m;
            const decimal tamanioEsperadoEnvase5 = 0.8m;
            const decimal tamanioEsperadoEnvase6 = 0.3m;
            const decimal tamanioEsperadoEnvase7 = 0.8m;
            const decimal tamanioEsperadoEnvase8 = 0.9m;
            const decimal tamanioEsperadoEnvase9 = 0.6m;
            const decimal tamanioEsperadoEnvase10 = 1.0m;

            Assert.AreEqual(cantidadEnvases, solucionAprox.Envases.Count);
            Assert.AreEqual(tamanioEsperadoEnvase1, solucionAprox.Envases[1]);
            Assert.AreEqual(tamanioEsperadoEnvase2, solucionAprox.Envases[2]);
            Assert.AreEqual(tamanioEsperadoEnvase3, solucionAprox.Envases[3]);
            Assert.AreEqual(tamanioEsperadoEnvase4, solucionAprox.Envases[4]);
            Assert.AreEqual(tamanioEsperadoEnvase5, solucionAprox.Envases[5]);
            Assert.AreEqual(tamanioEsperadoEnvase6, solucionAprox.Envases[6]);
            Assert.AreEqual(tamanioEsperadoEnvase7, solucionAprox.Envases[7]);
            Assert.AreEqual(tamanioEsperadoEnvase8, solucionAprox.Envases[8]);
            Assert.AreEqual(tamanioEsperadoEnvase9, solucionAprox.Envases[9]);
            Assert.AreEqual(tamanioEsperadoEnvase10, solucionAprox.Envases[10]);


        }

        [Test]
        public void TestEncontrarSolucion14Items()
        {
            decimal[] objetos = new decimal[14];
            objetos[0] = 0.6m;
            objetos[1] = 0.5m;
            objetos[2] = 0.5m;
            objetos[3] = 0.6m;
            objetos[4] = 0.8m;
            objetos[5] = 0.7m;
            objetos[6] = 0.9m;
            objetos[7] = 0.7m;
            objetos[8] = 0.6m;
            objetos[9] = 0.8m;
            objetos[10] = 0.9m;
            objetos[11] = 0.2m;
            objetos[12] = 0.7m;
            objetos[13] = 0.8m;
            SolucionAproximada solucionAprox = new SolucionAproximada(objetos);

            solucionAprox.EncontrarSolucion();

            const int cantidadEnvases = 12;
            const decimal tamanioEsperadoEnvase1 = 0.6m;
            const decimal tamanioEsperadoEnvase2 = 1.0m;
            const decimal tamanioEsperadoEnvase3 = 0.6m;
            const decimal tamanioEsperadoEnvase4 = 0.8m;
            const decimal tamanioEsperadoEnvase5 = 0.7m;
            const decimal tamanioEsperadoEnvase6 = 0.9m;
            const decimal tamanioEsperadoEnvase7 = 0.7m;
            const decimal tamanioEsperadoEnvase8 = 0.6m;
            const decimal tamanioEsperadoEnvase9 = 0.8m;
            const decimal tamanioEsperadoEnvase10 = 0.9m;
            const decimal tamanioEsperadoEnvase11 = 0.9m;
            const decimal tamanioEsperadoEnvase12 = 0.8m;


            Assert.AreEqual(cantidadEnvases, solucionAprox.Envases.Count);
            Assert.AreEqual(tamanioEsperadoEnvase1, solucionAprox.Envases[1]);
            Assert.AreEqual(tamanioEsperadoEnvase2, solucionAprox.Envases[2]);
            Assert.AreEqual(tamanioEsperadoEnvase3, solucionAprox.Envases[3]);
            Assert.AreEqual(tamanioEsperadoEnvase4, solucionAprox.Envases[4]);
            Assert.AreEqual(tamanioEsperadoEnvase5, solucionAprox.Envases[5]);
            Assert.AreEqual(tamanioEsperadoEnvase6, solucionAprox.Envases[6]);
            Assert.AreEqual(tamanioEsperadoEnvase7, solucionAprox.Envases[7]);
            Assert.AreEqual(tamanioEsperadoEnvase8, solucionAprox.Envases[8]);
            Assert.AreEqual(tamanioEsperadoEnvase9, solucionAprox.Envases[9]);
            Assert.AreEqual(tamanioEsperadoEnvase10, solucionAprox.Envases[10]);
            Assert.AreEqual(tamanioEsperadoEnvase11, solucionAprox.Envases[11]);
            Assert.AreEqual(tamanioEsperadoEnvase12, solucionAprox.Envases[12]);


        }


        [Test]
        public void TestEncontrarSolucion28Items()
        {
            decimal[] objetos = new decimal[28];
            objetos[0] = 0.6m;
            objetos[1] = 0.5m;
            objetos[2] = 0.5m;
            objetos[3] = 0.6m;
            objetos[4] = 0.8m;
            objetos[5] = 0.7m;
            objetos[6] = 0.9m;
            objetos[7] = 0.7m;
            objetos[8] = 0.6m;
            objetos[9] = 0.8m;
            objetos[10] = 0.9m;
            objetos[11] = 0.2m;
            objetos[12] = 0.7m;
            objetos[13] = 0.8m;
            objetos[14] = 0.6m;
            objetos[15] = 0.5m;
            objetos[16] = 0.5m;
            objetos[17] = 0.6m;
            objetos[18] = 0.8m;
            objetos[19] = 0.7m;
            objetos[20] = 0.9m;
            objetos[21] = 0.7m;
            objetos[22] = 0.6m;
            objetos[23] = 0.8m;
            objetos[24] = 0.9m;
            objetos[25] = 0.2m;
            objetos[26] = 0.7m;
            objetos[27] = 0.8m;
            SolucionAproximada solucionAprox = new SolucionAproximada(objetos);

            solucionAprox.EncontrarSolucion();



        }


        private void TomarTiempo(int tamanio)
        {
            decimal tiempoPromedio = 0;
            for (int i = 0; i < 8; i++)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                SolucionAproximada solucionAprox = new SolucionAproximada(GetDatos(tamanio));

                solucionAprox.EncontrarSolucion();

                Console.WriteLine(string.Format("Tiempo {0}:{1}", i + 1, stopwatch.Elapsed.TotalMilliseconds));

                stopwatch.Stop();

                tiempoPromedio += (decimal)stopwatch.Elapsed.TotalMilliseconds;
            }
            Console.WriteLine(string.Format("Tiempo Promedio:{0}", tiempoPromedio / 8));
        }

        private decimal[] GetDatos(int tamanio)
        {
            decimal[] objetos = new decimal[tamanio];
            Random random = new Random();
            for (int i = 0; i < tamanio; i++)
            {
                objetos[i] = (decimal)random.NextDouble();
            }

            return objetos;

        }
        [Test]
        public void TestTiempoEncontrarSolucion10Items()
        {
            TomarTiempo(10);
        }


        [Test]
        public void TestTiempoEncontrarSolucion11Items()
        {
            TomarTiempo(11);

        }

        [Test]
        public void TestTiempoEncontrarSolucion12Items()
        {
            TomarTiempo(12);
        }


        [Test]
        public void TestTiempoEncontrarSolucion13Items()
        {
            TomarTiempo(13);
        }

        [Test]
        public void TestTiempoEncontrarSolucion14Items()
        {
            TomarTiempo(14);

        }
    }
}
