using System;

namespace TicTacToe
{

    class Juego
    {
        private int[,] numeros;

        public void Cargar()
        {
            numeros = new int[3, 3];
            int contador = 1;

            for (int i = 0; i < numeros.GetLength(0); i++)
            {
                for (int f = 0; f < numeros.GetLength(1); f++)
                {
                    numeros[i, f] = contador;
                    contador++;
                }
            }
        }

        public void Imprimir()
        {
            for (int i = 0; i < numeros.GetLength(0); i++)
            {
                for (int f = 0; f < numeros.GetLength(1); f++)
                {
                    if (numeros[i, f] == 10)
                    {
                        Console.Write(" x ");
                    }
                    else if (numeros[i, f] == 20)
                    {
                        Console.Write(" o ");
                    }
                    else
                    {
                        Console.Write(" {0} ", numeros[i, f]);
                    }
                }

                if (i < 2)
                {
                    Console.WriteLine();
                    Console.WriteLine("----------");
                }
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        public void Jugar()
        {
            int turno = 1;
            int casillero;
            bool[] seleccionados1 = new bool[9];
            bool[] seleccionados2 = new bool[9];
            string partida = "";

            // se solicita elejir un casillero
            // el casillero que se selecciona queda marcado
            if (turno == 1)
            {
                Console.WriteLine("Jugador 1 ingrese un casillero...");
                casillero = int.Parse(Console.ReadLine());
                seleccionados1[casillero - 1] = true;
            }
            else
            {
                Console.WriteLine("Jugador 2 ingrese un casillero...");
                casillero = int.Parse(Console.ReadLine());
                seleccionados2[casillero - 1] = true;
            }

            // se marca el casillero seleccionado por el jugador
            // y se cambia de turno
            for (int i = 0; i < numeros.GetLength(0); i++)
            {
                for (int f = 0; f < numeros.GetLength(1); f++)
                {
                    if (numeros[i, f] == casillero)
                    {
                        if (turno == 1)
                        {
                            numeros[i, f] = 10;
                            turno = 2;
                        }
                        else
                        {
                            numeros[i, f] = 20;
                            turno = 1;
                        }
                    }
                }
            }

            Console.Clear();
            Imprimir();

            for (int i = 0; i < seleccionados1.Length; i++)
            {
                if (
                    (
                        seleccionados1[0] && seleccionados1[1] && seleccionados1[2]
                        || seleccionados1[3] && seleccionados1[4] && seleccionados1[5]
                        || seleccionados1[6] && seleccionados1[7] && seleccionados1[8]
                        || seleccionados1[0] && seleccionados1[3] && seleccionados1[6]
                        || seleccionados1[1] && seleccionados1[4] && seleccionados1[7]
                        || seleccionados1[2] && seleccionados1[5] && seleccionados1[8]
                        || seleccionados1[0] && seleccionados1[4] && seleccionados1[8]
                        || seleccionados1[2] && seleccionados1[4] && seleccionados1[6]
                    )
                    ||
                    (
                        seleccionados2[0] && seleccionados2[1] && seleccionados2[2]
                        || seleccionados2[3] && seleccionados2[4] && seleccionados2[5]
                        || seleccionados2[6] && seleccionados2[7] && seleccionados2[8]
                        || seleccionados2[0] && seleccionados2[3] && seleccionados2[6]
                        || seleccionados2[1] && seleccionados2[4] && seleccionados2[7]
                        || seleccionados2[2] && seleccionados2[5] && seleccionados2[8]
                        || seleccionados2[0] && seleccionados2[4] && seleccionados2[8]
                        || seleccionados2[2] && seleccionados2[4] && seleccionados2[6]
                    )
                   )
                {
                    partida = "terminada";
                }
            }

            if (partida == "terminada")
            {
                Console.WriteLine("Felicitaciones! Ha ganado el jugador {0}", turno);
                Console.WriteLine("Presione cualquier tecla para reiniciar el juego");
                Console.ReadKey();
                Console.Clear();
                Cargar();
                Imprimir();
                Jugar();
            }
            else if (partida == "empate")
            {
                Console.WriteLine("La partida ha terminado en empate!");
                Console.WriteLine("Presione cualquier tecla para reiniciar el juego");
                Console.ReadKey();
                Console.Clear();
                Cargar();
                Imprimir();
                Jugar();
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                Juego tictactoe = new Juego();
                tictactoe.Cargar();
                tictactoe.Imprimir();
                tictactoe.Jugar();


            }
        }
    }
}