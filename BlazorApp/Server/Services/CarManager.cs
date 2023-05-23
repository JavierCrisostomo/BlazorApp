using BlazorApp.Server.Interfaces;
using BlazorApp.Shared.Models;

namespace BlazorApp.Server.Services
{
    public class CarManager : ICar
    {
        private static List<Car> cars = new(){
        new Car { Id = 1, Make = "Audi", Model = "R8", Year = "2018", Doors = "2"},
        new Car { Id = 2, Make = "Aston Martin", Model = "Rapide", Year = "2014", Doors = "2"}
        };

        public List<Car> GetCarDetails()
        {
            return cars;
        }
  
        public void AddCar(Car car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(nameof(car));
            }

            if (car.Id == 0)
            {
                car.Id = cars.Max(c => c.Id) + 1;
            }
            cars.Add(car);
        }

        public void UpdateCarDetails(Car car)
        {
           try
            {
                if (car.Id != 0)
                {
                    var carToUpdate = cars.FirstOrDefault(c => c.Id == car.Id);
                    if (carToUpdate != null)
                    {
                        cars.Remove(carToUpdate);
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public Car GetCarData(int id)
        {
            try
            {
                var car = cars.FirstOrDefault(c => c.Id == id);

                if (car != null)
                {
                    return car;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public void DeleteCar(int id)
        {
            try
            {
                Car car = GetCarData(id);
                if (car != null)
                {
                    cars.Remove(car);
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}