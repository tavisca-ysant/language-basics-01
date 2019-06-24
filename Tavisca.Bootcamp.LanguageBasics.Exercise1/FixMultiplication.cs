using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1{


        static class Constants{
            public const int NOSOLUTION = -1;
        }
        public class FixMultiplication{

        
        public static int ContainsMissingDigit(string operand){
            if(operand.Contains("?"))
                return Constants.NOSOLUTION;
            return Convert.ToInt32(operand);
        }

        public static int MissingDigitOnLHS(int argument1, int argument2, string operandWithMissingDigit){
            var result = (double)argument1 / argument2;
            if (result.ToString().Contains('.')) return Constants.NOSOLUTION;
             var A = argument1 / argument2;    
            
            var resultString = A.ToString();
                    //Avoiding leading zeroes here
            if(resultString.Length != operandWithMissingDigit.Length) return Constants.NOSOLUTION;
            var index = operandWithMissingDigit.IndexOf('?');
            return resultString[index] - '0';
        }

        public static int FindDigit(string equation)
        {
            string[] arr = equation.Split('=');
			string[] leftOps = arr[0].Split('*');
            string variableA = leftOps[0];
            string variableB = leftOps[1];
            string resultC = arr[1];
            int A = 0;
            int B = 0, C = 0;
            int missingDigitCount = 0;
            //Find question marks in A, B and C respectively
            A = ContainsMissingDigit(variableA);
            if(A == -1) missingDigitCount++;
            B = ContainsMissingDigit(variableB);
            if(B == -1) missingDigitCount++;
            C = ContainsMissingDigit(resultC);
            if(C == -1) missingDigitCount++;
            //IF more than one question mark, we can't solve this
            if(missingDigitCount > 1)
                return Constants.NOSOLUTION;
            //If result itself has a question, it's easy to calculate
            if(C == -1){
                C = A * B;
                var result = C.ToString();
                var index = resultC.IndexOf('?');
                return result[index] - '0';
            }
           else if(A == -1)
                    return MissingDigitOnLHS(C,B, variableA);
            return MissingDigitOnLHS(C,A, variableB);
            }
        }
}