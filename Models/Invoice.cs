using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace WebApplication1.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        [Required]
        [StringLength(150)]
        public string For { get; set; }
        [Required]
        [Display(Name = "Invoice Date")]
        public DateTime InvoiceDate { get; set; } = DateTime.Now;

        public decimal Payment { get; set; }

        public List<InvoiceItem> InvoiceItems { get; set; }

        [NotMapped]
        public decimal InvoiceSum { get { return (InvoiceItems == null) ? 0 : InvoiceItems.Sum(i => i.Price);   } }
    }       

    public class InvoiceItem
    {
        public int InvoiceItemId { get; set; }
        [Required]
        [StringLength(50)]
        public string Code { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        [Required]
        public int Qty { get; set; }
        [Required]
        public int Price { get; set; }
    }
}
