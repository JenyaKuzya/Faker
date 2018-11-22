using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLibrary
{
    class StringGenerator : IValueGenerator
    {
        public object Generate()
        {
            string result = "";
            ByteGenerator byteGenerator = new ByteGenerator();
            CharGenerator charGenerator = new CharGenerator();

            byte stringSize = (byte)byteGenerator.Generate();

            for (int i = 0; i < stringSize; i++)
            {
                result = result + charGenerator.Generate();
            }

            return result;
        }
    }
}
