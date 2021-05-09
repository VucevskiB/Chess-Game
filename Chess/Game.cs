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
        public  Piece[,] tileMap { get { return MainBoard.TileMap; } set { MainBoard.TileMap = value; } }
        public HashSet<Point> AvaliblePositions { get; set; }
        public Piece SelectedPiece { get; set; }

        public bool WhitesTurn = true;

        public Board MainBoard { get; set; }

        public ChessAi ChessEnemy { get; set; }
        private Task findMove;



        public Game(Form1 gameForm) {
            GameForm = gameForm;
            MainBoard = new Board();


            AvaliblePositions = new HashSet<Point>();

            ChessEnemy = new ChessAi(this);
        }
        public double getEvaluation() {
            return MainBoard.Evaluation;
        }
        public void onBoardClick(int x, int y) {
            if (findMove != null && findMove.IsCompleted)
                findMove = null;

            if (SelectedPiece == null) {
                selectPiece(x, y);
                return;
            }

            if(checkIfMoveValid(new Point(x, y))) {

                makeMove(SelectedPiece.Position, new Point(x, y));

            }
            SelectedPiece = null;
            AvaliblePositions.Clear();

        }
        public void makeMove(Point from , Point to) {
            MainBoard.makeMove(from, to);
            WhitesTurn = MainBoard.whitesTurn;

            if (WhitesTurn == false && findMove == null) {
                findMove = ChessEnemy.getMove(MainBoard);
            }
            GameForm.GameBox.Invalidate();
        }

        private bool checkIfMoveValid(Point clickPos) {
            return AvaliblePositions.Contains(clickPos);
        }
        private void selectPiece(int x, int y) {
            if (tileMap[y,x] == null) {
                AvaliblePositions.Clear();
                return;
            }
            if((tileMap[y, x].Color == Piece.COLOR.WHITE) != (MainBoard.whitesTurn == true)) {
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
