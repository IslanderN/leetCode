public static class TailRecursion
{
    public static T Execute<T>(Func<RecursionResult<T>> func)
    {
        do
        {
            var recursionResult = func();
            if (recursionResult.IsFinalResult)
                return recursionResult.Result;
            func = recursionResult.NextStep;
        } while (true);
    }

    public static RecursionResult<T> Return<T>(T result)
    {
        return new RecursionResult<T>(true, result, null);
    }

    public static RecursionResult<T> Next<T>(Func<RecursionResult<T>> nextStep)
    {
        return new RecursionResult<T>(false, default(T), nextStep);
    }

}

public class RecursionResult<T>
{
    private readonly bool _isFinalResult;
    private readonly T _result;
    private readonly Func<RecursionResult<T>> _nextStep;
    internal RecursionResult(bool isFinalResult, T result, Func<RecursionResult<T>> nextStep)
    {
        _isFinalResult = isFinalResult;
        _result = result;
        _nextStep = nextStep;
    }

    public bool IsFinalResult { get { return _isFinalResult; } }
    public T Result { get { return _result; } }
    public Func<RecursionResult<T>> NextStep { get { return _nextStep; } }
}

public class Solution {
    public int Fib(int n) {
        return TailRecursion.Execute<int>(()=>InnerFib(n, 0, 1));
    }

    internal static RecursionResult<int> InnerFib(int n, int a, int b)
    {
        if(n == 0)
        {
            return TailRecursion.Return<int>(a);
        }
        else if (n == 1)
        {
            return TailRecursion.Return<int>(b);
        }
        return TailRecursion.Next<int>(() => InnerFib(n - 1, b, a + b));
    }
}