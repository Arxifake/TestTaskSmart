using TestTaskSmart.Server.DataAccess.DBContext;
using TestTaskSmart.Server.DataAccess.Interfaces;
using TestTaskSmart.Server.DataAccess.Models;

namespace TestTaskSmart.Server.DataAccess.Repositories
{
    public class Subdivisions: ISubdivisions
    {
        private readonly IServiceScopeFactory _scopeFactory;
        public Subdivisions(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public List<Subdivision> SubdivisionList()
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<TestAppContext>();
                return db.Subdivisions.ToList();
            }
        }
    }
}
