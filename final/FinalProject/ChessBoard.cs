

using System.Data;
using System.Drawing;
using System.Reflection.Metadata.Ecma335;
using System.Xml;
using System.Xml.Schema;

class ChessBoard
{
    public List<List<Piece>> _board = new List<List<Piece>>();
    public int _whitePoints = 0;
    public int _blackPoints = 0;
    public ChessBoard()
    {
        StartNewBoard();
    }
    public ChessBoard( List<List<Piece>> board)
    {
        _board =  new List<List<Piece>>(board);
    }
    public void StartNewBoard()
    {
        for (int y = 0; y < 8; y++)
        {
            List<Piece> tempList = new List<Piece>();
            for (int x = 0; x < 8; x++)
            {
                tempList.Add(new Piece(y,x));
            }
            _board.Add(tempList);
        }
        bool hasNotMoved = false;
        _board[0][0] = new Rook(0, 0, "white", hasNotMoved);
        _board[0][1] = new Knight(0, 1, "white", hasNotMoved);
        _board[0][2] = new Bishop(0, 2, "white", hasNotMoved);
        _board[0][3] = new King(0,3, "white", hasNotMoved);
        _board[0][4] = new Queen(0, 4, "white", hasNotMoved);
        _board[0][5] = new Bishop(0,5, "white", hasNotMoved);
        _board[0][6] = new Knight(0, 6, "white", hasNotMoved);
        _board[0][7] = new Rook(0,7, "white", hasNotMoved);
        for (int x = 0; x < 8; x++)
        {
            _board[1][x] = new Pawn(1, x, "white", hasNotMoved, false);
        }
        for (int x = 0; x < 8; x++)
        {
            _board[6][x] = new Pawn(6, x, "black", hasNotMoved, false);
        }
        _board[7][0] = new Rook(7, 0, "black", hasNotMoved);
        _board[7][1] = new Knight(7, 1, "black", hasNotMoved);
        _board[7][2] = new Bishop(7, 2, "black", hasNotMoved);
        _board[7][3] = new King(7,3, "black", hasNotMoved);
        _board[7][4] = new Queen(7, 4, "black", hasNotMoved);
        _board[7][5] = new Bishop(7,5, "black", hasNotMoved);
        _board[7][6] = new Knight(7, 6, "black", hasNotMoved);
        _board[7][7] = new Rook(7,7, "black", hasNotMoved);
        
    }


    public void DisplayBoard()
    {
        if (_blackPoints == 2)
        {
            Console.WriteLine("ShadowZone");
        }
        Console.WriteLine("   1  2  3  4  5  6  7  8");
        for (int y = 0; y < 8; y++)
        {
            DisplayLine(y);
        }
    }
    public void DisplayLine(int row)
    {
        Console.Write((row + 1) + "  ");
        foreach (Piece piece in _board[row])
        {
            piece.DisplayPiece();
        }
        Console.WriteLine("");
    }











    public bool RunBoard(int yPick, int xPick, bool userIsWhite)
    {
        RemoveEnPassant(userIsWhite);
        if (InitialMoveInvalid(yPick, xPick, userIsWhite))
        {
            Console.WriteLine("You don't control this Piece! Pick a different move");
            return false;
        }
        List<Piece> fixedValidMoves = GetValidMoves(userIsWhite, yPick, xPick);
        int moveCount = HighlightValidMoves(fixedValidMoves);
        if (moveCount == 0)
        {
            Console.WriteLine("There are no possible moves");
            return false;
        }

        int yPlayerMove = 0;
        int xPlayerMove = 0;
        for (bool moveDoesWork = true; moveDoesWork; moveDoesWork = !moveDoesWork)
        {
            List<int> moveCords = SecondUserSelection(moveCount);
            // This means the user inputed a string or only one number
            if (moveCords[0] == -10)
            {
                return false;
            }
            yPlayerMove = moveCords[0];
            xPlayerMove = moveCords[1];
            if (!_board[yPlayerMove][xPlayerMove].IsHighlighted())
            {
                Console.WriteLine("Nope, that didn't work. Now your turn is skipped.");
                moveDoesWork = false;
                continue;
            }
            // Check if move causes your own colors king to come into check
            
        }
        ExecuteMove(userIsWhite, yPick, xPick, yPlayerMove, xPlayerMove);
        PromotePawns(userIsWhite);
        return true;
    }



