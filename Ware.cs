using System.ComponentModel.DataAnnotations;

namespace test_hilo
{
    public class Ware
    {
        [Key]
        public long Id {get;set;}

        public string Name {get;set;}
    }
}