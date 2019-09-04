using System;
using System.Diagnostics;
using Moq;
using Xunit;

public class CommandExecuterTest {

  [Fact]
  public void itReturnsTrueWhenCommandIsNotUnknown() {
    Assert.True(CommandExecutor.execute(CommandType.DISPLAY, new String[0]));
  }

  [Fact]
  public void itReturnsFalseWhenCommandIsUnknown() {
    Assert.False(CommandExecutor.execute(CommandType.UNKNOWN, new String[0]));
  }
}
