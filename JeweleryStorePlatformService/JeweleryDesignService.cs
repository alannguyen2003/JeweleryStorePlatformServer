
using AutoMapper;
using Azure.Core;
using JeweleryStorePlatformBusinessObject.Design;
using JeweleryStorePlatformBusinessObject.Diamond;
using JeweleryStorePlatformBusinessObject.Jewelery;
using JeweleryStorePlatformDataTransfer.Request;
using JeweleryStorePlatformDataTransfer.Request.Diamond;
using JeweleryStorePlatformRepository;
using JeweleryStorePlatformRepository.Interface;
using JeweleryStorePlatformService.DTOs;
using JeweleryStorePlatformService.Interface;

namespace JeweleryStorePlatformService;

public class JeweleryDesignService : IJeweleryDesignService
{
    private readonly IJeweleryDesignRepository _jeweleryDesignRepository;
    private readonly IJeweleryDesignImageRepository _jeweleryDesignImageRepository;
    private readonly IMapper _mapper;

    public JeweleryDesignService(IJeweleryDesignRepository jeweleryDesignRepository, IMapper mapper, IJeweleryDesignImageRepository jeweleryDesignImageRepository)
    {
        _jeweleryDesignRepository = jeweleryDesignRepository;
        _mapper = mapper;
        _jeweleryDesignImageRepository = jeweleryDesignImageRepository;
    }

    public async Task<List<JeweleryDesign>> GetAllJeweleryDesign()
    {
        return await _jeweleryDesignRepository.GetAllJeweleryDesign();
    }

    public async Task<JeweleryDesign> AddNewJeweleryDesign(CreateJeweleryDesignRequest jeweleryDesign)
    {
        var design = _mapper.Map<JeweleryDesign>(jeweleryDesign);
        var jewelery = new JeweleryDesign()
        {
            DesignDescription = jeweleryDesign.DesignDescription,
        };
        var created = await _jeweleryDesignRepository.AddNewJeweleryDesign(jewelery);
        if (jeweleryDesign.ImageUrl != null && jeweleryDesign.ImageUrl.Count > 0)
        {
            for (int i = 0; i < jeweleryDesign.ImageUrl.Count; i++)
            {
                var image = new JeweleryDesignImage
                {
                    JeweleryDesignId = created.Id,
                    ImageUrl = jeweleryDesign.ImageUrl[i],
                    ImageDescription = jeweleryDesign.ImageDescription,
                };

                await _jeweleryDesignImageRepository.AddNewJeweleryDesignImage(image);
            }
        }
        return _mapper.Map<JeweleryDesign>(created);
    }
}