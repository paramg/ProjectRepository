using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DynamicProgramming
{
    public class Job
    {
        public char JobName;
        public int StartTime;
        public int EndTime;
        public int Weight;
        public int CalculatedWeight;

        public Job(char jobName, int startTime, int endTime, int weight)
        {
            this.JobName = jobName;
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.Weight = weight;
            this.CalculatedWeight = weight;
        }
    }

    [TestClass]
    public class WightedJobScheduling
    {
        public int GetMaxJobSchedule(List<Job> jobs)
        {
            List<char> charList = new List<char>();
            jobs.Sort(Comparer<Job>.Create((j1, j2) => j1.EndTime.CompareTo(j2.EndTime)));

            for(int i=1; i< jobs.Count; i++)
            {
                for(int j=0; j< i; j++)
                {
                    if (jobs[i].StartTime >= jobs[j].EndTime)
                    {
                        jobs[i].CalculatedWeight = Math.Max(jobs[i].CalculatedWeight, jobs[i].Weight + jobs[j].CalculatedWeight);
                    }
                }
            }

            var maxProfitJob = jobs.Where((j) => j.CalculatedWeight == jobs.Max<Job>((job) => job.CalculatedWeight)).FirstOrDefault();

            return maxProfitJob.CalculatedWeight;
        }

        [TestMethod]
        public void TestMethod()
        {
            var jobs = new Job[] { new Job('a', 1,4, 3), new Job('b', 2, 6, 5), new Job('c', 4,7,2), new Job('d', 5, 9, 4), new Job('e', 6, 8, 6), new Job('f', 7, 10, 8)};
            int maxProfit =  this.GetMaxJobSchedule(jobs.ToList());

            Assert.AreEqual(maxProfit, 13);
        }
    }
}