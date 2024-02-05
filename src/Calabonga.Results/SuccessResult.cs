namespace Calabonga.Results
{
    public struct SuccessResult<TResult>
    {
        internal readonly TResult Value;

        internal SuccessResult(TResult result) => Value = result;
    }

    public struct SuccessResult
    {
    }
}