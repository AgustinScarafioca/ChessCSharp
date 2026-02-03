using System;
using System.Collections.Generic;
using System.Text;

namespace ChessLogic
{
    public class Queen : Piece
    {
        public override PieceType Type => PieceType.Queen;
        public override Player Color { get; }

        private static readonly Direction[] dirs = new Direction[]
        {
            Direction.North,
            Direction.East,
            Direction.South,
            Direction.West,
            Direction.NorthWest,
            Direction.NorthEast,
            Direction.SouthWest,
            Direction.SouthEast,
        };

        public Queen(Player color)
        {
            Color = color;
        }
        public override Piece Copy()
        {
            Queen copy = new Queen(this.Color);
            copy.HasMoved = HasMoved;
            return copy;
        }
        public override IEnumerable<Move> GetMoves(Position from, Board board)
        {
            return MovePositionInDirs(from, board, dirs).Select(to => new NormalMove(from, to));
        }
    }
}
