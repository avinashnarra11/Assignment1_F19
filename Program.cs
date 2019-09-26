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

            //finding the largest common subarray
            int[] a1 = new int[] { 1, 2, 3, 5, 6, 7, 8, 9 };
            int[] a2 = new int[] { 1, 2, 4, 5 };
            int[] w = getLargestCommonSubArray(a1, a2);
            string s = String.Join("", w);
            foreach (var item in w)
            {
                Console.WriteLine(item.ToString());
                
            }

        }
        public static void printSelfDividingNumbers(int x, int y)
        {
            try
            {
               
                
                int a;
                int b;
                int m;
                int n;
                int j;
                bool selfDividing;
                int c=0;

                a = x;
                b = y;

                
                for (int i = a; i < b + 1; i++) 
                {
                    selfDividing = true; 
                    j = i;
                    while (j > 0) 
                    {
                        m = j % 10; 
                        if (m == 0) 
                        {
                            selfDividing = false;
                            break;
                        }
                        else
                        {
                            n = i % m; 
                            if (n > 0) 
                            {
                                selfDividing = false;
                                break;
                            }
                            else
                            {
                                
                            }
                        }
                        j = j / 10; 
                    }
                    if (selfDividing == true)
                    {
                        Debug.WriteLine("{i} is self-dividing", i);
                        c += 1;
                    }
                   
                    if (i == b)
                    {
                        Debug.WriteLine("no. of self dividing numbers: {countOfSd}", c);
                    }
                }

                

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
            int[] large = null;

            try
            {
                
                
                string s1;
                string s2;
                int len;
                int[] s = null;

               
                s1 = string.Join("", a);
                s2 = string.Join("", b);
                len = s1.Length;



                for (int i = len - 1; i > 0; i--)
                {
                    if (s2.Contains(s1))
                    {
                        
                        break;
                    }
                    else
                    {
                        s1 = s1.Remove(i, 1);
                    }
                }
                if (s1.Length > 0)
                {
                    char[] charArr = s1.ToCharArray();
                    s = Array.ConvertAll(s1.Split(' '), int.Parse);
                    large = s;

                    
                }



            }
            catch
            {
                Console.WriteLine("Exception occurred while computing getLargestCommonSubArray()");
            }


            return large;
        }


    }
}
