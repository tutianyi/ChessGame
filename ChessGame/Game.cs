using System.Text;

namespace ChessGame
{
    public class Game
    {
        private StringBuilder _board;

        public Game(string board)
        {
            _board = new StringBuilder(board);
        }

        public Game(StringBuilder board, int position, char player)
        {
            _board = new StringBuilder();
            _board.Append(board);
            _board[position] = player;
        }

        public int Move(char player)
        {
            for (int i = 0; i < 9; i++)
            {
                if (_board[i] == '-')
                {
                    Game game = play(i, player);
                    if (game.winner() == player)
                        return i;
                }
            }

            for (int i = 0; i < 9; i++)
            {
                if (_board[i] == '-')
                    return i;
            }
            return -1;
        }

        public Game play(int i, char player)
        {
            return new Game(this._board, i, player);
        }

        public char winner()
        {
            if (_board[0] != '-'
                && _board[0] == _board[1]
                && _board[1] == _board[2])
                return _board[0];
            if (_board[3] != '-'
                && _board[3] == _board[4]
                && _board[4] == _board[5])
                return _board[3];
            if (_board[6] != '-'
                && _board[6] == _board[7]
                && _board[7] == _board[8])
                return _board[6];
            return '-';
        }
    }
}
