namespace Calabonga.Results
{
    /// <summary>
    /// Result of operation
    /// </summary>
    /// <typeparam name="TResult">Type of Value field</typeparam>
    public readonly struct Operation<TResult>
    {
        public TResult Result { get; }

        public bool Success { get; }

        private Operation(bool isSuccess)
        {
            Success = isSuccess;
            Result = default!;
        }

        private Operation(TResult result)
        {
            Success = true;
            Result = result;
        }

        public static implicit operator bool(Operation<TResult> result) => result.Success;

        public static implicit operator Operation<TResult>(TResult result) => new Operation<TResult>(result);

        public static implicit operator Operation<TResult>(SuccessResult<TResult> result) => new Operation<TResult>(result.Value);

        private static readonly Operation<TResult> _error = new Operation<TResult>(false);

        public static implicit operator Operation<TResult>(ErrorResult result) => _error;
    }

    /// <summary>
    /// Operation of operation with one Error
    /// </summary>
    /// <typeparam name="TResult">Type of Value field</typeparam>
    /// <typeparam name="TError">Type of Error field</typeparam>
    public readonly struct Operation<TResult, TError>
    {
        public readonly TResult Value;
        public readonly TError Error;

        public bool Ok { get; }

        private Operation(TResult result)
        {
            Ok = true;
            Value = result;
            Error = default!;
        }

        private Operation(TError error)
        {
            Ok = false;
            Value = default!;
            Error = error;
        }

        public void Deconstruct(out TResult result, out TError error)
        {
            result = Value;
            error = Error;
        }

        public static implicit operator bool(Operation<TResult, TError> result) => result.Ok;

        public static implicit operator Operation<TResult, TError>(TResult result) => new Operation<TResult, TError>(result);

        public static implicit operator Operation<TResult, TError>(SuccessResult<TResult> result) => new Operation<TResult, TError>(result.Value);

        public static implicit operator Operation<TResult, TError>(ErrorResult<TError> result) => new Operation<TResult, TError>(result.Error);
    }

    /// <summary>
    /// Operation of operation with two different Errors
    /// </summary>
    /// <typeparam name="TResult">Type of Value field</typeparam>
    /// <typeparam name="TError1">Type of first Error</typeparam>
    /// <typeparam name="TError2">Type of second Error</typeparam>
    public readonly struct Operation<TResult, TError1, TError2>
    {

        public readonly TResult Value;
        public readonly object? Error;

        public bool Ok { get; }

        public bool HasError<TError>() => Error is TError;

        public TError GetError<TError>()
        {
            if (Error is null)
            {
                return (TError)Error!;
            }

            return default!;
        }

        private Operation(TResult result)
        {
            Ok = true;
            Value = result;
            Error = null;
        }

        private Operation(object error)
        {
            Ok = false;
            Value = default!;
            Error = error;
        }

        public void Deconstruct(out TResult result, out object? error)
        {
            result = Value;
            error = Error;
        }

        public static implicit operator bool(Operation<TResult, TError1, TError2> result) => result.Ok;

        public static implicit operator Operation<TResult, TError1, TError2>(TResult result) => new Operation<TResult, TError1, TError2>(result);

        public static implicit operator Operation<TResult, TError1, TError2>(SuccessResult<TResult> result) => new Operation<TResult, TError1, TError2>(result.Value);

        public static implicit operator Operation<TResult, TError1, TError2>(ErrorResult<TError1> result) => new Operation<TResult, TError1, TError2>(result.Error!);

        public static implicit operator Operation<TResult, TError1, TError2>(ErrorResult<TError2> result) => new Operation<TResult, TError1, TError2>(result.Error!);
    }

    /// <summary>
    /// Operation of operation (with different Errors)
    /// </summary>
    /// <typeparam name="TResult">Type of Value field</typeparam>
    /// <typeparam name="TError1">Type of first Error</typeparam>
    /// <typeparam name="TError2">Type of second Error</typeparam>
    /// <typeparam name="TError3">Type of third Error</typeparam>
    public readonly struct Operation<TResult, TError1, TError2, TError3>
    {
        public readonly TResult Value;
        public readonly object? Error;

        public bool Ok { get; }

        public bool HasError<TError>() => Error is TError;

        public TError GetError<TError>()
        {
            if (Error is null)
            {
                return (TError)Error!;
            }

            return default!;
        }

        private Operation(TResult result)
        {
            Ok = true;
            Value = result;
            Error = null;
        }

        private Operation(object error)
        {
            Ok = false;
            Value = default!;
            Error = error;
        }

        public void Deconstruct(out TResult result, out object? error)
        {
            result = Value;
            error = Error;
        }

        public static implicit operator bool(Operation<TResult, TError1, TError2, TError3> operation) => operation.Ok;

        public static implicit operator Operation<TResult, TError1, TError2, TError3>(TResult result) => new Operation<TResult, TError1, TError2, TError3>(result);

        public static implicit operator Operation<TResult, TError1, TError2, TError3>(SuccessResult<TResult> result) => new Operation<TResult, TError1, TError2, TError3>(result.Value);

        public static implicit operator Operation<TResult, TError1, TError2, TError3>(ErrorResult<TError1> result) => new Operation<TResult, TError1, TError2, TError3>(result);

        public static implicit operator Operation<TResult, TError1, TError2, TError3>(ErrorResult<TError2> result) => new Operation<TResult, TError1, TError2, TError3>(result.Error);

        public static implicit operator Operation<TResult, TError1, TError2, TError3>(ErrorResult<TError3> result) => new Operation<TResult, TError1, TError2, TError3>(result.Error);
    }
}