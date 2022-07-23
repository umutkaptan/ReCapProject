using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _car;
        public InMemoryCarDal()
        {
            _car = new List<Car> {

             new Car {CarId=1,BrandId=1,ColorId=1,DailyPrice=10000,Description="AUDİ 4 ÇEKER",ModelYear="2015"},
             new Car {CarId=2,BrandId=1,ColorId=2,DailyPrice=8000,Description="AUDİ 2 ÇEKER",ModelYear="2017"},
             new Car {CarId=3,BrandId=2,ColorId=1,DailyPrice=15000,Description="BMW JEEP",ModelYear="2020"},
             new Car {CarId=4,BrandId=2,ColorId=1,DailyPrice=5000,Description="BMW TAXI",ModelYear="2010"},
             new Car {CarId=5,BrandId=3,ColorId=2,DailyPrice=20000,Description="MERCEDES",ModelYear="2022"},

            };
        }
        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _car.SingleOrDefault(c=>c.CarId==car.CarId);

            _car.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public List<Car> GetAllByBrand(int BrandId)
        {
            return _car.Where(c => c.BrandId == BrandId).ToList();
        }

        public List<Car> GetAllByColor(int ColorId)
        {
            return _car.Where(c => c.ColorId == ColorId).ToList();
        }

        public List<Car> GetById(int carId)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _car.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
