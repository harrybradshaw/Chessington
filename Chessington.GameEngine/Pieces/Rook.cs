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
            for (int i = 0; i < 8; i++)
            {
                var newSquareX = new Square(curSquare.Row,i);
                availMoves.Add(newSquareX);
                var newSquareY = new Square(i,curSquare.Col);
                availMoves.Add(newSquareY);
            }
            
            return availMoves;
        }
    }
}