using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLibrary
{
    class UShortGenerator : IValueGenerator
    {
        public object Generate()
        {
            ushort result;

            do
            {
                result = (ushort)Randomizer.random.Next();
            }
            while (result == default(ushort));

            return result;
        }
    }
}
