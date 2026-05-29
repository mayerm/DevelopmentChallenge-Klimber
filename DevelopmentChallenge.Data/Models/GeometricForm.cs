using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Models
{
    public abstract class GeometricForm
    {
        protected internal decimal Base { get; set; }

        public virtual decimal Height { get; set; }


        public abstract decimal CalculatePerimeter();
        public abstract decimal CalculateArea();


    }
}
