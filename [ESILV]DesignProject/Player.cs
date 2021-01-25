using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _ESILV_DesignProject
{
    public class Player
    {
        private String name;
        private Piece piece;
        private Board board;
        private Dice dice;
        private Player next;
        private bool prisoner;
        private int jailTime;

        public String Name
        {
            get { return name; }
        }

        public Player Next
        {
            get { return next; }
            set { next = value; }
        }

        public Piece Piecee
        {
            get { return piece; }
            set { piece = value; }
        }

        public Player(String name, Board board)
        {
            this.name = name;
            this.board = board;
            piece = new Piece(board.Start);
            prisoner = false;
            jailTime = 0;
            dice = board.dice;
        }

        public void takeTurn()
        {
            Console.WriteLine(Name + " plays :");
            int rollTotal = 0;
            int rolls = 0;
            bool doublee;
            if(jailTime == 3)
            {
                prisoner = false;
                jailTime = 0;
            }
            if (prisoner)
            {
                dice.roll();
                Console.Write("Rolled " + rollTotal + " (" + dice.Values[0] + " and " + dice.Values[1] + "). ");
                if (dice.Values[0] == dice.Values[1])
                {
                    prisoner = false;
                    Console.WriteLine("Double! Out of jail");
                }
                else
                {
                    jailTime++;
                    if (jailTime == 3)
                    {
                        Console.WriteLine("Out of jail next round");
                    }
                    else
                    {
                        Console.WriteLine("Not a double, still in jail");
                    }
                }
            }
            if (!prisoner)
            {
                do
                {
                    rolls++;
                    dice.roll();
                    rollTotal = dice.Values[0] + dice.Values[1];
                    Console.Write("Rolled " + rollTotal + " (" + dice.Values[0] + " and " + dice.Values[1] + "). ");
                    doublee = (dice.Values[0] == dice.Values[1]);
                    if (rolls == 3 && doublee)
                    {
                        Console.WriteLine("Too much doubles, going to jail!");
                        piece.Location = board.search(piece.Location, "Jail");
                        prisoner = true;
                    }
                    if (!prisoner)
                    {
                        Case newLoc = board.forward(piece.Location, rollTotal);
                        piece.Location = newLoc;
                        Console.WriteLine("Arrived on case " + piece.Location.Name + " (" + piece.Location.Index + ")");
                        caseAction();
                    }
                } while (doublee && !prisoner);
            }
        }

        public Case getLocation()
        {
            return piece.Location;
        }

        public void caseAction()
        {
            string action = piece.Location.Action();
            if(action != "")
            {
                Console.WriteLine(action);

                if (action == "Go to jail!")
                {
                    piece.Location = board.search(piece.Location, "Jail");
                    prisoner = true;
                    jailTime = 0;
                }
            }
            
        }
    }
}