    public void ExecuteMove(bool userIsWhite, int yPick, int xPick, int yPlayerMove, int xPlayerMove)
    {
        if (_board[yPick][xPick].GetName() == "pawn" && _board[yPlayerMove][xPlayerMove].GetEnPassantStatus())
        {
            ExecuteEnPassant(userIsWhite, yPick, xPick, yPlayerMove, xPlayerMove);
            return;
        }
        if (_board[yPick][xPick].GetName() == "king" && Math.Abs(xPlayerMove-xPick) > 1)
        {
            ExecuteCastling(userIsWhite, yPick, xPick, yPlayerMove, xPlayerMove);
            return;
        }
        if (userIsWhite)
        {
            _whitePoints = _board[yPlayerMove][xPlayerMove].GetPoints();
        }
        else 
        {
            _blackPoints = _board[yPlayerMove][xPlayerMove].GetPoints();
        }
        _board[yPlayerMove][xPlayerMove] = _board[yPick][xPick];
        _board[yPlayerMove][xPlayerMove].DidMove(yPlayerMove, xPlayerMove);
        _board[yPick][xPick] = new Piece(yPick, xPick);
        DeHighlightBoard();
    }
    public void ExecuteEnPassant(bool userIsWhite, int yPick, int xPick, int yPlayerMove, int xPlayerMove)
    {
        if (userIsWhite)
        {
            _whitePoints = _board[yPlayerMove][xPlayerMove].GetPoints();
        }
        else 
        {
            _blackPoints = _board[yPlayerMove][xPlayerMove].GetPoints();
        }
        _board[yPlayerMove + 1][xPlayerMove] = _board[yPick][xPick];
        _board[yPlayerMove + 1][xPlayerMove].DidMove(yPlayerMove,xPlayerMove);
        _board[yPick][xPick] = new Piece(yPick, xPick);
        _board[yPlayerMove][xPlayerMove] = new Piece(yPlayerMove, xPlayerMove);
        DeHighlightBoard();
    }
    public void ExecuteCastling(bool userIsWhite, int yPick, int xPick, int yPlayerMove, int xPlayerMove)
    {
        if (xPlayerMove < xPick)
        {
            _board[yPlayerMove][1] = _board[yPick][xPick];
            _board[yPlayerMove][1].DidMove(yPlayerMove,xPlayerMove);
            _board[yPlayerMove][2] = _board[yPlayerMove][0];
            _board[yPlayerMove][2].DidMove(yPlayerMove,2);
            _board[yPick][xPick] = new Piece(yPick, xPick);
            _board[yPlayerMove][0] = new Piece(yPick, 0);
        }
        else
        {
            _board[yPlayerMove][xPlayerMove] = _board[yPick][xPick];
            _board[yPlayerMove][xPlayerMove].DidMove(yPlayerMove,xPlayerMove);
            _board[yPlayerMove][4] = _board[yPlayerMove][7];
            _board[yPlayerMove][4].DidMove(yPlayerMove,4);
            _board[yPick][xPick] = new Piece(yPick, xPick);
            _board[yPlayerMove][7] = new Piece(yPick, 7);
        }
        DeHighlightBoard();
    }


    public void PromotePawns(bool userIsWhite)
    {
        int row = 0;
        string color = "black";
        if (userIsWhite)
        {
            row = 7;
            color = "white";
        }
        for (int x = 0; x < 8; x++)
        {
            if (_board[row][x].GetName().Equals("pawn"))
            {
                Console.WriteLine("What would you like to promote to? Type the name of the piece you wish to promote to.");
                String userChoice = Console.ReadLine();
                userChoice = userChoice.ToLower();
                if (userChoice.Equals("bishop"))
                {
                    _board[row][x] = new Bishop(row, x, color, true);
                }
                else if (userChoice.Equals("rook"))
                {
                    _board[row][x] = new Rook(row, x, color, true);
                }
                else if (userChoice.Equals("knight"))
                {
                    _board[row][x] = new Knight(row, x, color, true);
                }
                else
                {
                    _board[row][x] = new Queen(row, x, color, true);
                }
            }
        }
    }
    
