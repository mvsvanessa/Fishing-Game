using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrecaoPescaria
{
    class Program
    {
        static bool[,] lago = new bool[MAX_LINHAS, MAX_COLUNAS];
        const int MAX_LINHAS = 5, MAX_COLUNAS = 10;
        static int num = 10;
        static void montaLago()
        {
            for (int linha = 0; linha < MAX_LINHAS; linha++)
            {
                for (int coluna = 0; coluna < MAX_COLUNAS; coluna++)
                {
                    //Console.Write("[" + linha + ", " + coluna + "]   ");
                    Console.Write("[" + lago[linha, coluna] + "]\t" );
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            //declaraçao variaveis
            Random rnd = new Random();
            int quantJogadores, quantPeixes, quantIscas;
            string[] nomeJogadores;
            int[] quantPeixesPescados;

            //Entradas
            Console.WriteLine("Insira quantidades de peixes do LAgo");
            quantPeixes = int.Parse(Console.ReadLine());
            Console.WriteLine("Insira quantidades de tentativas (Iscas)");
            quantIscas = int.Parse(Console.ReadLine());
            Console.WriteLine("Insira quantidades de jogadores");
            quantJogadores = int.Parse(Console.ReadLine());

            nomeJogadores = new string[quantJogadores];
            for (int jo = 0; jo < quantJogadores; jo++)
            {
                Console.WriteLine("Insira o nome do Jogador");
                nomeJogadores[jo] = Console.ReadLine();
            }

            //Montar Lago
            //coloca peixe no lago

            for (int peixe = 0; peixe < quantPeixes; peixe++)
            {
                int x, y;
                x = rnd.Next(MAX_LINHAS);
                y = rnd.Next(MAX_COLUNAS);
                if (!lago[x, y])   //lago[x,y] = true
                {
                    lago[x, y] = true;
                } 
                else
                {
                    peixe--;
                }
            }
            montaLago();

            //pescando 
            //int jx, jy;
            quantPeixesPescados = new int[quantJogadores];
            for (int isc = 0; isc < quantIscas; isc++)
            {
                Console.WriteLine("Tentiva " + (isc + 1) + " Boa Sorte");
                for (int jog = 0; jog < quantJogadores; jog++)
                {
                    Console.Write(nomeJogadores[jog] + " insira linha ou X entre 1 e 5: ");
                    int jx = int.Parse(Console.ReadLine());
                    Console.Write(" insira coluna ou Y entre 1 e 10: ");
                    int jy = int.Parse(Console.ReadLine());

                    if (lago[jx - 1, jy - 1])
                    {
                        Console.WriteLine("Parabens - pescou um peixe ");
                        quantPeixesPescados[jog]++;

                        //retirnado o peixe do posicao pescada
                        lago[jx - 1, jy - 1] = false;
                    }
                    else
                    {
                        Console.WriteLine("Não pegou peixe ");
                    }
                }
            }

            // pontuação final
            int mais_peixes = 0;
            string nome_vencedor = "";
            for (int posicaojogador = 0; posicaojogador < quantJogadores; posicaojogador++)
            {
                if (quantPeixesPescados[posicaojogador] > mais_peixes)
                {
                    mais_peixes = quantPeixesPescados[posicaojogador];
                    nome_vencedor = nomeJogadores[posicaojogador];
                }
            }

            if ( mais_peixes == 0)
            {
                Console.WriteLine("Ninguem pescou nada PEsqueiro Ganhou");
            } 
            else
            {
                Console.WriteLine("o Jogador Vencedor é: " + nome_vencedor);
                Console.WriteLine("Pescou: " + mais_peixes);
            }

            montaLago();
            Console.ReadKey();
        }
    }
}
