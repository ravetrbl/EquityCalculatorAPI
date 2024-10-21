using EquityCalculatorAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EquityCalculatorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquityCalculatorController : ControllerBase
    {
        [HttpPost]
        [Route("calculate")]
        public IActionResult CalculateEquity([FromBody] EquityCalculatorModel model)
        {
            if (model == null)
            {
                return BadRequest("invalid data");
            }

            decimal monthlyAmount = model.SellingPrice / model.EquityTerm;
            DateTime startDate = model.ReservationDate.AddMonths(1);
            List<PaymentInfo> paymentSchedule = new List<PaymentInfo>();
            decimal currentBalance = model.SellingPrice - monthlyAmount;

            for (int term = 1; term <= model.EquityTerm; term++)
            {
                PaymentInfo payment = new PaymentInfo();
                payment.Term = term;
                payment.Balance = currentBalance;
                payment.DueDate = startDate.AddMonths(term - 1);
                payment.Amount = monthlyAmount;
                payment.Interest = 0.05m * payment.Balance;
                payment.Insurance = 0.01m * payment.Amount;
                payment.Total = payment.Amount + payment.Interest + payment.Insurance;
                paymentSchedule.Add(payment);
                currentBalance -= monthlyAmount;
            }

            return Ok(paymentSchedule);
        }
    }

   
}
