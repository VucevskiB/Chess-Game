using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public abstract class MoveSet
    {
        public Piece MyPiece { get; set; }
        public HashSet<Point> Set { get; set; }

        protected Piece[,] getTileMap() {
            return MyPiece.Board.tileMap;
        }


        public abstract HashSet<Point> GenerateMoveSet(Point position);


        protected bool isOutOfBoundsCheck(Point vec) {
            if (vec.X < 0 || vec.X >= getTileMap().GetLength(1)) return true;
            if (vec.Y < 0 || vec.Y >= getTileMap().GetLength(0)) return true;
            if (getTileMap()[vec.Y, vec.X] != null && MyPiece.Color == getTileMap()[vec.Y, vec.X].Color) return true;


            return false;
        }
        protected bool enemyCheck(Point v) {
            Piece tile = getTileMap()[v.Y, v.X];
            if (tile != null && tile.Type != Piece.TYPE.NONE) return true;

            return false;
        }
    }

    public class PawnMoveSet : MoveSet
    {
        public override HashSet<Point> GenerateMoveSet(Point position) {
            Set = Set = new HashSet<Point>();

            int dir = MyPiece.Color == Piece.COLOR.WHITE ? -1 : 1;

            //MoveSet forward
            Point vec = new Point(0, dir);
            Point movPos = new Point(vec.X + position.X, vec.Y + position.Y);
            if (!isOutOfBoundsCheck(movPos))
                if (getTileMap()[movPos.Y, movPos.X] == null || getTileMap()[movPos.Y, movPos.X].Type == Piece.TYPE.NONE)
                    Set.Add(movPos);


            //Double MoveSet
            if (position.Y - dir == 0 || position.Y - dir == getTileMap().GetLength(0) - 1) {
                vec = new Point(0, dir * 2);
                movPos = new Point(vec.X + position.X,vec.Y + position.Y);
                if (!isOutOfBoundsCheck(movPos) && Set.Count > 0)
                    if (getTileMap()[movPos.Y, movPos.X] == null || getTileMap()[movPos.Y, movPos.X].Type == Piece.TYPE.NONE)
                        Set.Add(movPos);
            }

            //Attack left
            vec = new Point(-1, dir);
            movPos = new Point(vec.X + position.X, vec.Y + position.Y);
            if (checkForAttack(movPos))
                Set.Add(movPos);

            //Attack right
            vec = new Point(1, dir);
            movPos = new Point(vec.X + position.X, vec.Y + position.Y);
            if (checkForAttack(movPos))
                Set.Add(movPos);


            return Set;
        }
        private bool checkForAttack(Point movePos) {
            if (movePos.X < 0 || movePos.X >= getTileMap().GetLength(1)) return false;
            if (movePos.Y < 0 || movePos.Y >= getTileMap().GetLength(0)) return false;

            if (getTileMap()[movePos.Y, movePos.X] != null && getTileMap()[movePos.Y, movePos.X].Color != MyPiece.Color)
                return true;

            return false;
        }
    }
    class KnightMoveSet : MoveSet
    {

        public override HashSet<Point> GenerateMoveSet(Point position) {
            Set = new HashSet<Point>();

            Point[] vector = new Point[8];
            vector[0] = new Point(1, 2);
            vector[1] = new Point(1, -2);
            vector[2] = new Point(2, 1);
            vector[3] = new Point(2, -1);
            vector[4] = new Point(-1, 2);
            vector[5] = new Point(-1, -2);
            vector[6] = new Point(-2, 1);
            vector[7] = new Point(-2, -1);

            foreach (Point vec in vector) {
                Point movPos = new Point(vec.X + position.X , vec.Y + position.Y);

                if (!isOutOfBoundsCheck(movPos))
                    Set.Add(movPos);
            }
            return Set;
        }
    }
    class BishopMoveSet : MoveSet
    {


        public override HashSet<Point> GenerateMoveSet(Point position) {
            Set = new HashSet<Point>();

            for (int d = 0; d < 4; d++) {
                int x = 1, y = 1;
                switch (d) {
                    case 0: x = 1; y = 1; break;
                    case 1: x = 1; y = -1; break;
                    case 2: x = -1; y = 1; break;
                    case 3: x = -1; y = -1; break;
                }

                for (int i = 1; i < getTileMap().GetLength(0); i++) {
                    Point vec = new Point(x * i, y * i);
                    Point movPos = new Point(vec.X + position.X , vec.Y + position.Y);

                    if (isOutOfBoundsCheck(movPos)) break;

                    Set.Add(movPos);

                    if (enemyCheck(movPos)) break;
                }
            }

            return Set;
        }

    }
    class RookMoveSet : MoveSet
    {

        public override HashSet<Point> GenerateMoveSet(Point position) {
            Set = new HashSet<Point>();

            for (int d = 0; d < 4; d++) {
                int x = 1, y = 1;
                switch (d) {
                    case 0: x = 1; y = 0; break;
                    case 1: x = -1; y = 0; break;
                    case 2: x = 0; y = 1; break;
                    case 3: x = 0; y = -1; break;
                }
                for (int i = 1; i < 100; i++) {
                    Point vec = new Point(x * i, y * i);
                    Point movPos = new Point(vec.X + position.X , vec.Y + position.Y);

                    if (isOutOfBoundsCheck(movPos)) break;

                    Set.Add(movPos);

                    if (enemyCheck(movPos)) break;

                }

            }

            return Set;
        }
    }
    class QueenMoveSet : MoveSet
    {

        public override HashSet<Point> GenerateMoveSet(Point position) {
            Set = Set = new HashSet<Point>();

            RookMoveSet rm = new RookMoveSet();
            rm.MyPiece = MyPiece;
            BishopMoveSet bm = new BishopMoveSet();
            bm.MyPiece = MyPiece;

            Set.UnionWith(rm.GenerateMoveSet(position));
            Set.UnionWith(bm.GenerateMoveSet(position));

            return Set;
        }
    }
    class KingMoveSet : MoveSet
    {


        public override HashSet<Point> GenerateMoveSet(Point position) {
            Set = new HashSet<Point>();

            Point[] vector = new Point[8];
            vector[0] = new Point(0, 1);
            vector[1] = new Point(0, -1);
            vector[2] = new Point(1, 1);
            vector[3] = new Point(1, -1);
            vector[4] = new Point(-1, 1);
            vector[5] = new Point(-1, -1);
            vector[6] = new Point(-1, 0);
            vector[7] = new Point(1, 0);

            foreach (Point vec in vector) {
                Point movPos = new Point(vec.X + position.X , vec.Y + position.Y);

                if (!isOutOfBoundsCheck(movPos))
                    Set.Add(movPos);
            }

            return Set;
        }
    }
}
