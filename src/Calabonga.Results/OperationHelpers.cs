namespace Calabonga.Results
{
    /// <summary>
    /// Operation results extensions
    /// </summary>
    public static class Operation
    {
        /// <summary>
        /// Returns default <see cref="SuccessResult"/>
        /// </summary>
        internal static SuccessResult SuccessResult { get; } = new SuccessResult();

        /// <summary>
        /// Create <see cref="SuccessResult"/>
        /// </summary>
        public static SuccessResult Result() => SuccessResult;

        /// <summary>
        /// Create <see cref="SuccessResult"/> with generic result
        /// </summary>
        public static SuccessResult<T> Result<T>(T result) => new SuccessResult<T>(result);

        /// <summary>
        /// Returns default 
        /// </summary>
        internal static ErrorResult ErrorResult { get; } = new ErrorResult();

        /// <summary>
        /// Returns <see cref="ErrorResult"/>
        /// </summary>
        public static ErrorResult Error() => ErrorResult;

        /// <summary>
        /// Create <see cref="ErrorResult"/> for operation
        /// </summary>
        public static ErrorResult<T> Error<T>(T error) => new ErrorResult<T>(error);
    }
}