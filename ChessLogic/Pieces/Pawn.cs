using System;
using System.Collections.Generic;
using System.Text;

namespace ChessLogic
{
    public class Pawn : Piece
    {
        public override PieceType Type => PieceType.Pawn;
        public override Player Color { get; }

        public Pawn(Player color)
        {
            Color = color;
        }

        public override Piece Copy()
        {
            Pawn copy = new Pawn(this.Color);
            copy.HasMoved = HasMoved;
            return copy;
        }
    }
}
