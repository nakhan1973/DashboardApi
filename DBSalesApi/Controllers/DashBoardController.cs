using DBSalesApi.Models;
using DBSalesApi.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBSalesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DashBoardController : ControllerBase
    {


        private readonly ILogger<DashBoardController> _logger;
        private readonly DashBoardService _context;

        public DashBoardController(ILogger<DashBoardController> logger, DashBoardService context)
        {
            _logger = logger;
            this._context = context;
        }

        [HttpGet]
        public ActionResult<DashboardData> Get()
        {
            DashboardData dbData = new DashboardData();

            dbData.TotalCallsAttempt = _context.Calls.Count();
            dbData.MeaningFullCalls = _context.Quotations.Count();
            dbData.QuotationIssued = _context.Quotations.Count();
            dbData.QuotationValue = _context.Quotations.Select(x => x.TotalAmount).Sum();
            dbData.BusinessClosed = _context.Quotations.Where(x => x.Invoiced == true).Count();

            var x = _context.Quotations.GroupBy(x => x.Agent.FullName);
            dbData.SalesAgents = _context.Quotations.GroupBy(x => new { x.Agent.FullName})
                .Select(b => new SalesAgents
                {
                    QuotationQty = b.Count(),
                    QuotationValue = b.Sum(x=> x.TotalAmount),
                    AgentName = b.Key.FullName
                }).ToList();

            

            return Ok(dbData);
        }
    }
}
