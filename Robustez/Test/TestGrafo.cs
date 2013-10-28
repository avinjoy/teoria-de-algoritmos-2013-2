using NUnit.Framework;
using Robustez;

namespace Test
{
    [TestFixture]
    public class TestGrafo
    {
        private Grafo<string> _grafo;

        [SetUp]
        public void SetUp()
        {
            _grafo = new Grafo<string>();
        }



        [Test]
        public void TestRecorridoDFSGrafoTres()
        {

            Vertice<string> verticeA = new Vertice<string>("A");
            Vertice<string> verticeB = new Vertice<string>("B");
            Vertice<string> verticeC = new Vertice<string>("C");
            Vertice<string> verticeD = new Vertice<string>("D");
            Vertice<string> verticeE = new Vertice<string>("E");
            Vertice<string> verticeF = new Vertice<string>("F");
            Vertice<string> verticeG = new Vertice<string>("G");
            Vertice<string> verticeH = new Vertice<string>("H");
            Vertice<string> verticeI = new Vertice<string>("I");


            //A: B, C
            verticeA.Adyacentes.Agregar(verticeB);
            verticeA.Adyacentes.Agregar(verticeC);
            //B: A, C
            verticeB.Adyacentes.Agregar(verticeA);
            verticeB.Adyacentes.Agregar(verticeC);
            //C: A, B
            verticeC.Adyacentes.Agregar(verticeA);
            verticeC.Adyacentes.Agregar(verticeB);
            //D: E
            verticeD.Adyacentes.Agregar(verticeE);
            
            //E: D, G
            verticeE.Adyacentes.Agregar(verticeD);
            verticeE.Adyacentes.Agregar(verticeG);
            //F: G            
            verticeF.Adyacentes.Agregar(verticeG);
            //G: E, F
            verticeG.Adyacentes.Agregar(verticeE);
            verticeG.Adyacentes.Agregar(verticeF);
            //H:I            
            verticeH.Adyacentes.Agregar(verticeI);
            //I:H
            verticeI.Adyacentes.Agregar(verticeH);

            _grafo.AgregarVertice(verticeA);
            _grafo.AgregarVertice(verticeB);
            _grafo.AgregarVertice(verticeC);
            _grafo.AgregarVertice(verticeD);
            _grafo.AgregarVertice(verticeE);
            _grafo.AgregarVertice(verticeF);
            _grafo.AgregarVertice(verticeG);
            _grafo.AgregarVertice(verticeH);
            _grafo.AgregarVertice(verticeI);
            

            _grafo.recorridoDFS(_grafo);       

            Assert.AreEqual(1, _grafo.CiclosGrafo.Tamanio);

            Assert.AreEqual(3, _grafo.CiclosGrafo.Iterador.Next().Tamanio);
            Assert.AreEqual(verticeC, _grafo.CiclosGrafo.Iterador.Lista.Primero().Iterador.Next());
            Assert.AreEqual(verticeB, _grafo.CiclosGrafo.Iterador.Lista.Primero().Iterador.Next());
            Assert.AreEqual(verticeA, _grafo.CiclosGrafo.Iterador.Lista.Primero().Iterador.Next());
            
            
    

        }

        [Test]
        public void TestRecorridoDFSGrafoDos()
        {

            Vertice<string> verticeA = new Vertice<string>("A");
            Vertice<string> verticeB = new Vertice<string>("B");
            Vertice<string> verticeC = new Vertice<string>("C");
            Vertice<string> verticeD = new Vertice<string>("D");
            Vertice<string> verticeE = new Vertice<string>("E");
            Vertice<string> verticeF = new Vertice<string>("F");      
       
            //A: B, C
            verticeA.Adyacentes.Agregar(verticeB);
            verticeA.Adyacentes.Agregar(verticeC);
            //B: A, C, E
            verticeB.Adyacentes.Agregar(verticeA);
            verticeB.Adyacentes.Agregar(verticeC);
            verticeB.Adyacentes.Agregar(verticeE);
            //C: A, B
            verticeC.Adyacentes.Agregar(verticeA);
            verticeC.Adyacentes.Agregar(verticeB);
            //D: E, F
            verticeD.Adyacentes.Agregar(verticeE);
            verticeD.Adyacentes.Agregar(verticeF);
            //E: B, D, F
            verticeE.Adyacentes.Agregar(verticeB);
            verticeE.Adyacentes.Agregar(verticeD);
            verticeE.Adyacentes.Agregar(verticeF);
            //F: D, E
            verticeF.Adyacentes.Agregar(verticeD);
            verticeF.Adyacentes.Agregar(verticeE);


            _grafo.AgregarVertice(verticeA);
            _grafo.AgregarVertice(verticeB);
            _grafo.AgregarVertice(verticeC);
            _grafo.AgregarVertice(verticeD);
            _grafo.AgregarVertice(verticeE);
            _grafo.AgregarVertice(verticeF);
         

            _grafo.recorridoDFS(_grafo);

            Assert.AreEqual(2, _grafo.CiclosGrafo.Tamanio);

            Assert.AreEqual(3, _grafo.CiclosGrafo.Iterador.Next().Tamanio);

            Assert.AreEqual(verticeC, _grafo.CiclosGrafo.Iterador.Lista.Primero().Iterador.Next());
            Assert.AreEqual(verticeB, _grafo.CiclosGrafo.Iterador.Lista.Primero().Iterador.Next());
            Assert.AreEqual(verticeA, _grafo.CiclosGrafo.Iterador.Lista.Primero().Iterador.Next());          
            
            Assert.AreEqual(3, _grafo.CiclosGrafo.Iterador.Next().Tamanio);

            Assert.AreEqual(verticeF, _grafo.CiclosGrafo.Iterador.Lista.Ultimo().Iterador.Next());
            Assert.AreEqual(verticeD, _grafo.CiclosGrafo.Iterador.Lista.Ultimo().Iterador.Next());        
            Assert.AreEqual(verticeE, _grafo.CiclosGrafo.Iterador.Lista.Ultimo().Iterador.Next());
                
            




        }

