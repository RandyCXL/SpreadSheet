using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpreadSheetAPP.Command;

namespace SpreadSheetAPP
{
    class Program
    {
        static SpreadSheet sheet = null;

        static void Main(string[] args)
        {
            Console.WriteLine("SpreadSheetApplication");
            Console.WriteLine("Command1:C w h, create a new spread sheet of width w and height h");
            Console.WriteLine("Command2:N x1 y1 v1, insert a number in specified cell (x1,y1)");
            Console.WriteLine("Command3:S x1 y1 x2 y2 x3 y3, perform sum on top of all cells from x1 y1 to x2 y2 and store the result in x3 y3");
            Console.WriteLine("Command4:Q, qiut");

            var result = true;
            while (result)
            {
                try
                {
                    Console.Write("Please input Command:");
                    var commandStr = Console.ReadLine();
                    var commandModel = new CommandFactory().GetCommand(commandStr);
                    if (commandModel == null)
                    {
                        Console.WriteLine("Unknown command!");
                        continue;
                    }
                    result = ExeCommand(commandModel);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(string.Format("Runtime exception:{0}", ex.Message));
                }
            }

            Console.Write("Press any key to end!");
            Console.ReadLine();
        }

        /// <summary>
        /// Execute command
        /// </summary>
        /// <param name="commandModel"></param>
        /// <param name="sheet"></param>
        public static bool ExeCommand(CommandModel commandModel)
        {
            var result = true;
            switch (commandModel.CommandType)
            {
                case "Q":
                    result = false;
                    break;
                case "C":
                    var creatModel = (CommandCreate)commandModel;
                    if (sheet != null)
                    {
                        Console.WriteLine("SpreadSheet already exists!");
                        sheet.Show();
                    }
                    else
                    {
                        sheet = new SpreadSheet(creatModel.row, creatModel.column);
                        Console.WriteLine("Create SpreadSheet Success!");
                        sheet.Show();
                    }
                    break;
                case "N":
                    var creatNewValue = (CommandNewValue)commandModel;
                    if (sheet == null)
                    {
                        Console.WriteLine("Please Create SpreadSheet First!");
                    }
                    else
                    {
                        sheet.SetValue(creatNewValue.point.x, creatNewValue.point.y, creatNewValue.point.value);
                        sheet.Show();
                    }
                    break;
                case "S":
                    var creatSum = (CommandSum)commandModel;
                    if (sheet == null)
                    {
                        Console.WriteLine("Please Create SpreadSheet First!");
                    }
                    else
                    {
                        var value1 = sheet.GetValue(creatSum.point1.x, creatSum.point1.y);
                        var value2 = sheet.GetValue(creatSum.point2.x, creatSum.point2.y);
                        sheet.SetValue(creatSum.point3.x, creatSum.point3.y, value1 + value2);
                        sheet.Show();
                    }
                    break;
            }
            return result;
        }
    }
}
