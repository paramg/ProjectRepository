using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.String
{
    [TestClass]
    public class MultiplyTwoStrings
    {
        [TestMethod]
        public void TestMultiplyTwoStrings()
        {
            string output =  this.MultiplyTwoStringValues("23958233",
                "5831");

            Assert.AreEqual(output, "139676498390");
        }

        public string MultiplyTwoStringValues(string str1, string str2)
        {
            List<string> intermediateResults = new List<string>();
            for(int i=str2.Length-1; i>=0 ; i--)
            {
                int level = (str2.Length -1) - i;
                string intermediate = string.Empty;
                int r = 0;

                for (int j=str1.Length -1; j>=0 ; j--)
                {
                    int dem = int.Parse(str2[i].ToString());
                    int num = int.Parse(str1[j].ToString());

                    int ans =  (dem* num) + r;

                    int q = ans;
                    r = 0;
                    // it has carry
                    if (ans.ToString().Length > 1)
                    {
                         q = int.Parse(ans.ToString()[1].ToString());
                         r = int.Parse(ans.ToString()[0].ToString());
                    }

                    intermediate = q.ToString() + intermediate;
                }

                intermediate = r > 0 ? r.ToString() + intermediate : intermediate;

                while (level > 0)
                {
                    intermediate = intermediate + "0";
                    level--;
                }

                intermediateResults.Add(intermediate);
            }

            int largestLen = 0;
            int counter = 0;
            while(counter < intermediateResults.Count)
            {
                int len = intermediateResults[counter].Length;

                largestLen = Math.Max(largestLen, len);
                counter++;
            }

            List<string> intermediateResultTemp = new List<string>();

            for(int i= 0; i< intermediateResults.Count; i++)
            {
                string temp =  intermediateResults[i];

                if (temp.Length < largestLen)
                {
                    int val = largestLen - temp.Length;
                    string zeros = string.Empty;
                    for (int spac = 1; spac <= val; spac++)
                    {
                        zeros += "0";
                    }

                    string tempWithZeros = zeros + intermediateResults[i];

                    intermediateResultTemp.Add(tempWithZeros);
                }
                else
                {
                    intermediateResultTemp.Add(temp);
                }
            }

            int resultCounter = 0;
            int carry = 0;
            string finalResult = string.Empty;

            while (resultCounter < intermediateResultTemp.First().Length)
            {
                int level = 0;
                int val = 0;
                
                while (level < intermediateResultTemp.Count)
                {
                    string value = intermediateResultTemp[level];
                    val += int.Parse( value[value.Length - 1 - resultCounter].ToString());

                    level++;
                }

                val += carry;
                carry = 0;
                int q = val;
                if (val.ToString().Length > 1)
                {
                    q = int.Parse( val.ToString()[1].ToString());
                    carry = int.Parse(val.ToString()[0].ToString());
                }

                finalResult = q.ToString() + finalResult;

                resultCounter++;
            }

            finalResult = carry > 0 ? carry.ToString() + finalResult : finalResult;

            return finalResult;
        }
    }
}
