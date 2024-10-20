
namespace StartMyNewApp.Domain.Queries
{
    public class PagedListGenericQuery<T> where T : class
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string OrderBy { get; set; } = string.Empty;  // Optional: Sort by a specific field
        public bool IsDescending { get; set; } = false;      // Optional: Sort direction

        public PagedListGenericQuery(int pageIndex, int pageSize, string orderBy = "", bool isDescending = false)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            OrderBy = orderBy;
            IsDescending = isDescending;
        }
    }
}