using AutoMapper;
using DevIO.App.Data;
using DevIO.App.ViewModels;
using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevIO.App.Controllers
{
    public class ProvidersController : Controller
    {
        private readonly IProviderRepository _repository;
        private readonly IMapper _mapper;

        public ProvidersController(IProviderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: Providers
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ProviderViewModel>>(await _repository.GetAll()));
        }

        // GET: Providers/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var providerViewModel = await _repository.GetById(id);
            if (providerViewModel == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<ProviderViewModel>(providerViewModel));
        }

        // GET: Providers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Providers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Document,TypeProvider,Enabled")] ProviderViewModel providerViewModel)
        {
            if (ModelState.IsValid)
            {
                providerViewModel.Id = Guid.NewGuid();
                _repository.Add(_mapper.Map<Provider>(providerViewModel));
                return RedirectToAction(nameof(Index));
            }
            return View(_mapper.Map<ProviderViewModel>(providerViewModel));
        }

        // GET: Providers/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var providerViewModel = await _repository.GetById(id);
            if (providerViewModel == null)
            {
                return NotFound();
            }
            return View(_mapper.Map<ProviderViewModel>(providerViewModel));
        }

        // POST: Providers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Document,TypeProvider,Enabled")] ProviderViewModel providerViewModel)
        {
            if (id != providerViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _repository.Update(_mapper.Map<Provider>(providerViewModel));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProviderViewModelExists(providerViewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(_mapper.Map<ProviderViewModel>(providerViewModel));
        }

        // GET: Providers/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var providerViewModel = await _repository.GetById(id);
            if (providerViewModel == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<ProviderViewModel>(providerViewModel));
        }

        // POST: Providers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            
            var providerViewModel = await _repository.GetById(id);
            if (providerViewModel != null)
            {
                _repository.DeleteById(id);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool ProviderViewModelExists(Guid id)
        {
            return _repository.Get(e => e.Id == id) != null;
        }
    }
}
