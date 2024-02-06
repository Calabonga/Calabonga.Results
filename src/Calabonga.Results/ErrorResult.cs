namespace Calabonga.Results
{
    public struct ErrorResult { }

    public struct ErrorResult<T>
    {
        internal readonly T Error;

        internal ErrorResult(T error) => Error = error;
    }
}