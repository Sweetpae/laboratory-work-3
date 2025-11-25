using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class PolybiusCipher
{
    static Dictionary<char, string> encryptTable = new Dictionary<char, string>()
    {
        {'A',"11"}, {'B',"12"}, {'C',"13"}, {'D',"14"}, {'E',"15"},
        {'F',"21"}, {'G',"22"}, {'H',"23"}, {'I',"24"}, {'J',"24"}, {'K',"25"},
        {'L',"31"}, {'M',"32"}, {'N',"33"}, {'O',"34"}, {'P',"35"},
        {'Q',"41"}, {'R',"42"}, {'S',"43"}, {'T',"44"}, {'U',"45"},
        {'V',"51"}, {'W',"52"}, {'X',"53"}, {'Y',"54"}, {'Z',"55"}
    };

    static Dictionary<string, char> decryptTable = new Dictionary<string, char>()
    {
        {"11",'A'}, {"12",'B'}, {"13",'C'}, {"14",'D'}, {"15",'E'},
        {"21",'F'}, {"22",'G'}, {"23",'H'}, {"24",'I'}, {"25",'K'},
        {"31",'L'}, {"32",'M'}, {"33",'N'}, {"34",'O'}, {"35",'P'},
        {"41",'Q'}, {"42",'R'}, {"43",'S'}, {"44",'T'}, {"45",'U'},
        {"51",'V'}, {"52",'W'}, {"53",'X'}, {"54",'Y'}, {"55",'Z'}
    };

    static string Encrypt(string text)
    {
        text = text.ToUpper();
        StringBuilder result = new StringBuilder();
        foreach (char c in text)
        {
            if (encryptTable.ContainsKey(c))
                result.Append(encryptTable[c] + " ");
        }
        return result.ToString().Trim();
    }

    static string Decrypt(string code)
    {
        string[] parts = code.Split(' ');
        StringBuilder result = new StringBuilder();
        foreach (var p in parts)
        {
            if (decryptTable.ContainsKey(p))
                result.Append(decryptTable[p]);
        }
        return result.ToString();
    }

    static void Main()
    {
        Console.WriteLine("Введите текст для шифрования: ");
        string input = Console.ReadLine();

        string encrypted = Encrypt(input);
        File.WriteAllText("encrypted.txt", encrypted);

        Console.WriteLine("\nТекст зашифрован и сохранён в файл encrypted.txt");
        Console.WriteLine("Зашифрованный текст: " + encrypted);

        string readEncrypted = File.ReadAllText("encrypted.txt");
        string decrypted = Decrypt(readEncrypted);

        Console.WriteLine("\nСчитанный из файла шифртекст: " + readEncrypted);
        Console.WriteLine("Расшифрованный текст: " + decrypted);
    }
}
