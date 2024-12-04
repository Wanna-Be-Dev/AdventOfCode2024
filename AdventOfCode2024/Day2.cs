using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    class Day2
    {
        public static string path = @"C:\Users\grman\source\repos\AdventOfCode2024\AdventOfCode2024\Input\Day2.txt";
        public static string[] ReadInput()
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("No file Found");
                return null;
            }

            string[] lines = File.ReadAllLines(path);

            return lines;
        }
        static int First()
        {
            int count = 0;
            string?[] lines = ReadInput();

            if (lines?.Length <= 0)
                return -1;

            foreach (string line in lines)
            {
                int correct = 0;

                var numbers = line.Split(' ').Select(n => Convert.ToInt32(n)).ToList();
                var sorted = line.Split(' ').Select(n => Convert.ToInt32(n)).OrderBy(n => n).ToList();
                var sortedRev = line.Split(' ').Select(n => Convert.ToInt32(n)).OrderByDescending(n => n).ToList();

                if(sorted.SequenceEqual(numbers)|| sortedRev.SequenceEqual(numbers))
                {     
                    for(int i = 0; i < numbers.Count - 1;i++)
                    {
                        var diff = Math.Abs(numbers[i] - numbers[i + 1]);

                        if (diff <= 3 && diff != 0)
                            correct++;
                    }
                    if (correct == numbers.Count - 1)
                        count++;
                }
            }

            return count;
        }

        static int Second()//TODO:FIX later govnocode
        {
            int count = 0;
            int index = 0;
            string?[] lines = ReadInput();

            if (lines?.Length <= 0)
                return -1;

            foreach (string line in lines)
            {
                index++;
                int correct = 0;
                var numbers = line.Split(' ').Select(n => Convert.ToInt32(n)).ToList();

                var Ascend = new List<int>(numbers).OrderBy(n => n).ToList();
                var Descend = new List<int>(numbers).OrderByDescending(n => n).ToList();

                if (numbers.SequenceEqual(Ascend) || numbers.SequenceEqual(Descend))
                {
                    for (int i = 0; i < numbers.Count - 1; i++)
                    {
                        var diff = Math.Abs(numbers[i] - numbers[i + 1]);
                        if (diff <= 3 && diff != 0)
                            correct++;
                    }
                }
                if (correct == numbers.Count - 1)
                {
                    count++;
                    continue;          
                }
                else
                { 
                    for (int a = 0; a < numbers.Count; a++)
                    {
                        correct = 0;
                        var variant = new List<int>(numbers);
                        variant.RemoveAt(a);
                        for (int j = 0; j < variant.Count - 1; j++)
                        {
                            var diff = Math.Abs(variant[j] - variant[j + 1]);
                            if (diff <= 3 && diff != 0)
                                correct++;
                        }
                        var Ascend1 = new List<int>(variant).OrderBy(n => n).ToList();
                        var Descend1 = new List<int>(variant).OrderByDescending(n => n).ToList();
                        if (variant.SequenceEqual(Ascend1) || variant.SequenceEqual(Descend1))
                        {
                            if (correct == variant.Count - 1)
                            {
                                count++;
                                break;   
                            }
                            
                        }
                    }
                }
                
            }

            return count;
        }

        static void Main(string[] args)
        {

            Console.WriteLine(Second());
        }

    }
}