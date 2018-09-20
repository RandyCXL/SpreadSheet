using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadSheetAPP.Command
{
    public class CommandModel
    {
        public string CommandStr { get; set; }

        public string CommandType { get; set; }

        public CommandModel(string input, string type)
        {
            CommandStr = input;
            CommandType = type;
        }
    }
}
