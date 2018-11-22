﻿using System;
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
            return (ulong)Randomizer.random.Next();
        }
    }
}
