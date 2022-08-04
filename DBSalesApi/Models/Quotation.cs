using System.ComponentModel.DataAnnotations.Schema;

namespace DBSalesApi.Models
{
    public class Quotation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public decimal TotalAmount { get; set; }
        public bool Invoiced { get; set; }
        public Agent Agent { get; set; }
        public CallAttempts CallAttempt { get; set; }
    }
}