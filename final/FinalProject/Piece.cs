using System.Drawing;

class Piece
{
    protected int _points;
    protected String _name;
    protected String _color;
    protected int _xPos;
    protected int _yPos;
    protected bool _hasMoved;
    protected String _symbol;
    protected bool _highlightMode;

    public Piece(int startYPos, int startXPos)
    {
        // Default
        _points = 0;
        _name = "blank";
        _color = "none";
        _yPos = startYPos;
        _xPos = startXPos;
        _hasMoved = false;
        _symbol = "*";
        _highlightMode = false;
    }
    public virtual List<Piece> CheckMovement(ChessBoard board, bool userIsWhite)
    {
        Console.Clear();
        // Print a screen of the board, but replace any spot where the piece can move with an X.
        // Then show the user how many possible moves there are.
        return new List<Piece>(); 
    }
    public bool IsSameColor(bool userIsWhite)
    {
        if (_color.Equals("white") && userIsWhite)
        {
            return true;
        }
        if (_color.Equals("black") && !userIsWhite)
        {
            return true;
        }
        return false;
    }
    public bool IsOppositeColor(bool userIsWhite)
    {
        if (_color.Equals("none"))
        {
            return false;
        }
        if (_color.Equals("white") && !userIsWhite)
        {
            return true;
        }
        if (_color.Equals("black") && userIsWhite)
        {
            return true;
        }
        return false;
    }
    public List<Piece> RemoveCheckMoves(List<Piece> possibleMoves, bool userIsWhite, ChessBoard board)
    {
        /*List<Piece> fixedList = new List<Piece>();
        for (int i = 0; i < possibleMoves.Count; i++)
        {
            ChessBoard futureBoard = board.GetFutureBoard();
            futureBoard.ExecuteMove(userIsWhite, _xPos, _yPos, possibleMoves[i].GetY(), possibleMoves[i].GetX());
            List<Piece> futureCaptures = futureBoard.CheckAllOppositePieces(userIsWhite);
            futureBoard.HighlightValidMoves(futureCaptures);
            
            if (!futureBoard.GetOwnCheckmateStatus(userIsWhite))
            {
                fixedList.Add(possibleMoves[i]);
                // Remove from list.
            }
        }
        return fixedList;
        */

        // Was going to implement this, but i forgot about it. Just ignore it for now.
        return possibleMoves;
    }
    public int GetPoints()
    {
        return _points;
    }
    public void DisplayPiece()
    {
        if (_highlightMode == true)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(_symbol + "  ");
            Console.ResetColor();
        }
        else
        {
            Console.Write(_symbol + "  ");
        }
        
    }
    public void HighlightPiece()
    {
        _highlightMode = true;
    }
    public void DeHighlightPiece()
    {
        _highlightMode = false;
    }
    public bool IsHighlighted()
    {
        return _highlightMode;
    }
    public void ColorDif()
    {
        if (_color.Equals("black"))
        {
            _symbol = _symbol.ToLower();
        }
    }
    public void DidMove(int yPos, int xPos)
    {
        _yPos = yPos;
        _xPos = xPos;
        _hasMoved = true;
    }
    public string GetName()
    {
        return _name;
    }
    public virtual void ResetToNeutral()
    {
        // Does nothing in the piece class
    }
    public virtual bool GetEnPassantStatus()
    {
        // Does nothing in the piece class, system doesn't trust me.
        return false;
    }
    public int GetX()
    {
        return _xPos;
    }
    public int GetY()
    {
        return _yPos;
    }
    public bool GetHasMoved()
    {
        return _hasMoved;
    }
    public string GetColor()
    {
        return _color;
    }
    public bool IsEmpty()
    {
        return _name.Equals("blank");
    }
}