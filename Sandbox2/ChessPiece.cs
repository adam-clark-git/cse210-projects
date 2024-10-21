using System;

class ChessPiece()
{
// attributes
/*
We want a way to know where a piece is
We want to know what a piece is
We want to know where that piece can move
*/
    private string _PieceType;
    public class ChessPiece()
    {
        _PieceType = " * ";
    }
    public class ChessPiece(string pieceType)
    {
        _PieceType = pieceType;
    }

    public string getPieceType()
    {
        return _PieceType;
    }



}