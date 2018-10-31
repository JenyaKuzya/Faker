using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLibrary
{
    public class Faker : IFaker
    {
        public Faker()
        {

        }

        public T Create<T>()
        {
            return (T)Create(typeof(T));
        }

        private object Create(Type type)
        {
            object generatedItem;

            if (baseTypesGenerators.TryGetValue(type, out IBaseTypeGenerator baseTypeGenerator))
            {
                generated = baseTypeGenerator.Generate();
            }
            else if (type.IsGenericType && genericTypesGenerators.TryGetValue(type.GetGenericTypeDefinition(), out IGenericTypeGenerator genericTypeGenerator))
            {
                generated = genericTypeGenerator.Generate(type.GenericTypeArguments[0]);
            }
            else if (type.IsArray && arraysGenerators.TryGetValue(type.GetArrayRank(), out IArrayGenerator arrayGenerator))
            {
                generated = arrayGenerator.Generate(type.GetElementType());
            }
            else if (type.IsClass && !type.IsGenericType && !type.IsArray && !type.IsPointer && !type.IsAbstract && !generatedTypes.Contains(type))
            {
            }

        }
    }
}
