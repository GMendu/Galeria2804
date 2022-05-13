#nullable disable
using Galeria2804.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Galeria2804.Controllers
{
    public class ImagemsController : Controller
    {
        private readonly Contexto _context;

        public ImagemsController(Contexto context)
        {
            _context = context;
        }

        public string VerificaExtensao(string nomeArquivo)
        {
            string extensaoArquivo = System.IO.Path.GetExtension(nomeArquivo).ToLower();
            string[] validacaoLista = { ".gif", ".jpeg", ".jpg", ".png", ".mp4", ".mp3" };

            foreach (string extensao in validacaoLista)
                if (extensao == extensaoArquivo)
                    return extensao;
            return "none";
        }
        // GET: Imagems
        public async Task<IActionResult> Index()
        {
            return View(await _context.Imagens.ToListAsync());
        }

        // GET: Imagems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imagem = await _context.Imagens
                .FirstOrDefaultAsync(m => m.arquivoId == id);
            if (imagem == null)
            {
                return NotFound();
            }

            return View(imagem);
        }

        // GET: Imagems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Imagems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("arquivoId,arquivoName,arquivoTam,arquivoType,arquivoDescricao")] Imagem imagem, IFormFile arquivo)
        {
            var fileName = arquivo.FileName;
            var fileTam = arquivo.Length;
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/arq/", fileName);

            if (imagem.arquivoDescricao != null)
            {
                imagem.arquivoName = fileName;
                imagem.arquivoTam = (int)fileTam;
                imagem.arquivoType = VerificaExtensao(fileName);

                using (var localFile = System.IO.File.OpenWrite(filePath))
                using (var uploadedFile = arquivo.OpenReadStream())
                {
                    uploadedFile.CopyTo(localFile);
                }

                _context.Add(imagem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(imagem);
        }

        // GET: Imagems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imagem = await _context.Imagens.FindAsync(id);
            if (imagem == null)
            {
                return NotFound();
            }
            return View(imagem);
        }

        // POST: Imagems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("arquivoId,arquivoName,arquivoTam,arquivoType,arquivoDescricao")] Imagem imagem, IFormFile arquivo)
        {
            if (arquivo != null)
            {
                var dataImagemAntes = await _context.Imagens.FindAsync(id);
                var nomeArquivoAntes = dataImagemAntes.arquivoName;

                var nomeArquivoAtual = arquivo.FileName;

                if (nomeArquivoAtual != nomeArquivoAntes)
                {
                    var nomeArquivoAtual_comURL = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/arq/", nomeArquivoAtual);
                    System.IO.File.Delete(nomeArquivoAtual_comURL);

                    using (var localFile = System.IO.File.OpenWrite(nomeArquivoAtual_comURL))
                    using (var uploadedFile = arquivo.OpenReadStream())
                    {
                        uploadedFile.CopyTo(localFile);
                    }

                    dataImagemAntes.arquivoName = nomeArquivoAtual;
                    dataImagemAntes.arquivoTam = (int)arquivo.Length;
                    dataImagemAntes.arquivoType = VerificaExtensao(nomeArquivoAtual);
                    dataImagemAntes.arquivoDescricao = imagem.arquivoDescricao;
                }

                _context.Update(dataImagemAntes);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(imagem);
        }

        // GET: Imagems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imagem = await _context.Imagens
                .FirstOrDefaultAsync(m => m.arquivoId == id);
            if (imagem == null)
            {
                return NotFound();
            }

            return View(imagem);
        }

        // POST: Imagems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var imagem = await _context.Imagens.FindAsync(id);
            var stringEndereco = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/arq/", imagem.arquivoName);

            if (!System.IO.File.Exists(stringEndereco))
                return RedirectToAction(nameof(Index));

            System.IO.File.Delete(stringEndereco);

            _context.Imagens.Remove(imagem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImagemExists(int id)
        {
            return _context.Imagens.Any(e => e.arquivoId == id);
        }
    }
}
