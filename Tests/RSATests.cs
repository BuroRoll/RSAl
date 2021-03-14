using System;
using NUnit.Framework;
using RSAl;

namespace Tests
{
    [TestFixture]
    public class RSATests
    {
        [Test]
        [TestCase("19", "37", "2", "5")]
        [TestCase("19", "3", "11", "7")]
        [TestCase("19", "3", "7", "5")]
        [TestCase("19", "17", "31", "7")]
        [TestCase("19", "5037569", "5810011", "65537")]
        public void CorrectDecode(string data, string p, string q, string e)
        {
            var (item1, item2) = RSA.CreateKeys(new MyBigInteger(p), new MyBigInteger(q), new MyBigInteger(e));
            var decryptedMsg = RSA.Decrypt(new MyBigInteger(data), item1);
            var encryptedMsg = RSA.Encrypt(decryptedMsg, item2);
            CollectionAssert.AreEqual(data, encryptedMsg.ToString());
        }
        
        [Test]
        [TestCase("3", "7", "5", "5", "21")]
        [TestCase("17", "31", "7", "7", "527")]
        [TestCase("47", "71", "79", "79", "3337")]
        [TestCase("3557", "2579", "3", "3", "9173503")]
        public void OpenKeysTest(string p, string q, string e, string k1, string k2)
        {
            var key1 = new MyBigInteger(k1);
            var key2 = new MyBigInteger(k2);
            var (item1, item2) = RSA.CreateKeys(new MyBigInteger(p), new MyBigInteger(q), new MyBigInteger(e));
            Assert.AreEqual(key1, item1.Item1);
            Assert.AreEqual(key2, item1.Item2);
        }
        
        [Test]
        [TestCase("3", "7", "5", "17", "21")]
        [TestCase("17", "31", "7", "823", "527")]
        [TestCase("47", "71", "79", "4239", "3337")]
        [TestCase("3557", "2579", "3", "15278947", "9173503")]
        public void ClosedKeysTest(string p, string q, string e, string k1, string k2)
        {
            var key1 = new MyBigInteger(k1);
            var key2 = new MyBigInteger(k2);
            var (item1, item2) = RSA.CreateKeys(new MyBigInteger(p), new MyBigInteger(q), new MyBigInteger(e));
            Assert.AreEqual(key1, item2.Item1);
            Assert.AreEqual(key2, item2.Item2);
        }
    }
}