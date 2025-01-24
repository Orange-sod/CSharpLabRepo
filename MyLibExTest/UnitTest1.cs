using Xunit;
using MyLibEx;

namespace MyLibExTest;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        int a = 2; int b = 3; //arrange
        int expected = 6;

        int actual = LibEx.MyLibEx(2,3);
        Assert.Equal(expected, actual);
    }
}
