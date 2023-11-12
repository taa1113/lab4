using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class PlannedEvent
    {
        public int Id {  get; set; }
        [Column("Enterprise")]
        public int EnterpriseId {  get; set; }
        [Display(Name = "Предприятие")]
        public Enterprise Enterprise { get; set; }
        [Display(Name = "Начало")]
        public DateTime DateOfStart { get; set; }
        [Display(Name = "Конец")]
        public DateTime DateOfEnd { get; set; }
        [Display(Name = "Объём")]
        public int Scope { get; set; }
        [Display(Name = "Затраты")]
        public decimal Expenses { get; set; }
        [Display(Name = "Экономический эффект")]
        public decimal EconomicEffect { get; set; }
        [Column("Responsible")]
        public int EmployeeId { get; set; }
        [Display(Name = "Ответственный")]
        public Employee Responsible { get; set; }
        [Column("Event")]
        public int EventId { get; set; }
        [Display(Name = "Мероприятие")]
        public Event Event { get; set; }
        [Column("Finance")]
        public int FinanceId { get; set; }
        [Display(Name = "Финансирование")]
        public SourceOfFinancing Finance { get; set; }
    }
}
