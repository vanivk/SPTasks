using System;

namespace SPTask2
{
	class Program
	{
		static void Main(string[] args)
		{
            bool isGood = true;
            string inputStr;

            Console.WriteLine("Enter Binary String");
            inputStr = Console.ReadLine();

            if (!IsBinaryString(inputStr)) // check given input is Binary or not
            {
                Console.WriteLine("Invalid Binary string");
                Console.Read();
                return;
            }

            if (FirstCondition(countOnes(inputStr), countZeros(inputStr))) // check 1st condition
            {
                for (int i = 1; i < inputStr.Length; i++)
                {
                    var res = inputStr.Substring(0, i);
                    if (!SecondCondition(countOnes(res), countZeros(res)))  // check 2nd condition
                    {
                        Console.WriteLine("Bad Binary String");
                        Console.WriteLine("The number of 1's is less than the number of 0's in one of prefixes of given Binary string");
                        isGood = false;
                        break;
                    }
                }

                if (isGood)
                    Console.WriteLine("Good Binary String");
            }
            else
            {
                Console.WriteLine("Bad Binary String");
                Console.WriteLine("The number of 0's is not equal to the number of 1's");
            }
            Console.ReadKey();
        }

        static int countOnes(string input)
        {
            return input.Length - input.Replace("1", "").Length;
        }
        static int countZeros(string input)
        {
            return input.Length - input.Replace("0", "").Length;
        }
        static bool FirstCondition(int OnesLength, int ZerosLength)
        {
            if (OnesLength == ZerosLength)
                return true;

            return false;
        }

        static bool SecondCondition(int OnesLength, int ZerosLength)
        {
            if (OnesLength >= ZerosLength)
                return true;

            return false;
        }
        static bool IsBinaryString(string str)
        {
            foreach (char c in str)
            {
                if (c != '0' && c != '1')
                    return false;
            }
            return true;
        }
    }
}
