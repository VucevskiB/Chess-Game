using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Board
    {

        public Piece[,] TileMap { get; set; }
        public string FEN { get; set; }
        public bool whitesTurn { get; set; }

        public List<Piece> whitePieces { get; set; }
        public List<Piece> blackPieces { get; set; }

        public double Evaluation { get; set; }
        public bool isOriginal { get; set; }

        public int PieceCount { get; set; }


        public Board() : this("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1") {

        }
        //Main Constructor
        public Board(string starterFEN) {
            isOriginal = true;
            this.FEN = starterFEN;
            whitePieces = new List<Piece>();
            blackPieces = new List<Piece>();

            string[] parts = starterFEN.Split(' ');
            TileMap = fenToMap(parts[0]);

            if (parts[1].Equals("w"))
                whitesTurn = true;


            Evaluation = getEvaluation();

        }
        //Copy Constructor
        public Board(Board b) {
            this.FEN = b.FEN;
            whitePieces = new List<Piece>();
            blackPieces = new List<Piece>();
            TileMap = copyBoard(b.TileMap);

            whitesTurn = b.whitesTurn;

            Evaluation = getEvaluation();
            isOriginal = false;
        }

        public void makeMove(Point from, Point to) {
            Piece endPiece = TileMap[to.Y, to.X];
            Piece startPiece = TileMap[from.Y, from.X];

            if (endPiece != null) {
                if (endPiece.Color == Piece.COLOR.WHITE)
                    whitePieces.Remove(endPiece);
                else
                    blackPieces.Remove(endPiece);
            }
            else {
            }

            TileMap[to.Y, to.X] = startPiece;
            TileMap[to.Y, to.X].Position = to;
            TileMap[from.Y, from.X] = null;

            Evaluation = getEvaluation();
            whitesTurn = !whitesTurn;
        }

        private Piece[,] copyBoard(Piece[,] e) {
            Piece[,] entityMap = new Piece[e.GetLength(0), e.GetLength(0)];

            for (var y = 0; y < e.GetLength(0); y++) {
                for (var x = 0; x < e.GetLength(0); x++) {
                    Piece old = e[y, x];
                    Piece newPiece;
                    if (old == null) {
                        newPiece = null;
                        entityMap[y, x] = newPiece;
                        continue;
                    }
                    else {
                        newPiece = new Piece(old.Color, old.Type, new Point(x, y));
                        newPiece.Board = this;
                    }



                    entityMap[y, x] = newPiece;

                    if (newPiece.Color == Piece.COLOR.WHITE)
                        whitePieces.Add(newPiece);
                    else
                        blackPieces.Add(newPiece);
                }
            }

            return entityMap;

        }
        public bool hasWhiteKing() {
            foreach (var e in whitePieces) {
                if (e.Type == Piece.TYPE.KING)
                    return true;
            }
            return false;
        }
        public bool hasBlackKing() {
            foreach (var e in blackPieces) {
                if (e.Type == Piece.TYPE.KING)
                    return true;
            }
            return false;
        }

        private Piece[,] fenToMap(string fen) {
            string[] pieces = fen.Split('/');

            Piece[,] entityMap = new Piece[pieces.Length, pieces.Length];

            int y = 0;
            foreach (string s in pieces) {
                char[] piece = s.ToCharArray();
                int x = 0;
                for (int i = 0; i < piece.Length; i++, x++) {
                    bool isNum = int.TryParse(piece[i].ToString(), out _);
                    if (isNum) {
                        x += int.Parse(piece[i].ToString()) - 1;
                        continue;
                    }
                    Piece newPiece = charToEntity(piece[i], y, x);

                    entityMap[y, x] = newPiece;

                    if (newPiece.Color == Piece.COLOR.WHITE)
                        whitePieces.Add(newPiece);
                    else
                        blackPieces.Add(newPiece);
                }
                y++;
            }

            return entityMap;
        }
        public double getEvaluation() {
            int pieceCount = 0;
            double eval = 0;
            foreach (Piece entity in whitePieces) {
                eval += entity.Price;
                pieceCount += (int)entity.Price;
                eval += entity.PositionPrice;
            }
            foreach (Piece entity in blackPieces) {
                eval -= entity.Price;
                pieceCount -= (int)entity.Price;
                eval += entity.PositionPrice;
            }
            PieceCount = pieceCount;
            return eval;

        }
        private Piece charToEntity(char c, int y, int x) {
            Piece newEntity = null;
            switch (c) {
                case 'p':
                    newEntity = new Piece(Piece.COLOR.BLACK, Piece.TYPE.PAWN, new Point(x, y),this);
                    break;
                case 'n':
                    newEntity = new Piece(Piece.COLOR.BLACK, Piece.TYPE.KNIGHT, new Point(x, y),this);
                    break;
                case 'b':
                    newEntity = new Piece(Piece.COLOR.BLACK, Piece.TYPE.BISHOP, new Point(x, y),this);
                    break;
                case 'r':
                    newEntity = new Piece(Piece.COLOR.BLACK, Piece.TYPE.ROOK, new Point(x, y),this);
                    break;
                case 'q':
                    newEntity = new Piece(Piece.COLOR.BLACK, Piece.TYPE.QUEEN, new Point(x, y),this);
                    break;
                case 'k':
                    newEntity = new Piece( Piece.COLOR.BLACK, Piece.TYPE.KING, new Point(x, y),this);
                    break;
                case 'P':
                    newEntity = new Piece( Piece.COLOR.WHITE, Piece.TYPE.PAWN, new Point(x, y),this);
                    break;
                case 'N':
                    newEntity = new Piece( Piece.COLOR.WHITE, Piece.TYPE.KNIGHT, new Point(x, y),this);
                    break;
                case 'B':
                    newEntity = new Piece( Piece.COLOR.WHITE, Piece.TYPE.BISHOP, new Point(x, y),this);
                    break;
                case 'R':
                    newEntity = new Piece( Piece.COLOR.WHITE,Piece.TYPE.ROOK, new Point(x, y),this);
                    break;
                case 'Q':
                    newEntity = new Piece( Piece.COLOR.WHITE, Piece.TYPE.QUEEN, new Point(x, y),this);
                    break;
                case 'K':
                    newEntity = new Piece( Piece.COLOR.WHITE, Piece.TYPE.KING, new Point(x, y),this);
                    break;
            }
            if (newEntity != null)
                newEntity.Board = this;

            return newEntity;
        }
    }

}
