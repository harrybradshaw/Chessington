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
            var newSquare = new Square(curSquare.Row + 1, curSquare.Col + 1);
            while (board.IsValid(newSquare))
            {
                availMoves.Add(newSquare);
                newSquare = new Square(newSquare.Row + 1, newSquare.Col + 1);
            }
            newSquare = new Square(curSquare.Row + 1, curSquare.Col -1 );
            while (board.IsValid(newSquare))
            {
                availMoves.Add(newSquare);
                newSquare = new Square(newSquare.Row + 1, newSquare.Col - 1);
            }
            newSquare = new Square(curSquare.Row - 1, curSquare.Col + 1);
            while (board.IsValid(newSquare))
            {
                availMoves.Add(newSquare);
                newSquare = new Square(newSquare.Row - 1, newSquare.Col + 1);
            }
            newSquare = new Square(curSquare.Row - 1, curSquare.Col - 1);
            while (board.IsValid(newSquare))
            {
                availMoves.Add(newSquare);
                newSquare = new Square(newSquare.Row - 1, newSquare.Col - 1);
            }
            return availMoves;
        }
    }
}