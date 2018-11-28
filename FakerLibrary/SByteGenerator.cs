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
            sbyte result;

            do
            {
                result = (sbyte)Randomizer.random.Next();
            }
            while (result == default(sbyte));

            return result;
        }
    }
}
