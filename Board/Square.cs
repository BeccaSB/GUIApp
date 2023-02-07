using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board
{
    public class Square
    {
        public int Horizontal { get; set; }
        public int Vertical { get; set; }

        public bool Occupied { get; set; }
        public bool ValidMove { get; set; }

        public Square( int x, int y)
        {
            Horizontal = x; Vertical = y;
        }
    }
}

