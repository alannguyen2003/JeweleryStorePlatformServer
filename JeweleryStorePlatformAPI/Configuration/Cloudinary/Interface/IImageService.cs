using CloudinaryDotNet.Actions;

namespace JeweleryStorePlatformAPI.Configuration.Cloudinary.Interface;

public interface IImageService
{
    public Task<ImageUploadResult> UploadImageAsync(IFormFile file);
    public Task<DeletionResult> DeletePhotoAsync(string publicId);
}