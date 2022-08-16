using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ReryFood.Models;

namespace LanchesMac.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminImagensController : Controller
    {
        private readonly ImagesConfigModel _myConfig;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public AdminImagensController(IWebHostEnvironment hostingEnvironment,
                    IOptions<ImagesConfigModel> myConfiguration)
        {
            _hostingEnvironment = hostingEnvironment;
            _myConfig = myConfiguration.Value;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UploadFiles(List<IFormFile> files)
        {
            if (files == null || files.Count == 0)
            {
                ViewData["Erro"] = "Error: Arquivo(s) não selecionado(s)";
                return View(ViewData);
            }

            if (files.Count > 10)
            {
                ViewData["Erro"] = "Error: Quantidade de arquivos excedeu o limite";
                return View(ViewData);
            }

            var filePathsName = new List<string>();

            var filePath = Path.Combine(_hostingEnvironment.WebRootPath,
                _myConfig.ImagesDir);

            foreach (var formFile in files)
            {
                if (formFile.FileName.Contains(".jpg") || formFile.FileName.Contains(".gif")
                    || formFile.FileName.Contains(".png"))
                {
                    var fileNameWithPath = string.Concat(filePath, "\\", formFile.FileName);

                    filePathsName.Add(fileNameWithPath);

                    using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }

            ViewData["Resultado"] = $"{files.Count} arquivos foram enviados";

            ViewBag.Arquivos = filePathsName;

            return View(ViewData);
        }

        public IActionResult GetImagens()
        {
            FileManagerModel model = new FileManagerModel();
            var userImagesPath = Path.Combine(_hostingEnvironment.WebRootPath,
                _myConfig.ImagesDir);
            DirectoryInfo dir = new DirectoryInfo(userImagesPath);
            FileInfo[] files = dir.GetFiles();

            model.PathImages = _myConfig.ImagesDir;

            if (files.Length == 0)
            {
                ViewData["Erro"] = $"Nenhum arquivo encontrado na pasta {userImagesPath}";
            }

            model.Files = files;

            return View(model);
        }

        public IActionResult Deletefile(string fname)
        {
            string _imagemDeleta = Path.Combine(_hostingEnvironment.WebRootPath,
                _myConfig.ImagesDir + "\\", fname);

            if ((System.IO.File.Exists(_imagemDeleta)))
            {
                System.IO.File.Delete(_imagemDeleta);
                ViewData["Deletado"] = $"Arquivo(s) {_imagemDeleta} deletado com sucesso";
            }
            return View("index");
        }
    }
}
