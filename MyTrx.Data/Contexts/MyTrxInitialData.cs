using MyTrx.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTrx.Data.Contexts
{
    public class MyTrxInitialData
    {
        private MyTrxContext _context;

        public MyTrxInitialData(MyTrxContext context)
        {
            _context = context;
        }

        public async Task SeedData()
        {
            if (!_context.Categories.Any())
            {
                var toBeBudgeted = new Category()
                {
                    Name = "To Be Budgeted",
                };

                _context.Categories.Add(toBeBudgeted);
                await _context.SaveChangesAsync();
            }
        }
    }
}
