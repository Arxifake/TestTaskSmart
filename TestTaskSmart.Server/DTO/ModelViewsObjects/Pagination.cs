namespace TestTaskSmart.Server.DTO.ModelViewsObjects
{
    public class Pagination<T>
    {
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }
        public List<T> Items { get; set; }
        public string SortBy { get; set; }
        public string SortType { get; set; }

        public Pagination(List<T> items, int count, int pageIndex, int pageSize, string searchString, string sortBy, string sortType)
        {
            SearchString = searchString;
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            Items = items;
            SortBy = sortBy;
            SortType = sortType;
        }

        public bool HasPrevPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;

        public static Pagination<T> Create(IEnumerable<T> source, int pageIndex, int pageSize, string searchString, string sortBy, string sortType)
        {
            var count = source.Count();
            if (pageIndex > (int)Math.Ceiling(count / (double)pageSize))
            {
                pageIndex = (int)Math.Ceiling(count / (double)pageSize);
            }
            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return new Pagination<T>(items, count, pageIndex, pageSize, searchString, sortBy, sortType);
        }
    }
}
