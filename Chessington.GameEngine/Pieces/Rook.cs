using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var curSquare = board.FindPiece(this);
            var availMoves = new List<Square>();

            int[,] dirs = {{1,0},{0,-1},{-1,0},{0,1} };
            for (int i = 0; i < 4; i++)
            {
                int[] dir = {dirs[i, 0],dirs[i,1]};
                GetMovesDirection(board, availMoves, dir);
            }
            return availMoves;
        }
    }
}