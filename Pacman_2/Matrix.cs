using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman_2
{
    public class Matrix
    {
        private int rows;
        private int columns;
        private int[,] data;

        public Matrix(int[,] data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            rows = data.GetLength(0);
            columns = data.GetLength(1);
            this.data = new int[rows, columns];

            Array.Copy(data, this.data, data.Length);
        }

        public int Rows => rows;
        public int Columns => columns;

        public int this[int row, int col]
        {
            get
            {
                if (row < 0 || row >= rows || col < 0 || col >= columns)
                {
                    throw new IndexOutOfRangeException("Index out of range.");
                }
                return data[row, col];
            }
            set
            {
                if (row < 0 || row >= rows || col < 0 || col >= columns)
                {
                    throw new IndexOutOfRangeException("Index out of range.");
                }
                data[row, col] = value;
            }
        }


    }
}

