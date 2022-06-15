﻿using Chessboard.Entities;
using Chessboard.Enums;

namespace Chessgame.Entities
{
    class Pawn : Piece
    {
        //Constructors
        public Pawn()
        {
        }

        public Pawn(Board board, Color color) : base(board, color)
        {
        }

        //Overrides
        public override string ToString()
        {
            return "P";
        }
    }
}

