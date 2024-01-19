using Business.Abstract;
using Core.Utilities.FileHelper;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class WorkImageManager : IWorkImageService
    {
        private IWorkImageDal _workImageDal;

        public WorkImageManager(IWorkImageDal workImageDal)
        {
            _workImageDal = workImageDal;
        }

        public IResult Add(IFormFile file, WorkImage workImage)
        {
            workImage.WorkImagePath = FileHelper.Add(file);
            workImage.Date = DateTime.Now;
            _workImageDal.Add(workImage);
            return new SuccessResult("News image added");
        }

        public IResult AddCollective(IFormFile[] files, WorkImage workImage)
        {
            foreach (var file in files)
            {
                workImage = new WorkImage { WorkId = workImage.WorkId};
                Add(file, workImage);
            }
            return new SuccessResult("Oldu");
        }

        public IResult Delete(WorkImage workImage)
        {
            _workImageDal.Delete(workImage);
            return new SuccessResult();
        }

        public IDataResult<List<WorkImage>> GetAll()
        {
            return new SuccessDataResult<List<WorkImage>>(_workImageDal.GetAll(), "Hberler listelendi");
        }

        public IDataResult<List<WorkImage>> GetImagesByWorkId(int workId)
        {
            return new SuccessDataResult<List<WorkImage>>(_workImageDal.GetAll(p => p.WorkId == workId));
        }

        public IDataResult<WorkImage> GetImageByImageId(int imageId)
        {
            return new SuccessDataResult<WorkImage>(_workImageDal.Get(p => p.Id == imageId));
        }


        public IResult Update(IFormFile file, WorkImage workImage)
        {
            WorkImage oldNewImage = GetImageByImageId(workImage.Id).Data;
            workImage.WorkImagePath= FileHelper.Update(file, oldNewImage.WorkImagePath);
            workImage.Date = DateTime.Now;
            workImage.WorkId= oldNewImage.WorkId;
            _workImageDal.Update(workImage);
            return new SuccessResult("News image updated");
        }
    }
}
