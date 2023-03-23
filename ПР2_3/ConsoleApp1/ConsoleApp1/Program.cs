using Microsoft.VisualBasic;
using System;
using System.Security.Cryptography;
using System.Text;



namespace PW2_3
{
    class CesarChifr
    {
        public char[] message;
        public int key;
        private char[] alfavit = { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };



        public string Encrypt()
        {
            int number_symbol;
            int smechenie;
            string result;
            for (int i = 0; i < message.Length; i++)
            {
                int m;
                for (m = 0; m < alfavit.Length; m++)
                {
                    if (message[i] == alfavit[m])
                    {
                        break;
                    }
                }
                if (m < 33)
                {
                    number_symbol = m;
                    smechenie = number_symbol + key;
                    if (smechenie > 32)
                    {
                        smechenie = smechenie - 33;
                    }
                    message[i] = alfavit[smechenie];
                }
            }
            result = new string(message);
            return result;
        }
        public string Decipher()
        {
            int number_symbol;
            int smechenie;
            string result;
            for (int i = 0; i < message.Length; i++)
            {
                int m;
                for (m = 0; m < alfavit.Length; m++)
                {
                    if (message[i] == alfavit[m])
                    {
                        break;
                    }
                }
                if (m < 33)
                {
                    number_symbol = m;
                    smechenie = number_symbol + (33 - key);



                    if (smechenie > 32)
                    {
                        smechenie = smechenie - 33;
                    }
                    message[i] = alfavit[smechenie];
                }
            }
            result = new string(message);
            return result;
        }
    }



    class Program
    {
        static void Main()
        {
            CesarChifr cesar = new CesarChifr();
            Console.WriteLine("Используется нижний регистр русского языка");
            Console.Write("Введите текст: ");
            string m = Convert.ToString(Console.ReadLine());
            m = m.ToLower();
            char[] message = m.ToCharArray();
            cesar.message = message;
            Console.Write("Ввести ключ: ");
            cesar.key = Convert.ToInt32(Console.ReadLine());
            string result = cesar.Encrypt();
            Console.WriteLine("Зашифрованный текст: " + result);
            result = cesar.Decipher();
            Console.WriteLine("Расшифрованный текст: " + result);
            Console.ReadKey(true);
        }
    }
}