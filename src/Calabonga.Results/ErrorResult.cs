namespace Calabonga.Results
{
    public struct ErrorResult<TError>
    {
        internal readonly TError Error;

        internal ErrorResult(TError error) => Error = error;
    }

    public struct ErrorResult
    {
    }
}