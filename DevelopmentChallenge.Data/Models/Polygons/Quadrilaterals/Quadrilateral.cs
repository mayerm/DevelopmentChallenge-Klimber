using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Data.Models.Polygons
{
    public abstract class Quadrilateral : Polygon
    {
        virtual public decimal Side4 { get; set; }
    }
}
