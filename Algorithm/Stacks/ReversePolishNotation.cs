using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problem.Stacks
{
    [TestClass]
    public class ReversePolishNotation
    {
        /// <summary>
        /// Push the stack if it's number
        /// Pop the last two numbers and perform expression with the current operator
        /// Push the result of the previous operation
        /// When the expression list is completed, pop the element from the Stack
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public double Evaluate(string[] expression)
        {
            Stack<string> stack = new Stack<string>();

            for(int i=0; i < expression.Length; i++)
            {
                int number;
                if (int.TryParse(expression[i].ToString(), out number))
                {
                    stack.Push(number.ToString());
                }
                else
                {
                    string number2 = stack.Pop();
                    string number1 = stack.Pop();

                    string @operator = expression[i];

                    string constructExp = number1 + @operator + number2;

                    double result = EvaluateMathExpression(constructExp);

                    stack.Push(result.ToString());
                }
            }

            return Double.Parse(stack.Pop());
        }

        public static double EvaluateMathExpression(string expression)
        {
            DataTable table = new DataTable();
            table.Columns.Add("expression", typeof(string), expression);

            DataRow row = table.NewRow();
            table.Rows.Add(row);

            return double.Parse((string)row["expression"]);
        }
        
        [TestMethod]
        public void Test()
        {
            string[] expression = { "4", "13", "5", "/", "+" };

            double result = this.Evaluate(expression);

            Assert.AreEqual(result, 6.6);

            string[] expression1 = { "2", "1", "+", "3", "*" };

            double result1 = this.Evaluate(expression1);

            Assert.AreEqual(result1, 9);
        }
    }
}
