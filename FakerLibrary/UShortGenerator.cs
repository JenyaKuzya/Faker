﻿using System;
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
            return (ushort)Randomizer.random.Next();
        }
    }
}
