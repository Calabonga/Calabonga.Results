namespace Calabonga.Results
{
    public static class Operation
    {
        public static SuccessResult SuccessResult { get; } = new SuccessResult();

        /// <summary>
        /// Create "Success" Status or Operation
        /// </summary>
        public static SuccessResult Success() => SuccessResult;

        /// <summary>
        /// Create "Success" Status or Operation
        /// </summary>
        public static SuccessResult<TResult> Success<TResult>(TResult result) => new SuccessResult<TResult>(result);

        public static ErrorResult ErrorResult { get; } = new ErrorResult();

        /// <summary>
        /// Create "Error" Status or Operation
        /// </summary>
        public static ErrorResult Error() => ErrorResult;

        /// <summary>
        /// Create "Error" Status or Operation
        /// </summary>
        public static ErrorResult<TError> Error<TError>(TError error) => new ErrorResult<TError>(error);
    }
}