using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using cube_summation.Controllers;
using cube_summation.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace cube_summation.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ValidarResultadoConDatosDeEntradaDelEjercicioOriginal()
        {

            InformacionSecuenciaOperacion informacionOperacion = new InformacionSecuenciaOperacion();
            informacionOperacion.ValoresOperacion = new List<string>();
            List<string> resultadoOperacion = new List<string>();


            informacionOperacion.ValoresOperacion.Add("2");
            informacionOperacion.ValoresOperacion.Add("4 5");
            informacionOperacion.ValoresOperacion.Add("UPDATE 2 2 2 4");
            informacionOperacion.ValoresOperacion.Add("QUERY 1 1 1 3 3 3");
            informacionOperacion.ValoresOperacion.Add("UPDATE 1 1 1 23");
            informacionOperacion.ValoresOperacion.Add("QUERY 2 2 2 4 4 4");
            informacionOperacion.ValoresOperacion.Add("QUERY 1 1 1 3 3 3");
            informacionOperacion.ValoresOperacion.Add("2 4");
            informacionOperacion.ValoresOperacion.Add("UPDATE 2 2 2 1");
            informacionOperacion.ValoresOperacion.Add("QUERY 1 1 1 1 1 1");
            informacionOperacion.ValoresOperacion.Add("QUERY 1 1 1 2 2 2");
            informacionOperacion.ValoresOperacion.Add("QUERY 2 2 2 2 2 2");

            CubeSummationController cubeSummationController = new CubeSummationController();

            resultadoOperacion = cubeSummationController.EjecutarCubeSummationTest(informacionOperacion);

            List<string> resultadoOperacionEsperado = new List<string>();

            resultadoOperacionEsperado.Add("4");
            resultadoOperacionEsperado.Add("4");
            resultadoOperacionEsperado.Add("27");
            resultadoOperacionEsperado.Add("0");
            resultadoOperacionEsperado.Add("1");
            resultadoOperacionEsperado.Add("1");

            CollectionAssert.AreEqual(resultadoOperacion, resultadoOperacionEsperado);
        }

        [TestMethod]
        public void ValidarDatosDeEntradaConNumeroDeCasosErroneo()
        {
            InformacionSecuenciaOperacion informacionOperacion = new InformacionSecuenciaOperacion();
            informacionOperacion.ValoresOperacion = new List<string>();

            informacionOperacion.ValoresOperacion.Add("51");
            informacionOperacion.ValoresOperacion.Add("4 5");
            informacionOperacion.ValoresOperacion.Add("UPDATE 2 2 2 4");
            informacionOperacion.ValoresOperacion.Add("QUERY 1 1 1 3 3 3");
            informacionOperacion.ValoresOperacion.Add("UPDATE 1 1 1 23");
            informacionOperacion.ValoresOperacion.Add("QUERY 2 2 2 4 4 4");
            informacionOperacion.ValoresOperacion.Add("QUERY 1 1 1 3 3 3");
            informacionOperacion.ValoresOperacion.Add("2 4");
            informacionOperacion.ValoresOperacion.Add("UPDATE 2 2 2 1");
            informacionOperacion.ValoresOperacion.Add("QUERY 1 1 1 1 1 1");
            informacionOperacion.ValoresOperacion.Add("QUERY 1 1 1 2 2 2");
            informacionOperacion.ValoresOperacion.Add("QUERY 2 2 2 2 2 2");

            CubeSummationController cubeSummationController = new CubeSummationController();

            List<string> listaMensajesValidacion = cubeSummationController.ValidacionReglasDatosEntrada(informacionOperacion);

            Assert.AreEqual("El número de casos debe estar entre 1 y 50", listaMensajesValidacion[0]);

        }

        [TestMethod]
        public void ValidarDatosDeEntradaCoTamañoMatrizErroneo()
        {
            InformacionSecuenciaOperacion informacionOperacion = new InformacionSecuenciaOperacion();
            informacionOperacion.ValoresOperacion = new List<string>();

            informacionOperacion.ValoresOperacion.Add("2");
            informacionOperacion.ValoresOperacion.Add("101 5");
            informacionOperacion.ValoresOperacion.Add("UPDATE 2 2 2 4");
            informacionOperacion.ValoresOperacion.Add("QUERY 1 1 1 3 3 3");
            informacionOperacion.ValoresOperacion.Add("UPDATE 1 1 1 23");
            informacionOperacion.ValoresOperacion.Add("QUERY 2 2 2 4 4 4");
            informacionOperacion.ValoresOperacion.Add("QUERY 1 1 1 3 3 3");
            informacionOperacion.ValoresOperacion.Add("2 4");
            informacionOperacion.ValoresOperacion.Add("UPDATE 2 2 2 1");
            informacionOperacion.ValoresOperacion.Add("QUERY 1 1 1 1 1 1");
            informacionOperacion.ValoresOperacion.Add("QUERY 1 1 1 2 2 2");
            informacionOperacion.ValoresOperacion.Add("QUERY 2 2 2 2 2 2");

            CubeSummationController cubeSummationController = new CubeSummationController();

            List<string> listaMensajesValidacion = cubeSummationController.ValidacionReglasDatosEntrada(informacionOperacion);

            Assert.AreEqual("El tamaño de la matriz debe estar entre 1 y 100", listaMensajesValidacion[0]);

        }

        [TestMethod]
        public void ValidarDatosDeEntradaCoValorCoordenadaXEnOperacionUpdateErroneo()
        {
            InformacionSecuenciaOperacion informacionOperacion = new InformacionSecuenciaOperacion();
            informacionOperacion.ValoresOperacion = new List<string>();

            informacionOperacion.ValoresOperacion.Add("2");
            informacionOperacion.ValoresOperacion.Add("4 5");
            informacionOperacion.ValoresOperacion.Add("UPDATE 5 2 2 4");
            informacionOperacion.ValoresOperacion.Add("QUERY 1 1 1 3 3 3");
            informacionOperacion.ValoresOperacion.Add("UPDATE 1 1 1 23");
            informacionOperacion.ValoresOperacion.Add("QUERY 2 2 2 4 4 4");
            informacionOperacion.ValoresOperacion.Add("QUERY 1 1 1 3 3 3");
            informacionOperacion.ValoresOperacion.Add("2 4");
            informacionOperacion.ValoresOperacion.Add("UPDATE 2 2 2 1");
            informacionOperacion.ValoresOperacion.Add("QUERY 1 1 1 1 1 1");
            informacionOperacion.ValoresOperacion.Add("QUERY 1 1 1 2 2 2");
            informacionOperacion.ValoresOperacion.Add("QUERY 2 2 2 2 2 2");

            CubeSummationController cubeSummationController = new CubeSummationController();

            List<string> listaMensajesValidacion = cubeSummationController.ValidacionReglasDatosEntrada(informacionOperacion);

            Assert.AreEqual("El valor de cada cordenada de la operación UPDATE debe estar entre 1 y 4", listaMensajesValidacion[0]);

        }
        [TestMethod]
        public void ValidarDatosDeEntradaCoValorCoordenadaXEnOperacionQueryErroneo()
        {
            InformacionSecuenciaOperacion informacionOperacion = new InformacionSecuenciaOperacion();
            informacionOperacion.ValoresOperacion = new List<string>();

            informacionOperacion.ValoresOperacion.Add("2");
            informacionOperacion.ValoresOperacion.Add("4 5");
            informacionOperacion.ValoresOperacion.Add("UPDATE 2 2 2 4");
            informacionOperacion.ValoresOperacion.Add("QUERY 1 1 1 3 3 3");
            informacionOperacion.ValoresOperacion.Add("UPDATE 1 1 1 23");
            informacionOperacion.ValoresOperacion.Add("QUERY 2 2 2 4 4 4");
            informacionOperacion.ValoresOperacion.Add("QUERY 1 1 1 3 3 3");
            informacionOperacion.ValoresOperacion.Add("2 4");
            informacionOperacion.ValoresOperacion.Add("UPDATE 2 2 2 1");
            informacionOperacion.ValoresOperacion.Add("QUERY 4 1 1 1 1 1");
            informacionOperacion.ValoresOperacion.Add("QUERY 1 1 1 2 2 2");
            informacionOperacion.ValoresOperacion.Add("QUERY 2 2 2 2 2 2");

            CubeSummationController cubeSummationController = new CubeSummationController();

            List<string> listaMensajesValidacion = cubeSummationController.ValidacionReglasDatosEntrada(informacionOperacion);

            Assert.AreEqual("El valor de cada cordenada de la operación QUERY debe estar entre 1 y 2", listaMensajesValidacion[0]);

        }

        [TestMethod]
        public void ValidarContenidoCreacionMatriz()
        {
            int tamañoMatriz = 5;

            int[,,] matrizEsperada = new int[tamañoMatriz, tamañoMatriz, tamañoMatriz];

            Matriz matriz = new Matriz(tamañoMatriz);

            Assert.AreEqual(tamañoMatriz, matriz.tamaño);
            CollectionAssert.AreEqual(matrizEsperada, matriz.contenidoMatriz);
        }
    }
}
