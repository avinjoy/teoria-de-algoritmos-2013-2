using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Robustez;

namespace Test
{
    [TestFixture]
    public class TestListaEnlazada
    {
        private ListaEnlazada<Vertice<string>> lista;
        [SetUp]
        public void SetUp()
        {
           lista = new ListaEnlazada<Vertice<string>>();
        }

        [Test]
        public void TestVaciaTrue()
        {
            Assert.IsTrue(lista.Vacia());
            
        }

        [Test]
        public void TestVaciaFalse()
        {
            lista.Agregar(new Vertice<string>());
            Assert.IsFalse(lista.Vacia());

        }

        [Test]
        public void TestPrimero()
        {
            lista.Agregar(new Vertice<string>("1"));
            lista.Agregar(new Vertice<string>("2"));
            lista.Agregar(new Vertice<string>("3"));

            Assert.AreEqual("1",lista.Primero().Contenido);

        }

        [Test]
        public void TestUltimo()
        {
            lista.Agregar(new Vertice<string>("1"));
            lista.Agregar(new Vertice<string>("2"));
            lista.Agregar(new Vertice<string>("3"));


            Assert.AreEqual("3", lista.Ultimo().Contenido);

        }

        [Test]
        public void TestIteradorListaHasNextTrue()
        {
            lista.Agregar(new Vertice<string>());
            Assert.IsTrue(lista.Iterador.HasNext());
        }


        [Test]
        public void TestIteradorListaHasNextFalse()
        {
           Assert.IsFalse(lista.Iterador.HasNext());
        }

        [Test]
        public void TestIteradorListaNextNull()
        {
            Assert.AreEqual(null,lista.Iterador.Next());
        }

        [Test]
        public void TestIteradorListaNextUnVertice()
        {
            lista.Agregar(new Vertice<string>("1"));
            Assert.AreEqual(new Vertice<string>("1"), lista.Iterador.Next());
            
        }

        [Test]
        public void TestElementoContieneTrue()
        {
            lista.Agregar(new Vertice<string>("1"));
            Assert.IsTrue(lista.Contiene(new Vertice<string>("1")));

        }

        [Test]
        public void TestElementoContieneFalse()
        {
            lista.Agregar(new Vertice<string>("2"));
            Assert.IsFalse(lista.Contiene(new Vertice<string>("1")));

        }

        [Test]
        public void TestIteradorListaNextDosVertices()
        {
            lista.Agregar(new Vertice<string>("1"));
            lista.Agregar(new Vertice<string>("2"));
            Assert.AreEqual(new Vertice<string>("1"), lista.Iterador.Next());
            Assert.AreEqual(new Vertice<string>("2"), lista.Iterador.Next());
        }

        
        [TearDown]
        public void TearDown()
        {
            lista = new ListaEnlazada<Vertice<string>>();
            
        }
    }

}
