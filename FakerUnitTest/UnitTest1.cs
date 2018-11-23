using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FakerLibrary;
using System.Collections.Generic;

namespace FakerUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private Faker faker = new Faker();

        [TestMethod]
        public void ObjectGeneratorTest()
        {
            Object obj = faker.Create<object>();
            Assert.IsTrue(obj != null);
        }

        [TestMethod]
        public void CharGeneratorTest()
        {
            Char obj = faker.Create<char>();
            Assert.IsTrue((byte)obj > 0 && (byte)obj <= 255);
        }

        [TestMethod]
        public void ByteGeneratorTest()
        {
            Byte obj = faker.Create<byte>();
            Assert.IsTrue(obj != default(byte) && byte.MinValue <= obj && byte.MaxValue >= obj);
        }

        [TestMethod]
        public void SByteGeneratorTest()
        {
            SByte obj = faker.Create<sbyte>();
            Assert.IsTrue(obj != default(sbyte) && sbyte.MinValue <= obj && sbyte.MaxValue >= obj);
        }

        [TestMethod]
        public void IntGeneratorTest()
        {
            int obj = faker.Create<int>();
            Assert.IsTrue(obj != default(int) && int.MinValue <= obj && int.MaxValue >= obj);
        }

        [TestMethod]
        public void UIntGeneratorTest()
        {
            uint obj = faker.Create<uint>();
            Assert.IsTrue(obj != default(uint) && uint.MinValue <= obj && uint.MaxValue >= obj);
        }

        [TestMethod]
        public void ShortGeneratorTest()
        {
            short obj = faker.Create<short>();
            Assert.IsTrue(obj != default(short) && short.MinValue <= obj && short.MaxValue >= obj);
        }

        [TestMethod]
        public void UShortGeneratorTest()
        {
            ushort obj = faker.Create<ushort>();
            Assert.IsTrue(obj != default(ushort) && ushort.MinValue <= obj && ushort.MaxValue >= obj);
        }

        [TestMethod]
        public void LongGeneratorTest()
        {
            long obj = faker.Create<long>();
            Assert.IsTrue(obj != default(long) && long.MinValue <= obj && long.MaxValue >= obj);
        }

        [TestMethod]
        public void ULongGeneratorTest()
        {
            ulong obj = faker.Create<ulong>();
            Assert.IsTrue(obj != default(ulong) && ulong.MinValue <= obj && ulong.MaxValue >= obj);
        }

        [TestMethod]
        public void DecimalGeneratorTest()
        {
            decimal obj = faker.Create<decimal>();
            Assert.IsTrue(obj != default(decimal) && decimal.MinValue <= obj && decimal.MaxValue >= obj);
        }

        [TestMethod]
        public void FloatGeneratorTest()
        {
            float obj = faker.Create<float>();
            Assert.IsTrue(obj != default(float) && float.MinValue <= obj && float.MaxValue >= obj);
        }

        [TestMethod]
        public void DoubleGeneratorTest()
        {
            double obj = faker.Create<double>();
            Assert.IsTrue(obj != default(double) && double.MinValue <= obj && double.MaxValue >= obj);
        }

        [TestMethod]
        public void DateGeneratorTest()
        {
            DateTime empty = new DateTime();
            DateTime obj = faker.Create<DateTime>();
            Assert.IsTrue(obj != empty);
        }

        [TestMethod]
        public void StringGeneratorTest()
        {
            String obj = faker.Create<string>();
            Assert.IsTrue(obj != null && obj != String.Empty);
        }
    }
}
