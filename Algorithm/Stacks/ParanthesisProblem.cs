namespace Stacks
{
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ParanthesisProblem
    {
        public bool ValidateParanthesis(char[] bracketsList)
        {
            if (bracketsList == null || bracketsList.Length == 0) return false;

            Stack<char> stack = new Stack<char>();
            for(int i=0; i <= bracketsList.Length - 1; i++)
            {
                if (bracketsList[i] == '{' || bracketsList[i] == '(')
                {
                    stack.Push(bracketsList[i]);
                }
                else
                {
                    char openbrackets = stack.Pop();
                    if (!this.IsValidMatchingbrackets(openbrackets, bracketsList[i]))
                    {
                        return false;
                    }
                }
            }

            if (stack.Count > 0) return false;

            return true;
        }

        private bool IsValidMatchingbrackets(char open, char close)
        {
            if (open == '(' && close == ')')
                return true;
            else if (open == '{' && close == '}')
                return true;

            return false;
        }
        
        [TestMethod]
        public void TestValidateParanthesis()
        {
            string paranthesis = "{{";

           bool result =  this.ValidateParanthesis(paranthesis.ToCharArray());

            Assert.AreEqual(result, false);
        }
    }
}
