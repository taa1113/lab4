namespace WebApplication1.Models.ViewModels
{
    public class EventsViewModel
    {
        public IEnumerable<Event> Events { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
