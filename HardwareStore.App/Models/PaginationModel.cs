namespace HardwareStore.App.Models
{
    public class PaginationModel
    {
        public int Page { get; set; }

        public int PageSize { get; set; }

        public bool HasPreviousPage => Page > 1;

        public bool HasNexPage => Page < PageSize;

        public int PreviousPageNumber => Page - 1 == 0 ? 1 : Page - 1;

        public int NextPageNumber => Page + 1 > PageSize ? PageSize : Page + 1;
    }
}
