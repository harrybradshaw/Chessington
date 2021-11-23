using System.Linq;
using Chessington.GameEngine.Pieces;
using FluentAssertions;
using NUnit.Framework;

namespace Chessington.GameEngine.Tests.Pieces
{
    [TestFixture]
    public class CheckTests
    {
        [Test]
        public void CantMoveIntoCheckFromRook()
        {
            var board = new Board();
            var king = new King(Player.White);
            var rook = new Rook(Player.Black);
            board.AddPiece(Square.At(0, 0), king);
            board.AddPiece(Square.At(1,1), rook);
            
            var moves = king.GetAvailableMoves(board).ToList();
            moves.Should().Contain(Square.At(1, 0));
            moves.Should().HaveCount(1);

        }

        [Test]
        public void SimulationDoesNotRemovePiece()
        {
            var board = new Board();
            var king = new King(Player.White);
            var rook = new Rook(Player.Black);
            var pawn = new Pawn(Player.Black);
            board.AddPiece(Square.At(0, 0), king);
            board.AddPiece(Square.At(1,2), rook);
            board.AddPiece(Square.At(1,0), pawn);
            
            var moves = king.GetAvailableMoves(board).ToList();
            moves.Should().Contain(Square.At(0, 1));
            board.GetPiece(Square.At(0, 0)).Should().BeSameAs(king);
            //board.GetPiece(Square.At(1, 0)).Should().BeSameAs(pawn);
        }
    }
}