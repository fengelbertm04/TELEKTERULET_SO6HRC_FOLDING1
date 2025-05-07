using TelekAPI.Models;

namespace TelekAPI.Data
{
    public class AreaRepository : IAreaRepository
    {
        public Area Area { get; set; }


        public void SetArea(Area area)
        {
            Area = area;
        }

        public AreaOutput Result()
        {
            Coordinates startCoordinate = new Coordinates() { X = 0, Y = 0 };
            Coordinates endCoordinate = new Coordinates();
            for (int i = 0; i < Area.PlotArea.GetLength(0); i++)
            {
                for (int j = 0; j < Area.PlotArea.GetLength(1); j++)
                {
                    if (Area.PlotArea[i][j] - Area.Epsilon > Area.PlotArea[startCoordinate.X][startCoordinate.Y])
                    {
                        startCoordinate.X = i;
                        startCoordinate.Y = j;
                    }
                    else
                    {
                        endCoordinate.X = i;
                        endCoordinate.Y = j;
                    }
                }
            }
            return new AreaOutput() { Area = Area, startIndex = startCoordinate, endIndex = endCoordinate };

        }
    }
}
