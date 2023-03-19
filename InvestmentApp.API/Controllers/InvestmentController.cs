using InvestmentApp.API.Models;
using InvestmentApp.Core.Entities;
using InvestmentApp.Core.Enums;
using InvestmentApp.Infrastructure.ApplicationData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace InvestmentAppProd.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class InvestmentController : ControllerBase
    {
        private readonly InvestmentDBContext _context;

        public InvestmentController(InvestmentDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<InvestmentResponse>> FetchInvestment()
        {
            try
            {
                var investmentList = _context.Investments.ToList();
                var investmentResponseList = JsonConvert.DeserializeObject<List<InvestmentResponse>>(JsonConvert.SerializeObject(investmentList));
                return Ok(investmentResponseList);
            }
            catch (Exception e)
            {
                return NotFound(e.ToString());
            }
        }

        [HttpGet("name")]
        public ActionResult<InvestmentResponse> FetchInvestment([FromQuery] string name)
        {
            try
            {
                var investment = _context.Investments.Find(name);
                if (investment == null)
                    return NotFound();

                var investmentResponse = JsonConvert.DeserializeObject<InvestmentResponse>(JsonConvert.SerializeObject(investment));
                return Ok(investmentResponse);
            }
            catch (Exception e)
            {
                return NotFound(e.ToString());
            }
        }


        [HttpPost]
        public ActionResult<Investment> AddInvestment([FromBody] InvestmentRequest investmentRequest)
        {
            try
            {
                if (investmentRequest.StartDate > DateTime.Now)
                {
                    return BadRequest("Investment Start Date cannot be in the future.");
                }

                // covert the investment type string to enum.
                if (!Enum.TryParse<InterestType>(investmentRequest.InterestType, out var InterestType))
                {
                    return BadRequest($"Invalid value for interest type. Valid values are: {string.Join(", ", Enum.GetNames(typeof(InterestType)))}.");
                }

                // validate the investment exists in the db
                var isExisted = _context.Investments.Any(i => i.Name == investmentRequest.Name);
                if (isExisted)
                {
                    return BadRequest("Investment already exists.");
                }

                var investment = JsonConvert.DeserializeObject<Investment>(JsonConvert.SerializeObject(investmentRequest));

                investment.CalculateValue();
                _context.ChangeTracker.Clear();
                _context.Investments.Add(investment);
                _context.SaveChanges();

                var investmentResponse = JsonConvert.DeserializeObject<InvestmentResponse>(JsonConvert.SerializeObject(investment));
                return CreatedAtAction("AddInvestment", investment.Name, investmentResponse);
            }
            catch (DbUpdateException dbE)
            {
                return Conflict(dbE.ToString());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.ToString());
            }
        }

        [HttpPut("name")]
        public ActionResult UpdateInvestment([FromQuery] string name, [FromBody] InvestmentRequest investmentRequest)
        {
            try
            {
                if (name != investmentRequest.Name)
                    return BadRequest("Name does not match the Investment you are trying to update.");

                if (investmentRequest.StartDate > DateTime.Now)
                    return BadRequest("Investment Start Date cannot be in the future.");

                // covert the investment type string to enum.
                if (!Enum.TryParse<InterestType>(investmentRequest.InterestType, out var InterestType))
                {
                    return BadRequest($"Invalid value for interest type. Valid values are: {string.Join(", ", Enum.GetNames(typeof(InterestType)))}.");
                }

                // validate the investment exists in the db
                var isExisted = _context.Investments.Any(i => i.Name == name);
                if (!isExisted)
                {
                    return NotFound();
                }

                var investment = JsonConvert.DeserializeObject<Investment>(JsonConvert.SerializeObject(investmentRequest));

                investment.CalculateValue();
                _context.ChangeTracker.Clear();
                _context.Entry(investment).State = EntityState.Modified;
                _context.SaveChanges();

                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.ToString());
            }
        }

        [HttpDelete("name")]
        public ActionResult DeleteInvestment([FromQuery] string name)
        {
            try
            {
                var investment = _context.Investments.Find(name);
                if (investment == null)
                {
                    return NotFound();
                }
                _context.ChangeTracker.Clear();
                _context.Investments.Remove(investment);
                _context.SaveChanges();

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }

        }
    }
}