    public bool CheckSingleMove(int yPick, int xPick, bool userIsWhite)
    {
        // Users will input a possible move for that piece
        if (xPick < 0 || xPick > 7)
        {
            return false;
        }
        if (yPick < 0 || yPick > 7)
        {
            return false;
        }
        if (_board[yPick][xPick].IsSameColor(userIsWhite))
        {
            return false;
        }
        // Also include return false if move leads to your own checkmate
        // Current problem. Pieces should not be able to move past pieces that are behind pieces that are inaccesible
        // Solution: have each piece check each location one by one, and not iterate further in that direction if return false;
        // Current problem. Users can input false moves that allow the user to cheat.
        // Solution: Only allow users to access moves declared as possible.

        return true;
    }
    public bool CheckPawnCapture(int yPick, int xPick, bool userIsWhite)
    {
        if (xPick < 0 || xPick > 7)
        {
            return false;
        }
        if (yPick < 0 || yPick > 7)
        {
            return false;
        }
        if (_board[yPick][xPick].IsSameColor(userIsWhite))
        {
            return false;
        }
        if (!_board[yPick][xPick].IsOppositeColor(userIsWhite))
        {
            return false;
        }
        return true;
    }
    public bool CheckPawnMove(int yPick, int xPick, bool userIsWhite)
    {
        if (xPick < 0 || xPick > 7)
        {
            return false;
        }
        if (yPick < 0 || yPick > 7)
        {
            return false;
        }
        if (_board[yPick][xPick].GetName() == "blank")
        {
            return true;
        }
        return false;
    }
    
    
    public bool GetOwnCheckStatus(bool userIsWhite)
    {
        for (int y = 0; y < 8; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                if (_board[y][x].GetName().Equals("king") && _board[y][x].IsSameColor(userIsWhite) && _board[y][x].IsHighlighted())
                {
                    return true;
                }
            }
        }
        return false;
    }
    public List<Piece> CheckAllOppositePieces(bool userIsWhite)
    {
        List<Piece> allPieces = new List<Piece>();
        for (int y = 0; y < 8; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                if (_board[y][x].IsOppositeColor(userIsWhite))
                {
                    List<Piece> tempList = new List<Piece>();
                    tempList.AddRange(_board[y][x].CheckMovement(this, !userIsWhite));
                    allPieces.AddRange(tempList);
                }
                
            }
        }
        return allPieces;
    }


    public List<Piece> GetAllValidSameMoves(bool userIsWhite)
    {
        List<Piece> allPieces = new List<Piece>();
        for (int y = 0; y < 8; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                if (_board[y][x].IsSameColor(userIsWhite))
                {
                    List<Piece> fixedValidMoves = GetValidMoves(userIsWhite, y, x);
                    allPieces.AddRange(fixedValidMoves);
                }
                
            }
        }
        return allPieces;
    }
    public List<Piece> GetValidMoves(bool userIsWhite, int yPick, int xPick)
    {
        List<Piece> validMoves = _board[yPick][xPick].CheckMovement(this, userIsWhite);
        List<Piece> fixedValidMoves = new List<Piece>();
        for (int i = 0; i < validMoves.Count; i++)
        {
            ChessBoard futureBoard = GetFutureBoard();
            futureBoard.ExecuteMove(userIsWhite,  yPick, xPick, validMoves[i].GetY(), validMoves[i].GetX());
            List<Piece> futureCaptures = futureBoard.CheckAllOppositePieces(userIsWhite);
            futureBoard.HighlightValidMoves(futureCaptures);
            if (!futureBoard.GetOwnCheckStatus(userIsWhite) && !futureBoard.GetCastleCheckStatus(this,userIsWhite))
            {
                fixedValidMoves.Add(validMoves[i]);
            }
            
        }
        return fixedValidMoves;
    }

    
    public ChessBoard GetFutureBoard()
    {
        List<List<Piece>> newBoard = new List<List<Piece>>();
        for (int y = 0; y < 8; y++)
        {
            List<Piece> tempList = new List<Piece>();
            for (int x = 0; x < 8; x++)
            {
                Piece piece = _board[y][x];
                tempList.Add(AddPiece(piece.GetY(), piece.GetX(), piece.GetHasMoved(), piece.GetColor(), piece.GetName(), piece.GetEnPassantStatus()));
            }
            newBoard.Add(tempList);
        }
        ChessBoard futureBoard =  new ChessBoard(newBoard);
        return futureBoard;
    }
    
    
    public List<int> SecondUserSelection(int moveCount)
    {
        List<int> cords = new List<int>();
        DisplayBoard();
        Console.WriteLine("There are " +  moveCount + " possible moves");
        Console.WriteLine("Choose a highlighted square to move to.");
        string playerMove = Console.ReadLine();
        int y = 0;
        int x = 0;
        if (playerMove.Split(" ").Length < 2)
        {
            DeHighlightBoard();
            cords.Add(-10);
            return cords;
        }
        if (!int.TryParse(playerMove.Split(" ")[1], out y) || !int.TryParse(playerMove.Split(" ")[0], out x))
        {
            DeHighlightBoard();
            cords.Add(-10);
            return cords;
        }
        
        cords.Add(y-1);
        cords.Add(x-1);
        return cords;
    }
    public bool GetCastleCheckStatus(ChessBoard pastBoard, bool userIsWhite)
    {
        int row = 7;
        if (userIsWhite)
        {
            row = 0;
        }
        if (pastBoard._board[row][3].GetName().Equals("king"))
        {
            // Long Castle
            if (_board[row][5].GetName().Equals("king"))
            {
                if (_board[row][4].IsHighlighted() || _board[row][3].IsHighlighted())
                {
                    return true;
                }
            }
            // Short Castle
            if (_board[row][1].GetName().Equals("king"))
            {
                if (_board[row][2].IsHighlighted() || _board[row][3].IsHighlighted())
                {
                    return true;
                }
            }
        }
        return false;
    }
    public Piece AddPiece(int yPos, int xPos, bool hasMoved, string color, string name, bool enPassantStatus)
    {
        Piece piece = new Piece(yPos,xPos);
        if (name.Equals("king"))
        {
            piece = new King(yPos, xPos, color, hasMoved);
        }
        else if (name.Equals("queen"))
        {
            piece = new Queen(yPos, xPos, color, hasMoved);
        }
        else if (name.Equals("bishop"))
        {
            piece = new Bishop(yPos, xPos, color, hasMoved);
        }
        else if (name.Equals("knight"))
        {
            piece = new Knight(yPos, xPos, color, hasMoved);
        }
        else if (name.Equals("rook"))
        {
            piece = new Rook(yPos, xPos, color, hasMoved);
        }
        else if (name.Equals("pawn"))
        {
            piece = new Pawn(yPos, xPos, color, hasMoved, enPassantStatus);
        }
        
        return piece;
    }
    public bool InitialMoveInvalid(int yPick, int xPick, bool userIsWhite)
    {
        return !_board[yPick][xPick].IsSameColor(userIsWhite);
    }
    public int HighlightValidMoves(List<Piece> validMoves)
    {

        int moveCount = 0;
        foreach (Piece piece in validMoves)
        {
            piece.HighlightPiece();
            moveCount++;
        }
        return moveCount;
    }
    public void DeHighlightBoard()
    {
        for (int yList = 0; yList < 8; yList++)
        {
            for (int xList = 0; xList < 8; xList++)
            {
                _board[yList][xList].DeHighlightPiece();
            }
        }
    }
    public bool CheckEnPassant(int yPick, int xPick, bool userIsWhite)
    {
        return _board[yPick][xPick].GetEnPassantStatus();
    }
    public void RemoveEnPassant(bool userIsWhite)
    {
        for (int y = 0; y < 8; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                if (_board[y][x].GetName() == "pawn" && _board[y][x].IsSameColor(userIsWhite))
                {
                    _board[y][x].ResetToNeutral();
                }
            }
        }
    }


    // AI ZONE
    public List<Piece> FindPiecesToMove(bool userIsWhite)
    {
        List<Piece> allPieces = new List<Piece>();
        for (int y = 0; y < 8; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                if (_board[y][x].IsSameColor(userIsWhite))
                {
                    allPieces.Add(_board[y][x]);
                }
                
            }
        }
        return allPieces;
    }
    public bool RandAI(bool userIsWhite)
    {
        RemoveEnPassant(userIsWhite);
        List<Piece> yourPieces = FindPiecesToMove(userIsWhite);
        Random randMove = new Random();
        int pickedPiece = (int) randMove.Next(yourPieces.Count());
        Piece aiChoice = yourPieces[pickedPiece];
        List<Piece> fixedValidMoves = GetValidMoves(userIsWhite, aiChoice.GetY(), aiChoice.GetX());
        int moveCount = HighlightValidMoves(fixedValidMoves);
        if (moveCount < 1)
        {
            return false;
        }
        int pickedMove = (int) randMove.Next(fixedValidMoves.Count());
        Piece aiMove = fixedValidMoves[pickedMove];
        ExecuteMove(userIsWhite, aiChoice.GetY(), aiChoice.GetX(), aiMove.GetY(), aiMove.GetX());
        PromotePawns(userIsWhite);
        return true;
    }
}