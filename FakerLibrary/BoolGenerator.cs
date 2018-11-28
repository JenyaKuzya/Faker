using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLibrary
{
    class BoolGenerator : IValueGenerator
    {
        public object Generate()
        {
            bool result;

            do
            {
                result = Randomizer.random.Next(100) < 50;
            }
            while (result == default(bool));

            return result;
        }
    }
}
