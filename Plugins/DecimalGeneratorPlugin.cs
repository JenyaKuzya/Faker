﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakerLibrary;

namespace Plugins
{
    class DecimalGeneratorPlugin : IPlugin
    {
        public Type GeneratedType
        { get; private set; }

        public object Generate()
        {
            return Randomizer.random.Next();
        }

        public DecimalGeneratorPlugin()
        {
            GeneratedType = typeof(double);
        }
    }
}
