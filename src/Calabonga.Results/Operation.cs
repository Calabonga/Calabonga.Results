namespace Calabonga.Results
{
    /// <summary>
    /// The operation with some Result
    /// </summary>
    /// <typeparam name="T">Type of Result field</typeparam>
    public readonly struct Operation<T>
    {
        /// <summary>
        /// Operation result
        /// </summary>
        public T Result { get; }

        /// <summary>
        /// Indicate is operation succeed
        /// </summary>
        public bool Ok { get; }

        private Operation(bool isOk)
        {
            Ok = isOk;
            Result = default!;
        }

        private Operation(T result)
        {
            Ok = true;
            Result = result;
        }

        public static implicit operator bool(Operation<T> result) => result.Ok;

        public static implicit operator Operation<T>(T result) => new Operation<T>(result);

        public static implicit operator Operation<T>(SuccessResult<T> result) => new Operation<T>(result.Result);

        private static readonly Operation<T> Error = new Operation<T>(false);

        public static implicit operator Operation<T>(ErrorResult result) => Error;
    }

    /// <summary>
    /// The operation with some Result and with one error
    /// </summary>
    /// <typeparam name="T">Type of Result field</typeparam>
    /// <typeparam name="T1">Type of Error field</typeparam>
    public readonly struct Operation<T, T1>
    {
        /// <summary>
        /// Operation error
        /// </summary>
        public readonly T1 Error;

        /// <summary>
        /// Operation result
        /// </summary>
        public T Result { get; }

        /// <summary>
        /// Indicate is operation succeed
        /// </summary>
        public bool Ok { get; }

        private Operation(T result)
        {
            Ok = true;
            Result = result;
            Error = default!;
        }

        private Operation(T1 error)
        {
            Ok = false;
            Result = default!;
            Error = error;
        }

        public void Deconstruct(out T result, out T1 error)
        {
            result = Result;
            error = Error;
        }

        public static implicit operator bool(Operation<T, T1> result) => result.Ok;

        public static implicit operator Operation<T, T1>(T result) => new Operation<T, T1>(result);

        public static implicit operator Operation<T, T1>(SuccessResult<T> result) => new Operation<T, T1>(result.Result);

        public static implicit operator Operation<T, T1>(ErrorResult<T1> result) => new Operation<T, T1>(result.Error);
    }

    /// <summary>
    /// The operation with some Result and with two different errors
    /// </summary>
    /// <typeparam name="T">Type of Result field</typeparam>
    /// <typeparam name="T1">Type of first Error</typeparam>
    /// <typeparam name="T2">Type of second Error</typeparam>
    public readonly struct Operation<T, T1, T2>
    {
        /// <summary>
        /// Operation error
        /// </summary>
        public readonly object? Error;

        /// <summary>
        /// Operation result
        /// </summary>
        public T Result { get; }

        /// <summary>
        /// Indicate is operation succeed
        /// </summary>
        public bool Ok { get; }

        private Operation(T result)
        {
            Ok = true;
            Result = result;
            Error = null;
        }

        private Operation(object error)
        {
            Ok = false;
            Result = default!;
            Error = error;
        }

        public void Deconstruct(out T result, out object? error)
        {
            result = Result;
            error = Error;
        }

        public static implicit operator bool(Operation<T, T1, T2> result) => result.Ok;

        public static implicit operator Operation<T, T1, T2>(T result) => new Operation<T, T1, T2>(result);

        public static implicit operator Operation<T, T1, T2>(SuccessResult<T> result) => new Operation<T, T1, T2>(result.Result);

        public static implicit operator Operation<T, T1, T2>(ErrorResult<T1> result) => new Operation<T, T1, T2>(result.Error!);

        public static implicit operator Operation<T, T1, T2>(ErrorResult<T2> result) => new Operation<T, T1, T2>(result.Error!);
    }

    /// <summary>
    /// The operation with some Result and with three different errors
    /// </summary>
    /// <typeparam name="T">Type of Result field</typeparam>
    /// <typeparam name="T1">Type of first Error</typeparam>
    /// <typeparam name="T2">Type of second Error</typeparam>
    /// <typeparam name="T3">Type of third Error</typeparam>
    public readonly struct Operation<T, T1, T2, T3>
    {
        /// <summary>
        /// Operation error
        /// </summary>
        public readonly object? Error;

        /// <summary>
        /// Operation result
        /// </summary>
        public T Result { get; }

        /// <summary>
        /// Indicate is operation succeed
        /// </summary>
        public bool Ok { get; }

        private Operation(T result)
        {
            Ok = true;
            Result = result;
            Error = null;
        }

        private Operation(object error)
        {
            Ok = false;
            Result = default!;
            Error = error;
        }

        public void Deconstruct(out T result, out object? error)
        {
            result = Result;
            error = Error;
        }

        public static implicit operator bool(Operation<T, T1, T2, T3> operation) => operation.Ok;

        public static implicit operator Operation<T, T1, T2, T3>(T result) => new Operation<T, T1, T2, T3>(result);

        public static implicit operator Operation<T, T1, T2, T3>(SuccessResult<T> result) => new Operation<T, T1, T2, T3>(result.Result);

        public static implicit operator Operation<T, T1, T2, T3>(ErrorResult<T1> result) => new Operation<T, T1, T2, T3>(result);

        public static implicit operator Operation<T, T1, T2, T3>(ErrorResult<T2> result) => new Operation<T, T1, T2, T3>(result.Error);

        public static implicit operator Operation<T, T1, T2, T3>(ErrorResult<T3> result) => new Operation<T, T1, T2, T3>(result.Error);
    }
}