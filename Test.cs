using System;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace test_hilo
{
    public class Test : Base
    {
        public Test(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void TestHilo()
        {
            var ware = new Ware();
            MainDbContext.Ware.Add(ware);
            var order = new Order();
            order.Ware = ware;
            Assert.Equal(0, order.Id);
            var waresLocal = MainDbContext.Set<Ware>().Local.ToList();
            var wares = MainDbContext.Set<Ware>().ToList();
            Assert.Equal(0, order.Id);
            MainDbContext.Order.Add(order);
            Assert.NotEqual(0, order.Id);
        }
    }
}
