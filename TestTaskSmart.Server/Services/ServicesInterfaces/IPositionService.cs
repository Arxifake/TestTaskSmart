using TestTaskSmart.Server.DTO.ModelViewsObjects;

namespace TestTaskSmart.Server.Services.ServicesInterfaces
{
    public interface IPositionService
    {
        public List<PositionDTO> GetPositions();
    }
}
