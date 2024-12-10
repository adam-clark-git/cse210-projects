class Queen : Piece
{
    public Queen(int yPos, int xPos) : base(yPos, xPos)
    {
        _points = 9;
        _name = "queen";
        _color = "white";
        _symbol = "Q";
        ColorDif();
    }
    public Queen(int yPos, int xPos, string color, bool hasMoved) : base(yPos, xPos)
    {
        _points = 9;
        _name = "queen";
        _color = color;
        _symbol = "Q";
        _hasMoved = hasMoved;
        ColorDif();
    }
    public override List<Piece> CheckMovement(ChessBoard board, bool userIsWhite)
    {
        List<Piece> possibleMoves = new List<Piece>();
        // Diaganol to up-right
        for (int distance = 1; board.CheckSingleMove(_yPos + distance, _xPos + distance, userIsWhite); distance++)
        {
            possibleMoves.Add(board._board[_yPos + distance][_xPos + distance]);
            if (possibleMoves[possibleMoves.Count - 1].IsOppositeColor(userIsWhite))
            {
                break;
            }
        }
        // Diaganol to up-left
        for (int distance = 1; board.CheckSingleMove(_yPos - distance, _xPos + distance, userIsWhite); distance++)
        {
            possibleMoves.Add(board._board[_yPos - distance][_xPos + distance]);
            if (possibleMoves[possibleMoves.Count - 1].IsOppositeColor(userIsWhite))
            {
                break;
            }
        }
        // Diaganol to down-right
        for (int distance = 1; board.CheckSingleMove(_yPos + distance, _xPos - distance, userIsWhite); distance++)
        {
            possibleMoves.Add(board._board[_yPos + distance][_xPos - distance]);
            if (possibleMoves[possibleMoves.Count - 1].IsOppositeColor(userIsWhite))
            {
                break;
            }
        }
        // Diaganol to down-left
        for (int distance = 1; board.CheckSingleMove(_yPos - distance, _xPos - distance, userIsWhite); distance++)
        {
            possibleMoves.Add(board._board[_yPos - distance][_xPos - distance]);
            if (possibleMoves[possibleMoves.Count - 1].IsOppositeColor(userIsWhite))
            {
                break;
            }
        }

        // For straight up and down
        // Straight right
        for (int distance = 1; board.CheckSingleMove(_yPos + distance, _xPos, userIsWhite); distance++)
        {
            possibleMoves.Add(board._board[_yPos + distance][_xPos]);
            if (possibleMoves[possibleMoves.Count - 1].IsOppositeColor(userIsWhite))
            {
                break;
            }
        }
        // Straight left
        for (int distance = 1; board.CheckSingleMove(_yPos - distance, _xPos, userIsWhite); distance++)
        {
            possibleMoves.Add(board._board[_yPos - distance][_xPos]);
            if (possibleMoves[possibleMoves.Count - 1].IsOppositeColor(userIsWhite))
            {
                break;
            }
        }
        // Straight up
        for (int distance = 1; board.CheckSingleMove(_yPos, _xPos + distance, userIsWhite); distance++)
        {
            possibleMoves.Add(board._board[_yPos][_xPos + distance]);
            if (possibleMoves[possibleMoves.Count - 1].IsOppositeColor(userIsWhite))
            {
                break;
            }
        }
        // Straight down
        for (int distance = 1; board.CheckSingleMove(_yPos, _xPos - distance, userIsWhite); distance++)
        {
            possibleMoves.Add(board._board[_yPos][_xPos - distance]);
            if (possibleMoves[possibleMoves.Count - 1].IsOppositeColor(userIsWhite))
            {
                break;
            }
        }
        return RemoveCheckMoves(possibleMoves, userIsWhite, board);

    }
}
