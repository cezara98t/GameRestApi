using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameRestApi
{
    public class BoardRepository
    {
        public List<Board> boards { get; set; }


        private static BoardRepository instance = null;

        public int nrPlayers = 0;
        public int room = 0;

        public static BoardRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BoardRepository();
                }
                return instance;
            }
        }
    
    public BoardRepository()
        {
            boards = new List<Board>();
        }

        public bool add(Board b)
        {
            b.turn = false;
            boards.Add(b);
            nrPlayers++;

            if (nrPlayers % 2 == 0)
            {
                boards.ElementAt(nrPlayers-1).opponent = boards.ElementAt(nrPlayers - 2).username;
                boards.ElementAt(nrPlayers-2).opponent = boards.ElementAt(nrPlayers - 1).username;
                boards.ElementAt(nrPlayers - 1).turn = true; 
                
            }
            return true;
        }

        public Board get(string username)
        {
            foreach (Board b in boards)
                if (b.username.Equals(username))
                    return b;
            return null;
        }

        public int check(string username, int spot)
        {
            Board b = get(username);
            b.turn = true;
            get(b.opponent).turn = false;
            foreach (int pos in b.gameBoard)
                if (pos == spot)
                    return 1;
            return -1;
        }
    }
}
