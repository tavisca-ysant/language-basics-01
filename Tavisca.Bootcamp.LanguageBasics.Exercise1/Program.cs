using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }

        public static int FindDigit(string equation)
        {
            // Add your code here.
            string[] arr = equation.Split('=');
			string[] leftOps = arr[0].Split('*');
            int A = 0;
            int B = 0, C = 0;
            double valA = 0.0, valB = 0.0;
            int nQues = 0;
            int res = 0;
            int index = 0;
            //Find question marks in A, B and C respectively
            A = (leftOps[0].Contains("?")) ? -1: Convert.ToInt32(leftOps[0]);
            if(A == -1) nQues++;
            B = (leftOps[1].Contains("?")) ? -1: Convert.ToInt32(leftOps[1]);
            if(B == -1) nQues++;
            C = (arr[1].Contains("?")) ? -1: Convert.ToInt32(arr[1]);
            if(C == -1) nQues++;
            //IF more than one question mark, we can't solve this
            if(nQues > 1)
                return -1;
            //If result itself has a question, it's easy to calculate
            if(C == -1){
                C = A * B;
                string myC = C.ToString();
                index = arr[1].IndexOf('?');

                res = myC[index] - '0';
                return res;
            }
           else if(A == -1){
               // In case if we get a floating point number, it's not exact multiplication
                    valA = (double)C / B;
                    string checkA = valA.ToString();
                    if(checkA.Contains(".")) return -1;
                    A = C / B;    
                    string myA = A.ToString();
                    //Avoiding leading zeroes here
                    if(myA.Length != leftOps[0].Length) return -1;
                    index = leftOps[0].IndexOf('?');
                    res = myA[index] - '0';
                    return res;
                }
           else{
                    valB = (double)C / A;
                    string checkB = valB.ToString();
                    if(checkB.Contains(".")) return -1;
                     B = C / A;
                     string myB = B.ToString(); 
                     if(myB.Length != leftOps[1].Length) return -1;
                     index = leftOps[1].IndexOf('?');
                     res = myB[index] - '0';
                     return res;
                }
            }
        }
    }

