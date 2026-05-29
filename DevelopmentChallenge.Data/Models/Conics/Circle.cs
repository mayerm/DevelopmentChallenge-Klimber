using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Models.Conics
{
    public class Circle : Conics
    {
        public override decimal Height { get => base.Height; set => base.Height = base.Base; }
        public override decimal CalculateArea()
        {
            return (decimal)Math.PI * (Base/2) * (Base/2) ;
        }

        public override decimal CalculatePerimeter()
        {
            return (decimal)Math.PI * Base;
        }

        public Circle(decimal b)
        {
            this.Base = b;
        }
    }
}
