using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace InterviewQuestions
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task 1
            int count = LetterOccurenceInString('a', "mE and you need a banner");
            Console.WriteLine(count);


            //Task 2
            bool isPalin = IsPalindrome("God saved Eva's dog");
            Console.WriteLine(isPalin);


            //Task 3 Part A
            string[] forbidden = new[] { "dog", "cat", "large" };
            int forbiddenWordCount = CountOfCensoredWords(
                "I have a cat named Meow and a dog name Woof. I love the dog a lot. He is larger than a small horse.",
                "dog", "cat", "large");
            Console.WriteLine(forbiddenWordCount);


            //Task 4 Part B
            string[] cen = new[] { "meow", "woof", };
            string uncen = "I have a cat named Meow and a dog name Woof.I love the dog a lot. He is larger than a small horse.";
            CensorWordsInText(uncen, cen);

            Console.ReadLine();


            //Task 4 Part C
                        
        }


        //Task 1
        public static int LetterOccurenceInString(char letter, string word)
        {
            int count = word.ToLower().Count(o => o == char.ToLower(letter));
            return count;
        }


        //Task 2
        public static bool IsPalindrome(string word)
        {
            var newWord = word.ToLower().Replace("'", "").Replace(" ", "");
            char[] array = newWord.ToCharArray();
            Array.Reverse(array);
            return newWord == new string(array);
        }

        //Task 3 Part A 
        public static int CountOfCensoredWords(string sentence, params string[] forbidden)
        {
            int count = 0;
            foreach (var word in forbidden)
            {
                MatchCollection matches = Regex.Matches(sentence, word);
                count += matches.Count;
            }
            return count;
        }



        
            //Task 3 Part B
            public static string CensorWord(string word)
        {
            int asterixLength = word.Length - 2;

            string newWord = $"{word.First()}";
            for (int i = 0; i < asterixLength; i++)
            {
                newWord += "*";
            }

            newWord = newWord + word.Last();
            return newWord;

        }

        public static string CensorWordsInText(string sentence, string[] censored)
        {

            string newSentence = "";
            string[] words = sentence.ToLower().Replace("."," ").Split(' ');

         
            for (int i = 0; i < censored.Length; i++)
            {
                censored[i] = censored[i].ToLower();
            }

            foreach (string word in words)
            {

                if (censored.Contains(word))
                {
                    var censeredWord = CensorWord(word);
                    newSentence += censeredWord + " ";

                }
                else
                {
                    newSentence += word + " ";
                }

            }

            Console.WriteLine(newSentence);

            return "";

        }
                       
        //Task 3 Part C

              
    }
}
