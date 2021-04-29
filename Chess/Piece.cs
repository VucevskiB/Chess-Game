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




        public Piece(COLOR color,TYPE type, Point position) {
            this.Position = position;
            this.Color = color;
            this.Type = type;

            generateSprite();
        }
        public void generateSprite() {
            if(Color == COLOR.WHITE) {
                switch (Type) {
                    case TYPE.BISHOP: image = Properties.Resources.b_bishop_png_shadow_128px;break;
                }
            }
        }
        public void draw(Graphics g) {
            g.DrawImage(image, Position.X * Game.IMAGE_SIZE , Position.Y * Game.IMAGE_SIZE, Game.IMAGE_SIZE, Game.IMAGE_SIZE);
        }
        public HashSet<Point> getMoves() {
            HashSet<Point> set = new HashSet<Point>();
            set.Add(new Point(1,0));
            set.Add(new Point(1,1));
            set.Add(new Point(2,1));

            return set;
        }
    }

    public abstract class MoveSet
    {
        public Piece myPiece;
        protected HashSet<Point> set;

        protected Piece[,] getTileMap() {
            return null;
            //return myPiece.Board.getTileMap();
        }

        public MoveSet() { set = new HashSet<Point>(); }

        public abstract HashSet<Point> GenerateMoveSet(Point position);


        protected bool isOutOfBoundsCheck(Point vec) {
            if (vec.X < 0 || vec.X >= getTileMap().GetLength(1)) return true;
            if (vec.Y < 0 || vec.Y >= getTileMap().GetLength(0)) return true;
            if (getTileMap()[vec.Y, vec.X] != null && myPiece.Color == getTileMap()[vec.Y, vec.X].Color) return true;


            return false;
        }
        protected bool enemyCheck(Point v) {
            Piece tile = getTileMap()[v.Y, v.X];
            if (tile != null && tile.Type != Piece.TYPE.NONE) return true;

            return false;
        }
    }
}
