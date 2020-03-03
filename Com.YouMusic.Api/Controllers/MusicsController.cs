using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Com.YouMusic.Core.Dtos;
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
        public async Task<IActionResult> CreateMusic([FromBody]MusicSaveDto musicDto)
        {
            var newMusic = await _musicService.CreateMusic(musicDto);

            return Ok(newMusic);
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<IActionResult> UpdateMusic([FromBody]MusicSaveDto musicDto)
        {
            await _musicService.UpdateMusic(musicDto);

            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _musicService.DeleteMusic(id);

            return Ok();
        }
    }
}
