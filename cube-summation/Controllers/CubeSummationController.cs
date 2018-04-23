using cube_summation.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace cube_summation.Controllers
{
    public class CubeSummationController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        // POST: Default/Create
        [HttpPost]
        public ActionResult ProcesoCubeSummation(InformacionProceso informacionProceso)
        {
            try
            {
                InformacionSecuenciaOperacion informacionOperacion = new InformacionSecuenciaOperacion();
           
                informacionOperacion.ValoresOperacion = informacionProceso.DatosEntrada.Replace("\r\n", ";").Split(';').ToList();

                List<string> listaMensajesValidacion = ValidacionReglasDatosEntrada(informacionOperacion);

                if (listaMensajesValidacion.Count > 0)
                {
                    ViewData["Mensaje"] = string.Join("; ", listaMensajesValidacion);
                    return View("Index");
                }

                List<string> resultadoOperacion = EjecutarCubeSummationTest(informacionOperacion);

                informacionProceso.DatosSalida = string.Join("\r\n", resultadoOperacion);

                return View("Index", informacionProceso);
            }
            catch
            {
                ViewData["Mensaje"] = "Los datos de entrada no estan correctos, por favor valida y vuelve a intentar";
                return View("Index");
            }
        }

        /// <summary>
        /// Orquesta el proceso principal de la prueba Cube Summation.
        /// </summary>
        /// <param name="informacionSecuenciaOperacion">Contine una lista de secuencias de operaciones que se deben ejecutar.</param>
        /// <returns>Resultado de la operación.</returns>
        internal List<string> EjecutarCubeSummationTest(InformacionSecuenciaOperacion informacionSecuenciaOperacion)
        {
            List<string> resultadoOperacion = new List<string>();

            int posicionEntradas = 0;

            int numeroCasos = int.Parse(informacionSecuenciaOperacion.ValoresOperacion[posicionEntradas]);

            posicionEntradas++;

            for (int i = 0; i < numeroCasos; i++)
            {
                List<string> informacionCaso = informacionSecuenciaOperacion.ValoresOperacion[posicionEntradas].Split(' ').ToList();

                int tamañoMatriz = int.Parse(informacionCaso[0]) + 1;
                int numeroOperaciones = int.Parse(informacionCaso[1]);

                posicionEntradas++;

                Matriz matriz = new Matriz(tamañoMatriz);

                for (int j = 0; j < numeroOperaciones; j++)
                {
                    List<string> contenidoOperacion = informacionSecuenciaOperacion.ValoresOperacion[posicionEntradas].Split(' ').ToList();

                    Operacion operacion = new Operacion();

                    operacion.SeleccionarOperacion(contenidoOperacion);
                    operacion.EjecutarOperacion(contenidoOperacion, matriz, resultadoOperacion);

                    posicionEntradas++;

                }

            }

            return resultadoOperacion;
        }

        /// <summary>
        /// Valida que el contenido de las operaciones ingresadas esten correctas para operar con el proceso.
        /// </summary>
        /// <param name="informacionSecuenciaOperacion">Contine una lista de secuencias de operaciones que se deben ejecutar.</param>
        /// <returns>Lista de mensajes encontrados en las validaciones.</returns>
        internal List<string> ValidacionReglasDatosEntrada(InformacionSecuenciaOperacion informacionSecuenciaOperacion)
        {
            List<string> listaMensajesValidacion = new List<string>();

            int tamañoMatriz = 0;

            for (int i = 0; i < informacionSecuenciaOperacion.ValoresOperacion.Count; i++)
            {
                var regexNumeroCasos = new Regex(@"^[0-9]{1,2}$");

                if (regexNumeroCasos.IsMatch(informacionSecuenciaOperacion.ValoresOperacion[i]))
                {
                    if (int.Parse(informacionSecuenciaOperacion.ValoresOperacion[i]) < 0 || int.Parse(informacionSecuenciaOperacion.ValoresOperacion[i]) > 50)
                    {
                        listaMensajesValidacion.Add("El número de casos debe estar entre 1 y 50");
                    }
                }

                var regexTamañoMatrizNumeroOperaciones = new Regex(@"^[0-9]{1,3}\s[0-9]{1,3}$");

                if (regexTamañoMatrizNumeroOperaciones.IsMatch(informacionSecuenciaOperacion.ValoresOperacion[i]))
                {
                    tamañoMatriz = int.Parse(informacionSecuenciaOperacion.ValoresOperacion[i].Split(' ').ToList()[0]);
                    int numeroOperaciones = int.Parse(informacionSecuenciaOperacion.ValoresOperacion[i].Split(' ').ToList()[1]);

                    if (tamañoMatriz < 0 || tamañoMatriz > 100)
                    {
                        listaMensajesValidacion.Add("El tamaño de la matriz debe estar entre 1 y 100");
                    }

                    if (1 < 0 || numeroOperaciones > 1000)
                    {
                        listaMensajesValidacion.Add("El número de operaciones debe estar entre 1 y 1000");
                    }
                }

                if (informacionSecuenciaOperacion.ValoresOperacion[i].Contains("QUERY"))
                {
                    int coordenadaX1 = int.Parse(informacionSecuenciaOperacion.ValoresOperacion[i].Split(' ').ToList()[1]);
                    int coordenadaY1 = int.Parse(informacionSecuenciaOperacion.ValoresOperacion[i].Split(' ').ToList()[2]);
                    int coordenadaZ1 = int.Parse(informacionSecuenciaOperacion.ValoresOperacion[i].Split(' ').ToList()[3]);

                    int coordenadaX2 = int.Parse(informacionSecuenciaOperacion.ValoresOperacion[i].Split(' ').ToList()[4]);
                    int coordenadaY2 = int.Parse(informacionSecuenciaOperacion.ValoresOperacion[i].Split(' ').ToList()[5]);
                    int coordenadaZ2 = int.Parse(informacionSecuenciaOperacion.ValoresOperacion[i].Split(' ').ToList()[6]);

                    if ((coordenadaX1 < 0 || coordenadaX1 > tamañoMatriz) || (coordenadaX2 < 0 || coordenadaX2 > tamañoMatriz) || (coordenadaY1 < 0 || coordenadaY1 > tamañoMatriz) || (coordenadaY2 < 0 || coordenadaY2 > tamañoMatriz) || (coordenadaZ1 < 0 || coordenadaZ1 > tamañoMatriz) || (coordenadaZ2 < 0 || coordenadaZ2 > tamañoMatriz))
                    {
                        listaMensajesValidacion.Add("El valor de cada cordenada de la operación QUERY debe estar entre 1 y " + tamañoMatriz.ToString());
                    }
                }

                if (informacionSecuenciaOperacion.ValoresOperacion[i].Contains("UPDATE"))
                {
                    int coordenadaX = int.Parse(informacionSecuenciaOperacion.ValoresOperacion[i].Split(' ').ToList()[1]);
                    int coordenadaY = int.Parse(informacionSecuenciaOperacion.ValoresOperacion[i].Split(' ').ToList()[2]);
                    int coordenadaZ = int.Parse(informacionSecuenciaOperacion.ValoresOperacion[i].Split(' ').ToList()[3]);

                    int valorCoordenadaW = int.Parse(informacionSecuenciaOperacion.ValoresOperacion[i].Split(' ').ToList()[4]);

                    if ((coordenadaX < 0 || coordenadaX > tamañoMatriz) || (coordenadaY < 0 || coordenadaY > tamañoMatriz) || (coordenadaZ < 0 || coordenadaZ > tamañoMatriz))
                    {
                        listaMensajesValidacion.Add("El valor de cada cordenada de la operación UPDATE debe estar entre 1 y " + tamañoMatriz.ToString());
                    }

                    if (valorCoordenadaW < -109 || valorCoordenadaW > 109)
                    {
                        listaMensajesValidacion.Add("El valor de la coordenada debe estar entre -109 y 109");
                    }
                }

            }


          


            return listaMensajesValidacion;
        }
       
    }
}
