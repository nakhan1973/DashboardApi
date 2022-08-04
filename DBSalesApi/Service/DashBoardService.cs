using DBSalesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBSalesApi.Service
{
    public class DashBoardService
    {
        public List<CallAttempts> Calls { get; set; }
        public List<Agent> Agents { get; set; }
        public List<Quotation> Quotations { get; set; }
        public DashBoardService()
        {
            var rand = new Random();
            Calls = Enumerable.Range(1, 75).Select(x => new CallAttempts()
            {
                Id = 1000 + x,
                CallDateTime = DateTime.Now.AddDays(rand.Next(1, 29)),
                Description = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            }).ToList();

            Agents = Enumerable.Range(1, 7).Select(x => new Agent()
            {
                Id = 1 + x,
                FullName = (new string[] { "Robert", "John", "Marry", "Jackson", "Nancy","Philips","Julia" })[new Random().Next(7)],
            }).ToList();

            Quotations = Enumerable.Range(1, 35).Select(x => new Quotation()
            {
                Id = 1 + x,
                TotalAmount = (decimal)(12.3 * (rand.Next(2, 8))),
                Agent = Agents.Skip(rand.Next(6)).FirstOrDefault(),
                CallAttempt = Calls.Where(a => a.Id == rand.Next(1001, 1075)).FirstOrDefault(),
                Invoiced = ((1 + x) % 2 == 0)
            }).ToList();
        }

    }
}
