using TestTaskSmart.Server.DataAccess.DBContext;
using TestTaskSmart.Server.DataAccess.Interfaces;
using TestTaskSmart.Server.DataAccess.Models;

namespace TestTaskSmart.Server.DataAccess.Repositories
{
    public class Positions: IPositions
    {
        private readonly IServiceScopeFactory _scopeFactory;
        public Positions(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public List<Position> PositionList()
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<TestAppContext>();
                return db.Positions.ToList();
            }
        }
    }
}
