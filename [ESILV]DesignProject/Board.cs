using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _ESILV_DesignProject
{
    public class Board
    {
        private Board()
        {
            defaultSetup();
            setLinks();
            start = cases.ElementAt(0);
        }

        public static Board getInstance()
        {
            if (instance == null)
                instance = new Board();
            return instance;
        }

        private static Board instance;

        private Case start;
        private List<Case> cases = new List<Case>();
        public Dice dice = new Dice();

        public Case Start
        {
            get { return start; }
        }

        private void defaultSetup()
        {
            for (int i = 0; i < 40; i++)
            {
                Case c = null;
                if (i == 10)
                {
                    c = new Jail(10);
                }
                else if (i == 30)
                {
                    c = new GoToJail(30);
                }
                else
                {
                    c = new Default(i);
                }
                cases.Add(c);
            }
        }

        private void setLinks()
        {
            int n = cases.Count;
            cases.ElementAt(n - 1).Next = cases.ElementAt(0);
            for (int i = 0; i < n - 1; i++)
            {
                cases.ElementAt(i).Next = cases.ElementAt(i + 1);
            }
            cases.ElementAt(0).Previous = cases.ElementAt(n - 1);
            for (int i = n - 1; i > 0; i--)
            {
                cases.ElementAt(i).Previous = cases.ElementAt(i - 1);
            }
        }

        public Case forward(Case from, int value)
        {
            Case res = from;
            for (int i = 0; i < value; i++)
            {
                res = res.Next;
            }
            return res;
        }

        public Case search(Case from, string name)
        {
            Case res = from;
            for (int i = 0; i < cases.Count; i++)
            {
                res = res.Next;
                if (res.Name == name)
                {
                    return res;
                }
            }
            return res;
        }
    }
}
