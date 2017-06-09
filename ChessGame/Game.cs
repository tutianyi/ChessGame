using System.Text;

namespace ChessGame
{
    public class Game
    {
        public const int None = -1;
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
            var position = None;
            if (CanWin(player, ref position))
                return position;
            if (CanMove(ref position))
                return position;
            return position;
        }

        private bool CanWin(char player, ref int position)
        {
            for (int i = 0; i < 9; i++)
            {
                if (_board[i] == '-')
                {
                    Game game = Play(i, player);
                    if (game.Winner() == player)
                    {
                        position = i;
                        return true;
                    }
                }
            }
            return false;
        }

        private bool CanMove(ref int position)
        {
            for (int i = 0; i < 9; i++)
            {
                if (_board[i] == '-')
                {
                    position = i;
                    return true;
                }
            }
            return false;
        }

        public Game Play(int i, char player)
        {
            return new Game(this._board, i, player);
        }

        public char Winner()
        {
            if (IsLine(0))
                return _board[0];
            if (IsLine(3))
                return _board[3];
            if (IsLine(6))
                return _board[6];
            return '-';
        }

        private bool IsLine(int index)
        {
            return _board[index] != '-'
                   && _board[index] == _board[index + 1]
                   && _board[index + 1] == _board[index + 2];
        }
    }
}
