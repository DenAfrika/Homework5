//Чернышев Денис

using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace Homework5
{
    static class Message
    {
        static string[] separator = { " ", ",", ".", ":", ";", "?", "!", "@"};
        public static void Print(string str)
        {
            string[] words = str.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            Console.Write("Введите допустимое кол-во букв в слове:");
            int count = int.Parse(Console.ReadLine());
            foreach (string word in words)
            {
                if (word.Length <= count)
                    Console.Write(word + " ");
            }
            Console.WriteLine();
        }
        public static void DeleteWords(string str)
        {
            Console.Write("Введите символ:");
            string sumbol = Console.ReadLine();
            Console.WriteLine(Regex.Replace(str, $@"\w*{sumbol}\s", String.Empty));
        }
        public static void LongWord(string str)
        {
            var matches = Regex.Matches(str, @"\b[\S]+\b");
            int maxindex = 0;
            for (int i = 0; i < matches.Count; i++)
                if (matches[i].Length > matches[maxindex].Length)
                    maxindex = i;
            Console.WriteLine("Самое длинное слово = {0}", matches[maxindex]);
        }
        public static void GetLingWords(string str)
        {
            StringBuilder stringBuilder = new StringBuilder();
            var matches = Regex.Matches(str, @"\b[\S]+\b");
            int maxindex = 0;
            for (int i = 0; i < matches.Count; i++)
                if (matches[i].Length > matches[maxindex].Length)
                    maxindex = i;
            string[] words = str.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words)
                if (matches[maxindex].Length == word.Length)
                    stringBuilder.Append(word + " ");
            Console.WriteLine();
            Console.WriteLine(stringBuilder);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task01();
            Task02();
            //Task03();
            //Task04();
        }

        private static void Task04()
        {
            Console.WriteLine("4. *Задача ЕГЭ." +
                "\nТребуется написать как можно более эффективную программу, которая будет выводить на экран фамилии и имена трёх худших по среднему баллу учеников. Если среди остальных есть ученики, набравшие тот же средний балл, что и один из трёх худших, следует вывести и их фамилии и имена.");
            Console.WriteLine();

            string[] separator = { " ", ",", ".", ":", ";", "?", "!", "@" };
            StreamReader streamReader = new StreamReader("..//..//users.txt");
            int usersCount = int.Parse(streamReader.ReadLine());

            string[] users = new string[usersCount];
            int[] lowScore = new int[usersCount];

            for (int i = 0;i < usersCount; i++)
            {
                users[i] = streamReader.ReadLine();
                string[] usersScore = users[i].Split(separator, StringSplitOptions.RemoveEmptyEntries);
                lowScore[i] = int.Parse(usersScore[2]) + int.Parse(usersScore[3]) + int.Parse(usersScore[4]);
            }
            int minIndex01 = lowScore.Min();
            int minIndex02 = 15;
            int minIndex03 = 15;

            foreach (int v in lowScore)
                if (minIndex02 > v && v != minIndex01)
                    minIndex02 = v;
            
            foreach (int v in lowScore)
                if (minIndex03 > v && v != minIndex01 && v != minIndex02)
                    minIndex03 = v;

            for(int i = 0; i < users.Length; i++)
            {
                if(lowScore[i] == minIndex01)
                    Console.WriteLine("С самыми низкими баллами {0}", users[i]);
                if(lowScore[i] == minIndex02) { Console.WriteLine("Второй по самому низкому баллу {0}", users[i]); }
                if(lowScore[i] == minIndex03) { Console.WriteLine("Третий по самому низкому баллу {0}", users[i]); }
            }

            Console.WriteLine();

            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
            Console.Clear();
        }

        private static void Task03()
        {
            Console.WriteLine("3. *Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой." +
                "\nНапример: badc являются перестановкой abcd.");
            Console.WriteLine();
            Console.WriteLine("Является ли одна строка перестановкой другой?");
            Console.WriteLine("=============================================");
            Console.WriteLine("Напишите первую строку: ");
            char[] chars01 = Console.ReadLine().ToCharArray();
            Console.WriteLine("Напишите вторую строку: ");
            char[] chars02 = Console.ReadLine().ToCharArray();
            Array.Sort(chars01);
            Array.Sort(chars02);
            string message01 = new string(chars01);
            string message02 = new string(chars02);

            if (message01 == message02)
            {
                Console.WriteLine("\nДа, является!");
            }
            else Console.WriteLine("\nНет, не является!");
                

            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
            Console.Clear();
        }

        private static void Task02()            //Задание 2. Выполнено всё
        {
            Console.WriteLine("Разработать статический класс Message, содержащий следующие статические методы для обработки текста:" +
                "\nа) Вывести только те слова сообщения, которые содержат не более n букв." +
                "\nб) Удалить из сообщения все слова, которые заканчиваются на заданный символ." +
                "\nв) Найти самое длинное слово сообщения." +
                "\nг) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.");
            Console.WriteLine();
            Console.WriteLine("Введите предложение: ");
            string str = Console.ReadLine();
            Message.Print(str);                     
            Message.DeleteWords(str);
            Message.LongWord(str);
            Message.GetLingWords(str);
            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
            Console.Clear();
        }

        private static void Task01()            //Задание 1. Выполнено с использованием регулярных выражений
        {
            Console.WriteLine("1. Создать программу, которая будет проверять корректность ввода логина. Корректным логином будет строка от 2 до 10 символов, содержащая только буквы латинского алфавита или цифры, при этом цифра не может быть первой:" +
                "\nа) без использования регулярных выражений;" +
                "\nб) **с использованием регулярных выражений.");
            Console.WriteLine();

            Regex regex01 = new Regex(@"[a-zA-Z]+(\w*)");
            while (true)
            {
                Console.Write("Введите логин: ");
                string str = Console.ReadLine();
                if (str.Length > 10 || str.Length <= 2 || !regex01.IsMatch(str))
                {
                    Console.WriteLine("Логин не принят!\nПопробуйте ещё раз\nНажмите любую клавишу...");
                    Console.ReadKey();
                }
                else break;
                Console.Clear();
            }
            Console.WriteLine("Логин принят!");
            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
