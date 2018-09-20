using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadSheetAPP.Command
{
    public class CommandCreate : CommandModel
    {
        public int row { get; set; }
        public int column { get; set; }

        public CommandCreate(string input, string type, string[] inputArr) :
            base(input, type)
        {
            //para check
            ParaCheck(inputArr);

            row = int.Parse(inputArr[1]);
            column = int.Parse(inputArr[2]);
        }

        public bool ParaCheck(string[] inputArr)
        {
            if (inputArr.Length != 3)
            {
                throw new Exception("Incorrect number of parameters");
            }
            int paraInt;
            if (!int.TryParse(inputArr[1], out paraInt) || paraInt < 0 ||
                !int.TryParse(inputArr[2], out paraInt) || paraInt < 0)
            {
                throw new Exception("The parameter must be an integer greater than zero");
            }
            return true;
        }
    }
}
