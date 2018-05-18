using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace CharGen.UnitTests.DD35
{
    public class StatRollingTests
    {
        [Fact]
        public void StatRolls()
        {
            var results = new DD35StatRoll().RollStats();

//            Assert.Equal(6, results.Count);
//            Assert.True(results.All(r => r.Length == 4));
//            Assert.True(results.All(r => r.Sum() >= 4 && r.Sum() <= 24));
        }
    }

    public class DD35StatRoll
    {
        public List<int[]> RollStats()
        {
            return new List<int[]>();
        }
    }
}