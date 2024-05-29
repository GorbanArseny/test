using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Izuran.Shared.Entities
{
    public class Item
    {
        [Key]
        public Guid IDRef { get; set; }
        public string? Group {  get; set; }
        public string? Name { get; set; }
        public double Quantity { get; set; }
        public string? Unit { get; set; }
        public DateOnly Date { get; set; }
        public string? Counterparty { get; set; }
        public int Type { get; set; }

    }
}
