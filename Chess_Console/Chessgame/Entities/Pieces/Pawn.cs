using Chessboard.Entities;
using Chessboard.Enums;

namespace Chessgame.Entities
{
    class Pawn : ChessPiece
    {
        //Variables
        private ChessMatch ChessMatch;

        //Constructors
        public Pawn(Board board, Color color, ChessMatch chessMatch) : base(board, color)
        {
            ChessMatch = chessMatch;
        }

        //Overrides
        public override string ToString()
        {
            return "P";
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];

            Position pos = new Position(0, 0);

            if (Color == Color.White)
            {
                //Bellow
                pos.SetValues(Position.Row + 1, Position.Column);
                Position pos2 = new Position(Position.Row + 2, Position.Column);
                if (Board.PositionExists(pos) && !Board.ThereIsAPiece(pos) && Board.PositionExists(pos2) && !Board.ThereIsAPiece(pos2) && MoveCount == 0)
                {
                    mat[pos.Row, pos.Column] = true;
                    mat[pos2.Row, pos2.Column] = true;
                }
                else if (Board.PositionExists(pos) && !Board.ThereIsAPiece(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }

                //Bottom Right Corner
                pos.SetValues(Position.Row + 1, Position.Column + 1);
                if (Board.PositionExists(pos) && IsThereOpponentPiece(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }

                //Bottom Left Corner
                pos.SetValues(Position.Row + 1, Position.Column - 1);
                if (Board.PositionExists(pos) && IsThereOpponentPiece(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }

                // #specialmove en passant white
                if (Position.Row == 4)
                {
                    Position left = new Position(Position.Row, Position.Column - 1);
                    if (Board.PositionExists(left) && IsThereOpponentPiece(left) && Board.GetPiece(left) == ChessMatch.EnPassantVulnerable)
                    {
                        mat[left.Row + 1, left.Column] = true;
                    }
                    Position right = new Position(Position.Row, Position.Column + 1);
                    if (Board.PositionExists(right) && IsThereOpponentPiece(right) && Board.GetPiece(right) == ChessMatch.EnPassantVulnerable)
                    {
                        mat[right.Row + 1, right.Column] = true;
                    }
                }
            }
            else
            {
                //Above
                pos.SetValues(Position.Row - 1, Position.Column);
                Position pos2 = new Position(Position.Row - 2, Position.Column);
                if (Board.PositionExists(pos) && !Board.ThereIsAPiece(pos) && Board.PositionExists(pos2) && !Board.ThereIsAPiece(pos2) && MoveCount == 0)
                {
                    mat[pos.Row, pos.Column] = true;
                    mat[pos2.Row, pos2.Column] = true;
                }
                else if (Board.PositionExists(pos) && !Board.ThereIsAPiece(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }

                //Top Right Corner
                pos.SetValues(Position.Row - 1, Position.Column + 1);
                if (Board.PositionExists(pos) && IsThereOpponentPiece(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }

                //Top Left Corner
                pos.SetValues(Position.Row - 1, Position.Column - 1);
                if (Board.PositionExists(pos) && IsThereOpponentPiece(pos))
                {
                    mat[pos.Row, pos.Column] = true;
                }

                // #specialmove en passant red
                if (Position.Row == 3)
                {
                    Position left = new Position(Position.Row, Position.Column - 1);
                    if (Board.PositionExists(left) && IsThereOpponentPiece(left) && Board.GetPiece(left) == ChessMatch.EnPassantVulnerable)
                    {
                        mat[left.Row - 1, left.Column] = true;
                    }
                    Position right = new Position(Position.Row, Position.Column + 1);
                    if (Board.PositionExists(right) && IsThereOpponentPiece(right) && Board.GetPiece(right) == ChessMatch.EnPassantVulnerable)
                    {
                        mat[right.Row - 1, right.Column] = true;
                    }
                }
            }

            return mat;
        }
    }
}