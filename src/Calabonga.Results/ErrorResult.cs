namespace Calabonga.OperationResults
{
    /// <summary>
    /// Operation response result with error
    /// </summary>
    public struct ErrorResult { }

    /// <summary>
    /// Operation response result with error
    /// </summary>
    public struct ErrorResult<T>
    {
        /// <summary>
        /// Operation error
        /// </summary>
        internal readonly T Error;

        internal ErrorResult(T error) => Error = error;
    }
}