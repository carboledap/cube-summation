using System.Collections.Generic;

namespace cube_summation.Models
{
    /// <summary>
    /// Contine una lista de secuencias de operaciones que se deben ejecutar.<
    /// </summary>
    public class InformacionSecuenciaOperacion
    {
        /// <summary>
        /// Obtiene o establece las secuencias de las operaciones.
        /// </summary>
        public List<string> ValoresOperacion { get; set; }
    }
}