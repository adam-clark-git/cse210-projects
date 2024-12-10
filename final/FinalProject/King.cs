using System.Drawing;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;

class King : Piece
{
    public King(int yPos, int xPos) : base(yPos, xPos)
    {
        _points = 100;
        _name = "king";
        _color = "white";
        _symbol = "K";
        ColorDif();
    }
    public King(int yPos, int xPos, string color, bool hasMoved) : base(yPos, xPos)
    {
        _points = 100;
        _name = "king";
        _color = color;
        _symbol = "K";
        _hasMoved = hasMoved;
        ColorDif();
    }
    public override List<Piece> CheckMovement(ChessBoard board, bool userIsWhite)
    {
        List<Piece> possibleMoves = new List<Piece>();
        // Diaganol to up-right
        if ( board.CheckSingleMove(_yPos + 1, _xPos + 1, userIsWhite))
        {
            possibleMoves.Add(board._board[_yPos + 1][_xPos + 1]);
        }
        // Diaganol to up-left
        if ( board.CheckSingleMove(_yPos - 1, _xPos + 1, userIsWhite))
        {
            possibleMoves.Add(board._board[_yPos - 1][_xPos + 1]);
        }
        // Diaganol to down-right
        if ( board.CheckSingleMove(_yPos + 1, _xPos - 1, userIsWhite))
        {
            possibleMoves.Add(board._board[_yPos + 1][_xPos - 1]);
        }
        // Diaganol to down-left
        if ( board.CheckSingleMove(_yPos - 1, _xPos - 1, userIsWhite))
        {
            possibleMoves.Add(board._board[_yPos - 1][_xPos - 1]);
        }
        // if straight up and down
        // Straight right
        if (board.CheckSingleMove(_yPos + 1, _xPos, userIsWhite))
        {
            possibleMoves.Add(board._board[_yPos + 1][_xPos]);
        }
        // Straight left
        if (board.CheckSingleMove(_yPos - 1, _xPos, userIsWhite))
        {
            possibleMoves.Add(board._board[_yPos - 1][_xPos]);
        }
        // Straight up
        if (board.CheckSingleMove(_yPos, _xPos + 1, userIsWhite))
        {
            possibleMoves.Add(board._board[_yPos][_xPos + 1]);
        }
        // Straight down
        if ( board.CheckSingleMove(_yPos, _xPos - 1, userIsWhite))
        {
            possibleMoves.Add(board._board[_yPos][_xPos - 1]);
        }
        
        // CASTLING
        if (_hasMoved != true)
        {
            int row = 7;
            if (_color.Equals("White"))
            {
                row  = 0;
            }
            
            // Short castle
            if (!board._board[row][0].GetHasMoved() && board._board[row][1].IsEmpty() && board._board[row][2].IsEmpty())
            {
                possibleMoves.Add(board._board[_yPos][_xPos - 2]);
            }
            // Long castle
            if (!board._board[row][7].GetHasMoved()&& board._board[row][4].IsEmpty() && board._board[row][5].IsEmpty() && board._board[row][6].IsEmpty())
            {
                possibleMoves.Add(board._board[_yPos][_xPos + 2]);
            }
        }
        return RemoveCheckMoves(possibleMoves, userIsWhite, board);

    }
}
