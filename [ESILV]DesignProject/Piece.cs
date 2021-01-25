using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _ESILV_DesignProject
{
    public class Piece
    {
        private Case location;

        public Piece(Case location)
        {
            this.location = location;
        }

        public Case Location
        {
            get { return location; }
            set { location = value; }
        }
    }
}
