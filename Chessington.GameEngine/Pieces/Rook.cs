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
            var tempSquare = new Square(curSquare.Row - 1, curSquare.Col);
            while (board.IsValid(tempSquare))
            {
                if (board.GetPiece(tempSquare) == null)
                {
                    availMoves.Add(tempSquare);
                    tempSquare = new Square(tempSquare.Row - 1, tempSquare.Col);
                }
                else
                {
                    break;
                }
            }
            tempSquare = new Square(curSquare.Row , curSquare.Col + 1);
            while (board.IsValid(tempSquare))
            {
                if (board.GetPiece(tempSquare) == null)
                {
                    availMoves.Add(tempSquare);
                    tempSquare = new Square(tempSquare.Row, tempSquare.Col +1);
                }
                else
                {
                    break;
                }
            }
            tempSquare = new Square(curSquare.Row, curSquare.Col - 1);
            while (board.IsValid(tempSquare))
            {
                if (board.GetPiece(tempSquare) == null)
                {
                    availMoves.Add(tempSquare);
                    tempSquare = new Square(tempSquare.Row, tempSquare.Col -1);
                }
                else
                {
                    break;
                }
            }
            tempSquare = new Square(curSquare.Row + 1, curSquare.Col);
            while (board.IsValid(tempSquare))
            {
                if (board.GetPiece(tempSquare) == null)
                {
                    availMoves.Add(tempSquare);
                    tempSquare = new Square(tempSquare.Row + 1, tempSquare.Col);
                }
                else
                {
                    break;
                }
            }
            return availMoves;
        }
    }
}