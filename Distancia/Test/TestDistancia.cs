using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using TDATP2;

namespace Test
{
    [TestFixture]
    public class TestDistancia
    {
        private Distancia _distancia;
        private char[] _cadenaX;
        private char[] _cadenaY;
        private char[] _cadenaZ;
        private int _i;
        private int _j;

        
        [SetUp]
        public void SetUp()
        {
            _cadenaX = new char[] { 'A' };
            _cadenaY = new char[] { 'B' };
            _cadenaZ = new char[_cadenaY.Length];
            _distancia = new Distancia(_cadenaX, _cadenaY, _cadenaZ, 1, 2, 3, 4, 5, 6);
            _i = 0;
            _j = 0;
        }
        [Test]
        public void TestCopiar()
        {
        
            _distancia.Copiar(ref _i, ref _j);
            Assert.AreEqual('A',_cadenaZ[_j-1]);
            Assert.AreEqual(1,_i);
            Assert.AreEqual(1, _j);
            Assert.AreEqual(1, _distancia.DistanciaCalculada);
        }

        [Test]
        public void TestReemplazar()
        {
            _distancia.Reemplazar(ref _i, ref _j);
            Assert.AreEqual('B', _cadenaZ[_j-1]);
            Assert.AreEqual(1, _i);
            Assert.AreEqual(1, _j);
            Assert.AreEqual(2, _distancia.DistanciaCalculada);
        }

        [Test]
        public void TestBorrar()
        {
            _distancia.Borrar(ref _i, ref _j);
            Assert.AreEqual(1, _i);
            Assert.AreEqual(0, _j);
            Assert.AreEqual(3, _distancia.DistanciaCalculada);
        }

        [Test]
        public void TestInsertar()
        {
            _distancia.Insertar(ref _i, ref _j);
            Assert.AreEqual('B', _cadenaZ[_j-1]);
            Assert.AreEqual(0, _i);
            Assert.AreEqual(1, _j);
            Assert.AreEqual(4, _distancia.DistanciaCalculada);
        }

        [Test]
        public void TestIntercambiar()
        {
            _cadenaX = new char[] { 'A','C' };
            _cadenaY = new char[] { 'C','A' };
            _cadenaZ = new char[_cadenaY.Length];
            _distancia = new Distancia(_cadenaX, _cadenaY, _cadenaZ, 1, 2, 3, 4, 5, 6);

            _distancia.Intercambiar(ref _i, ref _j);
            Assert.AreEqual('C', _cadenaZ[_j-2]);
            Assert.AreEqual('A', _cadenaZ[_j-1]);
            Assert.AreEqual(2, _i);
            Assert.AreEqual(2, _j);
            Assert.AreEqual(5, _distancia.DistanciaCalculada);
        }

        [Test]
        public void TestTerminar(){
            
            _distancia.Terminar(ref _i);
            Assert.AreEqual(_cadenaX.Length+1, _i);
            Assert.AreEqual(0, _j);
            Assert.AreEqual(6, _distancia.DistanciaCalculada);
        }

        [Test]
        public void TestObtenerDistanciaUno()
        {
             _cadenaX = new char[] { 'A', 'L', 'I', 'C', 'I', 'A' };
             _cadenaY = new char[] { 'E', 'S', 'C', 'O', 'B', 'A', 'S' };
            _cadenaZ = new char[_cadenaY.Length];

            _distancia = new Distancia(_cadenaX, _cadenaY, _cadenaZ, 1, 2, 3, 4, 5, 6);
            Assert.AreEqual(21,_distancia.ObtenerDistancia());

        }

        [Test]
        public void TestObtenerDistanciaDos()
        {
            _cadenaX = new char[] { 'J', 'U', 'L', 'I', 'A', 'N', };
            _cadenaY = new char[] { 'N', 'I', 'C', 'O', 'L', 'A', 'S' };
            _cadenaZ = new char[_cadenaY.Length];

            _distancia = new Distancia(_cadenaX, _cadenaY, _cadenaZ, 1, 2, 3, 4, 5, 6);
            Assert.AreEqual(22, _distancia.ObtenerDistancia());

        }


        [Test]
        public void TestObtenerDistanciaTres()
        {
            _cadenaX = new char[] { 'G', 'A', 'T', 'O', 'S' };
            _cadenaY = new char[] { 'P', 'E', 'R', 'R', 'O', 'S' }; _cadenaZ = new char[_cadenaY.Length];
            _cadenaZ = new char[_cadenaY.Length];
            _distancia = new Distancia(_cadenaX, _cadenaY, _cadenaZ, 1, 2, 3, 4, 5, 6);
            Assert.AreEqual(20, _distancia.ObtenerDistancia());

        }


        [Test]
        public void TestObtenerDistanciaCuatro()
        {
            _cadenaX = new char[] { 'A', 'L', 'G', 'O', 'R', 'I', 'T', 'M', 'O' };
            _cadenaY = new char[] { 'A', 'L', 'T', 'R', 'U', 'I', 'S', 'T', 'A' };
            _cadenaZ = new char[_cadenaY.Length];
            _distancia = new Distancia(_cadenaX, _cadenaY, _cadenaZ, 1, 2, 3, 4, 5, 6);
            Assert.AreEqual(15, _distancia.ObtenerDistancia());

        }

        [Test]
        public void TestObtenerDistanciaIntercambiar()
        {
            _cadenaX = new char[] { 'A', 'C' };
            _cadenaY = new char[] { 'C', 'A' };
            _cadenaZ = new char[_cadenaY.Length];
            _distancia = new Distancia(_cadenaX, _cadenaY, _cadenaZ, 1, 2, 3, 4, 5, 6);

            _distancia.ObtenerDistancia();
            Assert.AreEqual('C', _cadenaZ[0]);
            Assert.AreEqual('A', _cadenaZ[1]);
            Assert.AreEqual(5, _distancia.DistanciaCalculada);
        }
    }
}
