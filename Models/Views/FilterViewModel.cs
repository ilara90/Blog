namespace Blog.Models.Views
{
    public class FilterViewModel
    {
        public FilterViewModel(int? category, DateTime? dateFrom, DateTime? dateTo, List<int> tagIds)
        {
            SelectedCategory = category;
            SelectedDateFrom = dateFrom;
            SelectedDateFromString = String.Format("{0:yyyy-MM-dd}", dateFrom);
            SelectedDateTo = dateTo;
            SelectedDateToString = String.Format("{0:yyyy-MM-dd}", dateTo);
            SelectedTagIds = tagIds;
        }
        public int? SelectedCategory { get; private set; }
        public DateTime? SelectedDateFrom { get; private set; }
        public string SelectedDateFromString { get; private set; }
        public DateTime? SelectedDateTo { get; private set; }
        public string SelectedDateToString { get; private set; }
        public List<int> SelectedTagIds { get; set; }
    }
}
