using System;

namespace trelloCli
{
  class Program
  {
    static Func<String, CommandType> GetCommandType = (String command) => {
      CommandType commandType;
      if(Enum.TryParse(command, true, out commandType)) {
        return commandType;
      }
      return CommandType.UNKNOWN;
    };

    static void Main(string[] args) {
      if (args.Length == 0) {
        Console.WriteLine("Invalid arguments.");
        return;
      }

      CommandType command = GetCommandType(args[0]);
      CommandExecutor.execute(command, args);
    }
  }
}
