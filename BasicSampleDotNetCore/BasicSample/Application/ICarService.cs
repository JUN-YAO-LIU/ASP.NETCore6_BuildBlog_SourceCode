using BasicSample.DbAccess.Models;

namespace BasicSample.Application
{
    public interface ICarService
    {
        /// <summary>
        /// 加油
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        string FillingUp(CancellationToken cancellationToken = default);
    }
}