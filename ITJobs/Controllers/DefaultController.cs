using ITJobs.Business;
using ITJobs.Business.Data.Mapping;
using ITJobs.Common.Entities;
using ITJobs.Resource;
using ITJobs.UI.Base;
using ITJobs.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITJobs.Controllers
{
    public class DefaultController : BaseController
    {
        public ActionResult Index()
        {
            AddJobViewModel model = new AddJobViewModel();

            LoadCategoryList(model);

            LoadLocationList(model);

            LoadJobTypeList(model);

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(AddJobViewModel model)
        {
            LoadCategoryList(model);

            LoadLocationList(model);

            LoadJobTypeList(model);

            if (ModelState.IsValid)
            {
                byte[] image = null;
                using(Stream sw = model.ImageFile.InputStream)
                {
                    image = new byte[model.ImageFile.ContentLength];
                    sw.Read(image, 0, model.ImageFile.ContentLength);
                }

                JobEntity job = EntityMapper.MapToEntity<JobEntity, AddJobViewModel>(model);
                job.Image = image;

                using(Stream sw = model.CompanyLogoFile.InputStream)
                {
                    image = new byte[model.CompanyLogoFile.ContentLength];
                    sw.Read(image, 0, model.CompanyLogoFile.ContentLength);
                }
                
                CompanyEntity company = new CompanyEntity();
                company.ContactEmail = model.CompanyContactEmail;
                company.Name = model.CompanyName;
                company.Url = model.CompanyUrl;
                company.Logo = image;

                CurrentSession.AddToState("NewJob", job);
                CurrentSession.AddToState("NewJobCompany", company);
            }
            return View("Index",model);
        }

        private void LoadCategoryList(AddJobViewModel model)
        {
            List<SelectListItem> itemList = CurrentSession.GetFromState<List<SelectListItem>>("CategoryList");
            if (itemList == null)
            {
                CategoryBusiness categoryBusiness = new CategoryBusiness();
                List<CategoryEntity> categoryList = categoryBusiness.GetList();
                itemList = new List<SelectListItem>();
                categoryList.ForEach(delegate(CategoryEntity each)
                {
                    itemList.Add(new SelectListItem() { Text = ResourceHelper.GetText(each.ResourceKey), Value = each.Id.ToString() });
                });
                CurrentSession.AddToState("CategoryList", itemList);
            }
            model.CategoryList = new List<SelectListItem>(itemList);
        }

        private void LoadLocationList(AddJobViewModel model)
        {
            List<SelectListItem> itemList = CurrentSession.GetFromState<List<SelectListItem>>("LocationList");
            if (itemList == null)
            {
                LocationBusiness business = new LocationBusiness();
                List<LocationEntity> list = business.GetList();
                itemList = new List<SelectListItem>();
                list.ForEach(delegate(LocationEntity each)
                {
                    itemList.Add(new SelectListItem() { Text = ResourceHelper.GetText(each.ResourceKey), Value = each.Id.ToString() });
                });
                CurrentSession.AddToState("LocationList", itemList);
            }
            model.LocationList = new List<SelectListItem>(itemList);
        }

        private void LoadJobTypeList(AddJobViewModel model)
        {
            List<SelectListItem> itemList = CurrentSession.GetFromState<List<SelectListItem>>("JobTypeList");
            if (itemList == null)
            {
                JobTypeBusiness business = new JobTypeBusiness();
                List<JobTypeEntity> list = business.GetList();
                itemList = new List<SelectListItem>();
                list.ForEach(delegate(JobTypeEntity each)
                {
                    itemList.Add(new SelectListItem() { Text = ResourceHelper.GetText(each.ResourceKey), Value = each.Id.ToString() });
                });
                CurrentSession.AddToState("JobTypeList", itemList);
            }
            model.JobTypeList = new List<SelectListItem>(itemList);
        }

    }
}