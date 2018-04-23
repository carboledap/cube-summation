using cube_summation.Framework;
using cube_summation.Models.Interface;
using System.Collections.Generic;

namespace cube_summation.Models
{
    /// <summary>
    /// Representa la operación UPDATE del proceso.
    /// </summary>
    public class Update : IOperacion
    {
        /// <summary>
        /// Ejecuta la operaciones previamente asignada.
        /// </summary>
        /// <param name="informacionOperacion">Información de las operaciones que ingresaron al sistema.</param>
        /// <param name="matriz">Matriz a la cual se le realizaran las operaciones.</param>
        /// <param name="resultadoOperacion">Variable para guardar los resultados obtenidos de lasoperacioines.</param>
        public void EjecutarOperacion(List<string> informacionOperacion, Matriz matriz, List<string> resultadoOperacion)
        {
            List<int> cordenadas = Cordenadas.AsignarCordenadas(informacionOperacion.GetRange(1, 3));
            matriz.contenidoMatriz[cordenadas[0], cordenadas[1], cordenadas[2]] = int.Parse(informacionOperacion[4]);
        }
    }
}