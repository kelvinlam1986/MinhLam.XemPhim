using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using MinhLam.Framework;
using MinhLam.XemPhim.Application;
using MinhLam.XemPhim.Application.Admin.InputModel;
using MinhLam.XemPhim.Application.Admin.Query;
using MinhLam.XemPhim.Application.Commands;
using System;
using System.IO;
using System.Net;

namespace MinhLam.XemPhim.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : BaseController
    {
        private readonly IAboutQuery _aboutQuery;
        private readonly IWebHostEnvironment _env;
        private readonly IAboutService _aboutService;

        public AboutController(
            IAboutQuery aboutQuery,
            IWebHostEnvironment env,
            IAboutService aboutService)
        {
            this._aboutQuery = aboutQuery;
            this._env = env;
            this._aboutService = aboutService;
        }

        public IActionResult Index(int page = 1, int pageSize = 10)
        {
            var aboutList = this._aboutQuery.GetPagedList(page, pageSize);
            return View(aboutList);
        }

        [HttpGet]
        public ActionResult New()
        {
            var newAbout = new AddAboutDto();
            newAbout.IsActive = true;
            return View(newAbout);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AddAboutDto inputModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var fileName = WebUtility.HtmlEncode(Path.GetFileName(inputModel.Image.FileName));
                    if ((inputModel.Image.ContentType.ToLower() != "image/jpg") &&
                        (inputModel.Image.ContentType.ToLower() != "image/jpeg") &&
                        (inputModel.Image.ContentType.ToLower() != "image/pjpeg") &&
                        (inputModel.Image.ContentType.ToLower() != "image/gif") &&
                        (inputModel.Image.ContentType.ToLower() != "image/x-png") &&
                        (inputModel.Image.ContentType.ToLower() != "image/png"))
                    {
                        ModelState.AddModelError("",
                            $"File upload ({fileName}) không phải file ảnh,.");
                        return View("AddNew", inputModel);
                    }

                    if (inputModel.Image.Length == 0)
                    {
                        ModelState.AddModelError("",
                            $"File upload ({fileName}) rỗng.");
                        return View("AddNew", inputModel);
                    }
                    else if (inputModel.Image.Length > 1048576)
                    {
                        ModelState.AddModelError("",
                            $"File upload ({fileName}) vượt quá 1 MB.");
                        return View("AddNew", inputModel);
                    }

                    var filePath = Path.Combine(this._env.WebRootPath, "uploads", fileName);
                    using (FileStream fs = new FileStream(filePath, FileMode.Create))
                    {
                        inputModel.Image.CopyTo(fs);
                    }

                    var newAboutCommand = new AddNewAboutCommand(inputModel.Name, inputModel.Description, fileName, inputModel.IsActive);
                    this._aboutService.AddNew(newAboutCommand);
                    SetAlert("Tạo giới thiệu thành công!", "success");
                    return RedirectToAction("Index");

                }
                return View("New");
            }
            catch (DomainException e)
            {
                ModelState.AddModelError("", e.Message);
                return View("New");
            }
            catch (ApplicationServiceException e)
            {
                ModelState.AddModelError("", e.Message);
                return View("New");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", OperationExceptionCodes.Message);
                return View("New");
            }
        }
    }
}
