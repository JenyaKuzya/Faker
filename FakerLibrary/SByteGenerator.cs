using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLibrary
{
    class SByteGenerator : IValueGenerator
    {
        public object Generate()
        {
            return (sbyte)Randomizer.random.Next();
        }
    }
}
