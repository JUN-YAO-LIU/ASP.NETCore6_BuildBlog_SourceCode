using BasicSample.DbAccess;
using BasicSample.DbAccess.Models;

namespace BasicSample.Application
{
    public class CarService : ICarService
    {
        public CarService()
        {
        }

        public string FillingUp(CancellationToken cancellationToken = default)
        {
            return "需要加油";
        }
    }
}