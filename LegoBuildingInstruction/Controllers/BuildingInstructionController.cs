using LegoBuildingInstruction.Models;
using LegoBuildingInstruction.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IFavoritesBuildingInstructionRepository _favoritesBuildingInstructionRepository;

        public BuildingInstructionController(IBuildingInstructionRepository buildingInstructionRepository, 
            ICategoryRepository categoryRepository, IHostingEnvironment hostingEnvironment,
            IFavoritesBuildingInstructionRepository favoritesBuildingInstructionRepository, UserManager<ApplicationUser> userManager)
        {
            _buildingInstructionRepository = buildingInstructionRepository;
            _categoryRepository = categoryRepository;
            _hostingEnvironment = hostingEnvironment;
            _userManager = userManager;
            _favoritesBuildingInstructionRepository = favoritesBuildingInstructionRepository;
        }


        public IActionResult Details(int id)
        {

            var buildingInstruction = _buildingInstructionRepository.GetBuildingInstructionById(id);



            if (buildingInstruction == null)
            {
                return NotFound();
            }

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
        public IActionResult AddNewInstruction()
        {

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddNewInstruction(AddBuildingInstructionViewModel instructionModel)
        {

            if (ModelState.IsValid)
            {

                if (instructionModel.InstructionPdf != null)
                {

                    if (!Path.GetExtension(instructionModel.InstructionPdf.FileName).Equals(".pdf"))
                    {
                        ModelState.AddModelError(string.Empty, "The building instruction format must be .pdf");
                        return View();
                    }

                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "buildinginstructions");
                    var uniquePdfFileName = Guid.NewGuid().ToString() + " " + instructionModel.InstructionPdf.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniquePdfFileName);



                    instructionModel.InstructionPdfUrl = @$"~/buildingInstructions/{uniquePdfFileName}";
                    await instructionModel.InstructionPdf.CopyToAsync(new FileStream(filePath, FileMode.Create));
                }

                if (instructionModel.InstructionImage != null)
                {

                    if (!Path.GetExtension(instructionModel.InstructionImage.FileName.ToLower()).Equals(".png") &&
                        !Path.GetExtension(instructionModel.InstructionImage.FileName.ToLower()).Equals(".jpg"))
                    {
                        ModelState.AddModelError(string.Empty, "The picture format must be .png or .jpg");
                        return View();
                    }

                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images/Instructions");
                    var uniqueImageFileName = Guid.NewGuid().ToString() + " " + instructionModel.InstructionImage.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueImageFileName);


                    instructionModel.InstructionImageUrl = @$"~/Images/Instructions/{uniqueImageFileName}";
                    await instructionModel.InstructionImage.CopyToAsync(new FileStream(filePath, FileMode.Create));
                }



                if (instructionModel.InstructionVideo != null)
                {

                    if (!Path.GetExtension(instructionModel.InstructionVideo.FileName.ToLower()).Equals(".mp4"))
                    {
                        ModelState.AddModelError(string.Empty, "The video format must be .mp4");
                        return View();
                    }

                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "video");
                    var uniqueVideoFileName = Guid.NewGuid().ToString() + " " + instructionModel.InstructionVideo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueVideoFileName);


                    instructionModel.InstructionVideoURL = @$"/Video/{uniqueVideoFileName}";
                    await instructionModel.InstructionVideo.CopyToAsync(new FileStream(filePath, FileMode.Create));
                }


                if (instructionModel.Program != null)
                {

                    if (!Path.GetExtension(instructionModel.Program.FileName.ToLower()).Equals(".ev3"))
                    {
                        ModelState.AddModelError(string.Empty, "The program format must be .ev3");
                        return View();
                    }

                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "programs");
                    var uniqueProgramFileName = Guid.NewGuid().ToString() + " " + instructionModel.Program.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueProgramFileName);


                    instructionModel.InstructionVideoURL = @$"/Programs/{uniqueProgramFileName}";
                    await instructionModel.InstructionVideo.CopyToAsync(new FileStream(filePath, FileMode.Create));
                }



                var newBuildingInstruction = new BuildingInstruction()
                {
                    CategoryId = instructionModel.CategoryId,
                    CreatedAt = DateTime.Now,
                    ImageThumbnailUrl = instructionModel.InstructionImageUrl,
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


                return RedirectToAction("Details", new { id = getNewBuildingInstruction.Id });

            }
            else
            {
                ModelState.AddModelError(string.Empty, "The building instruction cannot be added");
            }

            return View(instructionModel);
        }


        private async Task<string> UploadFile(string folderPath, IFormFile file)
        {

            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;

            string serverFolder = Path.Combine(_hostingEnvironment.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return "/" + folderPath;
        }

    }
}
