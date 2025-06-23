/*
namespace Estructuras_de_Datos.Examples.Exams
{
    public interface ITDA
    {
        void Inicializar();
        void AgregarPuntaje(int p1, int p2);
        int CalcularGanador();
        bool TDAVacio();
        bool TDALleno();
        void TDAImprimir();
    }
    
    public class TDAGame : ITDA
    {
        private int[] elements;
        private int maxCapacity;
        private int indiceP1;
        private int indiceP2;
        private const int CAPACITY = 10;
        private const int MAX_ROUNDS = 5;

        public void Inicializar()
        {
            maxCapacity = CAPACITY;
            elements = new int[maxCapacity];
            indiceP1 = 0;
            indiceP2 = maxCapacity - 1;
            
            for (int i = 0; i < maxCapacity; i++)
            {
                elements[i] = 0;
            }
        }

        public void AgregarPuntaje(int p1, int p2)
        {
            if (TDALleno())
                return;

            elements[indiceP1] = p1;
            elements[indiceP2] = p2;
            
            indiceP1++;
            indiceP2--;
        }

        public int CalcularGanador()
        {
            if (!CanCalculateWinner())
                return 0;

            int victoryP1 = 0;
            int victoryP2 = 0;
            
            for (int i = 0; i < MAX_ROUNDS; i++)
            {
                int puntajeP1 = elements[i];
                int puntajeP2 = elements[maxCapacity - 1 - i];
                
                if (puntajeP1 > puntajeP2)
                    victoryP1++;
                else if (puntajeP2 > puntajeP1)
                    victoryP2++;
            }
            
            if (victoryP1 > victoryP2) return 1;
            if (victoryP2 > victoryP1) return 2;
            return 0;
        }

        public bool TDAVacio()
        {
            return indiceP1 == 0 && indiceP2 == maxCapacity - 1;
        }

        public bool TDALleno()
        {
            return indiceP1 > indiceP2;
        }

        public void TDAImprimir()
        {
            if (TDAVacio())
            {
                Console.WriteLine("Game is empty");
                return;
            }
            
            Console.Write("Elements: [");
            for (int i = 0; i < maxCapacity; i++)
            {
                Console.Write(elements[i]);
                if (i < maxCapacity - 1)
                    Console.Write(", ");
            }
            Console.WriteLine("]");
            
            if (!TDAVacio())
            {
                Console.Write("Player 1 scores: ");
                for (int i = 0; i < indiceP1; i++)
                {
                    Console.Write($"elements[{i}]={elements[i]} ");
                }
                Console.WriteLine();
                
                Console.Write("Player 2 scores: ");
                for (int i = maxCapacity - 1; i > indiceP2; i--)
                {
                    Console.Write($"elements[{i}]={elements[i]} ");
                }
                Console.WriteLine();
            }
        }

        private bool CanCalculateWinner()
        {
            return GetRoundsPlayed() == MAX_ROUNDS;
        }

        private int GetRoundsPlayed()
        {
            if (TDAVacio())
                return 0;
            return indiceP1;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            TDAGame game = new TDAGame();
            
            Console.WriteLine("=== GAME TDA ===");
            Console.WriteLine();

            InteractiveTest(game);
        }
        
        static void InteractiveTest(TDAGame game)
        {
            game.Inicializar();

            for (int round = 1; round <= 5; round++)
            {
                if (game.TDALleno())
                {
                    Console.WriteLine("Game is full!");
                    break;
                }

                Console.WriteLine($"\nRound {round}:");
                Console.Write("  Player 1 score: ");
                if (!int.TryParse(Console.ReadLine(), out int player1Score))
                {
                    player1Score = 0;
                }

                Console.Write("  Player 2 score: ");
                if (!int.TryParse(Console.ReadLine(), out int player2Score))
                {
                    player2Score = 0;
                }

                game.AgregarPuntaje(player1Score, player2Score);
                game.TDAImprimir();
            }

            Console.WriteLine("\nFINAL RESULTS:");
            int finalWinner = game.CalcularGanador();
            
            switch (finalWinner)
            {
                case 1:
                    Console.WriteLine("WINNER: Player 1");
                    break;
                case 2:
                    Console.WriteLine("WINNER: Player 2");
                    break;
                case 0:
                    Console.WriteLine("TIE");
                    break;
            }

            game.TDAImprimir();
            Console.ReadKey();
        }
    }
}
*/