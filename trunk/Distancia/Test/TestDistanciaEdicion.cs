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
        public void TestObtenerDistanciaEdicionEjemplo4()
        {
            char[] palabraInicio = "ANALISIS".ToCharArray();
            char[] palabraFin = "TEORIA".ToCharArray();

            DistanciaEdicion distanciaEdicion = new DistanciaEdicion(palabraInicio, palabraFin, 1, 2, 3, 4, 5, 6);

            Assert.AreEqual(17, distanciaEdicion.ObtenerDistanciaEdicion());
            Assert.AreEqual(palabraFin, distanciaEdicion.Resultado);

            Assert.AreEqual(DistanciaEdicion.IdOperacion.Reemplazar, distanciaEdicion.Operaciones[0].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Reemplazar, distanciaEdicion.Operaciones[1].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Reemplazar, distanciaEdicion.Operaciones[2].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Reemplazar, distanciaEdicion.Operaciones[3].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Copiar, distanciaEdicion.Operaciones[4].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Reemplazar, distanciaEdicion.Operaciones[5].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Terminar, distanciaEdicion.Operaciones[6].Id);
            


        }

        [Test]
        public void TestObtenerDistanciaEdicionEjemplo6()
        {
            char[] palabraInicio = "ARCHIPIELAGO".ToCharArray();
            char[] palabraFin = "VAMPIRO".ToCharArray();

            DistanciaEdicion distanciaEdicion = new DistanciaEdicion(palabraInicio, palabraFin, 1, 2, 3, 4, 5, 6);

            Assert.AreEqual(19, distanciaEdicion.ObtenerDistanciaEdicion());
            Assert.AreEqual(palabraFin, distanciaEdicion.Resultado);

            Assert.AreEqual(DistanciaEdicion.IdOperacion.Reemplazar, distanciaEdicion.Operaciones[0].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Reemplazar, distanciaEdicion.Operaciones[1].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Reemplazar, distanciaEdicion.Operaciones[2].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Reemplazar, distanciaEdicion.Operaciones[3].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Copiar, distanciaEdicion.Operaciones[4].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Reemplazar, distanciaEdicion.Operaciones[5].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Reemplazar, distanciaEdicion.Operaciones[6].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Terminar, distanciaEdicion.Operaciones[7].Id);
            


        }


        [Test]
        public void TestADN()
        {
            char[] palabraInicio = "GATCGGCAT".ToCharArray();
            char[] palabraFin = "CAATGTGAATC".ToCharArray();


            const int copiar = -1;
            const int reemplazar = 1;
            const int borrar = 2;
            const int insertar = 2;
            const int intercambiar = 100;
            const int terminar = 100;

            DistanciaEdicion distanciaEdicion = new DistanciaEdicion(palabraInicio, palabraFin, copiar, reemplazar, intercambiar, borrar, insertar, terminar);

            Assert.AreEqual(3, distanciaEdicion.ObtenerDistanciaEdicion());
            Assert.AreEqual(palabraFin, distanciaEdicion.Resultado);

            Assert.AreEqual(DistanciaEdicion.IdOperacion.Reemplazar, distanciaEdicion.Operaciones[0].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Copiar, distanciaEdicion.Operaciones[1].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Reemplazar, distanciaEdicion.Operaciones[2].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Reemplazar, distanciaEdicion.Operaciones[3].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Copiar, distanciaEdicion.Operaciones[4].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Insertar, distanciaEdicion.Operaciones[5].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Copiar, distanciaEdicion.Operaciones[6].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Reemplazar, distanciaEdicion.Operaciones[7].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Copiar, distanciaEdicion.Operaciones[8].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Copiar, distanciaEdicion.Operaciones[9].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Insertar, distanciaEdicion.Operaciones[10].Id);
            

        }

        [Test]
        public void Test1()
        {

            char[] palabraInicio = "mississipi".ToCharArray();
            char[] palabraFin = "minessossi".ToCharArray();

            const int copiar = 0;
            const int reemplazar = 1;
            const int borrar = 1;
            const int insertar = 1;
            const int intercambiar = 1;
            const int terminar = 1;
            DistanciaEdicion distanciaEdicion = new DistanciaEdicion(palabraInicio, palabraFin,copiar,reemplazar,intercambiar,borrar,insertar,terminar);

            Assert.AreEqual(4, distanciaEdicion.ObtenerDistanciaEdicion());
            Assert.AreEqual(palabraFin, distanciaEdicion.Resultado);

            Assert.AreEqual(DistanciaEdicion.IdOperacion.Copiar, distanciaEdicion.Operaciones[0].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Copiar, distanciaEdicion.Operaciones[1].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Insertar, distanciaEdicion.Operaciones[2].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Insertar, distanciaEdicion.Operaciones[3].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Copiar, distanciaEdicion.Operaciones[4].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Copiar, distanciaEdicion.Operaciones[5].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Reemplazar, distanciaEdicion.Operaciones[6].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Copiar, distanciaEdicion.Operaciones[7].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Copiar, distanciaEdicion.Operaciones[8].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Copiar, distanciaEdicion.Operaciones[9].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Terminar, distanciaEdicion.Operaciones[10].Id);

        }


         [Test]
        public void Test2()
        {

            char[] palabraInicio = "mississipi".ToCharArray();
            char[] palabraFin = "minessossi".ToCharArray();

            const int copiar = 0;
            const int reemplazar = 2;
            const int borrar = 3;
            const int insertar = 3;
            const int intercambiar = 1;
            const int terminar = 1;
            DistanciaEdicion distanciaEdicion = new DistanciaEdicion(palabraInicio, palabraFin,copiar,reemplazar,intercambiar,borrar,insertar,terminar);

            Assert.AreEqual(9, distanciaEdicion.ObtenerDistanciaEdicion());
            Assert.AreEqual(palabraFin, distanciaEdicion.Resultado);

            Assert.AreEqual(DistanciaEdicion.IdOperacion.Copiar, distanciaEdicion.Operaciones[0].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Copiar, distanciaEdicion.Operaciones[1].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Insertar, distanciaEdicion.Operaciones[2].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Insertar, distanciaEdicion.Operaciones[3].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Copiar, distanciaEdicion.Operaciones[4].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Copiar, distanciaEdicion.Operaciones[5].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Reemplazar, distanciaEdicion.Operaciones[6].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Copiar, distanciaEdicion.Operaciones[7].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Copiar, distanciaEdicion.Operaciones[8].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Copiar, distanciaEdicion.Operaciones[9].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Terminar, distanciaEdicion.Operaciones[10].Id);

        }

        [Test]
        public void Test3()
        {

            char[] palabraInicio = "mississipi".ToCharArray();
            char[] palabraFin = "minessossi".ToCharArray();

            const int copiar = 0;
            const int reemplazar = 5;
            const int borrar = 3;
            const int insertar = 3;
            const int intercambiar = 1;
            const int terminar = 1;
            DistanciaEdicion distanciaEdicion = new DistanciaEdicion(palabraInicio, palabraFin, copiar, reemplazar, intercambiar, borrar, insertar, terminar);

            Assert.AreEqual(12, distanciaEdicion.ObtenerDistanciaEdicion());

            Assert.AreEqual(palabraFin, distanciaEdicion.Resultado);

            Assert.AreEqual(DistanciaEdicion.IdOperacion.Copiar, distanciaEdicion.Operaciones[0].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Copiar, distanciaEdicion.Operaciones[1].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Insertar, distanciaEdicion.Operaciones[2].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Insertar, distanciaEdicion.Operaciones[3].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Copiar, distanciaEdicion.Operaciones[4].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Copiar, distanciaEdicion.Operaciones[5].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Reemplazar, distanciaEdicion.Operaciones[6].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Copiar, distanciaEdicion.Operaciones[7].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Copiar, distanciaEdicion.Operaciones[8].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Copiar, distanciaEdicion.Operaciones[9].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Terminar, distanciaEdicion.Operaciones[10].Id);

        }

        [Test]
        public void Test4()
        {

            char[] palabraInicio = "mississipi".ToCharArray();
            char[] palabraFin = "minessossi".ToCharArray();

            const int copiar = -1;
            const int reemplazar = 1;
            const int borrar = 2;
            const int insertar = 2;
            const int intercambiar = 1000;
            const int terminar = 1000;
            DistanciaEdicion distanciaEdicion = new DistanciaEdicion(palabraInicio, palabraFin, copiar, reemplazar, intercambiar, borrar, insertar, terminar);

            Assert.AreEqual(2, distanciaEdicion.ObtenerDistanciaEdicion());
            Assert.AreEqual(palabraFin, distanciaEdicion.Resultado);

            Assert.AreEqual(DistanciaEdicion.IdOperacion.Copiar, distanciaEdicion.Operaciones[0].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Copiar, distanciaEdicion.Operaciones[1].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Insertar, distanciaEdicion.Operaciones[2].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Insertar, distanciaEdicion.Operaciones[3].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Copiar, distanciaEdicion.Operaciones[4].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Copiar, distanciaEdicion.Operaciones[5].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Reemplazar, distanciaEdicion.Operaciones[6].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Copiar, distanciaEdicion.Operaciones[7].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Copiar, distanciaEdicion.Operaciones[8].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Copiar, distanciaEdicion.Operaciones[9].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Borrar, distanciaEdicion.Operaciones[10].Id);
            Assert.AreEqual(DistanciaEdicion.IdOperacion.Borrar, distanciaEdicion.Operaciones[11].Id);

        }




    }
}
