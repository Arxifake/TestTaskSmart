using AutoMapper;
using System.Collections.Generic;
using TestTaskSmart.Server.DataAccess.Interfaces;
using TestTaskSmart.Server.DTO.ModelViewsObjects;
using TestTaskSmart.Server.Services.ServicesInterfaces;

namespace TestTaskSmart.Server.Services
{
    public class PositionService: IPositionService
    {
        private readonly IPositions _positionsRepository;
        private readonly IMapper _mapper;

        public PositionService(IPositions positionsRepository, IMapper mapper)
        {
            _positionsRepository = positionsRepository;
            _mapper = mapper;
        }

        public List<PositionDTO> GetPositions()
        {
            return _mapper.Map<List<PositionDTO>>(_positionsRepository.PositionList());
        }
    }
}
