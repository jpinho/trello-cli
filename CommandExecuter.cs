using System;
using static System.Runtime.InteropServices.RuntimeInformation;
using static System.Runtime.InteropServices.OSPlatform;
using static CommandType;
using System.Diagnostics;
using System.Linq;

class CommandExecutor {

  static void OpenBrowser(string url) {
    if (IsOSPlatform(Windows)){
      Process.Start(new ProcessStartInfo("cmd", $"/c start {url}"));
    } else if (IsOSPlatform(Linux)) {
      Process.Start("xdg-open", url);
    } else if (IsOSPlatform(OSX)) {
      Process.Start("open", url);
    }
  }

  class DisplayExecutor {
    private readonly string[] args;

    public DisplayExecutor(String[] args) {
      this.args = args;
    }

    public void run() {
      if (args == null || args.Length == 0) {
        return;
      }

      if(args[0].Equals("highlights", StringComparison.InvariantCultureIgnoreCase) && args.Length == 2) {
        String teamName = args[1];
        OpenBrowser($"https://trello.com/{teamName}/highlights");
      }
    }
  }

  public static bool execute(CommandType commandType, String[] args) {
    switch(commandType) {
      case DISPLAY:
        new DisplayExecutor(args.Skip(1).ToArray()).run();
        return true;
      default:
        return false;
    };
  }
}
