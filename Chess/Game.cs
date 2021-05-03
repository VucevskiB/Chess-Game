using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{

    public class Game
    {
        public const int IMAGE_SIZE = 64;
        Form1 GameForm;
        public  Piece[,] tileMap { get; set; }
        public HashSet<Point> AvaliblePositions { get; set; }
        public Piece SelectedPiece { get; set; }

        public bool WhitesTurn;


        public Game(Form1 gameForm) {
            GameForm = gameForm;
            tileMap = new Piece[8, 8];
            //tileMap[0, 0] = new Piece(Properties.Resources.b_bishop_png_shadow_128px,new Point(0,0));
            tileMap[6, 6] = new Piece(Piece.COLOR.WHITE,Piece.TYPE.PAWN,new Point(6,6));
            tileMap[6, 6].Board = this;

            tileMap[5, 7] = new Piece(Piece.COLOR.BLACK,Piece.TYPE.KNIGHT,new Point(7,5));
            tileMap[5, 7].Board = this;

            AvaliblePositions = new HashSet<Point>();
        }
        public void onBoardClick(int x, int y) {
            if (SelectedPiece == null) {
                selectPiece(x, y);
                return;
            }

            if(checkIfMoveValid(new Point(x, y))) {
                Piece copy = SelectedPiece;
                tileMap[copy.Position.Y, copy.Position.X] = null;
                tileMap[y, x] = copy;
                tileMap[y, x].Position = new Point(x, y);




            }
            SelectedPiece = null;
            AvaliblePositions.Clear();

        }
        private bool checkIfMoveValid(Point clickPos) {
            return AvaliblePositions.Contains(clickPos);
        }
        private void selectPiece(int x, int y) {
            if (tileMap[y,x] == null) {
                AvaliblePositions.Clear();
                return;
            }
            SelectedPiece = tileMap[y, x];
            drawSuggestion();
        }
        private void drawSuggestion() {
            AvaliblePositions.Clear();

            AvaliblePositions = SelectedPiece.getMoves();

        }

        public void loadBlank(Graphics g) {
            for (int y = 0; y < 8; y++) {
                for (int x = 0; x < 8; x++) {
                    Bitmap image = ((y + x) % 2) == 0 ? Properties.Resources.square_brown_light_png_shadow_128px : Properties.Resources.square_brown_dark_png_shadow_128px;
          
                    g.DrawImage(image, x * IMAGE_SIZE, y * IMAGE_SIZE, IMAGE_SIZE, IMAGE_SIZE);
                    image.Dispose();
                }
            }
        }
        public void draw(Graphics g) {
            //draw checkerd board
            loadBlank(g);
            //draw selected square
            if(SelectedPiece != null) {
                Rectangle rect = new Rectangle(new Point(SelectedPiece.Position.X * IMAGE_SIZE, SelectedPiece.Position.Y * IMAGE_SIZE), new Size(64, 64));
                g.FillRectangle(new SolidBrush(Color.FromArgb(148, 123, 50, 100)),rect);
            }
            //draw avalible moves
            foreach (Point point in AvaliblePositions) {
                g.FillEllipse(new SolidBrush(Color.FromArgb(148, 123, 50)), new Rectangle(point.X * IMAGE_SIZE + 20, point.Y * IMAGE_SIZE + 20, 24, 24));
            }

            //draw pieces
            foreach (Piece piece in tileMap) {
                if (piece == null) continue;

                piece.draw(g);
                //piece.Position = new Point(piece.Position.X, piece.Position.Y);
            }
            



        }

    }
}
