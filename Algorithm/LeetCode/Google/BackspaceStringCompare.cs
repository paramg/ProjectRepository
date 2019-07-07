using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Google
{
    [TestClass]
    public class BackspaceStringCompare
    {
        public bool DoBackSpaceMatchInArray(string S, string T)
        {
            Stack<char> stack1 = this.BuildStack(S);
            Stack<char> stack2 = this.BuildStack(T);

            if (stack1.Count != stack2.Count)
            {
                return false;
            }

            while (stack1.Any())
            {
                char c1 = stack1.Pop();
                char c2 = stack2.Pop();

                if (c1 != c2)
                {
                    return false;
                }
            }

            return true;
        }

        private Stack<char> BuildStack(string str)
        {
            Stack<char> stack = new Stack<char>();
            foreach(char c in str)
            {
                if (c != '#')
                {
                    stack.Push(c);
                }
                else if (stack.Any())
                {
                    stack.Pop();
                }
            }

            return stack;
        }

        [TestMethod]
        public void TestMethod()
        {
            bool isMatch = this.DoBackSpaceMatchInArray("ab##", "c#d#");

            Assert.IsTrue(isMatch);
        }
    }
}
