namespace WebApplication1.Models.ViewModels
{
    public class FinancingViewModel
    {
        public IEnumerable<SourceOfFinancing> Financings { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
