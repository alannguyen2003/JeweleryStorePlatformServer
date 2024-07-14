using JeweleryStorePlatformBusinessObject.Account;
using JeweleryStorePlatformBusinessObject.Diamond;
using JeweleryStorePlatformRepository;
using JeweleryStorePlatformRepository.Interface;
using JeweleryStorePlatformService.Interface;
using Service.Models.Payload.Requests.Member;
using Microsoft.EntityFrameworkCore;
using JeweleryStorePlatformService.DTOs;
using Service.Extensions;
using AutoMapper;


namespace JeweleryStorePlatformService;

public class DiamondService : IDiamondService
{
    private readonly IDiamondRepository _diamondRepository;
    private readonly IMapper _mapper;

    public DiamondService(IDiamondRepository diamondRepository, IMapper mapper)
    {
       _diamondRepository = diamondRepository;
        _mapper = mapper;
    }

    public async Task<PaginatedList<DiamondDTO>> GetAllDiamonds(GetDiamondsRequest request)
    { 
        var diamonds = _diamondRepository.GetAllDiamonds()
            .AsQueryable();
         
        if (request.SearchTerm is not null)
        {
            diamonds = diamonds.Where(x => x.DiamondOrigin.Contains(request.SearchTerm));
        }

        return await diamonds
            .ListPaginateWithSortAsync<Diamond, DiamondDTO>(
                request.Page,
                request.Size,
                request.SortBy,
                request.SortOrder,
                _mapper.ConfigurationProvider);
    }
}