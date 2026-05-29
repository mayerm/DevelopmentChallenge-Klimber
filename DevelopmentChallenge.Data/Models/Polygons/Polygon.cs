using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Models.Polygons
{
    public abstract class Polygon : GeometricForm
    {
        virtual public decimal Side2 { get; set; }
        virtual public decimal Side3 { get; set; }

    }
}
