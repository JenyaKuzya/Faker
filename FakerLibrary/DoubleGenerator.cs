using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLibrary
{
    class DoubleGenerator : IValueGenerator
    {
        public object Generate()
        {
            double result;

            do
            {
                result = Randomizer.random.NextDouble();
            }
            while (result == default(double));

            return result;

        }
    }
}
