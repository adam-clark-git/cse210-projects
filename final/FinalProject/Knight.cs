class Knight : Piece
{
    public Knight(int yPos, int xPos) : base(yPos, xPos)
    {
        _points = 3;
        _name = "knight";
        _color = "white";
        _symbol = "N";
        ColorDif();
    }
    public Knight(int yPos, int xPos, string color, bool hasMoved) : base(yPos, xPos)
    {
        _points = 100;
        _name = "knight";
        _color = color;
        _symbol = "N";
        _hasMoved = hasMoved;
        ColorDif();
    }
    public override List<Piece> CheckMovement(ChessBoard board, bool userIsWhite)
    {
        List<Piece> possibleMoves = new List<Piece>();
        // Right 2 Up 1
        if ( board.CheckSingleMove(_yPos + 2, _xPos + 1, userIsWhite))
        {
            possibleMoves.Add(board._board[_yPos + 2][_xPos + 1]);
        }
        // Left 2 Up 1
        if ( board.CheckSingleMove(_yPos - 2, _xPos + 1, userIsWhite))
        {
            possibleMoves.Add(board._board[_yPos - 2][_xPos + 1]);
        }
        // Right 2 Down 1
        if ( board.CheckSingleMove(_yPos + 2, _xPos - 1, userIsWhite))
        {
            possibleMoves.Add(board._board[_yPos + 2][_xPos - 1]);
        }
        // Left 2 Down 1
        if ( board.CheckSingleMove(_yPos - 2, _xPos - 1, userIsWhite))
        {
            possibleMoves.Add(board._board[_yPos - 2][_xPos - 1]);
        }

        // Right 1 Up 2
        if ( board.CheckSingleMove(_yPos + 1, _xPos + 2, userIsWhite))
        {
            possibleMoves.Add(board._board[_yPos + 1][_xPos + 2]);
        }
        // Left 1 Up 2
        if ( board.CheckSingleMove(_yPos - 1, _xPos + 2, userIsWhite))
        {
            possibleMoves.Add(board._board[_yPos - 1][_xPos + 2]);
        }
        // Right 1 Down 2
        if ( board.CheckSingleMove(_yPos + 1, _xPos - 2, userIsWhite))
        {
            possibleMoves.Add(board._board[_yPos + 1][_xPos - 2]);
        }
        // Left 1 Down 2
        if ( board.CheckSingleMove(_yPos - 1, _xPos - 2, userIsWhite))
        {
            possibleMoves.Add(board._board[_yPos - 1][_xPos - 2]);
        }
        
        return RemoveCheckMoves(possibleMoves, userIsWhite, board);

    }
}
