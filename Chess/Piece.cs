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
        public Point Position { get; set; }

        MoveSet moveSet;

        public Board Board { get; set; }




        public Piece(COLOR color,TYPE type, Point position) {
            this.Position = position;
            this.Color = color;
            this.Type = type;

            generateSprite();

            moveSet = setMoveSet();
            moveSet.MyPiece = this;
        }
        public void generateSprite() {
            if(Color == COLOR.WHITE) {
                switch (Type) {
                    case TYPE.PAWN: image = Properties.Resources.w_pawn_png_shadow_128px;break;
                    case TYPE.KNIGHT: image = Properties.Resources.w_knight_png_shadow_128px;break;
                    case TYPE.BISHOP: image = Properties.Resources.w_bishop_png_shadow_128px;break;
                    case TYPE.ROOK: image = Properties.Resources.w_rook_png_shadow_128px;break;
                    case TYPE.QUEEN: image = Properties.Resources.w_queen_png_shadow_128px;break;
                    case TYPE.KING: image = Properties.Resources.w_king_png_shadow_128px;break;
                }
            }
            else {
                switch (Type) {
                    case TYPE.PAWN: image = Properties.Resources.b_pawn_png_shadow_128px; break;
                    case TYPE.KNIGHT: image = Properties.Resources.b_knight_png_shadow_128px; break;
                    case TYPE.BISHOP: image = Properties.Resources.b_bishop_png_shadow_128px; break;
                    case TYPE.ROOK: image = Properties.Resources.b_rook_png_shadow_128px; break;
                    case TYPE.QUEEN: image = Properties.Resources.b_queen_png_shadow_128px; break;
                    case TYPE.KING: image = Properties.Resources.b_king_png_shadow_128px; break;
                }
            }
        }
        private MoveSet setMoveSet() {
            switch (Type) {
                case TYPE.PAWN: return new PawnMoveSet(); 
                case TYPE.BISHOP: return new BishopMoveSet(); 
                case TYPE.KNIGHT: return new KnightMoveSet();
                case TYPE.ROOK: return new RookMoveSet();
                case TYPE.QUEEN: return new QueenMoveSet(); 
                case TYPE.KING: return new KnightMoveSet();
            }
            return null;
        }
        public void draw(Graphics g) {
            g.DrawImage(image, Position.X * Game.IMAGE_SIZE , Position.Y * Game.IMAGE_SIZE, Game.IMAGE_SIZE, Game.IMAGE_SIZE);
        }
        public HashSet<Point> getMoves() {

            return moveSet.GenerateMoveSet(Position);
        }
    }

    
}
