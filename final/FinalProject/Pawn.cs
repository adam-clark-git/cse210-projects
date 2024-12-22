class Pawn : Piece
{
    private bool _enPassantEnabled;
    public Pawn(int yPos, int xPos) : base(yPos, xPos)
    {
        _points = 1;
        _name = "pawn";
        _color = "white";
        _symbol = "P";
        _enPassantEnabled = false;
        ColorDif();
    }
    public Pawn(int yPos, int xPos, string color, bool hasMoved, bool enPassantStatus) : base(yPos, xPos)
    {
        _points = 1;
        _name = "pawn";
        _color = color;
        _symbol = "P";
        _hasMoved = hasMoved;
        _enPassantEnabled = enPassantStatus;
        ColorDif();
    }
    public override List<Piece> CheckMovement(ChessBoard board, bool userIsWhite)
    {
        List<Piece> possibleMoves = new List<Piece>();
        // Diaganol to up-right
        int upOne = -1;
        if (userIsWhite)
        {
            upOne = 1;
        }
        

        if (board.CheckPawnCapture(_yPos + upOne, _xPos + 1, userIsWhite))
        {
            possibleMoves.Add(board._board[_yPos + upOne][_xPos + 1]);
        }
        // Diaganol to up-left
        if (board.CheckPawnCapture(_yPos + upOne, _xPos - 1, userIsWhite))
        {
            possibleMoves.Add(board._board[_yPos + upOne][_xPos - 1]);
        }
        // Straight up
        if (board.CheckPawnMove(_yPos + upOne, _xPos, userIsWhite))
        {
            possibleMoves.Add(board._board[_yPos + upOne][_xPos]);
            if (!_hasMoved)
            {
                if (board.CheckPawnMove(_yPos + (upOne * 2), _xPos, userIsWhite))
                {
                    possibleMoves.Add(board._board[_yPos + (upOne * 2)][_xPos]);
                    _enPassantEnabled = true;
                }
            }
        }
        
        // Checking for en passant.
        if (board.CheckSingleMove(_yPos, _xPos - 1, userIsWhite) && board.CheckEnPassant(_yPos, _xPos - 1, userIsWhite))
        {
            possibleMoves.Add(board._board[_yPos][_xPos - 1]);
        }
        if (board.CheckSingleMove(_yPos, _xPos + 1, userIsWhite) && board.CheckEnPassant(_yPos, _xPos + 1, userIsWhite))
        {
            possibleMoves.Add(board._board[_yPos][_xPos + 1]);
        }
        
        return RemoveCheckMoves(possibleMoves, userIsWhite, board);

    }
    public override void ResetToNeutral()
    {
        _enPassantEnabled = false;
    }
    public override bool GetEnPassantStatus()
    {
        return _enPassantEnabled;
    }
}
