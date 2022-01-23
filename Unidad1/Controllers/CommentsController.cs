using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unidad1.Controllers
{
    internal class CommentsController:ControllerBase
    {
        private readonly MyContext _context;

        public CommentsController(MyContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Comments>>> Get()
        {
            return await _context.Comentarios.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Comments>> Get(int id)
        {
            var existe = await _context.Comentarios.AnyAsync(x => x.Id == id);
            if (!existe) return BadRequest($"No existe ningún Comentario con Id: {id}");
            return await _context.Comentarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Comments comments)
        {
            var existe = await _context.Comentarios.AnyAsync(x => x.Id == comments.Id);
            if (existe) return BadRequest($"Ya existe un Comentarip con Id: {comments.Id}");
            _context.Comentarios.Add(comments);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Comments comments, int id)
        {
            var existe = await _context.Comentarios.AnyAsync(x => x.Id == id);
            if (!existe) return BadRequest($"No existe ningún Comentario con Id: {id}");
            _context.Update(comments);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await _context.Comentarios.AnyAsync(x => x.Id == id);
            if (!existe) return BadRequest($"No existe ningún Comentario con Id: {id}");
            _context.Comentarios.Remove(new Comments { Id = id });
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
