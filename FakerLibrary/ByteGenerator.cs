using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLibrary
{
    class ByteGenerator : IValueGenerator
    {
        public object Generate()
        {
            byte result;

            do
            {
                result = (byte)Randomizer.random.Next();
            }
            while (result == default(byte));

            return result;
        }
    }
}
