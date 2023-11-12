using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class Event
    {
        public int Id { get; set; }
        [Display(Name = "Мероприятие")]
        public string Name { get; set; }
        [Display(Name = "Ед. измерения")]
        public string Unit { get; set; }
    }
}
