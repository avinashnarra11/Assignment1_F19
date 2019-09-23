using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Assignment1_F19
{
    class Program
    {
        static void Main(string[] args)
        {
            //print selfdividing numbers
            int a = 1, b = 22;
            printSelfDividingNumbers(a, b);


            //print series
            Console.WriteLine("Enter the number of terms in the series:");
            int n = Convert.ToInt32(Console.ReadLine());
            printSeries(n);

            //print triangle
            Console.Write("Enter the numnber of rows:");
            int p = Convert.ToInt32(Console.ReadLine());
            printTriangle(p);
            
            //finding the no of jewels
            Console.WriteLine("Enter the jewels");
            string[] jewels = Console.ReadLine().Split(',');
            Console.WriteLine("Enter the stones");
            string[] stones = Console.ReadLine().Split(',');
            List<int> jewls = new List<int>();
            List<int> stons = new List<int>();
            foreach (string j in jewels)
            {
                jewls.Add(int.Parse(j));
            }
            foreach (string k in stones)
            {
                stons.Add(int.Parse(k));
            }

            Console.WriteLine(numJewelsInStones(jewls.ToArray(), stons.ToArray()));
            Console.ReadKey();

            //finnding the largest common subarray
            int[] arr1 = new int[] { 1, 2, 3, 5, 6, 7, 8, 9 };
            int[] arr2 = new int[] { 1, 2, 4, 5 };
            int[] r5 = getLargestCommonSubArray(arr1, arr2);
            string sx = String.Join("", r5);
            Debug.WriteLine($"Longest string found is {sx}", sx);
            foreach (var item in r5)
            {
                Console.WriteLine(item.ToString());
            }

        }
        public static void printSelfDividingNumbers(int x, int y)
        {
            try
            {
                //Initialize.
                string p;
                int x1;
                int y1;
                int d1;
                int d2;
                int j;
                bool selfDividing;
                int countOfSd;

                //Pseudocode
                p = "This is pseudocode. Initialize a variable selfDividing=true\n";
                p = p + "Read first number in the series of x to y in increments of 1. Lets say it is N1\n";
                p = p + "Find Modulo 10 of first number. It will give the unit place digit as reminder. Lets say it is D1\n";
                p = p + "If unit digit is zero, go to next step break the loop and iterate next number. If unit digit is > 0, do a modulo division of N1 by D1. If result is 0, it divides perfectly. If result is >0, break this inner loop and iterate next number\n";
                p = p + "Do a regular division of first number N1 by 10. If result is < 0, print 'N1 is self dividing'. If result is > 0, repeat previous two steps\n";
                Debug.WriteLine("Assignment 1. Self Dividing Number");
                Debug.WriteLine(p);

                //Read input
                //x1 = 100;
                //y1 = 125;
                //Debug.WriteLine("Enter value for first number x:");
                //x1 = int.Parse(Console.ReadLine());
                //Debug.WriteLine("Enter value for second number y:");
                //y1 = int.Parse(Console.ReadLine());
                x1 = x;
                y1 = y;

                //Iterate
                countOfSd = 0;
                for (int i = x1; i < y1 + 1; i++) //For each number in the given range of x to y
                {
                    selfDividing = true; //Start with a optimistic judgement, this number is selfDividing
                    j = i;
                    while (j > 0) //Use a different variable 'j' to get each digit in the given number
                    {
                        d1 = j % 10; //Find the unit digit of the number. At end of whileloop, j is trimmed of this unit digit to make new j
                        if (d1 == 0) //If unit digit is zero, then this number is not self dividing
                        {
                            selfDividing = false;
                            break;
                        }
                        else
                        {
                            d2 = i % d1; //If unit digit is not zero, then divide the input number x by the unit digit
                            if (d2 > 0) // If it does not perfectly divide, there is a reaminder, this is not self dividing number
                            {
                                selfDividing = false;
                                break;
                            }
                            else
                            {
                                //continue;
                                //selfDividing = true;
                            }
                        }
                        j = j / 10; //Trim the j to cast away the last digit on right and retain the remaining digits on left to repeat the steps above in the while loop
                    }
                    if (selfDividing == true)
                    {
                        Debug.WriteLine($"{i} is self dividing", i);
                        countOfSd += 1;
                    }
                    else
                    {
                        //Debug.WriteLine($"{i} is not self dividing", i);
                    }
                    if (i == y1)
                    {
                        Debug.WriteLine($"There is/are {countOfSd} self dividing numbers", countOfSd);
                    }
                }

                p = "This is the list of Learnings from the assignment and recommendations\n";
                p = p + "Learning 1. Writing a clear Pseudocode speeds up the coding\n";
                p = p + "Learning 2. Using the correct type of loop, like while, for at the right place helps in easy handling\n";
                p = p + "Recommendation: This is a good practice program. Continue kept the program in endless loop. In future, show caution about this when coding \n";
                Debug.WriteLine(p);

            }
            catch
            {
                Console.WriteLine("Exception occurred while computing print SelfDividingNumbers()");
            }
        }
        


        public static void printSeries(int n)
        {
            try
            {
                int c = 0;
                for (int i = 1; i <= n; i++)

                {
                    for (int j = 1; j <= i; j++)
                    {
                        c++;
                        if (c < n)
                            Console.Write(i + ",");
                        else if (c == n)
                            Console.Write(i);

                    }
                }
                Console.ReadLine();

            }
            catch
            {
                Console.WriteLine("Exception occured while computing printSeries()");
            }
        }

        public static void printTriangle(int n)
        {
            try
            {
                int c = 0;
                for (int i = n; i > 0; i--)
                {

                    for (int k = 0; k < (2 * c); k++)
                    {
                        Console.Write(" ");
                    }
                    for (int j = 0; j < ((2 * i) - 1); j++)
                    {

                        Console.Write("* ");
                    }

                    Console.WriteLine();

                    c++;
                }

            }
            catch
            {
                Console.WriteLine("Exception occured while computing printTriangle()");
            }
        }

        public static int numJewelsInStones(int[] J, int[] S)
        {
            try
            {
                int counter = 0;
                for (int i = 0; i < J.Length; i++)
                {
                    for (int j = 0; j < S.Length; j++)
                    {
                        if (J[i] == S[j])
                        {
                            counter++;
                        }

                    }
                }
                return counter;

            }
            catch
            {
                Console.WriteLine("Exception occured while computing numJewelsInStones()");
            }

            return 0;
        }

        public static int[] getLargestCommonSubArray(int[] a, int[] b)
        {
            int[] great = null;

            try
            {
                //Initialize
                string p;
                string str1;
                string str2;
                int len;
                int[] s = null;

                //Pseudocode
                p = "Pseudocode: read both the input arrays and convert into two strings S1 and S2\n";
                p = p + "For the length of the string, find if the string S1 is contained in the string S2\n";
                p = p + "If present, break and convert the string back to array and print the longest array found\n";
                p = p + "If not present, drop the last character in the string and repeat the above step\n";
                p = p + "If no string found, then print, first array is not found in the second array";
                Debug.WriteLine(p);

                //Code
                str1 = string.Join("", a);
                str2 = string.Join("", b);
                len = str1.Length;



                for (int i = len - 1; i > 0; i--)
                {
                    if (str2.Contains(str1))
                    {
                        //Debug.WriteLine($"Longest string found is {str1}", str1);
                        break;
                    }
                    else
                    {
                        str1 = str1.Remove(i, 1);
                    }
                }
                if (str1.Length > 0)
                {
                    char[] charArr = str1.ToCharArray();
                    s = Array.ConvertAll(str1.Split(' '), int.Parse);
                    great = s;
                    //r5 = Array.ConvertAll(charArr c => int.Parse(c));
                    foreach (var item in s)
                    {
                        Console.WriteLine(item.ToString());
                    }
                }

                //Learnings and Recommendations
                p = "Learnings and recommendations\n";
                p = p + "1. Learning the techniques to handle integer and string arrays is needed\n";
                p += "2. It is helpful to know joining an array into string and vice versa by heart\n ";
                p += "3. Strings and integer arrays have interchangeable needs\n";
                p += "4.It is recommended to practise more on the string to array conversion\n";
                Debug.WriteLine(p);
            }
            catch
            {
                Console.WriteLine("Exception occurred while computing getLargestCommonSubArray()");
            }


            return great;
        }


    }
}
