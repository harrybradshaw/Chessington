﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public abstract class Piece
    {
        protected Piece(Player player)
        {
            Player = player;
        }

        public Player Player { get; private set; }

        public abstract IEnumerable<Square> GetAvailableMoves(Board board);

        public void MoveTo(Board board, Square newSquare)
        {
            var currentSquare = board.FindPiece(this);
            board.MovePiece(currentSquare, newSquare);
        }
        
        public List<Square> GetMovesDirection(Board board, List<Square> availMoves, int[] dir)
        {
            var curSquare = board.FindPiece(this);
            var newSquare = new Square(curSquare.Row + dir[0], curSquare.Col + dir[1]);
            while (board.IsValid(newSquare))
            {
                if (board.GetPiece(newSquare) == null)
                {
                    availMoves.Add(newSquare);
                    newSquare = new Square(newSquare.Row + dir[0], newSquare.Col + dir[1]);
                }else
                {
                    //Square is not empty but...
                    if (!this.Player.Equals(board.GetPiece(newSquare).Player))
                    {
                        //Its the opponents piece. Valid move.
                        availMoves.Add(newSquare);
                    }
                    break;
                }
            }
            return availMoves;
        }

        public List<Square> GetMovesDirectionSingular(Board board, List<Square> availMoves, int[] dir)
        {
            var curSquare = board.FindPiece(this);
            var newSquare = new Square(curSquare.Row + dir[0], curSquare.Col + dir[1]);
            if (board.IsValid(newSquare))
            {
                if (board.GetPiece(newSquare) == null)
                {
                    availMoves.Add(newSquare);
                }
                else if (!this.Player.Equals(board.GetPiece(newSquare).Player))
                {
                    availMoves.Add(newSquare);
                }
                
            }
            return availMoves;
        }
    }
}