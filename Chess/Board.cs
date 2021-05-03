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

        float evaluation = 0;
        bool isOriginal;

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


            evaluation = getEvaluation();

        }
        //Copy Constructor
        public Board(Board b) {
            this.starterFEN = b.starterFEN;
            whitePieces = new List<Piece>();
            blackPieces = new List<Piece>();
            TileMap = copyBoard(b.tileMap);

            whitesTurn = b.whitesTurn;

            evaluation = getEvaluation();
            isOriginal = false;
        }

        private Piece[,] fenToMap(string fen) {
            string[] pieces = fen.Split('/');

            Piece[,] entityMap = new Piece[pieces.Length, pieces.Length];

            int y = pieces.Length - 1;
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
                y--;
            }

            return entityMap;
        }
        private Piece charToEntity(char c, int y, int x) {
            Piece newEntity = null;
            switch (c) {
                case 'p':
                    newEntity = new Piece(Piece.COLOR.BLACK, Piece.TYPE.PAWN, new Point(x, y));
                    break;
                case 'n':
                    newEntity = new Piece(Piece.COLOR.BLACK, Piece.TYPE.KNIGHT, new Point(x, y));
                    break;
                case 'b':
                    newEntity = new Piece(Piece.COLOR.BLACK, Piece.TYPE.BISHOP, new Point(x, y));
                    break;
                case 'r':
                    newEntity = new Piece(Piece.COLOR.BLACK, Piece.TYPE.ROOK, new Point(x, y));
                    break;
                case 'q':
                    newEntity = new Piece(Piece.COLOR.BLACK, Piece.TYPE.QUEEN, new Point(x, y));
                    break;
                case 'k':
                    newEntity = new Piece( Piece.COLOR.BLACK, Piece.TYPE.KING, new Point(x, y));
                    break;
                case 'P':
                    newEntity = new Piece( Piece.COLOR.WHITE, Piece.TYPE.PAWN, new Point(x, y));
                    break;
                case 'N':
                    newEntity = new Piece( Piece.COLOR.WHITE, Piece.TYPE.KNIGHT, new Point(x, y));
                    break;
                case 'B':
                    newEntity = new Piece( Piece.COLOR.WHITE, Piece.TYPE.BISHOP, new Point(x, y));
                    break;
                case 'R':
                    newEntity = new Piece( Piece.COLOR.WHITE,Piece.TYPE.ROOK, new Point(x, y));
                    break;
                case 'Q':
                    newEntity = new Piece( Piece.COLOR.WHITE, Piece.TYPE.QUEEN, new Point(x, y));
                    break;
                case 'K':
                    newEntity = new Piece( Piece.COLOR.WHITE, Piece.TYPE.KING, new Point(x, y));
                    break;
            }
            if (newEntity != null)
                newEntity.Board = this;

            return newEntity;
        }
    }

}
