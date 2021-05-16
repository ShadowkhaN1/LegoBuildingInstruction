using LegoBuildingInstruction.Models;
using LegoBuildingInstruction.Services;
using LegoBuildingInstruction.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LegoBuildingInstruction.Controllers
{
    public class BuildingInstructionController : Controller
    {

        private readonly IBuildingInstructionRepository _buildingInstructionRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IWebHostEnvironment _webHostingEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IFavoritesBuildingInstructionRepository _favoritesBuildingInstructionRepository;
        private readonly IRateInstructionRepository _rateInstructionRepository;


        public BuildingInstructionController(IBuildingInstructionRepository buildingInstructionRepository,
            ICategoryRepository categoryRepository, IWebHostEnvironment webHostingEnvironment,
            IFavoritesBuildingInstructionRepository favoritesBuildingInstructionRepository, UserManager<ApplicationUser> userManager,
            IRateInstructionRepository rateInstructionRepository)
        {
            _buildingInstructionRepository = buildingInstructionRepository;
            _categoryRepository = categoryRepository;
            _webHostingEnvironment = webHostingEnvironment;
            _userManager = userManager;
            _favoritesBuildingInstructionRepository = favoritesBuildingInstructionRepository;
            _rateInstructionRepository = rateInstructionRepository;
        }


        public IActionResult Details(int id)
        {

            var buildingInstruction = _buildingInstructionRepository.GetBuildingInstructionById(id);

            if (buildingInstruction == null)
            {
                return NotFound();
            }

            ViewBag.Values = new List<int> { 5, 4, 3, 2, 1 };



            return View(buildingInstruction);
        }






        public IActionResult List(string category)
        {

            IEnumerable<BuildingInstruction> buildingInstructions;
            string currentCategory;

            if (string.IsNullOrEmpty(category))
            {
                currentCategory = "All Building Instructions";
                buildingInstructions = _buildingInstructionRepository.AllBuildingInstructions.OrderByDescending(x => x.CreatedAt);

            }
            else if (category == "Favorites")
            {
                currentCategory = "Favorites";
                buildingInstructions = _favoritesBuildingInstructionRepository.GetFavoritesBuildingInstructionsByUserId(_userManager.GetUserId(HttpContext.User)).Select(x => x.BuildingInstruction);
            }
            else
            {

                currentCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;

                buildingInstructions = _buildingInstructionRepository.AllBuildingInstructions.Where(b => b.Category.CategoryName == category).OrderByDescending(b => b.CreatedAt);


            }


            BuildingInstructionListViewModel buildingInstructionListViewModel = new BuildingInstructionListViewModel
            {
                CurrentCategory = currentCategory,
                BuildingInstructions = buildingInstructions
            };

            return View(buildingInstructionListViewModel);
        }


        [Authorize]
        public IActionResult DeleteInstruction(int id)
        {

            var deleteInstruction = _buildingInstructionRepository.GetBuildingInstructionById(id);

            _buildingInstructionRepository.DeleteInstruction(deleteInstruction);

            return RedirectToAction("Index", "Home");
        }



        [Authorize]
        public IActionResult InstructionPDF(int id)
        {

            var buildingInstruction = _buildingInstructionRepository.GetBuildingInstructionById(id);

            return View(buildingInstruction);
        }


        [Authorize]
        public IActionResult CreateInstruction()
        {

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateInstruction(BuildingInstructionEditViewModel instructionModel)
        {

            if (ModelState.IsValid)
            {

                if (instructionModel.InstructionPdf != null)
                {
                    
                    var maxPdfSizeLimit = 30_000_000;
                    if (instructionModel.InstructionPdf.Length > maxPdfSizeLimit)
                    {
                        ModelState.AddModelError(string.Empty, "File instruction .pdf too large, max 30MB" );
                        return View();
                    }

                    var extension = ".pdf";
                    if (!extension.Contains(Path.GetExtension(instructionModel.InstructionPdf.FileName.ToLower())))
                    {
                        ModelState.AddModelError(string.Empty, "The building instruction format must be .pdf");
                        return View();
                    }

                    string uploadsFolder = Path.Combine(_webHostingEnvironment.WebRootPath, "buildinginstructions");
                    var uniquePdfFileName = Guid.NewGuid().ToString() + " " + instructionModel.InstructionPdf.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniquePdfFileName);



                    instructionModel.InstructionPdfUrl = @$"/buildingInstructions/{uniquePdfFileName}";

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await instructionModel.InstructionPdf.CopyToAsync(stream);

                    }
                }

                if (instructionModel.InstructionImage != null)
                {

                    var maxImageSizeLimt = 2_000_000;
                    if (instructionModel.InstructionImage.Length > maxImageSizeLimt)
                    {
                        ModelState.AddModelError(string.Empty, "Image is too large, max size 2MB");
                    }

                    var extensions = new string[] { ".png", ".jpg" };

                    if (!extensions.Contains(Path.GetExtension(instructionModel.InstructionImage.FileName.ToLower())))
                    {
                        ModelState.AddModelError(string.Empty, "The picture format must be .png or .jpg");
                        return View();
                    }

                    string uploadsFolder = Path.Combine(_webHostingEnvironment.WebRootPath, "images/Instructions");
                    var uniqueImageFileName = Guid.NewGuid().ToString() + " " + instructionModel.InstructionImage.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueImageFileName);


                    instructionModel.InstructionImageUrl = @$"/Images/Instructions/{uniqueImageFileName}";

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await instructionModel.InstructionImage.CopyToAsync(stream);

                    }
                }


                if (instructionModel.InstructionVideo != null)
                {

                    var maxVideoSizeLimit = 20_000_000;

                    if (instructionModel.InstructionVideo.Length > maxVideoSizeLimit)
                    {
                        ModelState.AddModelError(string.Empty, "Video too large, max size 20MB");
                    }

                    var extension = ".mp4";
                    if (!Path.GetExtension(instructionModel.InstructionVideo.FileName.ToLower()).Equals(extension))
                    {
                        ModelState.AddModelError(string.Empty, "The video format must be .mp4");
                        return View();
                    }

                    string uploadsFolder = Path.Combine(_webHostingEnvironment.WebRootPath, "video");
                    var uniqueVideoFileName = Guid.NewGuid().ToString() + " " + instructionModel.InstructionVideo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueVideoFileName);


                    instructionModel.InstructionVideoURL = @$"/Video/{uniqueVideoFileName}";


                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await instructionModel.InstructionVideo.CopyToAsync(stream);

                    }
                }


                if (instructionModel.Program != null)
                {

                    if (!Path.GetExtension(instructionModel.Program.FileName.ToLower()).Equals(".ev3"))
                    {
                        ModelState.AddModelError(string.Empty, "The program format must be .ev3");
                        return View();
                    }

                    string uploadsFolder = Path.Combine(_webHostingEnvironment.WebRootPath, "programs");
                    var uniqueProgramFileName = Guid.NewGuid().ToString() + " " + instructionModel.Program.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueProgramFileName);


                    instructionModel.InstructionVideoURL = @$"/Programs/{uniqueProgramFileName}";

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await instructionModel.InstructionVideo.CopyToAsync(stream);
                    }

                }


                var newBuildingInstruction = new BuildingInstruction()
                {
                    CategoryId = instructionModel.CategoryId,
                    CreatedAt = DateTime.Now,
                    ImageUrl = instructionModel.InstructionImageUrl,
                    UserId = _userManager.GetUserId(HttpContext.User),
                    PdfInstructionUrl = instructionModel.InstructionPdfUrl,
                    Pages = instructionModel.Pages,
                    Name = instructionModel.Name,
                    Set = instructionModel.Set,
                    VideoUrl = instructionModel.InstructionVideoURL,
                    ProgramUrl = instructionModel.ProgramUrl,
                    LongDescription = instructionModel.LongDescription,

                };

                await _buildingInstructionRepository.AddNewBuildingInstructionAsync(newBuildingInstruction);

                var getNewBuildingInstruction = _buildingInstructionRepository.AllBuildingInstructions.Last();


                return RedirectToAction("Details", new { id = getNewBuildingInstruction.BuildingInstructionId });

            }
            else
            {
                ModelState.AddModelError(string.Empty, "The building instruction cannot be added");
            }

            return View(instructionModel);
        }






        [Authorize]
        public IActionResult EditInstruction(int id)
        {
            var editInstruction = _buildingInstructionRepository.GetBuildingInstructionById(id);

      

            if (editInstruction == null)
            {
                return NotFound();
            }


            var editInstructionViewModel = new BuildingInstructionEditViewModel()
            {
                BuildingInstructionId = id,
                CategoryId = editInstruction.CategoryId,
                InstructionImageUrl = editInstruction.ImageUrl,
                InstructionPdfUrl = editInstruction.PdfInstructionUrl,
                Pages = editInstruction.Pages,
                Name = editInstruction.Name,
                Set = editInstruction.Set,
                InstructionVideoURL = editInstruction.VideoUrl,
                ProgramUrl = editInstruction.ProgramUrl,
                LongDescription = editInstruction.LongDescription,
            };



            return View(editInstructionViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> EditInstruction(BuildingInstructionEditViewModel editInstructionModel)
        {


            if (ModelState.IsValid)
            {

                if (editInstructionModel.InstructionPdf != null)
                {

                    var extension = ".pdf";
                    if (!extension.Contains(Path.GetExtension(editInstructionModel.InstructionPdf.FileName.ToLower())))
                    {
                        ModelState.AddModelError(string.Empty, "The building instruction format must be .pdf");
                        return View();
                    }

                    string uploadsFolder = Path.Combine(_webHostingEnvironment.WebRootPath, "buildinginstructions");
                    var uniquePdfFileName = Guid.NewGuid().ToString() + " " + editInstructionModel.InstructionPdf.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniquePdfFileName);



                    editInstructionModel.InstructionPdfUrl = @$"/buildingInstructions/{uniquePdfFileName}";

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await editInstructionModel.InstructionPdf.CopyToAsync(stream);

                    }
                }

                if (editInstructionModel.InstructionImage != null)
                {

                    var extensions = new string[] { ".png", ".jpg" };

                    if (!extensions.Contains(Path.GetExtension(editInstructionModel.InstructionImage.FileName.ToLower())))
                    {
                        ModelState.AddModelError(string.Empty, "The picture format must be .png or .jpg");
                        return View();
                    }

                    string uploadsFolder = Path.Combine(_webHostingEnvironment.WebRootPath, "images/Instructions");
                    var uniqueImageFileName = Guid.NewGuid().ToString() + " " + editInstructionModel.InstructionImage.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueImageFileName);


                    editInstructionModel.InstructionImageUrl = @$"/Images/Instructions/{uniqueImageFileName}";

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await editInstructionModel.InstructionImage.CopyToAsync(stream);

                    }
                }


                if (editInstructionModel.InstructionVideo != null)
                {

                    var extension = ".mp4";
                    if (!Path.GetExtension(editInstructionModel.InstructionVideo.FileName.ToLower()).Equals(extension))
                    {
                        ModelState.AddModelError(string.Empty, "The video format must be .mp4");
                        return View();
                    }

                    string uploadsFolder = Path.Combine(_webHostingEnvironment.WebRootPath, "video");
                    var uniqueVideoFileName = Guid.NewGuid().ToString() + " " + editInstructionModel.InstructionVideo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueVideoFileName);


                    editInstructionModel.InstructionVideoURL = @$"/Video/{uniqueVideoFileName}";


                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await editInstructionModel.InstructionVideo.CopyToAsync(stream);

                    }
                }


                if (editInstructionModel.Program != null)
                {

                    if (!Path.GetExtension(editInstructionModel.Program.FileName.ToLower()).Equals(".ev3"))
                    {
                        ModelState.AddModelError(string.Empty, "The program format must be .ev3");
                        return View();
                    }

                    string uploadsFolder = Path.Combine(_webHostingEnvironment.WebRootPath, "programs");
                    var uniqueProgramFileName = Guid.NewGuid().ToString() + " " + editInstructionModel.Program.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueProgramFileName);


                    editInstructionModel.InstructionVideoURL = @$"/Programs/{uniqueProgramFileName}";

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await editInstructionModel.InstructionVideo.CopyToAsync(stream);
                    }

                }


                var editBuildingInstruction = new BuildingInstruction()
                {
                    BuildingInstructionId = editInstructionModel.BuildingInstructionId,
                    CategoryId = editInstructionModel.CategoryId,
                    CreatedAt = DateTime.Now,
                    ImageUrl = editInstructionModel.InstructionImageUrl,
                    PdfInstructionUrl = editInstructionModel.InstructionPdfUrl,
                    Pages = editInstructionModel.Pages,
                    Name = editInstructionModel.Name,
                    Set = editInstructionModel.Set,
                    VideoUrl = editInstructionModel.InstructionVideoURL,
                    ProgramUrl = editInstructionModel.ProgramUrl,
                    LongDescription = editInstructionModel.LongDescription,

                };

                var updateInstruction =  await _buildingInstructionRepository.UpdateBuildingInstruction(editBuildingInstruction);



                return RedirectToAction("Details", new { id = updateInstruction.BuildingInstructionId });

            }
            else
            {
                ModelState.AddModelError(string.Empty, "The building instruction cannot be added");
            }

            return View(editInstructionModel);

        }


        private bool ValidFileExtension(IFormFile instructionModel, string extension)
        {

            if (Path.GetExtension(instructionModel.FileName).Equals(extension))
            {
                return true;
            }

            return false;

        }


        public async Task<IActionResult> RateInstruction(int buildingInstructionId, int rateValue)
        {

            var buildinInstruction = _buildingInstructionRepository.GetBuildingInstructionById(buildingInstructionId);

            if (buildinInstruction == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(HttpContext.User);

            if (user == null)
            {
                NotFound();
            }

        


            var rateInstruction = new RateInstruction()
            {
                BuildingInstructionId = buildinInstruction.BuildingInstructionId,
                BuildingInstruction = buildinInstruction,
                UserId = user.Id,
                User = user,
                RatingValue = rateValue
            };




            await _rateInstructionRepository.RateInstruction(rateInstruction);


            return RedirectToAction("Details", new { id = buildingInstructionId });
        }


        private async Task<IFormFile> UploadFile(string folderName, IFormFile file)
        {

            string uploadsFolder = Path.Combine(_webHostingEnvironment.WebRootPath, folderName);
            var uniqueFileName = Guid.NewGuid().ToString() + " " + file.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);



            //file. = @$"/buildingInstructions/{uniqueFileName}";
            await file.CopyToAsync(new FileStream(filePath, FileMode.Create));


            return file;

        }

    }
}
