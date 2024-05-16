using BodyFit.Context;
using BodyFit.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BodyFit.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class PessoaController : ControllerBase
    {
        private readonly PessoaContext _context;

        public PessoaController(PessoaContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(Pessoa pessoa)
        {
            _context.Add(pessoa);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ObterPorId), new { id = pessoa.Id}, pessoa);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id) 
        {
            var pessoa = _context.Pessoas.Find(id);

            if (pessoa == null)
            {
                return NotFound();
            }

            return Ok(pessoa);
        }

        [HttpGet("ObterPorNome")]
        public IActionResult ObterPorNome (string nome)
        {
            var pessoas = _context.Pessoas.Where(x => x.Nome.Contains(nome));
            return Ok(pessoas);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Pessoa pessoa)
        {
            var pessoaBanco = _context.Pessoas.Find(id);

            if (pessoaBanco == null)
                return NotFound();

            pessoaBanco.Nome = pessoa.Nome;
            pessoaBanco.Email = pessoa.Email;
            pessoaBanco.Telefone = pessoa.Telefone;
            pessoaBanco.CartaoCredito = pessoa.CartaoCredito;
            pessoaBanco.Ativo = pessoa.Ativo;

            _context.Pessoas.Update(pessoaBanco);
            _context.SaveChanges();

            return Ok(pessoaBanco);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pessoaBanco = _context.Pessoas.Find(id);

            if(pessoaBanco == null)
                return NotFound();

            _context.Pessoas.Remove(pessoaBanco);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
