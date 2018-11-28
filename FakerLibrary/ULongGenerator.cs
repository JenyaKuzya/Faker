using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLibrary
{
    class ULongGenerator : IValueGenerator
    {
        public object Generate()
        {
            ulong result;

            do
            {
                result = (ulong)Randomizer.random.Next();
            }
            while (result == default(ulong));

            return result;
        }
    }
}
