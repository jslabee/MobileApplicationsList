namespace MobileApplicationsList.Services.ApiModel
{
    public class PageParameters<T>
    {
        const int maxPageSize = 50;
        public int PageNumber { get; set; } = 1;

        public int maxpages { get; set; }

        private int _pageSize = 10;
        public List<T>? Items { get; set; }
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = value > maxPageSize ? maxPageSize : value;
            }
        }
    }
}