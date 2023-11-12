using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class SourceOfFinancing
    {
        public int Id { get; set; }
        [Display(Name = "Средства предприятия")]
        public decimal Enterprise { get; set; }
        [Display(Name = "Средства вышестоящей организации")]
        public decimal Organisation { get; set; }
        [Display(Name = "Средства министерства")]
        public decimal Ministry { get; set; }
        [Display(Name = "Средства республиканского бюджета")]
        public decimal RepublicBudget { get; set; }
        [Display(Name = "Средства локального бюджета")]
        public decimal LocalBudget { get; set; }
    }
}
