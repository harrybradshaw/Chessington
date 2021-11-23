using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var curSquare = board.FindPiece(this);
            var moves = new List<Square>();
            if (this.Player == Player.White)
            {
                if (curSquare.Row > 1 && board.GetPiece(new Square(curSquare.Row - 1, curSquare.Col)) == null)
                {
                    moves.Add(new Square(curSquare.Row - 1, curSquare.Col));
                }
                if (curSquare.Row == 6 && board.GetPiece(new Square(curSquare.Row - 2, curSquare.Col)) == null
                && board.GetPiece(new Square(curSquare.Row - 1, curSquare.Col)) == null)
                {
                    moves.Add(new Square(curSquare.Row - 2, curSquare.Col));
                }
                
            }
            else if (this.Player == Player.Black)
            {
                if (curSquare.Row < 8 && board.GetPiece(new Square(curSquare.Row + 1, curSquare.Col)) == null)
                {
                    moves.Add(new Square(curSquare.Row + 1, curSquare.Col));
                }
                if (curSquare.Row == 1 && board.GetPiece(new Square(curSquare.Row + 2, curSquare.Col)) == null && 
                    board.GetPiece(new Square(curSquare.Row +1 , curSquare.Col)) == null)
                {
                    moves.Add(new Square(curSquare.Row + 2, curSquare.Col));
                }
            }

            return moves;
        }
    }
}