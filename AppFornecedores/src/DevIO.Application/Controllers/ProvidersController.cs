using AutoMapper;
using DevIO.Application.ViewModels;
using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.Application.Controllers
{
    public class ProvidersController : BaseController
    {
        private readonly IProviderRepository _repository;
        private readonly IMapper _mapper;

        public ProvidersController(IProviderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var providers = await _repository.GetAll();
            return View(_mapper.Map<IEnumerable<ProviderViewModel>>(providers));
        }

        public async Task<IActionResult> Details(Guid id)
        {

            var providerViewModel = await GetProviderAddress(id);

            if (providerViewModel == null)
            {
                return NotFound();
            }

            return View(providerViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProviderViewModel providerViewModel)
        {
            if (!ModelState.IsValid) return View(providerViewModel);

            var provider = _mapper.Map<Provider>(providerViewModel);
            await _repository.Add(provider);

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Edit(Guid id)
        {

            var providerViewModel = await GetProviderProductsAddress(id);
            if (providerViewModel == null)
            {
                return NotFound();
            }
            return View(providerViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ProviderViewModel providerViewModel)
        {
            if (id != providerViewModel.Id) return NotFound();


            if (!ModelState.IsValid) return View(providerViewModel);

            var provider = _mapper.Map<Provider>(providerViewModel);
            await _repository.Update(provider);

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Delete(Guid id)
        {

            var providerViewModel = await GetProviderAddress(id);

            if (providerViewModel == null) return NotFound();

            return View(providerViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var providerViewModel = await GetProviderAddress(id);

            if (providerViewModel == null) return NotFound();

            await _repository.DeleteById(id);

            return RedirectToAction("Index");
        }

        private async Task<ProviderViewModel> GetProviderAddress(Guid id) =>
            _mapper.Map<ProviderViewModel>(await _repository.GetProviderAddress(id));

        private async Task<ProviderViewModel> GetProviderProductsAddress(Guid id) =>
            _mapper.Map<ProviderViewModel>(await _repository.GetProviderProductsAddress(id));
    }
}
