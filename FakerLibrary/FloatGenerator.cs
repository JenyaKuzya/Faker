using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLibrary
{
    class FloatGenerator : IValueGenerator
    {
        public object Generate()
        {
            float result;

            do
            {
                result = (float)Randomizer.random.NextDouble();
            }
            while (result == default(float));

            return result;
        }
    }
}
