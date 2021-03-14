using System;
using System.Collections.Generic;
using System.Linq;

namespace RSAl
{
    public class RSA
    {
        public static MyBigInteger Decrypt(MyBigInteger data, Tuple<MyBigInteger, MyBigInteger> key)
        {
            return MyBigInteger.ModPow(data, key.Item1, key.Item2);
        }

        public static MyBigInteger Encrypt(MyBigInteger data, Tuple<MyBigInteger, MyBigInteger> key)
        {
            return MyBigInteger.ModPow(data, key.Item1, key.Item2);
        }

        public static Tuple<Tuple<MyBigInteger, MyBigInteger>, Tuple<MyBigInteger, MyBigInteger>> CreateKeys(
            MyBigInteger p, MyBigInteger q, MyBigInteger e)
        {
            var n = p * q;
            var fi = (p - MyBigInteger.One) * (q - MyBigInteger.One);
            var publicKey = Tuple.Create(e, n);

            var d = MyBigInteger.GetModInverse(e, fi) + fi;
            var privateKey = Tuple.Create(d, n);

            return Tuple.Create(publicKey, privateKey);
        }

        public static List<MyBigInteger> EncryptFile(string path)
        {
            var p = new MyBigInteger(5037569);
            var q = new MyBigInteger(5810011);
            var e = new MyBigInteger(65537);
            var keys = RSA.CreateKeys(p, q, e);
            var encrypted = new List<MyBigInteger>();
            var text = System.IO.File.ReadAllText(@path).Split(' ');
            foreach (var s in text)
            {
                var chars = s.ToCharArray();
                encrypted.AddRange(chars.Select(c => RSA.Encrypt(new MyBigInteger(Convert.ToInt32(c)), keys.Item1)));
            }

            return encrypted;
        }
    }
}