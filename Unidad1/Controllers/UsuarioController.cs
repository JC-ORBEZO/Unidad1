using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unidad1.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class UsuarioController : ControllerBase
    {
        private readonly MyContext _context;

        public UsuarioController(MyContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> Get()
        {
            return await _context.Usuarios.ToListAsync();            
        } 

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Usuario>> Get(int id)
        {
            var existe=await _context.Usuarios.AnyAsync(x => x.Id == id);
            if (!existe) return BadRequest($"No existe ningún Usuario con Id: {id}");
            return await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Usuario usuario)
        {
            var existe = await _context.Usuarios.AnyAsync(x => x.Id == usuario.Id);
            if (existe) return BadRequest($"Ya existe un Usuario con Id: {usuario.Id}");
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Usuario usuario,int id)
        {
            var existe = await _context.Usuarios.AnyAsync(x => x.Id == id);
            if (!existe) return BadRequest($"No existe ningún Usuario con Id: {id}");
            _context.Update(usuario);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await _context.Usuarios.AnyAsync(x => x.Id == id);
            if (!existe) return BadRequest($"No existe ningún Usuario con Id: {id}");
            _context.Usuarios.Remove(new Usuario { Id = id });
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
