using NUnit.Framework;
using RSAl;

namespace Tests
{
    [TestFixture]
    public class MyBigIntegerTests
    {
        [Test]
        [TestCase("5", "-5", "0")]
        [TestCase("12", "-2", "10")]
        [TestCase("1000", "-10", "990")]
        [TestCase("155555", "-5", "155550")]
        [TestCase("1223324345364564563524354234536", "-2", "1223324345364564563524354234534")]
        public void SumTest(string first, string second,
            string expected)
        {
            var sum = new MyBigInteger(first) + new MyBigInteger(second);
            Assert.AreEqual(expected, sum.ToString());
        }
        
        
        [Test]
        [TestCase("10", "10", "0")]
        [TestCase("-10", "-2", "-8")]
        [TestCase("10", "-2", "12")]
        [TestCase("-10", "2", "-12")]
        [TestCase("1234254525677895465425345", "31324462654746584234", "1234223201215240718841111")]
        public void SubtractTest(string first, string second, string expected)
        {
            var sub = new MyBigInteger(first) - new MyBigInteger(second);
            Assert.AreEqual(sub.ToString(), expected);
        }

        [Test]
        [TestCase("4", "2", "2")]
        [TestCase("1", "2", "0")]
        [TestCase("10000", "10", "1000")]
        [TestCase("180", "60", "3")]
        [TestCase("10000000", "10", "1000000")]
        [TestCase("1232347", "315", "3912")]
        [TestCase("123234253577675484345657", "3152435", "39091766706585697")]
        public void DivTest(string first, string second, string expected)
        {
            var div = new MyBigInteger(first) / new MyBigInteger(second);
            Assert.AreEqual(expected, div.ToString());
        }
        
        [Test]
        [TestCase("10", "1", "0")]
        [TestCase("10000", "10", "0")]
        [TestCase("12", "6", "0")]
        [TestCase("1232347", "315", "67")]
        [TestCase("123234365457376547", "34675869678915", "31000488191552")]
        public void ModTest(string first, string second, string expected)
        {
            Assert.AreEqual(expected, (new MyBigInteger(first) % new MyBigInteger(second)).ToString());
        }
        
        [Test]
        [TestCase(short.MaxValue, short.MinValue)]
        [TestCase(short.MaxValue, short.MaxValue)]
        [TestCase(int.MaxValue, int.MinValue)]
        [TestCase(int.MaxValue, int.MaxValue)]
        [TestCase(11, 12)]
        [TestCase(-5, 15)]
        public void Compare(long first, long second)
        {
            Assert.AreEqual(first < second,
                new MyBigInteger(first.ToString()) < new MyBigInteger(second.ToString()));
        }

        [Test]
        [TestCase(15)]
        [TestCase(-55)]
        [TestCase(int.MaxValue)]
        [TestCase(int.MinValue)]
        public void Equals(long value)
        {
            var first = new MyBigInteger(value.ToString());
            var second = new MyBigInteger(value.ToString());
            Assert.That(first == second, Is.True);
        }
        
        [Test]
        [TestCase(55)]
        [TestCase(148)]
        [TestCase(int.MaxValue)]
        [TestCase(int.MinValue)]
        public void Unequals(long value)
        {
            var v = new MyBigInteger(value.ToString());
            Assert.That(v != MyBigInteger.One, Is.True);
        }
    }
}