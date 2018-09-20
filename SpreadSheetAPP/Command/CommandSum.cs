using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadSheetAPP.Command
{
    public class CommandSum : CommandModel
    {
        public SheetPoint point1 { get; set; }
        public SheetPoint point2 { get; set; }
        public SheetPoint point3 { get; set; }

        public CommandSum(string input, string type, string[] inputArr) :
            base(input, type)
        {
            //para check
            ParaCheck(inputArr);

            point1 = new SheetPoint
            {
                x = int.Parse(inputArr[1]),
                y = int.Parse(inputArr[2])
            };
            point2 = new SheetPoint
            {
                x = int.Parse(inputArr[3]),
                y = int.Parse(inputArr[4])
            };
            point3 = new SheetPoint
            {
                x = int.Parse(inputArr[5]),
                y = int.Parse(inputArr[6])
            };
        }

        public bool ParaCheck(string[] inputArr)
        {
            if (inputArr.Length != 7)
            {
                throw new Exception("Incorrect number of parameters");
            }
            int paraInt;
            if (!int.TryParse(inputArr[1], out paraInt) || paraInt < 0 ||
                !int.TryParse(inputArr[2], out paraInt) || paraInt < 0 ||
                !int.TryParse(inputArr[3], out paraInt) || paraInt < 0 ||
                !int.TryParse(inputArr[4], out paraInt) || paraInt < 0 ||
                !int.TryParse(inputArr[5], out paraInt) || paraInt < 0 ||
                !int.TryParse(inputArr[6], out paraInt) || paraInt < 0)
            {
                throw new Exception("The parameter must be an integer greater than zero");
            }
            return true;
        }
    }
}
