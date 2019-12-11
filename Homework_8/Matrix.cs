using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_8
{
    public class Matrix 
    {
        public int[,] Elements { get; set; } //Array of matrix elements

        public Matrix(int[,] elems) //constructor if we already have an array
        {
            Elements = elems;
        }

        public Matrix(bool initialize) //constructor if we want to generate elements at random
        {
            if(!initialize)
                return;
            Random rnd=new Random(DateTime.Now.Millisecond);
            Elements=new int[10,10];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Elements[i, j] = rnd.Next(100);
                }
            }
        }

        public void Print() //method to output matrix into the console
        {
            Console.WriteLine("Matrix:\n");
            for (int i = 0; i < Elements.GetLength(0); i++)
            {
                for (int j = 0; j < Elements.GetLength(1); j++)
                {
                    Console.Write($"{Elements[i,j]}\t");
                }

                Console.WriteLine("\n");
            }
        }
    }

    public class MatrixMultiply //class to multiply matrices
    {
        public Matrix Matrix1 { get; set; } //first multiplier
        public Matrix Matrix2 { get; set; } //second multiplier
        public Matrix MatrixRes { get; set; } //product of multiply

        public MatrixMultiply(Matrix m1, Matrix m2, Matrix m3)
        {
            Matrix1 = m1;
            Matrix2 = m2;
            MatrixRes = m3;
        }
        public void Multiply(object index) //method of one iteration of matrix multiply, with one parameter of type object to work with ParameterizedThreadStart
        {
            int row = (int) index;
            if (Matrix1.Elements.GetLength(1) != Matrix2.Elements.GetLength(0))
                return;
            if (MatrixRes.Elements == null)
            {
                MatrixRes.Elements = new int[Matrix1.Elements.GetLength(0), Matrix2.Elements.GetLength(1)];
            }

            for (int j = 0; j < Matrix2.Elements.GetLength(1); j++)
            {
                int res = 0;
                for (int k = 0; k < Matrix1.Elements.GetLength(1); k++)
                {
                    for (int i = 0; i < Matrix2.Elements.GetLength(0); i++)
                    {
                        if (k == i)
                            res += Matrix1.Elements[row, k] * Matrix2.Elements[i, j];
                    }
                }

                MatrixRes.Elements[row, j] = res;
            }

            Console.WriteLine($"Row number {row} was formed");
        }
    }
}
