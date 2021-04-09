using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrete;
using Entities.DTOs;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DebitCardsController : ControllerBase
    {
        private readonly IDebitCardService _debitCardService;
        public DebitCardsController(IDebitCardService debitCardService)
        {
            _debitCardService = debitCardService;
        }

        [HttpPost("add")]
        public IActionResult Add(DebitCard debitCard)
        {
            var result = _debitCardService.Add(debitCard);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(DebitCard debitCard)
        {
            var result = _debitCardService.Delete(debitCard);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(DebitCard debitCard)
        {
            var result = _debitCardService.Update(debitCard);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpPost("addbalance")]
        public IActionResult AddBalance(decimal amount, int cardId)
        {
            var result = _debitCardService.AddBalance(amount, cardId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpPost("decreasebalance")]
        public IActionResult DecreaseBalance(decimal amount, int cardId)
        {
            var result = _debitCardService.DecreaseBalance(amount, cardId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }



        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _debitCardService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbycardid")]
        public IActionResult GetByCardId(int cardId)
        {
            var result = _debitCardService.GetByCardId(cardId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbycardnumber")]
        public IActionResult GetByCardNumber(string cardNumber)
        {
            var result = _debitCardService.GetByCardNumber(cardNumber);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("checkcard")]
        public IActionResult CheckCard(string cardNumber)
        {
            var result = _debitCardService.CheckCard(cardNumber);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("addrental")]
        public IActionResult AddRental(PaymentDto paymentDto)
        {
            var result = _debitCardService.AddRental(paymentDto.cardNumber, paymentDto.rental, paymentDto.amount);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
