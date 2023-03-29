using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteCandidatoTriangulo
{
    public class Triangulo
    {
        /// <summary>
        ///    6
        ///   3 5
        ///  9 7 1
        /// 4 6 8 4
        /// Um elemento somente pode ser somado com um dos dois elementos da próxima linha. Como o elemento 5 na Linha 2 pode ser somado com 7 e 1, mas não com o 9.
        /// Neste triangulo o total máximo é 6 + 5 + 7 + 8 = 26
        /// 
        /// Seu código deverá receber uma matriz (multidimensional) como entrada. O triângulo acima seria: [[6],[3,5],[9,7,1],[4,6,8,4]]
        /// </summary>
        /// <param name="dadosTriangulo"></param>
        /// <returns>Retorna o resultado do calculo conforme regra acima</returns>
        public int ResultadoTriangulo(string dadosTriangulo)
        {
            List<List<int>> matriz = new List<List<int>>();

            if (dadosTriangulo == string.Empty)
                return 0;

            matriz = ConvertData(dadosTriangulo);

            return ResultCalc(matriz);
        }

        public List<List<int>> ConvertData(string line)
        {
            List<List<int>> matriz = new List<List<int>>();

            var data = line.Split(']');

            foreach (var item in data)
            {
                if (item == string.Empty)
                    break;

                string position = item.Remove(0, 2);
                List<int> positionList = position.Split(',').Select(Int32.Parse).ToList<int>();
                matriz.Add(positionList);
            }
            return matriz; 
        }
    
        public int ResultCalc(List<List<int>> matriz)
        {
            int soma = 0;
            int index = 0;

            for (int i = 0; i < matriz.Count; i++)
            {
                if (i == 0)
                    soma += matriz[i][i];
                else
                {
                    if (matriz[i][index] > matriz[i][index + 1])
                    {
                        soma += matriz[i][index];
                    }
                    else
                    {
                        soma += matriz[i][index + 1];
                        index += 1;
                    }
                }
            }
            return soma;
        }
    
    }


}
