using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.BackTrack
{
    // Tag: Google
    [TestClass]
    public class FrogJumpBackTracking
    {
        public bool FrogJump(int[] stones)
        {
            HashSet<int> hash = new HashSet<int>();
            stones.ToList().ForEach(stone => hash.Add(stone));

            hash.Remove(stones[0]);

            Stack<int> position = new Stack<int>();
            Stack<int> jumps = new Stack<int>();

            position.Push(stones[0]);
            jumps.Push(0);

            int positionIndex = -1;
            while (position.Any())
            {
                positionIndex = position.Pop();
                int lJump = jumps.Pop();

                for(int cJump = lJump -1; cJump <= lJump +1; cJump++)
                {
                    if (positionIndex == stones[stones.Length - 1])
                    {
                        return true;
                    }

                    int nextStonePosition = positionIndex + cJump;
                    if (hash.Contains(nextStonePosition) && nextStonePosition > positionIndex)
                    {
                        position.Push(nextStonePosition);
                        jumps.Push(cJump);
                    }
                }
            }
            return false;
        }

        [TestMethod]
        public void TestMethodFrogCanReach()
        {
            FrogJumpBackTracking jumpBackTracking = new FrogJumpBackTracking();
            bool hasReached = jumpBackTracking.FrogJump(new []{0, 1, 3, 5, 6, 8, 12, 17});

            Assert.IsTrue(hasReached, "The frog should reach the destination.");
        }

        [TestMethod]
        public void TestMethodFrogCannotReach()
        {
            FrogJumpBackTracking jumpBackTracking = new FrogJumpBackTracking();
            bool hasReached = jumpBackTracking.FrogJump(new[] { 1, 3, 6, 7, 11 });

            Assert.IsFalse(hasReached, "The frog should not reach the destination.");
        }
    }
}
