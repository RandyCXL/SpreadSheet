using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadSheetAPP.Command
{
    /// <summary>
    /// 
    /// </summary>
    public class CommandFactory
    {
        /// <summary>
        /// 解析命令
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public CommandModel GetCommand(string input)
        {
            var inputArr = input.Split(' ');
            var type = inputArr[0].ToUpper();
            switch (type)
            {
                case "Q":
                    return new CommandModel(input, type);
                case "C":
                    return new CommandCreate(input, type, inputArr);
                case "N":
                    return new CommandNewValue(input, type, inputArr);
                case "S":
                    return new CommandSum(input, type, inputArr);
            }
            return null;
        }
    }
}
