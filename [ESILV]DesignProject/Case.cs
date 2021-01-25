using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _ESILV_DesignProject
{
    public abstract class Case
    {
        public string name;
        private int index;
        private Case next;
        private Case previous;

        public Case(int index)
        {
            this.index = index;
        }

        public String Name
        {
            get { return name; }
        }

        public int Index
        {
            get { return index; }
        }

        public Case Next
        {
            get { return next; }
            set { next = value; }
        }

        public Case Previous
        {
            get { return previous; }
            set { previous = value; }
        }

        public abstract string Action();

    }

    public class Default : Case
    {
        public Default(int index) : base(index) 
        {
            base.name = "Default";
        }

        public override string Action()
        {
            return "";
        }

    }

    public class GoToJail : Case
    {
        public GoToJail(int index) : base(index) 
        {
            base.name = "Go to jail";
        }

        public override string Action()
        {
            return "Go to jail!";
        }

    }

    public class Jail : Case
    {
        public Jail(int index) : base(index)
        {
            base.name = "Jail";
        }

        public override string Action()
        {
            return "Just Visiting!";
        }
    }
}

