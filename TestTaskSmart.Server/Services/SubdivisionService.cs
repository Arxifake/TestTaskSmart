using AutoMapper;
using TestTaskSmart.Server.DataAccess.Interfaces;


using TestTaskSmart.Server.DTO.ModelViewsObjects;
using TestTaskSmart.Server.Services.ServicesInterfaces;

namespace TestTaskSmart.Server.Services
{
    public class SubdivisionService: ISubdivisionService
    {
        private readonly ISubdivisions _subdivisionsRepository;
        private readonly IMapper _mapper;

        public SubdivisionService(ISubdivisions subdivisionsRepository, IMapper mapper)
        {
            _subdivisionsRepository = subdivisionsRepository;
            _mapper = mapper;
        }

        public List<SubdivisionDTO> GetSubdivisions()
        {
            return _mapper.Map<List<SubdivisionDTO>>(_subdivisionsRepository.SubdivisionList());
        }
    }
}
