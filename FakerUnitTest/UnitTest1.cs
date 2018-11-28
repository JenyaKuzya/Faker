using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FakerLibrary;
using System.Collections.Generic;

namespace FakerUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private Faker faker;
        private Foo foo;
        private Bar bar;
        private EmptyConstructor emptyConstructor;

        [TestInitialize]
        public void SetUp()
        {
            faker = new Faker();
            foo = faker.Create<Foo>();
            bar = faker.Create<Bar>();
            emptyConstructor = faker.Create<EmptyConstructor>();
        }

        public class Foo
        {
            private object _object;

            private char _char;

            private bool _bool;

            private byte _byte;

            private sbyte _sbyte;

            private int _int;

            private uint _uint;

            private short _short;

            private ushort _ushort;

            private long _long;

            private ulong _ulong;

            private decimal _decimal;

            private float _float;

            private double _double;

            private DateTime _date;

            private string _string;

            private List<short> _list;

            private Bar _bar;

            public int justSimpleField;

            public object GetObject()
            {
                return _object;
            }

            public char GetChar()
            {
                return _char;
            }

            public bool GetBool()
            {
                return _bool;
            }

            public byte GetByte()
            {
                return _byte;
            }

            public sbyte GetSByte()
            {
                return _sbyte;
            }

            public int GetInt()
            {
                return _int;
            }

            public uint GetUInt()
            {
                return _uint;
            }

            public short GetShort()
            {
                return _short;
            }

            public ushort GetUShort()
            {
                return _ushort;
            }

            public long GetLong()
            {
                return _long;
            }

            public ulong GetULong()
            {
                return _ulong;
            }

            public decimal GetDecimal()
            {
                return _decimal;
            }

            public float GetFloat()
            {
                return _float;
            }

            public double GetDouble()
            {
                return _double;
            }

            public DateTime GetDate()
            {
                return _date;
            }

            public string GetString()
            {
                return _string;
            }

            public List<short> GetList()
            {
                return _list;
            }

            public Bar GetBar()
            {
                return _bar;
            }

            public Foo(object o, char c, bool b, byte by, sbyte sby, int i, uint ui, short s, ushort us, long l, ulong ul,
                decimal d, float f, double dob, DateTime dt, string str, List<short> list, Bar bar)
            {
                _object = o;
                _char = c;
                _bool = b;
                _byte = by;
                _sbyte = sby;
                _int = i;
                _uint = ui;
                _short = s;
                _ushort = us;
                _long = l;
                _ulong = ul;
                _decimal = d;
                _float = f;
                _double = dob;
                _date = dt;
                _string = str;
                _list = list;
                _bar = bar;
            }            
        }

        public class Bar
        {
            public object _object;

            public char _char;

            public bool _bool;

            public byte _byte;

            public sbyte _sbyte;

            public int _int;

            public uint _uint;

            public short _short;

            public ushort _ushort;

            public long _long;

            public ulong _ulong;

            public decimal _decimal;

            public float _float;

            public double _double;

            public DateTime _date;

            public string _string;

            public List<short> _list;

            public Foo _foo;
        }

        public class EmptyConstructor
        {
            private EmptyConstructor()
            {

            }

            public int emptyInt;
        }

        [TestMethod]
        public void ObjectGeneratorTest()
        {
            Assert.IsTrue(foo.GetObject() != null);
        }

        [TestMethod]
        public void CharGeneratorTest()
        {
            Assert.IsTrue((byte)foo.GetChar() > 0 && (byte)foo.GetChar() <= 255);
        }

        [TestMethod]
        public void ByteGeneratorTest()
        {
            Assert.IsTrue(foo.GetByte() != default(byte));
        }

        [TestMethod]
        public void BoolGeneratorTest()
        {
            Assert.IsTrue(foo.GetBool());
        }

        [TestMethod]
        public void SByteGeneratorTest()
        {
            Assert.IsTrue(foo.GetSByte() != default(sbyte));
        }

        [TestMethod]
        public void IntGeneratorTest()
        {
            Assert.IsTrue(foo.GetInt() != default(int));
        }

        [TestMethod]
        public void UIntGeneratorTest()
        {
            Assert.IsTrue(foo.GetUInt() != default(uint));
        }

        [TestMethod]
        public void ShortGeneratorTest()
        {
            Assert.IsTrue(foo.GetShort() != default(short));
        }

        [TestMethod]
        public void USortGeneratorTest()
        {
            Assert.IsTrue(foo.GetUShort() != default(ushort));
        }

        [TestMethod]
        public void LongGeneratorTest()
        {
            Assert.IsTrue(foo.GetLong() != default(long));
        }

        [TestMethod]
        public void ULongGeneratorTest()
        {
            Assert.IsTrue(foo.GetULong() != default(ulong));
        }

        [TestMethod]
        public void DecimalGeneratorTest()
        {
            Assert.IsTrue(foo.GetDecimal() != default(decimal));
        }

        [TestMethod]
        public void FloatGeneratorTest()
        {
            Assert.IsTrue(foo.GetFloat() != default(float));
        }

        [TestMethod]
        public void DoubleGeneratorTest()
        {
            Assert.IsTrue(foo.GetDouble() != default(double));
        }

        [TestMethod]
        public void DateGeneratorTest()
        {
            DateTime empty = new DateTime();
            Assert.IsTrue(foo.GetDate() != empty);
        }

        [TestMethod]
        public void StringGeneratorTest()
        {
            Assert.IsTrue(foo.GetString() != null && foo.GetString() != String.Empty);
        }

        [TestMethod]
        public void ListGeneratorTest()
        {
            Assert.IsTrue(foo.GetList() != null && foo.GetList() is List<short>);
        }

        [TestMethod]
        public void BarGeneratorTest()
        {
            Assert.IsTrue(foo.GetBar() != null && foo.GetBar()._string != null && foo.GetBar()._string != String.Empty);
        }

        [TestMethod]
        public void EmptyConstructorGeneratorTest()
        {
            Assert.AreEqual(emptyConstructor, null);
        }

        [TestMethod]
        public void ReurciveGeneratorTest()
        {
            // 1 уровень рекурсии
            Assert.IsTrue(foo.GetBar() != null && foo.GetBar()._foo != null);
            Assert.IsTrue(bar._foo != null && bar._foo.GetBar() != null);

            // 2 уровень рекурсии
            Assert.IsTrue(foo.GetBar()._foo.GetBar() == null);
            Assert.IsTrue(bar._foo.GetBar()._foo == null);
        }
    }
}
