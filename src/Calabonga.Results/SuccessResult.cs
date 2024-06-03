namespace Calabonga.OperationResults
{
    /// <summary>
    /// Default success result 
    /// </summary>
    public struct SuccessResult { }

    /// <summary>
    /// Default success result
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct SuccessResult<T>
    {
        /// <summary>
        /// Result value
        /// </summary>
        internal readonly T Result;

        internal SuccessResult(T result) => Result = result;
    }
}