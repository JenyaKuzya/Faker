using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLibrary
{
    class IntGenerator : IValueGenerator
    {
        public object Generate()
        {
            int result;

            do
            {
                result = Randomizer.random.Next();
            }
            while (result == default(int));

            return result;
        }
    }
}
