using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLibrary
{
    class BoolGenerator : IValueGenerator
    {
        public object Generate()
        {
            return Randomizer.random.Next(100) < 50;
        }
    }
}
