using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var availMoves = new List<Square>();
            var curSquare = board.FindPiece(this);

            int[,] dirs =  {{1, 2}, {-1, 2}, {-1, -2}, {1, -2}, {-2,1}, {-2,-1}, {2, 1}, {2,-1}};
            for (int i = 0; i < 8; i++)
            {
                int[] dir = {dirs[i, 0],dirs[i,1]};
                GetMovesDirectionSingular(board, availMoves, dir);
            }
            return availMoves;
        }
    }
}