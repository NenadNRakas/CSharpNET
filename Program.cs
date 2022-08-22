using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpNET
{
    class Program
    {
        static void Main(string[] args)
        {
            string E = "10:00";
            string L = "13:21";
            int A = 0;
            int B = 0;
            int[] X = { -1, -3};
            int Enemies = Enemy(E, A, X, X);
            Console.WriteLine($"Enemies: {Enemies}");
            int ST = SkillTree(X, X);
            Console.WriteLine($"Skill Tree: {ST}");
            int DS = DemoSol(X);
            Console.WriteLine($"Demo Solution: {DS}");
            string Price = solution(E, L).ToString();
            //solution(E,L);
            Console.WriteLine("Grand Total:  " + Price);
            //ParityDegree(A);
            string Modulo = ParityDegree(A).ToString();
            Console.WriteLine("Max Power: " + Modulo);
            string TK = ThreeKings(A, B);
            Console.WriteLine($"Three Kings: {TK}");
            Console.ReadLine();
        }
            /*int[] FUX = { 0,  1,  2,  3,  0, -1, -2, -3 };
            int[] FUY = { 0,  1,  2,  3,  5,  1,  2,  1 };
            int[] FRX = { 0,  1,  2,  3,  5,  1,  2,  3 };
            int[] FRY = { 0,  1,  2,  3,  0, -1, -2, -3 };
            int[] FDX = { 0,  1,  2,  3,  0, -1, -2, -3 };
            int[] FDY = { 0, -1, -2, -3, -5, -1, -2, -3 };
            int[] FLX = { 0, -1, -2, -3, -5, -1, -2, -3 };
            int[] FLY = { 0,  1,  2,  3,  0, -1, -2, -3 };
            //Y = Y1 + (Y2 – Y1) / (X2 – X1) * (X * X1)
            // Precise method, which guarantees v = v1 when t = 1. This method is monotonic only when v0 * v1 < 0.
            // Lerping between same values might not produce the same value
            float lerp(float v0, float v1, float t) 
            {
                return (1 - t) * v0 + t * v1;
            }*/
        public static int Enemy(string dir, int radius, int[] X, int[] Y)
        {
            int E = 0;
            int Reach = 5;
            int[] PosX = { -1, -2, 4, 1, 3, 0 };
            int[] PosY = { 5, 4, 3, 3, 1, -1 };
            const string Face = "L";
            for (int i = 0; i < PosX.Length; i++)
            {
                if (PosX[i] < Reach && PosY[i] < Reach)
                {
                    E++;
                    switch (Face)
                    {
                        case "U":
                            if (Face == "U" && PosX[i] > 3 || PosX[i] < -3 || PosY[i] < 0 || PosX[i] > PosY[i] || PosX[i] < (-(PosY[i])))
                            {
                                E--;
                            }
                            break;
                        case "R":
                            if (Face == "R" && PosY[i] > 3 || PosY[i] < -3 || PosX[i] < 0 || PosY[i] > PosX[i] || PosY[i] < (-(PosX[i])))
                            {
                                E--;
                            }
                            break;
                        case "D":
                            if (Face == "D" && PosX[i] > 3 || PosX[i] < -3 || PosY[i] > 0 || PosX[i] > (-(PosY[i])) || PosX[i] < PosY[i])
                            {
                                E--;
                            }
                            break;
                        case "L":
                            if (Face == "L" && PosY[i] > 3 || PosY[i] < -3 || PosX[i] > 0 || PosY[i] < PosX[i] || PosY[i] > (-(PosX[i])))
                            {
                                E--;
                            }
                            break;
                    }
                }
            }
            return E;
        }
        public static int SkillTree(int[] T, int[] A)
        {
            int[] tree = { 0,3,0,0,5,0,5 }; //0,0,1,1 //0,3,0,0,5,0,5
            int[] req = { 4,2,4,1,0 }; //2 //4,2,6,1,0
            int N = 0;
            if (req.Max() >= tree.Max()) 
            { 
                N = 1 + req.Max(); 
            }
            else 
            { 
                N = 1 + tree.Max(); 
            }
            return N;
        }
        public static int DemoSol(int[] A)
        {
            int N = 0;
            int[] X = { 1, 3, 6, 4, 1, 2 };
            Array.Sort(X);
            for (int i = 0; i < X.Length; i++)
            {
                N++;
                if (X[i] < N)
                {
                    i++;
                }
                if (X[i] > 0 && X[i] != N)
                {
                   return N;
                }
                if (X[i] > 0 && N == X.Max())
                {
                    N++;
                }
                if (X.Max() <= 0)
                {
                    N = 1;
                }
            }
            return N;
        }
                /*foreach (int i in Ary)
                {
                    N++;
                    //I = i;
                    int Min = Ary.Min();
                    int Max = Ary.Max();
                    Console.WriteLine($"Array: {i} Min: {Min} Max: {Max} " +
                                      $"N: " + N);
                
                    if (Ary[i] > N)
                    {
                        Console.WriteLine($"Compare: {N}");
                    break;
                    }
                }*/
        public static int solution(string E, string L)
        {
            E = "10:00";
            L = "00:00";

            int Fee = 2;
            int Hour = 3;
            int Hours = 4;
            int Cost = 0;

            float Period = 1;

            DateTime enterTime = DateTime.Parse(E);
            DateTime leftTime = DateTime.Parse(L);
            TimeSpan elipsedTime = (-(enterTime.Subtract(leftTime)));

            if (elipsedTime.TotalHours <= 1.0)
            {
                Cost = (Fee + Hour);
            }
            if (elipsedTime.TotalHours > 1.0)
            {
                Period = (float)elipsedTime.TotalHours;
                int multiPeriod = ((int)Period);
                if (elipsedTime.TotalHours <= 2.0)
                {
                    Cost = ((Fee + Hour) + (Hours));
                }
                else if (elipsedTime.TotalHours > 2.0)
                {
                    float[] h = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23 };
                    float decimalVals = (float)elipsedTime.TotalHours;
                    foreach (float i in h)
                    {
                        if (decimalVals == i)
                        {
                            multiPeriod = ((int)Period - 1);
                            Cost = ((Fee + Hour) + (Hours * multiPeriod));
                        }
                        else if (decimalVals > i)
                        {
                            multiPeriod = ((int)Period);
                            Cost = ((Fee + Hour) + (Hours * multiPeriod));
                        }
                    }
                }
            }
            Console.WriteLine($"Entered Time: {E}");
            Console.WriteLine($"Exited Time:  {L}");
            Console.WriteLine($"Total Time:   {Period}");
            Console.WriteLine("Sub Amount:   " + Cost);
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            return Cost;
        }
        public static int ParityDegree(int N)
        {
            N = 106496;
            double B = 2;
            double[] P = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14,
                           15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25,
                           26, 27, 28, 29, 30, 31, 32, 33 };
            double A = 0;
            double C = 0;
            //for (int p = 0; p <=)
            foreach(double i in P)
            {
                C = Math.Pow(B, i);              
                if (N == C * i)
                {
                    Console.WriteLine($"Div is : {i}");
                    A = i;
                }
            }
            return (int)A;
        }
        public static string ThreeKings(int A, int B)
        {
            A = 5;
            B = 3;
            int pos = 0;
            string c = "c";//(a * A) + (b * B);
            char current = '\u0000';
            char[] letters = { 'a', 'b' };
            Random rnd = new Random();
            
            StringBuilder strBuild1 = new StringBuilder();
            StringBuilder strBuild3 = new StringBuilder();
            for (int i = 0; i < A; i++)
            {
                strBuild3.Append(letters[0]);
                Console.WriteLine($"[NOTE]: {letters[0]}");
                for (int k = 0; k < strBuild3.Length; k = k + 2)
                {
                    strBuild3[k] = char.ToLower(letters[1]);
                }
            }
            for (int i = 0; i < B; i++)
            {
                strBuild3.Append(letters[1]);
                Console.WriteLine($"[NOTE]: {letters[1]}");
                for (int k = A; k < strBuild3.Length; k = k + 2)
                {
                    strBuild3[k] = char.ToLower(letters[0]);
                }
            }
            string strBuildStr3 = strBuild3.ToString();
            Console.WriteLine($"[3LETTERS]: {strBuildStr3}");
            for (ushort ctr = (ushort)'a'; ctr <= (ushort)'a'; ctr++)
            {
                strBuild1.Append(Convert.ToChar(ctr), A);
            }
            StringBuilder strBuild2 = new StringBuilder();
            for (ushort ctr = (ushort)'b'; ctr <= (ushort)'b'; ctr++)
            {
                strBuild2.Append(Convert.ToChar(ctr), B);
            }
            string[] temps = { strBuild1.ToString(), strBuild2.ToString() };
            
            do
            {
                if (strBuild1[pos] != current)
                {
                    current = strBuild1[pos];
                    strBuild1[pos] = char.ToUpper(strBuild1[pos]);
                   
                    if (pos < 3) 
                    { 
                        strBuild1.Replace("a", "b"); 
                    }
                    strBuild1[pos] = char.ToLower(strBuild1[pos]);
                    pos += 2;
                    
                }
                else { pos++; }
                if (strBuild2[pos] != current)
                {
                    current = strBuild2[pos];
                    strBuild2[pos] = char.ToUpper(strBuild2[pos]);
                    if (pos < 3) 
                    { 
                        strBuild2.Replace("b", "a"); 
                    }
                    strBuild2[pos] = char.ToLower(strBuild2[pos]);
                    pos += 2;
                }
                else { pos++; }
            } while (pos <= strBuild1.Length - 1 && pos <= strBuild2.Length - 1);
            string strBuildString1 = strBuild1.ToString();
            string strBuildString2 = strBuild2.ToString();
            Console.WriteLine("Three Kings: " + strBuildString1 + strBuildString2);
            for (int i = 0; i < A; i++)
            {
               
               // Console.WriteLine($"String: {c}");
                for (i = 0; i < B; i++)
                {
                }
            
            }
            //StringWriter sw = new StringWriter();
            //sw.Write(a);
            //Console.WriteLine(sw.ToString());
            //b.Where(x => A == 'a').Select(x => A.ToString());
            return c;
        }
    }
}
/*
 *              E = "10:00";
                L = "14:21";
                int Fee = 2;
                int Hour = 3;
                int Hours = 4;
                int Cost = 0;
                float Period = 1;
                DateTime enterTime = DateTime.Parse(E);
                DateTime leftTime = DateTime.Parse(L);
                TimeSpan elipsedTime = (-(enterTime.Subtract(leftTime)));
                if (elipsedTime.TotalHours <= 1.0)
                {
                    Cost = Fee + Hour;
                }
                if (elipsedTime.TotalHours > 1.0)
                {
                    Period = (float)elipsedTime.TotalHours;
                    int multiPeriod = ((int)Period);
                    Cost = Fee + Hour + (Hours * multiPeriod);
                    Console.WriteLine($"Entered Time: {E}");
                    Console.WriteLine($"Exited Time:  {L}");
                    Console.WriteLine("Sub Amount:   " + Cost);

            }
                // write your code in C# 6.0 with .NET 4.5 (Mono)
                return Cost;**/