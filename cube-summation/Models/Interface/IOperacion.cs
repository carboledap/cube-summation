using System.Collections.Generic;

namespace cube_summation.Models.Interface
{
    /// <summary>
    /// Interfase para la creación de las operaciones que puedan existir en el sistema.
    /// </summary>
    public interface IOperacion
    {
        void EjecutarOperacion(List<string> informacionOperacion, Matriz matriz, List<string> resultadoOperacion);
    }
}
