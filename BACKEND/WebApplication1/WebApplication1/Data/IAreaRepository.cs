using TelekAPI.Models;

namespace TelekAPI.Data
{
    public interface IAreaRepository
    {
        AreaOutput Result();
        void SetArea(Area area);
    }
}