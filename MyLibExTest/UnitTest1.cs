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

        int actual = LibEx.MyLibEx(a,b);
        Assert.Equal(expected, actual);
    }
    [Fact]
    public void Test2()
    {
        int a = 4; int b = 5; //arrange
        int expected = 20;

        int actual = LibEx.MyLibEx(a,b);
        Assert.Equal(expected, actual);
    }
    [Fact]
    public void Test3()
    {
        int a = 0; int b = 20; //arrange
        int expected = 0;

        int actual = LibEx.MyLibEx(a,b);
        Assert.Equal(expected, actual);
    }
    [Fact]
    public void Test4()
    {
        int a = 9; int b = -3; //arrange
        int expected = -27;

        int actual = LibEx.MyLibEx(a,b);
        Assert.Equal(expected, actual);
    }
}
