using TaskTimeDurationCalc.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTimeDurationCalc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskTimeCalculatorController : ControllerBase
    {
        private readonly TaskTimeCalculateService _taskTimeCalculateDateService;

        public TaskTimeCalculatorController()
        {
            _taskTimeCalculateDateService = new TaskTimeCalculateService();
        }
        [HttpGet]
        public string GetEndDate(DateTime startDate, int daysOfComplete)
        {
            var endDate = _taskTimeCalculateDateService.CalculateEndDate(startDate, daysOfComplete);
            return endDate;
        }
    }
}
