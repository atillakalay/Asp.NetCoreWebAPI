namespace Entities.RequestFeatures
{
    public abstract class RequestParameters
    {
        const int maxPageSize = 50;
        // Auto-implemented property
        public int PageNumber { get; set; }

        //Full-property
        private int _PageSize;

        public int PageSize
        {
            get { return _PageSize; }
            set { _PageSize = value > maxPageSize ? maxPageSize : value; }
        }
        public string? OrderBy { get; set; }
        public string? Fields { get; set; }
    }
}
