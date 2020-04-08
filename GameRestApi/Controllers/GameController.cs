using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameRestApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        BoardRepository repo = BoardRepository.Instance;

        [HttpGet]
        public List<Board> GetGames()
        {
            return repo.boards;
        }


        // GET: game/5
        [HttpGet("{username}", Name = "Get")]
        public Board Get(string username)
        {
            return repo.get(username);
        }

        [HttpGet("{username}/{spot}", Name = "GetSpot")]
        public int GetSpot(string username, int spot)
        {
            return repo.check(username, spot);
        }

        // POST: game
        [HttpPost]
        public bool Post([FromBody] Board b)
        {
            return repo.add(b);
        }

        [HttpPost("{winner}")]
        public void PostWin([FromBody] string username)
        {
            repo.get(username).winner = username;
            repo.get(repo.get(username).opponent).winner = username;
        }

    }
}
