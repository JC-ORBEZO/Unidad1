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
    internal class PostsController:ControllerBase
    {
        private readonly MyContext _context;

        public PostsController(MyContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Posts>>> Get()
        {
            return await _context.Posteos.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Posts>> Get(int id)
        {
            var existe = await _context.Posteos.AnyAsync(x => x.Id == id);
            if (!existe) return BadRequest($"No existe ningún Posteo con Id: {id}");
            return await _context.Posteos.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Posts posts)
        {
            var existe = await _context.Usuarios.AnyAsync(x => x.Id == posts.Id);
            if (existe) return BadRequest($"Ya existe un Posteo con Id: {posts.Id}");
            _context.Posteos.Add(posts);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Posts posts, int id)
        {
            var existe = await _context.Posteos.AnyAsync(x => x.Id == id);
            if (!existe) return BadRequest($"No existe ningún Posteo con Id: {id}");
            _context.Update(posts);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await _context.Posteos.AnyAsync(x => x.Id == id);
            if (!existe) return BadRequest($"No existe ningún Posteo con Id: {id}");
            _context.Posteos.Remove(new Posts { Id = id });
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
