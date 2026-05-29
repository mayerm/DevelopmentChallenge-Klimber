using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Models.Polygons.Quadrilaterals
{
    public class Square : Quadrilateral
    {
        public override decimal Side2
        {
            get => Side2;
            set => base.Side2 = Base;
        }

        public override decimal Side3
        {
            get => Side3;
            set => base.Side3 = Base;
        }
        public override decimal Side4
        {
            get => Side4;
            set => base.Side4 = Base;
        }

        public override decimal CalculateArea()
        {
            return Base * Base;
        }

        public override decimal CalculatePerimeter()
        {
            return 4 * Base;
        }

        public Square(decimal b)
        {
            this.Base = b;
        }
    }
}
