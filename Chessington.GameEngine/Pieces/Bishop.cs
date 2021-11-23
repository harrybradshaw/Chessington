using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var availMoves = new List<Square>();
            var curSquare = board.FindPiece(this);
            int[,] dirs = {{1,1},{1,-1},{-1,1},{-1,-1} };
            for (int i = 0; i < 4; i++)
            {
                int[] dir = {dirs[i, 0],dirs[i,1]};
                GetMovesDirection(board, availMoves, dir);
            }
            return availMoves;
        }
    }
}