using System;
using Xunit;

namespace MienDev.Common.Pagination.UnitTests
{

    public class PaginationTests
    {
        /// <summary>
        /// Page divid
        /// </summary>
        /// <param name="totalItem"></param>
        /// <param name="pagesize"></param>
        /// <param name="pagesExpect"></param>
        [Theory]
        [InlineData(10, 3, 4)] // common
        [InlineData(10, 5, 2)] // common
        [InlineData(1, 3, 1)] // pageSize bigger than item count
        [InlineData(0, 3, 0)] // item count is zero
        public void PageDivid_ShouldCorrectTest(uint totalItem, uint pagesize, uint pagesExpect)
        {
            var pagination = new Pagination(totalItem, pagesize);
            Assert.Equal(pagesExpect, pagination.TotalPages);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void PageSize_ShouldLaggerThanOneTest(uint pageSize)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var pagination = new Pagination(0, pageSize);
                Assert.NotNull(pagination);
            });
        }

        [Theory]
        [InlineData(10, 3, 3, 6)]
        [InlineData(10, 5, 2, 5)]
        [InlineData(10, 10, 2, 0)]//page is exceed
        [InlineData(10, 15, 2, 0)]// page size is bigger than items count

        public void SkipCount_shouldRetrunCorrect(uint itemCount, uint pageSize, uint page, uint skipCountExpect)
        {
            var pagination = new Pagination(itemCount, pageSize, page);
            Assert.Equal(skipCountExpect, pagination.SkipCount);
        }

    }
}