        [Test]
        public void TestRecorridoDFSGrafoUno()
        {

            Vertice<string> verticeA = new Vertice<string>("A");
            Vertice<string> verticeB = new Vertice<string>("B");
            Vertice<string> verticeC = new Vertice<string>("C");
            Vertice<string> verticeD = new Vertice<string>("D");
            Vertice<string> verticeE = new Vertice<string>("E");
            Vertice<string> verticeF = new Vertice<string>("F");
            Vertice<string> verticeG = new Vertice<string>("G");
            Vertice<string> verticeH = new Vertice<string>("H");


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

            _grafo.recorridoDFS(_grafo);

            Assert.AreEqual(2, _grafo.CiclosGrafo.Tamanio);

            Assert.AreEqual(4, _grafo.CiclosGrafo.Iterador.Next().Tamanio);
            Assert.AreEqual(verticeC, _grafo.CiclosGrafo.Iterador.Lista.Primero().Iterador.Next());
            Assert.AreEqual(verticeD, _grafo.CiclosGrafo.Iterador.Lista.Primero().Iterador.Next());
            Assert.AreEqual(verticeB, _grafo.CiclosGrafo.Iterador.Lista.Primero().Iterador.Next());
            Assert.AreEqual(verticeA, _grafo.CiclosGrafo.Iterador.Lista.Primero().Iterador.Next());        
          
            Assert.AreEqual(4, _grafo.CiclosGrafo.Iterador.Next().Tamanio);

            Assert.AreEqual(verticeG, _grafo.CiclosGrafo.Iterador.Lista.Ultimo().Iterador.Next());
            Assert.AreEqual(verticeH, _grafo.CiclosGrafo.Iterador.Lista.Ultimo().Iterador.Next());
            Assert.AreEqual(verticeF, _grafo.CiclosGrafo.Iterador.Lista.Ultimo().Iterador.Next());
            Assert.AreEqual(verticeE, _grafo.CiclosGrafo.Iterador.Lista.Ultimo().Iterador.Next());
            
            
            





        }

        [Test]
        public void TestAgregarVertice()
        {
            _grafo.AgregarVertice(new Vertice<string>("Vertice1"));

            Assert.AreEqual(1, _grafo.Vertices.Tamanio);
            Assert.AreEqual("Vertice1", _grafo.Vertices.Iterador.Next().Contenido);

        }

        [Test]
        public void TestAgregarArco()
        {

            _grafo.AgregarArco(new Vertice<string>("Vertice1"), new Vertice<string>("Vertice2"));

            Assert.AreEqual(2, _grafo.Vertices.Tamanio);
            Assert.AreEqual(new Vertice<string>("Vertice1"), _grafo.Vertices.Primero());
            Assert.AreEqual(new Vertice<string>("Vertice2"), _grafo.Vertices.Ultimo());
            Assert.AreEqual(1, _grafo.Vertices.Primero().Adyacentes.Tamanio);
            Assert.AreEqual(0, _grafo.Vertices.Ultimo().Adyacentes.Tamanio);
            Assert.AreEqual(new Vertice<string>("Vertice2"), _grafo.Vertices.Primero().Adyacentes.Iterador.Next());
            Assert.AreEqual(null, _grafo.Vertices.Ultimo().Adyacentes.Iterador.Next());

        }

        [Test]
        public void TestContieneVertice()
        {
            _grafo.AgregarVertice(new Vertice<string>("Vertice1"));

            Assert.AreEqual(1, _grafo.Vertices.Tamanio);
            Assert.IsTrue(_grafo.Vertices.Contiene(new Vertice<string>("Vertice1")));
        }

        [Test]
        public void TestObtenerVertice()
        {
            _grafo.AgregarVertice(new Vertice<string>("Vertice1"));

            Assert.AreEqual(1, _grafo.Vertices.Tamanio);
            Assert.AreEqual(new Vertice<string>("Vertice1"), _grafo.Vertices.Obtener(new Vertice<string>("Vertice1")));
        }


        [TearDown]
        public void TearDown()
        {
            _grafo = new Grafo<string>();


        }
    }

}
