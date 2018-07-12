using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CircleMvp.Models
{
    public class Circle : ICircle
    {
        public double GetArea(double radius) => Math.PI * radius * radius;
    }
}