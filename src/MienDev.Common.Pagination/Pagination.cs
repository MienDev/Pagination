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
            // if (itemsCount < 0) throw new ArgumentOutOfRangeException($"{nameof(itemsCount)} should largger or equal with 0");
            if (pageSize <= 1) throw new ArgumentOutOfRangeException($"{nameof(pageSize)} should largger than 1");

            ItemsCount = itemsCount;
            PageSize = pageSize;

            SetCurrentPage(page);
        }

        /// <summary>
        /// Set Current Page number
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public Pagination SetCurrentPage(uint page = 1)
        {
            if (page > TotalPages) page = TotalPages;
            Page = page;
            return this;
        }

        /// <summary>
        /// 返回当前页数 , 用户可定制(queryString) | page =[1, TotalPages]
        /// </summary>
        public uint Page { get; set; }

        /// <summary>
        /// 当前实际按每页多少数量进行返回数据
        /// </summary>
        public uint PageSize { get; set; }

        /// <summary>
        /// 全部数量，共有多少个目标数据
        /// </summary>
        public uint ItemsCount { get; set; }

        /// <summary>
        /// PrevPageLink
        /// </summary>
        public string PrevPageLink { get; set; }

        /// <summary>
        /// NextPageLink
        /// </summary>
        public string NextPageLink { get; set; }

        /// <summary>
        /// 总共有多少页数据
        /// </summary>
        public uint TotalPages => ItemsCount == 0 ? 0 : checked((uint)Math.Ceiling(ItemsCount / (double)PageSize));

        /// <summary>
        /// the skip items count for take some page 
        /// </summary>
        public uint SkipCount => IsValid ? (Page - 1) * PageSize : 0;

        /// <summary>
        /// Is this pagination valid
        /// </summary>
        public bool IsValid => ItemsCount > 0
         && (PageSize > 0)
         && Page > 0
         && Page <= TotalPages;
    }
}