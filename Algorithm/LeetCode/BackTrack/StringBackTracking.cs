using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.BackTrack
{
    [TestClass]
    public class StringBackTracking
    {
        /// <summary>
        /// consider input 
        /// A = {a,b,c,x}
        /// B = {d,e,f,g}
        /// C = {a,d,b,c,e,f,g,x}
        /// Make sure the C is in order of A and B
        /// </summary> 
        /// <returns></returns>
        public bool IsStringInterleaved(string A, string B, string C, int indexA, int indexB, int indexC)
        {
            // boundary
            if (indexA >= A.Length && indexB >= B.Length && indexC >= C.Length)
            {
                return true;
            }

            // main logic
            bool flagA = false, flagB = false;
            if (indexA < A.Length && indexC < C.Length && C[indexC] == A[indexA])
            {
                flagA = this.IsStringInterleaved(A, B, C, indexA + 1, indexB, indexC + 1);
            }
            else if (indexB < B.Length && indexC < C.Length && C[indexC] == B[indexB])
            {
                flagB = this.IsStringInterleaved(A, B, C, indexA, indexB + 1, indexC + 1);
            }
            else
            {
                return false;
            }

            return flagA || flagB;
        }

        [TestMethod]
        public void TestIsStringInterleaved()
        {
            bool resultValue = this.IsStringInterleaved("abcx", 
                                                                                        "defg", 
                                                                                        "adbecfgx", 0, 0, 0);
        }
    }
}
