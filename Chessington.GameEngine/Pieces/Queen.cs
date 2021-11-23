using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Queen : Piece
    {
        public Queen(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var availMoves = new List<Square>();
            var curSquare = board.FindPiece(this);
            
            for (int i = 0; i < 8; i++)
            {
                var newSquareX = new Square(curSquare.Row,i);
                if (!newSquareX.Equals(curSquare))
                {
                    availMoves.Add(newSquareX);
                }
                var newSquareY = new Square(i,curSquare.Col);
                if (!newSquareY.Equals(curSquare))
                {
                    availMoves.Add(newSquareY);
                }
               
            }
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