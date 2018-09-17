using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.String
{
    [TestClass]
    public class EvaluateExpression
    {
        private double EvaluateMathExpression(string expression)
        {
            DataTable table = new DataTable();
            table.Columns.Add("expression", typeof(string), expression);

            DataRow row = table.NewRow();
            table.Rows.Add(row);

            return double.Parse((string)row["expression"]);
        }

        private double GetNumber(string expression, ref int counter)
        {
            double temp = 0;
            string result = string.Empty;

            while (counter < expression.Length && double.TryParse(expression[counter].ToString(), out temp))
            {
                result += expression[counter].ToString();
                counter += 1;
            }

            double result_Integer = -1;
            double.TryParse(result.ToString(), out result_Integer);

            return result_Integer;

        }

        public double EvaluateExpressionMethod(string expression)
        {
            double number1 = 0;
            double number2 = 0;

            int counter = 0;

            number1 = this.GetNumber(expression, ref counter);

            while (counter < expression.Length)
            {
                string _operator = string.Empty;
                if (counter + 1 < expression.Length)
                {
                    _operator = expression[counter].ToString();
                }

                if (counter + 1 < expression.Length)
                {
                    ++counter;
                    number2 = this.GetNumber(expression, ref counter);
                }

                string expressionBuilder = number1.ToString() + _operator + number2.ToString();

                Console.WriteLine("Expression Builder: " + expressionBuilder);

                number1 = this.EvaluateMathExpression(expressionBuilder);
            }

            return number1;

        }

        [TestMethod]
        public void TestMethod()
        {
            double result = this.EvaluateExpressionMethod("200+300");
            Console.WriteLine(result);
        }
    }
}
