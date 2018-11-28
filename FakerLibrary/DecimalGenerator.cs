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
            decimal result;

            do
            {
                result = (decimal)Randomizer.random.Next();
            }
            while (result == default(decimal));

            return result;
        }
    }
}
