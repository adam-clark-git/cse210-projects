using System.Runtime.InteropServices;

class Bishop : Piece
{
    public Bishop(int yPos, int xPos) : base(yPos, xPos)
    {
        _points = 3;
        _name = "bishop";
        _color = "white";
        _symbol = "B";
        ColorDif();
    }
    public Bishop(int yPos, int xPos, string color, bool hasMoved) : base(yPos, xPos)
    {
        _points = 3;
        _name = "bishop";
        _color = color;
        _symbol = "B";
        _hasMoved = hasMoved;
        ColorDif();
    }
    public override List<Piece> CheckMovement(ChessBoard board, bool userIsWhite)
    {
        List<Piece> possibleMoves = new List<Piece>();
        // Checks all diaganols of the Bishop

        // Diaganol to down-right
        for (int distance = 1; board.CheckSingleMove(_yPos + distance, _xPos + distance, userIsWhite); distance++)
        {
            possibleMoves.Add(board._board[_yPos + distance][_xPos + distance]);
            if (possibleMoves[possibleMoves.Count - 1].IsOppositeColor(userIsWhite))
            {
                break;
            }
        }
        // Diaganol to down-left
        for (int distance = 1; board.CheckSingleMove(_yPos - distance, _xPos + distance, userIsWhite); distance++)
        {
            possibleMoves.Add(board._board[_yPos - distance][_xPos + distance]);
            if (possibleMoves[possibleMoves.Count - 1].IsOppositeColor(userIsWhite))
            {
                break;
            }
        }
        // Diaganol to up-right
        for (int distance = 1; board.CheckSingleMove(_yPos + distance, _xPos - distance, userIsWhite); distance++)
        {
            possibleMoves.Add(board._board[_yPos + distance][_xPos - distance]);
            if (possibleMoves[possibleMoves.Count - 1].IsOppositeColor(userIsWhite))
            {
                break;
            }
        }
        // Diaganol to up-left
        for (int distance = 1; board.CheckSingleMove(_yPos - distance, _xPos - distance, userIsWhite); distance++)
        {
            possibleMoves.Add(board._board[_yPos - distance][_xPos - distance]);
            if (possibleMoves[possibleMoves.Count - 1].IsOppositeColor(userIsWhite))
            {
                break;
            }
        }
        
        return RemoveCheckMoves(possibleMoves, userIsWhite, board);
    }
    
}