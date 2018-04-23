using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cube_summation.Framework
{
    public class Cordenadas
    {
        public static List<int> AsignarCordenadas(List<string> valoresOperacion)
        {
            List<int> cordenadas = new List<int>(3);

            for (int i = 0; i < 3; i++)
            {
                cordenadas.Add(int.Parse(valoresOperacion[i]));
            }

            return cordenadas;
        }
    }
}