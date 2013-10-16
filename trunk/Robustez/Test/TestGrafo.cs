using NUnit.Framework;
using Robustez;

namespace Test
{
    [TestFixture]
    public class TestGrafo
    {
        private Grafo<Nodo> _grafo;

        [SetUp]
        public void SetUp()
        {
            _grafo = new Grafo<Nodo>();
        }


        [Test]
        public void TestEncontrarCiclos()
        {
            
            Vertice<Nodo> verticeA = new Vertice<Nodo>(new Nodo("A"));
            
            Vertice<Nodo> verticeB = new Vertice<Nodo>(new Nodo("B"));
            Vertice<Nodo> verticeC = new Vertice<Nodo>(new Nodo("C"));
            Vertice<Nodo> verticeD = new Vertice<Nodo>(new Nodo("D"));
            Vertice<Nodo> verticeE = new Vertice<Nodo>(new Nodo("E"));
            Vertice<Nodo> verticeF = new Vertice<Nodo>(new Nodo("F"));
            Vertice<Nodo> verticeG = new Vertice<Nodo>(new Nodo("G"));
            Vertice<Nodo> verticeH = new Vertice<Nodo>(new Nodo("H"));


            //A: B, C
            verticeA.Adyacentes.Agregar(verticeB);
            verticeA.Adyacentes.Agregar(verticeC);
            //B: A, D
            verticeB.Adyacentes.Agregar(verticeA);
            verticeB.Adyacentes.Agregar(verticeD);
            //C: A, D
            verticeC.Adyacentes.Agregar(verticeA);
            verticeC.Adyacentes.Agregar(verticeD);
            //D: B, C, E
            verticeD.Adyacentes.Agregar(verticeB);
            verticeD.Adyacentes.Agregar(verticeC);
            verticeD.Adyacentes.Agregar(verticeE);
            //E: D, F, G
            verticeE.Adyacentes.Agregar(verticeD);
            verticeE.Adyacentes.Agregar(verticeF);
            verticeE.Adyacentes.Agregar(verticeG);
            //F: E, H
            verticeF.Adyacentes.Agregar(verticeE);
            verticeF.Adyacentes.Agregar(verticeH);
            //G: E, H
            verticeG.Adyacentes.Agregar(verticeE);
            verticeG.Adyacentes.Agregar(verticeH);
            //H: F, G
            verticeH.Adyacentes.Agregar(verticeF);
            verticeH.Adyacentes.Agregar(verticeG);

            _grafo.AgregarVertice(verticeA);
            _grafo.AgregarVertice(verticeB);
            _grafo.AgregarVertice(verticeC);
            _grafo.AgregarVertice(verticeD);
            _grafo.AgregarVertice(verticeE);
            _grafo.AgregarVertice(verticeF);
            _grafo.AgregarVertice(verticeG);
            _grafo.AgregarVertice(verticeH);

            _grafo.EncontrarCiclos(verticeA);

            Assert.AreEqual(8, _grafo.Visitados.Count);

            Assert.AreEqual(2, _grafo.CiclosGrafo.Tamanio);

            Assert.AreEqual(4, _grafo.CiclosGrafo.Iterador.Next().Tamanio);            
            Assert.AreEqual(verticeA,_grafo.CiclosGrafo.Iterador.Lista.Primero().Iterador.Next());
            Assert.AreEqual(verticeB, _grafo.CiclosGrafo.Iterador.Lista.Primero().Iterador.Next());            
            Assert.AreEqual(verticeD, _grafo.CiclosGrafo.Iterador.Lista.Primero().Iterador.Next());
            Assert.AreEqual(verticeC, _grafo.CiclosGrafo.Iterador.Lista.Primero().Iterador.Next());

            Assert.AreEqual(4, _grafo.CiclosGrafo.Iterador.Next().Tamanio);

            Assert.AreEqual(verticeE, _grafo.CiclosGrafo.Iterador.Lista.Ultimo().Iterador.Next());
            Assert.AreEqual(verticeF, _grafo.CiclosGrafo.Iterador.Lista.Ultimo().Iterador.Next());
            Assert.AreEqual(verticeH, _grafo.CiclosGrafo.Iterador.Lista.Ultimo().Iterador.Next());
            Assert.AreEqual(verticeG, _grafo.CiclosGrafo.Iterador.Lista.Ultimo().Iterador.Next());
            

            


        }

        [Test]
        public void TestAgregarVertice()
        {
            _grafo.AgregarVertice(new Vertice<Nodo>(new Nodo("Vertice1")));
            
            Assert.AreEqual(1,_grafo.Vertices.Tamanio);
            Assert.AreEqual("Vertice1",_grafo.Vertices.Iterador.Next().Contenido.Nombre);

        }

        [Test]
        public void TestAgregarArco()
        {

            _grafo.AgregarArco(new Vertice<Nodo>(new Nodo("Vertice1")), new Vertice<Nodo>(new Nodo("Vertice2")));

            Assert.AreEqual(2, _grafo.Vertices.Tamanio);
            Assert.AreEqual(new Vertice<Nodo>(new Nodo("Vertice1")), _grafo.Vertices.Primero());
            Assert.AreEqual(new Vertice<Nodo>(new Nodo("Vertice2")), _grafo.Vertices.Ultimo());
            Assert.AreEqual(1, _grafo.Vertices.Primero().Adyacentes.Tamanio);
            Assert.AreEqual(1, _grafo.Vertices.Ultimo().Adyacentes.Tamanio);
            Assert.AreEqual(new Vertice<Nodo>(new Nodo("Vertice2")), _grafo.Vertices.Primero().Adyacentes.Iterador.Next());
            Assert.AreEqual(new Vertice<Nodo>(new Nodo("Vertice1")), _grafo.Vertices.Ultimo().Adyacentes.Iterador.Next());

        }

        [Test]
        public void TestContiene()
        {
            _grafo.AgregarVertice(new Vertice<Nodo>(new Nodo("Vertice1")));

            Assert.AreEqual(1, _grafo.Vertices.Tamanio);
            Assert.IsTrue(_grafo.Vertices.Contiene(new Vertice<Nodo>(new Nodo("Vertice1"))));
        }

        [Test]
        public void TestObtener()
        {
            _grafo.AgregarVertice(new Vertice<Nodo>(new Nodo("Vertice1")));

            Assert.AreEqual(1, _grafo.Vertices.Tamanio);
            Assert.AreEqual(new Vertice<Nodo>(new Nodo("Vertice1")),_grafo.Vertices.Obtener(new Vertice<Nodo>(new Nodo("Vertice1"))));
        }


        [TearDown]
        public void TearDown()
        {
            _grafo = new Grafo<Nodo>();
            

        }
    }

}
