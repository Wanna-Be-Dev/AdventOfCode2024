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
            string?[] lines = ReadInput();

            if (lines?.Length <= 0)
                return -1;

            foreach (string line in lines)
            {
                int correct = 0;
                var numbers = line.Split(' ').Select(n => Convert.ToInt32(n)).ToList();
                for (int i = 0; i < numbers.Count - 1; i++)
                {
                    var diff = Math.Abs(numbers[i] - numbers[i + 1]);
                    if (diff <= 3 && diff != 0)
                        correct++;
                }
                if (correct == numbers.Count - 1)
                {
                    var Ascend = new List<int>(numbers);
                    var Descend = new List<int>(numbers);
                    Ascend.OrderBy(n => n);
                    Descend.OrderByDescending(n => n);
                    if (numbers.SequenceEqual(Ascend) || numbers.SequenceEqual(Descend))
                    {
                        count++;
                        for (int x = 0; x < numbers.Count; x++)
                            Console.Write(numbers[x] + " ");
                        Console.WriteLine("    @");
                        continue;
                    }
                }
                else
                { 
                    for (int a = 0; a < numbers.Count; a++)
                    {
                        correct = 0;
                        var variant = new List<int>(numbers);
                        variant.Remove(variant[a]);
                        for (int j = 0; j < variant.Count - 1; j++)
                        {
                            var diff = Math.Abs(variant[j] - variant[j + 1]);
                            Console.Write(variant[j] + " ");
                            if (diff <= 3 && diff != 0)
                                correct++;
                        }
                        var Ascend1 = new List<int>(variant);
                        var Descend1 = new List<int>(variant);
                        Ascend1.OrderBy(n => n);
                        Descend1.OrderByDescending(n => n);
                        Console.Write(variant[variant.Count - 1]);
                        if (variant.SequenceEqual(Ascend1) || variant.SequenceEqual(Descend1))
                        {
                            if (correct == variant.Count - 1)
                            {



                                    count++;
                                    Console.WriteLine("    @");
                                    break;
                                
                            }
                            Console.WriteLine(" ");
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