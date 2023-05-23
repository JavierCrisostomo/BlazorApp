using BlazorApp.Shared.Models;

namespace BlazorApp.Server.Interfaces
{
    public interface ICar
    {
        public List<Car> GetCarDetails();

        public void AddCar(Car user);

        public void UpdateCarDetails(Car user);

        public Car GetCarData(int id);

        public void DeleteCar(int id);
    }
}
