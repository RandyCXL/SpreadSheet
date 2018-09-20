using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadSheetAPP
{
    /// <summary>
    /// 
    /// </summary>
    public class SpreadSheet
    {
        //二维数组
        int[,] tableData;
        //行列数
        int row, column;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public SpreadSheet(int row, int column)
        {
            //参数校验

            //创建二维数组
            this.row = row;
            this.column = column;
            tableData = new int[row, column];
            //初始二维数组
            Init();
        }

        /// <summary>
        /// 
        /// </summary>
        private void Init()
        {
            for (var i = 0; i < row; i++)
            {
                for (var j = 0; j < column; j++)
                {
                    tableData[i, j] = 0;
                }
            }
        }

        /// <summary>
        /// 显示二维数组
        /// </summary>
        public void Show()
        {
            for (var i = 0; i < row; i++)
            {
                Console.Write("|");
                for (var j = 0; j < column; j++)
                {
                    if (tableData[i, j] == 0)
                    {
                        Console.Write("     |");
                    }
                    else
                    {
                        Console.Write(string.Format(" {0,3} |", tableData[i, j]));
                    }
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="value"></param>
        public void SetValue(int x, int y, int value)
        {
            //参数校验
            if (x < 0 || x >= row ||
                y < 0 || y >= column)
            {
                throw new Exception("Index out of range");
            }

            tableData[x, y] = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int GetValue(int x, int y)
        {
            return tableData[x, y];
        }
    }
}
