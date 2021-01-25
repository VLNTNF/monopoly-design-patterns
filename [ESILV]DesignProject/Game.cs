using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _ESILV_DesignProject
{
    public class Game
    {
        private int N_players;
        private int N_rounds;
        private Board board = Board.getInstance();
        private List<Player> players = new List<Player>();
        private Player player;

        private void setPlayers()
        {
            for (int i = 0; i < N_players; i++)
            {
                Player p = new Player("Player " + (i + 1), board);
                players.Add(p);
            }
            players.ElementAt(N_players - 1).Next = players.ElementAt(0);
            for (int i = 0; i < N_players - 1; i++)
            {
                players.ElementAt(i).Next = players.ElementAt(i + 1);
            }
        }

        public Game(int N_players, int N_rounds)
        {
            this.N_players = N_players;
            this.N_rounds = N_rounds;
            setPlayers();
            player = players.ElementAt(0);
        }

        public void run()
        {
            Console.WriteLine("Welcome in the game of Monopoly! (press any key)\n");
            Console.ReadKey();
            for (int i = 0; i < N_rounds*2; i++)
            {
                if(i%2 == 0)
                {
                    Console.WriteLine("# Tour " + (i/2 + 1) + "\n");
                }
                playRound();
            }
            Console.WriteLine("### End of the game ###");
            Console.ReadKey();
        }

        private void playRound()
        {
            player.takeTurn();
            player = player.Next;
            Console.ReadKey();
            Console.WriteLine();
        }
    }
}
