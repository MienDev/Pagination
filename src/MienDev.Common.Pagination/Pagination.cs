using System;

namespace MienDev.Common.Pagination
{
    /// <summary>
    /// Pagination
    /// X-Pagination
    /// </summary>
    public class Pagination
    {
        public Pagination() { }

        public Pagination(uint itemsCount, uint pageSize = 10, uint page = 1)
        {
            if (pageSize <=1) throw new ArgumentOutOfRangeException($"{nameof(pageSize)} should largger than 1");

            this.ItemsCount = itemsCount;
            this.PageSize = pageSize;
            this.Page = (page < 1) ? 1 : (page <= TotalPages) ? page : TotalPages;
        }

        public Pagination SetCurrentPage(uint page = 1)
        {
            this.Page = page;
            return this;
        }
        /// <summary>
        /// 返回当前页数 , 用户可定制(queryString) | page =[1, TotalPages]
        /// </summary>
        public uint Page { get; private set; }

        /// <summary>
        /// 当前实际按每页多少数量进行返回数据
        /// </summary>
        public uint PageSize { get; }

        /// <summary>
        /// 全部数量，共有多少个目标数据
        /// </summary>
        public uint ItemsCount { get; }

        /// <summary>
        /// 总共有多少页数据
        /// </summary>
        public uint TotalPages => ItemsCount == 0 ? 0 : (uint)Math.Ceiling(ItemsCount / (double)PageSize);

        /// <summary>
        /// PrevPageLink
        /// </summary>
        public string PrevPageLink { get; set; }

        /// <summary>
        /// NextPageLink
        /// </summary>
        public string NextPageLink { get; set; }
    }
}