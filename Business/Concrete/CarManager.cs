﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if (car.DailyPrice > 0 && (car.Description).Length >= 2)
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.CarAdded);
            }
            
                return new ErrorResult( Messages.CarNameInvalid);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);


        }

        public IDataResult <List<Car>> GetAll()
        {

            return new SuccessDataResult<List<Car>> (_carDal.GetAll(), Messages.CarsListed);
            
        }

        public IDataResult <Car> GetById(int carId) {
            return new SuccessDataResult <Car> (_carDal.Get(c => c.Id == carId));
        }

        public  IDataResult <List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());    
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>> (_carDal.GetAll(c => c.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>> (_carDal.GetAll(c => c.ColorId == id));
        }

        public IResult Update(Car car)
        {
            if (car.DailyPrice > 0 && (car.Description).Length>=2) 
            {
                _carDal.Update(car);
                return new SuccessResult(Messages.CarUpdated);

            }
            else
                return new SuccessResult(Messages.CarNameInvalid);

        }
    }
}
