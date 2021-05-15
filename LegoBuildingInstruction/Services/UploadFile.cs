using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LegoBuildingInstruction.Services
{
    public class UploadFile
    {



        private readonly IFormFile _file;
        private readonly IHostingEnvironment _hostingEnvironment;
        public string DataBaseFilePathUrl { get; set; }

        public UploadFile(IFormFile file, IHostingEnvironment hostingEnvironment)
        {

            _file = file;
            _hostingEnvironment = hostingEnvironment;

        }


        private string CreateFilePath(string folderPath)
        {

            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, folderPath);
            var uniqueFileName = Guid.NewGuid().ToString() + " " + _file.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            DataBaseFilePathUrl = $@"/{folderPath}/{uniqueFileName}";

            return filePath;

        }


        public async Task<string> Upload(string folderPath)
        {
            using (var stream = new FileStream(CreateFilePath(folderPath), FileMode.Create))
            {
                await _file.CopyToAsync(stream);

            }

            return DataBaseFilePathUrl;
        }

    }

}




//if (instructionModel.InstructionPdf != null)
//{

//    if (!Path.GetExtension(instructionModel.InstructionPdf.FileName).Equals(".pdf"))
//    {
//        ModelState.AddModelError(string.Empty, "The building instruction format must be .pdf");
//        return View();
//    }

//    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "buildinginstructions");
//    var uniquePdfFileName = Guid.NewGuid().ToString() + " " + instructionModel.InstructionPdf.FileName;
//    string filePath = Path.Combine(uploadsFolder, uniquePdfFileName);



//    instructionModel.InstructionPdfUrl = @$"/buildingInstructions/{uniquePdfFileName}";

//    using (var stream = new FileStream(filePath, FileMode.Create))
//    {
//        await instructionModel.InstructionPdf.CopyToAsync(stream);

//    }

//}