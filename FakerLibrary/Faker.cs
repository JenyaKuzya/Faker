using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace FakerLibrary
{
    public class Faker : IFaker
    {
        private Dictionary<Type, IValueGenerator> baseTypesGenerators;
        private ListGenerator listGenerator;
        private List<Type> generatedTypes;
        private static Assembly asm;

        public Faker()
        {
            generatedTypes = new List<Type>();

            asm = Assembly.LoadFrom("Plugins\\Plugins.dll");

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

            // плагины
            var types = asm.GetTypes().Where(t => t.GetInterfaces().Where(i => i == typeof(IPlugin)).Any());

            foreach (var type in types)
            {
                var plugin = asm.CreateInstance(type.FullName) as IPlugin;
                if (!baseTypesGenerators.ContainsKey(plugin.GeneratedType))
                    baseTypesGenerators.Add(plugin.GeneratedType, plugin);
            }
        }

        public T Create<T>()
        {
            return (T)Create(typeof(T));
        }

        public object Create(Type t)
        {
            // получение параметров конструктора
            ConstructorInfo[] constructorInfo = t.GetConstructors();
            ParameterInfo[] parameterInfo;
            ConstructorInfo parametrizedConstructor = null;

            // проверка конструктора на приватность
            if (constructorInfo.Length == 0)
            {
                return null;
            }

            // выбор конструктора с наибольшим числом параметров
            int maxConstructorFieldsCount = 0;
            foreach (ConstructorInfo info in constructorInfo)
            {
                parameterInfo = info.GetParameters();
                if (parameterInfo.Length > maxConstructorFieldsCount)
                {
                    maxConstructorFieldsCount = parameterInfo.Length;
                    parametrizedConstructor = info;
                }
            }

            // создание объекта
            object obj;
            if (parametrizedConstructor != null)
            {
                // по конструктору
                obj = CreateByConstructor(t, parametrizedConstructor);
            }
            else
            {
                // по public полям
                obj = CreateByPublicFields(t);
            }

            return obj;
        }

        private object CreateByConstructor(Type t, ConstructorInfo constructor)
        {
            // создание объекта по конструктору
            object[] tmp = new object[constructor.GetParameters().Length];
            int i = 0;

            // заполнение параметров
            foreach (ParameterInfo pi in constructor.GetParameters())
            {
                tmp[i] = GenerateValue(pi.ParameterType);
                i++;
            }

            return constructor.Invoke(tmp);
        }

        private object CreateByPublicFields(Type t)
        {
            object tmp = Activator.CreateInstance(t); ;

            FieldInfo[] fieldInfo = t.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            PropertyInfo[] propertyInfo = t.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

            // заполнение полей
            foreach (FieldInfo info in fieldInfo)
                info.SetValue(tmp, GenerateValue(info.FieldType));

            // заполнение свойств
            foreach (PropertyInfo info in propertyInfo)
            {
                if (info.CanWrite)
                    info.SetValue(tmp, GenerateValue(info.PropertyType));
            }

            return tmp;
        }

        private object GenerateValue(Type type)
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
            else if (type.IsClass && !type.IsGenericType && !type.IsArray && !type.IsPointer && !type.IsAbstract && !generatedTypes.Contains(type))
            {
                generatedTypes.Add(type);

                generatedObject = Create(type);

                generatedTypes.RemoveAt(generatedTypes.Count - 1);
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
