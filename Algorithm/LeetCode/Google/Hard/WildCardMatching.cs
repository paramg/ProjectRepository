using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Google.Hard
{
    [TestClass]
    public class WildCardMatching
    {
        public bool IsWildCardMatch(string s, string p)
        {
            var T = new Boolean[s.Length + 1, p.Length + 1];

            T[0, 0] = true;
            for (int i=1; i< T.GetLength(0); i++)
            {
                T[i, 0] = false;
            }

            // Handle empty case
            for (int j = 1; j < T.GetLength(1); j++)
            {
                if (p.Length > 0 && p[j - 1] == '*')
                {
                    T[0,j] = T[0,j - 2];
                }
            }

            for (int i= 0; i < s.Length; i++)
            {
                for(int j=0; j < p.Length; j++)
                {
                    int tRIndex = i + 1;
                    int tCIndex = j + 1;

                    if (s[i] == p[j] || p[j] == '.')
                    {
                        T[tRIndex, tCIndex] = T[tRIndex - 1, tCIndex - 1];
                    }

                    if (p[j] == '*')
                    {
                        if (T[tRIndex, tCIndex - 2] == true 
                            || ((s[i] == p[j-1] || p[j-1] == '.') && T[tRIndex - 1, tCIndex] == true))
                        {
                            T[tRIndex, tCIndex] = true;
                        }
                    }
                }
            }

            return T[s.Length, p.Length];
        }

        [TestMethod]
        public void TestMethod()
        {
            string str = "ab";
            string pattern = ".*";

            bool isMatch = this.IsWildCardMatch(str, pattern);

            Assert.IsTrue(isMatch);
        }
    }
}
