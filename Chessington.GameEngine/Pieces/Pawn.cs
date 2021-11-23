using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }
        
        public List<Square> PawnCapture(Board board, List<Square> availMoves, int[] dir)
        {
            var curSquare = board.FindPiece(this);
            var newSquare = new Square(curSquare.Row + dir[0], curSquare.Col + dir[1]);
            if (board.IsValid(newSquare))
            {
                if (board.GetPiece(newSquare) != null && !this.Player.Equals(board.GetPiece(newSquare).Player))
                {
                    availMoves.Add(newSquare);
                }
            }
            return availMoves;
        }

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
                int[,] dirs = {{-1,1},{-1,-1}};
                for (int i = 0; i < 2; i++)
                {
                    int[] dir = {dirs[i, 0],dirs[i,1]};
                    moves = PawnCapture(board, moves, dir);
                }
                
            }
            else if (this.Player == Player.Black)
            {
                if (curSquare.Row < 7 && board.GetPiece(new Square(curSquare.Row + 1, curSquare.Col)) == null)
                {
                    moves.Add(new Square(curSquare.Row + 1, curSquare.Col));
                }
                if (curSquare.Row == 1 && board.GetPiece(new Square(curSquare.Row + 2, curSquare.Col)) == null && 
                    board.GetPiece(new Square(curSquare.Row +1 , curSquare.Col)) == null)
                {
                    moves.Add(new Square(curSquare.Row + 2, curSquare.Col));
                }
                
                int[,] dirs = {{1,1},{1,-1}};
                for (int i = 0; i < 2; i++)
                {
                    int[] dir = {dirs[i, 0],dirs[i,1]};
                    moves = PawnCapture(board, moves, dir);
                }
            }
            
            return moves;
        }
    }
}