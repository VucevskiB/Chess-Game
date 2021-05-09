using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class ChessAi
    {
        public Move BestMove;
        public Game game;

        public ChessAi(Game game) {
            this.game = game;
        }

        public Task getMove(Board board) {
            BestMove = null;
            Task task = Task.Factory.StartNew(() => startSearch(3, true, board), TaskCreationOptions.LongRunning);
            return task;

        }
        public Move startSearch(int depth, bool blacksTurn, Board board) {
            Piece[] Piecearray;
            List<Move> posibleMoves = new List<Move>();

            if (blacksTurn == true)
                Piecearray = board.blackPieces.ToArray();
            else
                Piecearray = board.whitePieces.ToArray();

            foreach (Piece piece in Piecearray) {
                HashSet<Point> positions = piece.getMoves();
                foreach (var pos in positions) {
                    Move move = new Move(piece.Position, pos);
                    Board newBoard = new Board(board);
                    newBoard.makeMove(move.from,move.to);

                    double brojka = search(depth, !blacksTurn, newBoard, -10000, 10000);

                    move.value = brojka;
                    posibleMoves.Add(move);

                }
            }
            posibleMoves.Sort();
            //Move newMove = getRandomMove(posibleMoves);
            Move newMove = posibleMoves.First();
            if (BestMove == null || newMove.value < BestMove.value) {
                BestMove = newMove;
            }

            game.makeMove(BestMove.from, BestMove.to);
            return BestMove;
        }
        public double search(int depth, bool blacksTurn, Board board, double alpha, double beta) {
            if (depth == 0) return board.getEvaluation();
            if (!board.hasWhiteKing()) return -1000;
            if (!board.hasBlackKing()) return 1000;

            double bestMove = 0;
            Piece[] Piecearray;
            List<double> outputs = new List<double>();

            if (blacksTurn == true) {
                Piecearray = board.blackPieces.ToArray();
                bestMove = 9999;
            }
            else {
                Piecearray = board.whitePieces.ToArray();
                bestMove = -9999;
            }


            foreach (Piece piece in Piecearray) {
                HashSet<Point> moves = piece.getMoves();
                foreach (Point toPos in moves) {
                    Move move = new Move(piece.Position, toPos);
                    Board newBoard = new Board(board);
                    newBoard.makeMove(move.from,move.to);

                    if (!blacksTurn) {
                        bestMove = Math.Max(bestMove, search(depth - 1, !blacksTurn, newBoard, alpha, beta));

                        alpha = Math.Max(alpha, bestMove);
                    }
                    else {
                        bestMove = Math.Min(bestMove, search(depth - 1, !blacksTurn, newBoard, alpha, beta));

                        beta = Math.Min(beta, bestMove);
                    }

                    if (beta <= alpha) {
                        return bestMove;
                    }

                }
            }
            return bestMove;


        }
    }
    public class Move : IComparable<Move>
    {
        public Point from;
        public Point to;

        public double value;

        public Move(Point from, Point to) {
            this.from = from;
            this.to = to;
        }

        public int CompareTo(Move other) {
            return value.CompareTo(other.value);
        }

        public override string ToString() {
            return from + " to " + to;
        }
    }
}

