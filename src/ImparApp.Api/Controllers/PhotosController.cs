using ImparApp.Api.Configurations;
using ImparApp.Application.Extensions.ViewModels;
using ImparApp.Application.Interfaces;
using ImparApp.Application.ViewModels.Photo;
using Microsoft.AspNetCore.Mvc;

namespace ImparApp.Api.Controllers
{
    [ApiController]
    public class PhotosController : Controller
    {
        private readonly IPhotoService _service;

        public PhotosController(IPhotoService service)
            => _service = service;

        [HttpGet("odata")]
        [ODataQuery]
        public ActionResult<IQueryable<PhotoViewModel>> Query() => CustomResponse(_service.Query());

        [HttpPost]
        public async Task<ActionResult<PostReturnViewModel>> Post(PhotoPostViewModel viewModel)
            => CustomResponse(await _service.Insert(viewModel));

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, PhotoPutViewModel viewModel)
            => CustomResponse(await _service.Update(id, viewModel));

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
            => CustomResponse(await _service.Delete(id));
    }
}
