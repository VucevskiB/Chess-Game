using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Piece {
      public enum COLOR
        {
            WHITE,
            BLACK,
        };

        public enum TYPE
        {
            NONE,
            PAWN,
            KNIGHT,
            BISHOP,
            ROOK,
            QUEEN,
            KING
        }

        public COLOR Color { get; set; }
        public TYPE Type { get; set; }
        Bitmap image;
        private Point position;
        public Point Position { 
            get { return position; } 
            set {
                position = value;
                //Price = intitalPrice + POSITION_EVAL[position.Y,position.X];
            } 
        }

        MoveSet moveSet;

        public Board Board { get; set; }

        public double Price { get; set; }
        public double PositionPrice { get { return POSITION_EVAL[position.Y, position.X]; } }

        double[,] POSITION_EVAL;




        public Piece(COLOR color,TYPE type, Point position,Board board = null) {
            this.Color = color;
            this.Type = type;
            this.Board = board;

            POSITION_EVAL = getPriceBoard();

            if (Board != null)
                generateSprite();

            this.Position = position;
            

            moveSet = setMoveSet();
            moveSet.MyPiece = this;

            
        }
        public double[,] getPriceBoard() {
            if (Color == COLOR.WHITE) {
                switch (Type) {
                    case TYPE.PAWN:
                        return PositionEval.pawnEvalWhite;
                    case TYPE.KNIGHT: 
                        return PositionEval.knightEval;
                    case TYPE.BISHOP:
                        return PositionEval.bishopEvalWhite; 
                    case TYPE.ROOK: 
                        return PositionEval.rookEvalWhite; 
                    case TYPE.QUEEN: 
                        return PositionEval.evalQueen; 
                    case TYPE.KING: 
                        return PositionEval.kingEvalWhite; 
                }
            }
            else {
                switch (Type) {
                    case TYPE.PAWN:
                        return PositionEval.pawnEvalBlack();
                    case TYPE.KNIGHT:
                        return PositionEval.knightEval;
                    case TYPE.BISHOP:
                        return PositionEval.bishopEvalBlack();
                    case TYPE.ROOK:
                        return PositionEval.rookEvalBlack();
                    case TYPE.QUEEN:
                        return PositionEval.evalQueen;
                    case TYPE.KING:
                        return PositionEval.kingEvalBlack();
                }
            }
            return null;
        }
        public void generateSprite() {
            if(Color == COLOR.WHITE) {
                switch (Type) {
                    case TYPE.PAWN: image = Properties.Resources.w_pawn_png_shadow_128px;
                        POSITION_EVAL = PositionEval.pawnEvalWhite; break;
                    case TYPE.KNIGHT: image = Properties.Resources.w_knight_png_shadow_128px; POSITION_EVAL = PositionEval.knightEval; break;
                    case TYPE.BISHOP: image = Properties.Resources.w_bishop_png_shadow_128px; POSITION_EVAL = PositionEval.bishopEvalWhite; break;
                    case TYPE.ROOK: image = Properties.Resources.w_rook_png_shadow_128px; POSITION_EVAL = PositionEval.rookEvalWhite; break;
                    case TYPE.QUEEN: image = Properties.Resources.w_queen_png_shadow_128px; POSITION_EVAL = PositionEval.evalQueen; break;
                    case TYPE.KING: image = Properties.Resources.w_king_png_shadow_128px; POSITION_EVAL = PositionEval.kingEvalWhite; break;
                }
            }
            else {
                switch (Type) {
                    case TYPE.PAWN: image = Properties.Resources.b_pawn_png_shadow_128px; POSITION_EVAL = PositionEval.pawnEvalBlack(); break;
                    case TYPE.KNIGHT: image = Properties.Resources.b_knight_png_shadow_128px; POSITION_EVAL = PositionEval.knightEval; break;
                    case TYPE.BISHOP: image = Properties.Resources.b_bishop_png_shadow_128px; POSITION_EVAL = PositionEval.bishopEvalBlack(); break;
                    case TYPE.ROOK: image = Properties.Resources.b_rook_png_shadow_128px; POSITION_EVAL = PositionEval.rookEvalBlack(); break;
                    case TYPE.QUEEN: image = Properties.Resources.b_queen_png_shadow_128px; POSITION_EVAL = PositionEval.evalQueen; break;
                    case TYPE.KING: image = Properties.Resources.b_king_png_shadow_128px; POSITION_EVAL = PositionEval.kingEvalBlack(); break;
                }
            }
        }
        private MoveSet setMoveSet() {
            switch (Type) {
                case TYPE.PAWN: Price = 10; return new PawnMoveSet(); 
                case TYPE.BISHOP: Price = 30; return new BishopMoveSet(); 
                case TYPE.KNIGHT: Price = 30; return new KnightMoveSet();
                case TYPE.ROOK: Price = 50; return new RookMoveSet();
                case TYPE.QUEEN: Price = 90; return new QueenMoveSet(); 
                case TYPE.KING: Price = 900; return new KingMoveSet();
            }
            return null;
        }
        public void draw(Graphics g) {
            int i = 0;
            if (this.Type == TYPE.PAWN)
                i = 5;
            g.DrawImage(image, Position.X * Game.IMAGE_SIZE + i, Position.Y * Game.IMAGE_SIZE, image.Width/2, image.Height/2);
        }
        public HashSet<Point> getMoves() {

            return moveSet.GenerateMoveSet(Position);
        }
    }

    
}
