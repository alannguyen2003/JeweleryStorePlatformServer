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
using JeweleryStorePlatformDataTransfer.Request.Diamond;


namespace JeweleryStorePlatformService;

public class DiamondService : IDiamondService
{
    private readonly IDiamondRepository _diamondRepository;
    private readonly IGIAReportRepository _gIAReportRepository;
    private readonly IMapper _mapper;

    public DiamondService(IDiamondRepository diamondRepository, IMapper mapper, IGIAReportRepository gIAReportRepository)
    {
       _diamondRepository = diamondRepository;
        _mapper = mapper;
        _gIAReportRepository = gIAReportRepository;
    }

    public async Task<PaginatedList<GIAReportDTO>> GetAllDiamondswithGIAReport(GetDiamondsRequest request)
    { 
        var diamonds = _gIAReportRepository.GetAll().Include(x => x.Diamond)
            .AsQueryable();
         
        if (request.SearchTerm is not null)
        {
            diamonds = diamonds.Where(x => x.Diamond.ClarityType.Contains(request.SearchTerm) ||
                                       x.Diamond.ColorType.Contains(request.SearchTerm) ||
                                       x.Diamond.CutType.Contains(request.SearchTerm));
        }

        return await diamonds
            .ListPaginateWithSortAsync<GIAReport, GIAReportDTO>(
                request.Page,
                request.Size,
                request.SortBy,
                request.SortOrder,
                _mapper.ConfigurationProvider);
    }
    public async Task<DiamondDTO> GetDiamondById(int id)
    {
        var diamond = await _diamondRepository.GetDiamondById(id);
        return _mapper.Map<DiamondDTO>(diamond);
    }

    public async Task<DiamondDTO> CreateDiamond(CreateDiamondRequest request)
    {
        var diamond = _mapper.Map<Diamond>(request);
        diamond.IsMainDiamond = true;
        var createdDiamond = await _diamondRepository.CreateDiamond(diamond);
        var entity = new GIAReport()
        {
            ReportNumber = request.ReportNumber,
            ReportUrl = request.ReportUrl,
            DiamondId = createdDiamond.Id,
        };
        var createdGIAReport = await _gIAReportRepository.CreateGIA(entity);
        return _mapper.Map<DiamondDTO>(createdDiamond);
    }

    public async Task<DiamondDTO> UpdateDiamond(int id, UpdateDiamondRequest request)
    {
        var diamond = await _diamondRepository.GetDiamondById(id);
        if (diamond == null)
        {
            return null;
        }

        _mapper.Map(request, diamond);
        var updatedDiamond = await _diamondRepository.UpdateDiamond(diamond);
        if (request.ReportNumber != null || request.ReportUrl != null)
        {
            var giaReport = await _gIAReportRepository.GetGIAById(diamond.Id);

            if (giaReport == null)
            {
                var newGIAReport = new GIAReport
                {
                    ReportNumber = request.ReportNumber,
                    ReportUrl = request.ReportUrl,
                    DiamondId = diamond.Id
                };
                await _gIAReportRepository.CreateGIA(newGIAReport);
            }
            else
            {
                giaReport.ReportNumber = request.ReportNumber;
                giaReport.ReportUrl = request.ReportUrl;
                await _gIAReportRepository.UpdateGIA(giaReport);
            }
        }
        return _mapper.Map<DiamondDTO>(updatedDiamond);
    }

    public async Task<bool> DeleteDiamond(int id)
    {
        var gia = await _gIAReportRepository.GetGIAById(id);
        await _gIAReportRepository.DeleteGIA(id);
        if (gia == null)
        {
            return false;
        }
        return await _diamondRepository.DeleteDiamond(gia.DiamondId);
    }
    public async Task AddRangeDiamonds(List<Diamond> diamonds)
    {
        await _diamondRepository.AddRangeDiamonds(diamonds);
    }
    public async Task<PaginatedList<DiamondDTO>> GetAllDiamonds(GetDiamondsRequest request)
    {
        var diamonds = _diamondRepository.GetAllDiamonds();

        if (request.SearchTerm is not null)
        {
            diamonds = diamonds.Where(x => x.ClarityType.Contains(request.SearchTerm) ||
                                       x.ColorType.Contains(request.SearchTerm) ||
                                       x.CutType.Contains(request.SearchTerm));
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