using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLibrary
{
    class DecimalGenerator : IValueGenerator
    {
        public object Generate()
        {
            return (decimal)Randomizer.random.Next();
        }
    }
}
