using System.Numerics;

namespace Test;

public class Class1
{
    public void Thnig()
    {
        _ = new[] {1, 2, 3}.CountEven();
        _ = new[] {1L, 2, 3}.CountEven();
        _ = new[] {1m, 2, 3}.CountEven();
        _ = new[] {1d, 2, 3}.CountEven();
        _ = new[] {1f, 2, 3}.CountEven();
    }
}

public static class NumericExtensions
{
    private static class Helper<T> where T : INumber<T>
    {
        private static readonly T Two = T.One + T.One;
        public static int CountEven(IEnumerable<T> numbers) => numbers.Count(n => n % Two == T.Zero);
    }

    public static int CountEven<T>(this IEnumerable<T> numbers) where T : INumber<T> => Helper<T>.CountEven(numbers);
}