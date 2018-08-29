using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Problem.InterviewCake
{
    [TestClass]
    public class DirtyTestCode
    {
        [TestMethod]
        public void TestMethod1()
        {
            string str = "cats";

            string subStr = str.Substring(0, str.Length - 1);
        }
    }
}
