
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;

namespace WordsOfWonder
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lines = GetWords();
            var requirements = new List<Requirement>()
            {
            //    //new Requirement
            //    //{
            //    //    Position = 0,
            //    //    Charachter = 'R'
            //    //},
            new Requirement
            {
                Position = 1,
                Charachter = 'I'
            }
            };

        List<string> words = FindRealWords(lines, requirements);
            DisplayWords(words);
        }

        private static void DisplayWords(List<string> words)
        {
            foreach (var word in words)
            {
                Console.WriteLine(word);
            }
        }

        public class Requirement
        {
            public int Position { get; set; }
            public char Charachter { get; set; }
        }

        private static List<string> FindRealWords(List<string> lines, List<Requirement> requirements)
        {
            var words = new List<string>();
            int i = 0;
            foreach (var word in lines)
            {
                bool isSatisfyAllRequirements = IsSatisfyAllRequirements(requirements, word);
                if (isSatisfyAllRequirements && IsWordExistOnDexOnline(word))
                {
                    words.Add(word);
                };
                Console.Clear();
                Console.WriteLine($"{i} / {lines.Count()}");
                i++;
            }

            return words;
        }

        //private static bool IsWordExistOnDex(string word)
        //{
        //    var httpClient = new HttpClient();
        //    var httpResult = httpClient.GetAsync($"https://www.dex.ro/{word}").Result;
        //    bool result = httpResult.Content.ReadAsStringAsync().Result.Contains("Nici un rezultat!");

        //    return result;
        //}

        private static bool IsWordExistOnDexOnline(string word)
        {
            var httpClient = new HttpClient();
            var httpResult = httpClient.GetAsync($"https://dexonline.ro/definitie/{word}").Result;
            bool result = httpResult.StatusCode == System.Net.HttpStatusCode.OK;
            if (httpResult.StatusCode == System.Net.HttpStatusCode.Found)
            {
                Console.WriteLine(word);
            }

            return result;
        }

        private static bool IsSatisfyAllRequirements(List<Requirement> requirements, string word)
        {
            bool result = true;
            foreach (var requirement in requirements)
            {
                if (word[requirement.Position] != requirement.Charachter)
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        private static List<string> GetWords()
        {
            string[] lines = File.ReadAllLines("Random.txt");
            var words = new List<string>();
            foreach (var wordWithNumber in lines)
            {
                string word = wordWithNumber.Split("\t", StringSplitOptions.RemoveEmptyEntries)[1];
                words.Add(word);
            }

            return words;
        }

        private static List<string> GeneratePermutations(List<string> characters, int n)
        {
            var permutations = new List<string>();

            return permutations;
        }

        private static void Swap(ref char a, ref char b)
        {
            if (a == b) return;

            var temp = a;
            a = b;
            b = temp;
        }

        public static void GetPer(char[] list)
        {
            int x = list.Length - 1;
            GetPer(list, 0, x);
        }

        private static void GetPer(char[] list, int k, int m)
        {
            if (k == m)
            {
                Console.Write(list);
            }
            else
                for (int i = k; i <= m; i++)
                {
                    Swap(ref list[k], ref list[i]);
                    GetPer(list, k + 1, m);
                    Swap(ref list[k], ref list[i]);
                }
        }

    }
}
