using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Chess!");
        Console.WriteLine("Type 'commands' to see a list of commands");
        Console.WriteLine("Would you like to play against an AI or a human player?");
        Console.WriteLine("AI currently does not function");
        String userChoice = Console.ReadLine();
        if (userChoice.Equals("AI"))
        {
            AIMenu();
        }
        else
        {
            Menu();
        }
    }
    static void AIMenu()
    {
        ChessBoard chessBoard = new ChessBoard();
        bool userIsWhite = true;
        for (int i = 0; i < 5000; i++)
        {
            if (userIsWhite)
            {
                Console.WriteLine("It is white's turn");
                while (true)
                {
                    chessBoard.DisplayBoard();
                    List<Piece> allMoves = chessBoard.GetAllValidSameMoves(userIsWhite);
                    ChessBoard futureBoard = chessBoard.GetFutureBoard();
                    List<Piece> futureCaptures = futureBoard.CheckAllOppositePieces(userIsWhite);
                    futureBoard.HighlightValidMoves(futureCaptures);
                    if (allMoves.Count == 0 && futureBoard.GetOwnCheckStatus(userIsWhite))
                    {
                        Console.WriteLine("GAME OVER");
                        if (userIsWhite)
                        {
                            Console.WriteLine("WHITE LOSES");
                        }
                        else
                        {
                            Console.WriteLine("BLACK LOSES");
                        }
                        return;
                    }
                    else if (allMoves.Count == 0)
                    {
                        Console.WriteLine("GAME OVER");
                        Console.WriteLine("Stalemate.");
                        return;
                    }
                    else if (futureBoard.GetOwnCheckStatus(userIsWhite))
                    {
                        Console.WriteLine("Careful! You are in check.");
                    }
                    Console.WriteLine("What piece would you like to move?");
                    string playerMove = Console.ReadLine();
                    int yPlayerMove = 1;
                    int xPlayerMove = 1;
                    if (playerMove.Equals("points"))
                    {
                        Console.WriteLine("White has " +chessBoard._whitePoints + " points");
                        Console.WriteLine("Black has " +chessBoard._blackPoints + " points");
                        continue;
                    }
                    else if (playerMove.Equals("quit"))
                    {
                        return;
                    }
                    else if (playerMove.Equals("commands"))
                    {
                        Console.WriteLine("To move a piece, select a piece you want to move, then move to a highlighted square.");
                        Thread.Sleep(2000);
                        Console.WriteLine("Pieces are selected from the x axis first, then the y axis.");
                        Thread.Sleep(2000);
                        Console.WriteLine("Castling and En Passant are special");
                        Thread.Sleep(2000);
                        Console.WriteLine("quit and points are also commands");
                        Thread.Sleep(2000);
                    }
                    if (playerMove.Split(" ").Length < 2)
                    {
                        continue;
                    }
                    if (!int.TryParse(playerMove.Split(" ")[1], out yPlayerMove) || !int.TryParse(playerMove.Split(" ")[0], out xPlayerMove))
                    {
                        continue;
                    }
                    

                    if (chessBoard.RunBoard(yPlayerMove-1, xPlayerMove-1, userIsWhite))
                    {
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("It is AI's turn");
                List<Piece> allMoves = chessBoard.GetAllValidSameMoves(userIsWhite);
                ChessBoard futureBoard = chessBoard.GetFutureBoard();
                List<Piece> futureCaptures = futureBoard.CheckAllOppositePieces(userIsWhite);
                futureBoard.HighlightValidMoves(futureCaptures);
                if (allMoves.Count == 0 && futureBoard.GetOwnCheckStatus(userIsWhite))
                {
                    Console.WriteLine("GAME OVER");
                    if (userIsWhite)
                    {
                        Console.WriteLine("WHITE LOSES");
                    }
                    else
                    {
                        Console.WriteLine("BLACK LOSES");
                    }
                    return;
                }
                else if (allMoves.Count == 0)
                {
                    Console.WriteLine("GAME OVER");
                    Console.WriteLine("Stalemate.");
                    return;
                }
            }
            userIsWhite = !userIsWhite;
        }
    }
    static void Menu()
    {
        ChessBoard chessBoard = new ChessBoard();
        bool userIsWhite = true;
        for (int i = 0; i < 5000; i++)
        {
            if (userIsWhite)
            {
                Console.WriteLine("It is white's turn");
            }
            else
            {
                Console.WriteLine("It is black's turn");
            }
            while (true)
            {
                chessBoard.DisplayBoard();
                List<Piece> allMoves = chessBoard.GetAllValidSameMoves(userIsWhite);
                ChessBoard futureBoard = chessBoard.GetFutureBoard();
                List<Piece> futureCaptures = futureBoard.CheckAllOppositePieces(userIsWhite);
                futureBoard.HighlightValidMoves(futureCaptures);
                if (allMoves.Count == 0 && futureBoard.GetOwnCheckStatus(userIsWhite))
                {
                    Console.WriteLine("GAME OVER");
                    if (userIsWhite)
                    {
                        Console.WriteLine("WHITE LOSES");
                    }
                    else
                    {
                        Console.WriteLine("BLACK LOSES");
                    }
                    return;
                }
                else if (allMoves.Count == 0)
                {
                    Console.WriteLine("GAME OVER");
                    Console.WriteLine("Stalemate.");
                    return;
                }
                else if (futureBoard.GetOwnCheckStatus(userIsWhite))
                {
                    Console.WriteLine("Careful! You are in check.");
                }
                Console.WriteLine("What piece would you like to move?");
                string playerMove = Console.ReadLine();
                playerMove = playerMove.ToLower();
                int yPlayerMove = 1;
                int xPlayerMove = 1;
                if (playerMove.Equals("points"))
                {
                    Console.WriteLine("White has " +chessBoard._whitePoints + " points");
                    Console.WriteLine("Black has " +chessBoard._blackPoints + " points");
                    continue;
                }
                else if (playerMove.Equals("quit"))
                {
                    return;
                }
                else if (playerMove.Equals("commands"))
                {
                    Console.WriteLine("To move a piece, select a piece you want to move, then move to a highlighted square.");
                    Thread.Sleep(2000);
                    Console.WriteLine("Pieces are selected from the x axis first, then the y axis.");
                    Thread.Sleep(2000);
                    Console.WriteLine("Castling, En Passant and Promoting are all included.");
                    Thread.Sleep(2000);
                    Console.WriteLine("Quit and Points are also commands");
                    Thread.Sleep(2000);
                }
                if (playerMove.Split(" ").Length < 2)
                {
                    continue;
                }
                if (!int.TryParse(playerMove.Split(" ")[1], out yPlayerMove) || !int.TryParse(playerMove.Split(" ")[0], out xPlayerMove))
                {
                    continue;
                }
                

                if (chessBoard.RunBoard(yPlayerMove-1, xPlayerMove-1, userIsWhite))
                {
                    break;
                }
            }


            userIsWhite = !userIsWhite;
        }
        
    }
}