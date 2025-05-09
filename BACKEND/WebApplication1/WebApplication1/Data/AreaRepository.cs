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
            List<Coordinates> coordinates = new List<Coordinates>() { new Coordinates() { X = startCoordinate.X, Y = startCoordinate.Y } };
            List<Coordinates> oldCoordinates = new List<Coordinates>();

            for (int i = 0; i < Area.PlotArea.Length; i++)
            {
                for (int j = 0; j < Area.PlotArea[i].Length; j++)
                {
               
                    if (Math.Abs(Area.PlotArea[i][j] - Area.PlotArea[startCoordinate.X][startCoordinate.Y]) > Area.Epsilon)
                    {
                      
                        if (coordinates.Count > oldCoordinates.Count)
                        {
                            oldCoordinates = coordinates.ToList();  
                        }

                      
                        coordinates = new List<Coordinates>() { new Coordinates() { X = i, Y = j } };
                        startCoordinate.X = i;
                        startCoordinate.Y = j;
                    }
                    else
                    {
                      
                        coordinates.Add(new Coordinates() { X = i, Y = j });
                        endCoordinate.X = i;
                        endCoordinate.Y = j;
                    }
                }
            }

        
            if (coordinates.Count < oldCoordinates.Count)
            {
                return new AreaOutput() { Area = Area, Coordinates = oldCoordinates};
            }

            return new AreaOutput() { Area = Area, Coordinates = coordinates };


        }
    }
}
