using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class King : Piece
    {
        public King(Player player)
            : base(player) { }
        
        public new List<Square> GetMovesDirectionSingular(Board board, List<Square> availMoves, int[] dir)
        {
            var curSquare = board.FindPiece(this);
            var newSquare = new Square(curSquare.Row + dir[0], curSquare.Col + dir[1]);
            if (board.IsValid(newSquare))
            {
                if (board.GetPiece(newSquare) == null)
                {
                    availMoves.Add(newSquare);
                   
                }else if (!this.Player.Equals(board.GetPiece(newSquare).Player) )
                {
                    availMoves.Add(newSquare);
                }
            }
            return availMoves;
        }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var availMoves = new List<Square>();
            var curSquare = board.FindPiece(this);
            
            int[,] dirs = {{1, 0}, {-1, 0}, {-1, 1}, {1, -1}, {0,1}, {0,-1}, {1, 1}, {-1,-1}};
            for (int i = 0; i < 8; i++)
            {
                int[] dir = {dirs[i, 0],dirs[i,1]};
                GetMovesDirectionSingular(board, availMoves, dir);
            }
            return availMoves;
        }

        public bool IsMoveIntoCheck(Board board, Square newSquare, Square oldSquare)
        {
            var checkFlag = false;
            var simBoard = new Board();

            foreach (var piece in board.board)
            {
                var tempSquare = board.FindPiece(piece);
                var square = new Square(tempSquare.Row,tempSquare.Col);
                if (piece.GetType() == typeof(King))
                {
                    var tempPiece = new King(piece.Player);
                    simBoard.AddPiece(square,tempPiece);
                } else if (piece.GetType() == typeof(Queen))
                {
                    var tempPiece = new Queen(piece.Player);
                    simBoard.AddPiece(square,tempPiece);
                }
                
                
            }

            return checkFlag;
        }
        
    }
}