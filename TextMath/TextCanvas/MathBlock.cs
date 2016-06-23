using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace TextCanvas
{
    public class MathBlock : Block
    {

        private List<Block> children=new List<Block>();

     


        public List<Block> Children  
        {
            get { return children; }
            set { children = value; }
        }

        public override void Draw( WorkPanel workPanel, Point parentPosition)
        {
           
        }

        public override double GetHeight()
        {
            throw new NotImplementedException();
        }

        public override double GetPosition()
        {
            throw new NotImplementedException();
        }

        public override double GetWidth()
        {
            throw new NotImplementedException();
        }
    }
}
