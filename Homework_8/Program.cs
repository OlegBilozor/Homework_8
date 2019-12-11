using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Homework_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix m1=new Matrix(true);
            Matrix m2=new Matrix(true);
            Matrix m3=new Matrix(false);
            MatrixMultiply mmp=new MatrixMultiply(m1, m2, m3);
            Thread[] threads = new Thread[m1.Elements.GetLength(0)];
            for (int i = 0; i < m1.Elements.GetLength(0); i++)
            {
               threads[i]= new Thread(mmp.Multiply);
               threads[i].Start(i);
            }
            foreach (var th in threads)
            {
                th.Join();
            }
            m3.Print();
            Console.ReadLine();
        }
    }
}
