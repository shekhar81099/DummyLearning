namespace testapi.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        int a = 5;
        int b = 10;
        int sum = a + b;

        Assert.Equal(15, sum);
    }
}
