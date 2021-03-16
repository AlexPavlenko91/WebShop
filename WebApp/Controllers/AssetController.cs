using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        IAssetRepository _repository;

        public AssetController(IAssetRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public List<Guid> Add(IFormCollection formCollection)
        {
            List<Guid> result = new List<Guid>();

            if (formCollection.Files.Count > 0)
            {
                foreach (IFormFile formFile in formCollection.Files)
                {
                    Guid id = Guid.NewGuid();
                    string ext = Path.GetExtension(formFile.FileName);
                    Asset asset = new Asset
                    {
                        Id = id,
                        FileName = id.ToString() + ext,
                        OriginalFileName = formFile.FileName,
                        FileExtention = ext,
                        MimeType = formFile.ContentType
                    };
                    using (Stream stream = new FileStream("./Assets/" + asset.FileName,
                        FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write))
                    {
                        formFile.CopyTo(stream);
                    }
                    _repository.AddItemAsync(asset);
                    result.Add(id);
                }                
            }
            return result;
        }

        [HttpGet("{id}")]        
        public IActionResult Get(Guid? id)
        {
            if (!id.HasValue)
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);

            Asset asset = _repository.AllItems.FirstOrDefault(x => x.Id == id.Value);

            if (asset == null)
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);

            Stream s = new FileStream("./Assets/" + asset.FileName,
                FileMode.Open, FileAccess.Read, FileShare.Write);

            return new FileStreamResult(s, asset.MimeType);

        }
        [HttpDelete]
        public IActionResult Delete(Guid? id)
        {

            return Redirect("/Home/Index");
        }
        [HttpPut]
        public IActionResult Update(IFormCollection formCollection)
        {

            return Redirect("/Home/Index");
        }
    }
}
