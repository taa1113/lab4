namespace WebApplication1.Models.ViewModels
{
    public class PlanningViewModel
    {
        public IEnumerable<PlannedEvent> PlannedEvents { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
