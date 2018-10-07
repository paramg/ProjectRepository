using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.String
{
    [TestClass]
    public class EditDistanceProblem
    {
        public int EditDistance(char[] str1, char[] str2, int m, int n)
        {
            int minDistance = 0;
            if (m == 0) return n;

            if (n == 0) return m;

            if (str1[m] == str2[n])
            {
                minDistance = this.EditDistance(str1, str2, m - 1, n - 1);
                return minDistance;
            }

            // insert
            int insertDistance = this.EditDistance(str1, str2, m, n - 1);
            // update
            int updateDistance = this.EditDistance(str1, str2, m - 1, n - 1);
            // delete
            int deleteDistance = this.EditDistance(str1, str2, m - 1, n);

            minDistance = 1 + this.GetMin(insertDistance, updateDistance, deleteDistance);

            return minDistance;
        }

        public int GetMin(int value1, int value2, int value3)
        {
            int result = Math.Min(value1, value2);
            return Math.Min(result, value3);
        }

        public int UpdateStringInMinDistance(char[] str1, char[] str2, int m, int n)
        {
            if (m != n) throw new Exception("The string are not equal size.");

            if (m == str1.Length) return 0;
            int minDistance = 0;

            if (str1[m] == str2[n])
            {
                minDistance = this.UpdateStringInMinDistance(str1, str2, m + 1, n + 1);
            }
            else
            {
                str1[m] = str2[n];
                minDistance = 1 + this.UpdateStringInMinDistance(str1, str2, m + 1, n + 1);
            }

            return minDistance;
        }

        [TestMethod]
        public void TestUpdateStringInMinDistance()
        {
            string str1 = "sunday";
            string str2 = "saturday";

            int minDistance = this.EditDistance(str1.ToCharArray(), str2.ToCharArray(), str1.Length -1, str2.Length -1);
        }
    }
}
