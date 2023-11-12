namespace WebApplication1.Models.ViewModels
{
    public class PageInfo
    {
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
        public int totalItems { get; set; }
        public int totalPages 
        {
            get { return (int)Math.Ceiling((decimal)totalItems / pageSize); }
        }
    }
}
