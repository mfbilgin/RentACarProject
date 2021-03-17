﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Business.BusinessAspects.Autofac;
using Core.Aspects.Autofac.Caching;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImage)
        {
            _carImageDal = carImage;
        }

        public IResult Add(IFormFile file, CarImage carImage,int carId)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(carId));
            if (result != null)
            {
                return result;
            }
            var imageResult = FileHelper.Add(file);

            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }
            carImage.ImagePath = imageResult.Message;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.succeed);
        }

        public IResult Delete(CarImage carImage)
        {
            IResult result = BusinessRules.Run(CarImageDelete(carImage));
            if (result != null)
            {
                return result;
            }
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.listed);
        }


        public IDataResult<List<CarImageDto>> GetImagesByCarId(int carId)
        {
            IfImageNull(carId);
            return new SuccessDataResult<List<CarImageDto>>(_carImageDal.GetCarImageDetails(p => p.CarId == carId), Messages.succeed);
        }



        public IResult Update(IFormFile image, CarImage carImage)
        {
            var isImage = _carImageDal.Get(c => c.CarId == carImage.CarId);

            var updatedFile = FileHelper.Update(image, isImage.ImagePath);
            if (!updatedFile.Success)
            {
                return new ErrorResult(updatedFile.Message);
            }
            carImage.ImagePath = updatedFile.Message;
            _carImageDal.Update(carImage);
            return new SuccessResult("Car image updated");

        }
        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == id));
        }
        private IResult CheckImageLimitExceeded(int id)
        {
            if (_carImageDal.GetAll(image => image.CarId == id).Count >= 5)
            {
                return new ErrorResult(Messages.CarImagesCountExceded);
            }

            return new SuccessResult();
            
        }
        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.Id == id));
        }
        private IResult CarImageDelete(CarImage carImage)
        {
            try
            {
                File.Delete(carImage.ImagePath);
            }
            catch (Exception exception)
            {

                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }

        public IDataResult<List<CarImageDto>> GetImagesByColorId(int colorId)
        {

            return new SuccessDataResult<List<CarImageDto>>(_carImageDal.GetCarImageDetails(p => p.CarId == colorId), Messages.succeed);
        }

        public IDataResult<List<CarImageDto>> GetImagesByBrandId(int brandId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarImageDto>> IfImageNull(int carId)
        {
            string path = "/images/default.jpg";
            var result = _carImageDal.GetCarImageDetails(carImage => carImage.CarId == carId).Any();
            if (!result)
            {
                List<CarImageDto> carimage = new List<CarImageDto>();
                carimage.Add(new CarImageDto { CarId = carId, ImagePath = path });
                return new SuccessDataResult<List<CarImageDto>>(carimage);
            }
            return null;
        }
    }
}