using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLibrary
{
    public class Faker : IFaker
    {
        private Dictionary<Type, IValueGenerator> baseTypesGenerators;
        private ListGenerator listGenerator;

        public Faker()
        {
            baseTypesGenerators = new Dictionary<Type, IValueGenerator>
            {
                { typeof(object), new ObjectGenerator() },
                { typeof(char), new CharGenerator() },
                { typeof(bool), new BoolGenerator() },
                { typeof(byte), new ByteGenerator() },
                { typeof(sbyte), new SByteGenerator() },
                { typeof(int), new IntGenerator() },
                { typeof(uint), new UIntGenerator() },
                { typeof(short), new ShortGenerator() },
                { typeof(ushort), new UShortGenerator() },
                { typeof(long), new LongGenerator() },
                { typeof(ulong), new ULongGenerator() },
                { typeof(decimal), new DecimalGenerator() },
                { typeof(float), new FloatGenerator() },
                { typeof(double), new DoubleGenerator() },
                { typeof(DateTime), new DateGenerator() },
                { typeof(string), new StringGenerator() }
            };

            listGenerator = new ListGenerator(baseTypesGenerators);
        }

        public T Create<T>()
        {
            return (T)Create(typeof(T));
        }

        private object Create(Type type)
        {
            object generatedObject;
            IValueGenerator baseTypeGenerator;

            if (baseTypesGenerators.TryGetValue(type, out baseTypeGenerator))
            {
                generatedObject = baseTypeGenerator.Generate();
            }
            else if (type.IsGenericType)  // list
            {
                generatedObject = listGenerator.Generate(type.GenericTypeArguments[0]);
            }
            else if (type.IsClass && !type.IsGenericType && !type.IsArray && !type.IsPointer && !type.IsAbstract)
            {
                generatedObject = Create(type);
            }
            else if (type.IsValueType)
            {
                generatedObject = Activator.CreateInstance(type);
            }
            else
            {
                generatedObject = null;
            }

            return generatedObject;
        }
    }
}
