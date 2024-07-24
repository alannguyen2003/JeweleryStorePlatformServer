using System.Net;
using JeweleryStorePlatformAPI.Configuration.Cloudinary.Interface;
using JeweleryStorePlatformDataTransfer.Response.Image;
using JeweleryStorePlatformDataTransfer.Responses;
using Microsoft.AspNetCore.Mvc;

namespace JeweleryStorePlatformAPI.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ImageController : ControllerBase
{
    private readonly IImageService _imageService;

    public ImageController(IImageService imageService)
    {
        _imageService = imageService;
    }
    
    [HttpPost("upload")]
    public async Task<IActionResult> UploadAsync(IFormFile file)
    {
        var result = await _imageService.UploadImageAsync(file);
        if (result == null)
        {
            ModelState.AddModelError("Upload image", " Something went wrong");
            return Problem("Something went wrong", null, (int)HttpStatusCode.InternalServerError);
        }
        return Ok(new Result<ImageUploadResponse>()
        {
            Succeeded = true,
            Message = "Upload new image successful!",
            Data = new ImageUploadResponse()
            {
                Link = result.SecureUri.AbsoluteUri, 
                PublicId = result.PublicId
            }
        });
    }
}