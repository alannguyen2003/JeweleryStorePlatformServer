using JeweleryStorePlatformBusinessObject.Promotion;
using JeweleryStorePlatformService;
using JeweleryStorePlatformService.DTOs;
using JeweleryStorePlatformService.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JeweleryStorePlatformAPI.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class PromotionController : ControllerBase
    {
        private readonly IPromotionService _promotionService;

        public PromotionController(IPromotionService promotionService)
        {
            _promotionService = promotionService;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllPromotions()
        {
            return Ok(await _promotionService.GetAllPromotions());
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreatePromotion([FromBody] PromotionDTO promotionDTO)
        {
            if (promotionDTO == null)
            {
                return BadRequest("Invalid promotion data.");
            }

            var promotion = new Promotion
            {
                PromotionName = promotionDTO.PromotionName,
                PromotionContent = promotionDTO.PromotionContent,
                Amount = promotionDTO.Amount,
                Percentage = promotionDTO.Percentage
            };

            await _promotionService.AddNewPromotion(promotion);
            return CreatedAtAction(nameof(GetPromotionById), new { id = promotion.Id }, promotion);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdatePromotion([FromBody] Promotion promotion)
        {
            if (promotion == null)
            {
                return BadRequest("Invalid promotion data.");
            }

            var updatedPromotion = await _promotionService.UpdatePromotion(promotion);
            return Ok(updatedPromotion);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeletePromotion(int id)
        {
            var result = await _promotionService.DeletePromotion(id);
            if (!result)
            {
                return NotFound("Promotion not found.");
            }

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPromotionById(int id)
        {
            var promotion = await _promotionService.GetPromotionById(id);
            if (promotion == null)
            {
                return NotFound("Promotion not found.");
            }

            return Ok(promotion);
        }
    }
}
