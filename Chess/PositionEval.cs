using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class PositionEval
    {
        public static double[,] pawnEvalWhite = 
        {
        {0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0},
        {5.0, 5.0, 5.0, 5.0, 5.0, 5.0, 5.0, 5.0},
        {1.0, 1.0, 2.0, 3.0, 3.0, 2.0, 1.0, 1.0},
        {0.5, 0.5, 1.0, 2.5, 2.5, 1.0, 0.5, 0.5},
        {0.0, 0.0, 0.0, 2.0, 2.0, 0.0, 0.0, 0.0},
        {0.5, -0.5, -1.0, 0.0, 0.0, -1.0, -0.5, 0.5},
        {0.5, 1.0, 1.0, -2.0, -2.0, 1.0, 1.0, 0.5},
        {0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0}
        };

        public static double[,] knightEval =
        {
        {-5.0, -4.0, -3.0, -3.0, -3.0, -3.0, -4.0, -5.0},
        {-4.0, -2.0, 0.0, 0.0, 0.0, 0.0, -2.0, -4.0},
        {-3.0, 0.0, 1.0, 1.5, 1.5, 1.0, 0.0, -3.0},
        {-3.0, 0.5, 1.5, 2.0, 2.0, 1.5, 0.5, -3.0},
        {-3.0, 0.0, 1.5, 2.0, 2.0, 1.5, 0.0, -3.0},
        {-3.0, 0.5, 1.0, 1.5, 1.5, 1.0, 0.5, -3.0},
        {-4.0, -2.0, 0.0, 0.5, 0.5, 0.0, -2.0, -4.0},
        {-5.0, -4.0, -3.0, -3.0, -3.0, -3.0, -4.0, -5.0}
        };

        public static double[,] bishopEvalWhite = {
        
            {-2.0, -1.0, -1.0, -1.0, -1.0, -1.0, -1.0, -2.0},
        
            {-1.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, -1.0},
        
            {-1.0, 0.0, 0.5, 1.0, 1.0, 0.5, 0.0, -1.0},
        
            {-1.0, 0.5, 0.5, 1.0, 1.0, 0.5, 0.5, -1.0},
        
            {-1.0, 0.0, 1.0, 1.0, 1.0, 1.0, 0.0, -1.0},
        
            {-1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, -1.0},
        
            {-1.0, 0.5, 0.0, 0.0, 0.0, 0.0, 0.5, -1.0},
        
            {-2.0, -1.0, -1.0, -1.0, -1.0, -1.0, -1.0, -2.0}
        };

        public static double[,] rookEvalWhite = {
        {0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0},
        {0.5, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 0.5},
        {-0.5, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, -0.5},
        {-0.5, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, -0.5},
        {-0.5, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, -0.5},
        {-0.5, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, -0.5},
        {-0.5, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, -0.5},
        {0.0, 0.0, 0.0, 0.5, 0.5, 0.0, 0.0, 0.0}
        };

        public static double[,] evalQueen =
        {
        {-2.0, -1.0, -1.0, -0.5, -0.5, -1.0, -1.0, -2.0},
        {-1.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, -1.0},
        {-1.0, 0.0, 0.5, 0.5, 0.5, 0.5, 0.0, -1.0},
        {-0.5, 0.0, 0.5, 0.5, 0.5, 0.5, 0.0, -0.5},
        {0.0, 0.0, 0.5, 0.5, 0.5, 0.5, 0.0, -0.5},
        {-1.0, 0.5, 0.5, 0.5, 0.5, 0.5, 0.0, -1.0},
        {-1.0, 0.0, 0.5, 0.0, 0.0, 0.0, 0.0, -1.0},
        {-2.0, -1.0, -1.0, -0.5, -0.5, -1.0, -1.0, -2.0}
        };

        public static double[,] kingEvalWhite = {
        

            {-3.0, -4.0, -4.0, -5.0, -5.0, -4.0, -4.0, -3.0},
        
            {-3.0, -4.0, -4.0, -5.0, -5.0, -4.0, -4.0, -3.0},
        
            {-3.0, -4.0, -4.0, -5.0, -5.0, -4.0, -4.0, -3.0},
        
            {-3.0, -4.0, -4.0, -5.0, -5.0, -4.0, -4.0, -3.0},
        
            {-2.0, -3.0, -3.0, -4.0, -4.0, -3.0, -3.0, -2.0},
        
            {-1.0, -2.0, -2.0, -2.0, -2.0, -2.0, -2.0, -1.0},
        
            {2.0, 2.0, 0.0, 0.0, 0.0, 0.0, 2.0, 2.0},
        
            {2.0, 3.0, 1.0, 0.0, 0.0, 1.0, 3.0, 2.0}
        };

        public static double[,] pawnEvalBlack() {
            double[,] copy = pawnEvalWhite;
            Reverse2DimArray(copy);
            return copy;
        }
        public static double[,] bishopEvalBlack() {
            double[,] copy = bishopEvalWhite;
            Reverse2DimArray(copy);
            return copy;
        }
        public static double[,] rookEvalBlack() {
            double[,] copy = rookEvalWhite;
            Reverse2DimArray(copy);
            return copy;
        }
        public static double[,] kingEvalBlack() {
            double[,] copy = kingEvalWhite;
            Reverse2DimArray(copy);
            return copy;
        }

        public static void Reverse2DimArray(double[,] theArray) {
            for (int rowIndex = 0;
                 rowIndex <= (theArray.GetUpperBound(0)); rowIndex++) {
                for (int colIndex = 0;
                     colIndex <= (theArray.GetUpperBound(1) / 2); colIndex++) {
                    double tempHolder = theArray[rowIndex, colIndex];
                    theArray[rowIndex, colIndex] =
                      theArray[rowIndex, theArray.GetUpperBound(1) - colIndex];
                    theArray[rowIndex, theArray.GetUpperBound(1) - colIndex] =
                      tempHolder;
                }
            }
        }



    }
}
