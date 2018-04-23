using cube_summation.Models.Interface;
using System.Collections.Generic;

namespace cube_summation.Models
{
    /// <summary>
    /// Orquestador de las operaciones que se ejecutan de acuerdo al caso.
    /// </summary>
    public class Operacion
    {
        private IOperacion operacion;

        public Operacion()
        {

        }

        /// <summary>
        /// Asigna el tipo de operación a realizar, UPDATE o QUERY.
        /// </summary>
        /// <param name="operacion">Objeto de la operación a ejecutar.</param>
        private void AsignarOperacion(IOperacion operacion)
        {
            this.operacion = operacion;
        }

        /// <summary>
        /// Selección de la operación a ejecutar.
        /// </summary>
        /// <param name="informacionOperacion">Información de las operaciones que ingresaron al sistema.</param>
        public void SeleccionarOperacion(List<string> informacionOperacion)
        {

            switch (informacionOperacion[0])
            {
                case "UPDATE":
                    AsignarOperacion(new Update());
                    break;

                case "QUERY":
                    AsignarOperacion(new Query());
                    break;
            }
        }

        /// <summary>
        /// Ejecuta la operaciones previamente asignada.
        /// </summary>
        /// <param name="informacionOperacion">Información de las operaciones que ingresaron al sistema.</param>
        /// <param name="matriz">Matriz a la cual se le realizaran las operaciones.</param>
        /// <param name="resultadoOperacion">Variable para guardar los resultados obtenidos de lasoperacioines.</param>
        public void EjecutarOperacion(List<string> informacionOperacion, Matriz matriz, List<string> resultadoOperacion)
        {
            this.operacion.EjecutarOperacion(informacionOperacion, matriz, resultadoOperacion);
        }
    }
}