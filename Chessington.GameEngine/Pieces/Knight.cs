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

            int[,] moves = new int[,] {{1, 2}, {-1, 2}, {-1, -2}, {1, -2}, {-2,1}, {-2,-1}, {2, 1}, {2,-1}};
            for(int i = 0 ; i < 8; i++)
            {
                var tempSquare = new Square(curSquare.Row + moves[i, 0], curSquare.Col + moves[i, 1]);
                if (board.IsValid(tempSquare))
                {
                    availMoves.Add(tempSquare);
                }
            }
            return availMoves;
        }
    }
}