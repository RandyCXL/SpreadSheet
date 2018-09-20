using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadSheetAPP.Command
{
    public class CommandNewValue : CommandModel
    {
        public SheetPoint point { get; set; }

        public CommandNewValue(string input, string type, string[] inputArr) :
            base(input, type)
        {
            //para check
            ParaCheck(inputArr);

            point = new SheetPoint
            {
                x = int.Parse(inputArr[1]),
                y = int.Parse(inputArr[2]),
                value = int.Parse(inputArr[3])
            };
        }

        public bool ParaCheck(string[] inputArr)
        {
            if (inputArr.Length != 4)
            {
                throw new Exception("Incorrect number of parameters");
            }
            if (inputArr[3].Length == 0 || inputArr[3].Length > 3)
            {
                throw new Exception("Parameter length must between 1 and 3");
            }
            int paraInt;
            if (!int.TryParse(inputArr[1], out paraInt) || paraInt < 0 ||
                !int.TryParse(inputArr[2], out paraInt) || paraInt < 0 ||
                !int.TryParse(inputArr[3], out paraInt))
            {
                throw new Exception("The parameter must be an integer greater than zero");
            }
            return true;
        }
    }
}
