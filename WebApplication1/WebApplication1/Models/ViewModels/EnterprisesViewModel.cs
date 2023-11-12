namespace WebApplication1.Models.ViewModels
{
    public class EnterprisesViewModel
    {
        public IEnumerable<Enterprise> Enterprises { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
