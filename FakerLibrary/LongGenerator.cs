using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLibrary
{
    class LongGenerator : IValueGenerator
    {
        public object Generate()
        {
            return (long)Randomizer.random.Next();
        }
    }
}
