using System.ComponentModel.DataAnnotations;

namespace test_hilo
{
    public class Order
    {
        [Key]
        public long Id {get;set;}

        public decimal Quantity {get;set;}
    }
}