using cube_summation.Framework;
using cube_summation.Models.Interface;
using System.Collections.Generic;

namespace cube_summation.Models
{
    /// <summary>
    /// Representa la operación QUERY del proceso.
    /// </summary>
    public class Query : IOperacion
    {
        /// <summary>
        /// Ejecuta la operaciones previamente asignada.
        /// </summary>
        /// <param name="informacionOperacion">Información de las operaciones que ingresaron al sistema.</param>
        /// <param name="matriz">Matriz a la cual se le realizaran las operaciones.</param>
        /// <param name="resultadoOperacion">Variable para guardar los resultados obtenidos de lasoperacioines.</param>
        public void EjecutarOperacion(List<string> informacionOperacion, Matriz matriz, List<string> resultadoOperacion)
        {
            List<int> cordenadasInicio = Cordenadas.AsignarCordenadas(informacionOperacion.GetRange(1, 3));
            List<int> cordenadasFinales = Cordenadas.AsignarCordenadas(informacionOperacion.GetRange(4, 3));

            int suma = 0;

            for (int x = cordenadasInicio[0]; x <= cordenadasFinales[0]; x++)
            {
                for (int y = cordenadasInicio[1]; y <= cordenadasFinales[1]; y++)
                {
                    for (int z = cordenadasInicio[2]; z <= cordenadasFinales[2]; z++)
                    {
                        suma += matriz.contenidoMatriz[x, y, z];
                    }
                }

            }

            resultadoOperacion.Add(suma.ToString());
        }
    }
}