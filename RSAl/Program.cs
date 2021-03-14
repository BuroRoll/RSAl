using System;

namespace RSAl
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Что необходимо сделать?");
            Console.WriteLine("1. Зашифровать файл");
            Console.WriteLine("2. Зашифровать небольшой объём данных прямо в консоли");
            var userChoise = Console.ReadLine();
            switch (userChoise)
            {
                case "1":
                    Console.WriteLine("Введите путь к файлу");
                    var encryptedFile = RSA.EncryptFile(Console.ReadLine());
                    foreach(var d in encryptedFile)
                        Console.WriteLine(d);
                    break;
                case "2":
                    rsa();
                    break;
            }
        }

        private static void rsa()
        {
            Console.WriteLine("Введите первое простое число");
            var p = new MyBigInteger(Console.ReadLine());
        
            Console.WriteLine("Введите Второе простое число");
            var q = new MyBigInteger(Console.ReadLine());
        
            Console.WriteLine("Введите открытую экспоненту");
            var e = new MyBigInteger(Console.ReadLine());
        
            var keys = RSA.CreateKeys(p, q, e);
        
            Console.WriteLine("Открытый ключ - " + keys.Item1);
            Console.WriteLine("Закрытый ключ - " + keys.Item2);
        
            Console.WriteLine("Введите, что необходимо зашифровать");
            var data = Console.ReadLine();
        
            var encryptedMsg = RSA.Encrypt(new MyBigInteger(data), keys.Item1);
            Console.WriteLine("Зашифрованное сообщение - " + encryptedMsg);
        
            var decryptedMsg = RSA.Decrypt(encryptedMsg, keys.Item2);
            Console.WriteLine("Расшифрованное сообщение - " + decryptedMsg);
        }
    }
}