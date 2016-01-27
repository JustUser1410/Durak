using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BattleShipClient
{
    class Cell
    {
        public Point P;
        public Image Image;

        public Cell(Point p, Image image)
        {
            Image = image;
            P = p;
        }

        public Cell getCell()
        {
            return this;
        }
    }
}
