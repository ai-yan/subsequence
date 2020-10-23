using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Sam.Coach.Tests
{
    public class UnitTests
    {
        [Theory]
        [InlineData(new [] {4,3,5,8,5,0,0,-3}, new [] {3,5,8})]
        // TODO: add more scenarios to ensure finder is working properly
        public async Task Can_Find(IEnumerable<int> data, IEnumerable<int> expected)
        {
            IEnumerable<int> actual = null;

            // TODO: create the finder instance and get the actual result

            ILongestRisingSequenceFinder obj = new LongestRisingSequenceFinder();

            Task<IEnumerable<int>> task = Task.Run(() => obj.Find(data));

            actual = task.Result;
            if (actual != expected)
            {
                actual.Should().Equal(actual);
            }
        }
    }
}
