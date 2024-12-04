using System.Text.RegularExpressions;

namespace AdventOfCode
{
    class Day1
    {
        public static string path = @"C:\Users\grman\source\repos\AdventOfCode2024\AdventOfCode2024\Input\Day1.txt";
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
            var list1 = new List<int>();
            var list2 = new List<int>();

            string?[] lines = ReadInput();

            if (lines?.Length <= 0)
                return -1;

            foreach(string line in lines)
            {
                var number = System.Text.RegularExpressions.Regex.Split(line, @"\s+");
                list1.Add(Int32.Parse(number[0]));
                list2.Add(Int32.Parse(number[1]));
            }

            var newlist1 = list1.OrderBy(x => x).ToArray();
            var newlist2 = list2.OrderBy(x => x).ToArray();

            for(int i = 0; i< newlist1.Count(); i++)
            {
                var a = newlist1[i] - newlist2[i];
                count += Math.Abs(a);
            }

            return count;
        }
        static int Second() 
        {
            int count = 0;
            var list1 = new List<int>();
            var list2 = new List<int>();
            string?[] lines = ReadInput();

            if (lines?.Length <= 0)
                return -1;

            foreach (string line in lines)
            {
                var number = System.Text.RegularExpressions.Regex.Split(line, @"\s+");
                list1.Add(Int32.Parse(number[0]));
                list2.Add(Int32.Parse(number[1]));
            }
            
            for (int i = 0; i < list1.Count(); i++)
            {
                int similar = 0;
                for(int j = 0; j < list2.Count(); j++)
                {
                    if (list1[i] == list2[j])
                        similar++;
                }
                count += list1[i] * similar;
            }

            return count;
        }
       
        
    }
}