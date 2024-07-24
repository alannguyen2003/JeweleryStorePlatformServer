using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using JeweleryStorePlatformAPI.Configuration.Cloudinary;
using JeweleryStorePlatformAPI.Configuration.Cloudinary.Interface;
using Microsoft.Extensions.Options;

namespace JeweleryStorePlatformAPI.Configuration;

public class ImageService : IImageService
{
    private readonly CloudinaryDotNet.Cloudinary _cloudinary;

    public ImageService(IOptions<CloudinarySetting> options)
    {
        var account = new Account(options.Value.CloudName, options.Value.ApiKey, options.Value.ApiSecret);
        _cloudinary = new CloudinaryDotNet.Cloudinary(account);
    }
    
    public async Task<ImageUploadResult> UploadImageAsync(IFormFile file)
    {
        var result = await _cloudinary.UploadAsync(
            new ImageUploadParams()
            {
                File = new FileDescription(file.FileName, file.OpenReadStream()),
                DisplayName = file.FileName,
                Folder = "diamonds"
            }
        );
        if (result != null && result.StatusCode == System.Net.HttpStatusCode.OK)
        {
            return result;
        }
        return null;
    }

    public async Task<DeletionResult> DeletePhotoAsync(string publicId)
    {
        var deleteParams = new DeletionParams(publicId);
        return await _cloudinary.DestroyAsync(deleteParams);
    }
}