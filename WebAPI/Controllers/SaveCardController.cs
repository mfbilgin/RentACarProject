using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaveCardController : Controller
    { 
        private readonly ISaveCardService _saveCardService;

        public SaveCardController(ISaveCardService saveCardService)
        {
            _saveCardService = saveCardService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _saveCardService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyuserid")]
        public IActionResult GetByUserId(int userId)
        {
            var result = _saveCardService.GetByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbycardnumber")]
        public IActionResult GetByCardNumber(string cardNumber)
        {
            var result = _saveCardService.GetByCardNumber(cardNumber);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(SavedDebitCard savedDebitCard)
        {
            var result = _saveCardService.Add(savedDebitCard);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(SavedDebitCard savedDebitCard)
        {
            var result = _saveCardService.Delete(savedDebitCard);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}