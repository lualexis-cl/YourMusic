using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Com.YouMusic.Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Com.YouMusic.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicsController : ControllerBase
    {
        private readonly IMusicService _musicService;

        public MusicsController(IMusicService musicService)
        {
            _musicService = musicService;
        }
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> GetAllMusics()
        {
            var musics = await _musicService.GetAllWithArtist();

            return Ok(musics);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMusic(int id)
        {
            var music = await _musicService.GetMusicById(id);

            return Ok(music);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
