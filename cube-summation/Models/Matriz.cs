namespace cube_summation.Models
{
    /// <summary>
    /// Representa la matriz que se utilizara en el proceso.
    /// </summary>
    public class Matriz
    {
        /// <summary>
        /// Obtiene o establece el tamaño de la matriz.
        /// </summary>
        public int tamaño;

        /// <summary>
        /// Obtiene o establece el contenido de la matriz.
        /// </summary>
        public int[,,] contenidoMatriz;

        /// <summary>
        /// Constructor de la matriz.
        /// </summary>
        /// <param name="tamaño">Número que indica el tamaño de la matriz.</param>
        public Matriz(int tamaño)
        {
            this.tamaño = tamaño;
            ConstruirMatriz();

        }

        /// <summary>
        /// Construtor de la matriz.
        /// </summary>
        private void ConstruirMatriz()
        {
            contenidoMatriz = new int[tamaño, tamaño, tamaño];
        }
    }
}