using ImparApp.Api.Configurations;
using ImparApp.Application.Extensions.ViewModels;
using ImparApp.Application.Interfaces;
using ImparApp.Application.ViewModels.Card;
using Microsoft.AspNetCore.Mvc;

namespace ImparApp.Api.Controllers
{
    [ApiController]
    public sealed class CardsController : Controller
    {
        private readonly ICardService _service;

        public CardsController(ICardService service)
            => _service = service;

        [HttpGet("odata")]
        [ODataQuery]
        public ActionResult<IQueryable<CardViewModel>> Query() => CustomResponse(_service.Query());

        [HttpPost]
        public async Task<ActionResult<PostReturnViewModel>> Post(CardPostViewModel viewModel)
            => CustomResponse(await _service.Insert(viewModel));

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, CardPutViewModel viewModel)
            => CustomResponse(await _service.Update(id, viewModel));

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
            => CustomResponse(await _service.Delete(id));
    }
}
