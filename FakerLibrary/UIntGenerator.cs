using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLibrary
{
    class UIntGenerator : IValueGenerator
    {
        public object Generate()
        {
            return (uint)Randomizer.random.Next();
        }
    }
}
