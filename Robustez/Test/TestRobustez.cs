using System;
using System.Collections.Generic;
using System.Text;
using Robustez;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class TestRobustez
    {
        private Grafo<string> _grafo;

        [SetUp]
        public void SetUp()
        {
            _grafo = new Grafo<string>();
        }



        [Test]
        public void TestAumentarRobustezGrafoTres()
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
            Vertice<string> verticeJ = new Vertice<string>("J");


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
            _grafo.AgregarVertice(verticeJ);

            _grafo.RecorridoDFS();
            _grafo.EnlistarVerticesDiscontinuos();
            Robustez<string> robustez = new Robustez<string>(_grafo);
            robustez.Aumentar(_grafo.CiclosGrafo, 3);
            Assert.IsTrue(robustez.AristasAgregadas.Iterador.Next().Equals(new Arista<string>(verticeC, verticeF)));
            Assert.IsTrue(robustez.AristasAgregadas.Iterador.Next().Equals(new Arista<string>(verticeB, verticeF)));
            Assert.IsTrue(robustez.AristasAgregadas.Iterador.Next().Equals(new Arista<string>(verticeA, verticeG)));
            Assert.IsTrue(robustez.AristasAgregadas.Iterador.Next().Equals(new Arista<string>(verticeE, verticeI)));
            Assert.IsTrue(robustez.AristasAgregadas.Iterador.Next().Equals(new Arista<string>(verticeD, verticeI)));
            Assert.IsTrue(robustez.AristasAgregadas.Iterador.Next().Equals(new Arista<string>(verticeD, verticeH)));
            Assert.IsTrue(robustez.AristasAgregadas.Iterador.Next().Equals(new Arista<string>(verticeH, verticeJ)));
            Assert.IsTrue(robustez.AristasAgregadas.Iterador.Next().Equals(new Arista<string>(verticeJ, verticeC)));
            Assert.IsTrue(robustez.AristasAgregadas.Iterador.Next().Equals(new Arista<string>(verticeJ, verticeB)));



            Assert.AreEqual(9, robustez.AristasAgregadas.Tamanio);
        }

        [Test]
        public void TestAumentarRobustezGrafoDosRobustezTres()
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


            _grafo.RecorridoDFS();
            Robustez<string> robustez = new Robustez<string>(_grafo);
            robustez.Aumentar(_grafo.CiclosGrafo, 3);
            Assert.IsTrue(robustez.AristasAgregadas.Iterador.Next().Equals(new Arista<string>(verticeC, verticeF)));
            Assert.IsTrue(robustez.AristasAgregadas.Iterador.Next().Equals(new Arista<string>(verticeA,verticeD)));
            

            Assert.AreEqual(2, robustez.AristasAgregadas.Tamanio);



        }

        [Test]
        public void TestAumentarRobustezGrafoDosRobustezCuatro()
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

            _grafo.RecorridoDFS();
            Robustez<string> robustez = new Robustez<string>(_grafo);
            robustez.Aumentar(_grafo.CiclosGrafo, 4);
            Assert.IsTrue(robustez.AristasAgregadas.Iterador.Next().Equals(new Arista<string>(verticeC,verticeF)));
            Assert.IsTrue(robustez.AristasAgregadas.Iterador.Next().Equals(new Arista<string>(verticeC, verticeD)));
            Assert.IsTrue(robustez.AristasAgregadas.Iterador.Next().Equals(new Arista<string>(verticeB, verticeF)));
            Assert.IsTrue(robustez.AristasAgregadas.Iterador.Next().Equals(new Arista<string>(verticeA, verticeD)));
            Assert.IsTrue(robustez.AristasAgregadas.Iterador.Next().Equals(new Arista<string>(verticeA, verticeE)));

            Assert.AreEqual(5, robustez.AristasAgregadas.Tamanio);



        }

        [Test]
        public void TestAumentarRobustezGrafoUno()
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

            _grafo.RecorridoDFS();
            Robustez<string> robustez = new Robustez<string>(_grafo);
            robustez.Aumentar(_grafo.CiclosGrafo, 3);

            Assert.IsTrue(robustez.AristasAgregadas.Iterador.Next().Equals(new Arista<string>(verticeC, verticeG)));
            Assert.IsTrue(robustez.AristasAgregadas.Iterador.Next().Equals(new Arista<string>(verticeB, verticeH)));
            Assert.IsTrue(robustez.AristasAgregadas.Iterador.Next().Equals(new Arista<string>(verticeA, verticeF)));
            
            
          
            Assert.AreEqual(3, robustez.AristasAgregadas.Tamanio);





        }

      

        [TearDown]
        public void TearDown()
        {
            _grafo = new Grafo<string>();


        }
    }

}

