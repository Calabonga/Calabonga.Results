namespace Calabonga.Results
{
    /// <summary>
    /// OperationEmpty of operation (without Result and Error fields)
    /// </summary>
    public struct OperationEmpty
    {
        public bool Ok { get; }

        private OperationEmpty(bool ok)
        {
            Ok = ok;
        }

        public static implicit operator bool(OperationEmpty operationEmpty)
        {
            return operationEmpty.Ok;
        }

        private static readonly OperationEmpty Result = new OperationEmpty(true);

        public static implicit operator OperationEmpty(SuccessResult result)
        {
            return Result;
        }

        private static readonly OperationEmpty Error = new OperationEmpty(false);

        public static implicit operator OperationEmpty(ErrorResult result)
        {
            return Error;
        }
    }

    /// <summary>
    /// OperationEmpty of operation (without Result but with Error field)
    /// </summary>
    /// <typeparam name="T">Type of Error field</typeparam>
    public struct OperationEmpty<T>
    {
        public readonly T Error;

        public bool Ok { get; }

        private OperationEmpty(bool ok)
        {
            Ok = ok;
            Error = default!;
        }

        private OperationEmpty(T error)
        {
            Ok = false;
            Error = error;
        }

        public static implicit operator bool(OperationEmpty<T> operationEmpty)
        {
            return operationEmpty.Ok;
        }

        private static readonly OperationEmpty<T> Result = new OperationEmpty<T>(true);

        public static implicit operator OperationEmpty<T>(SuccessResult result)
        {
            return Result;
        }

        public static implicit operator OperationEmpty<T>(ErrorResult<T> tag)
        {
            return new OperationEmpty<T>(tag.Error);
        }
    }

    /// <summary>
    /// OperationEmpty of operation (without Result but with different Errors)
    /// </summary>
    /// <typeparam name="T">Type of first Error</typeparam>
    /// <typeparam name="T1">Type of second Error</typeparam>
    public readonly struct OperationEmpty<T, T1>
    {
        public readonly object? Error;

        public bool Ok { get; }

        private OperationEmpty(bool ok)
        {
            Ok = ok;
            Error = null;
        }

        private OperationEmpty(object error)
        {
            Ok = false;
            Error = error;
        }

        public static implicit operator bool(OperationEmpty<T, T1> operationEmpty)
        {
            return operationEmpty.Ok;
        }

        private static readonly OperationEmpty<T, T1> Result = new OperationEmpty<T, T1>(true);

        public static implicit operator OperationEmpty<T, T1>(SuccessResult result)
        {
            return Result;
        }

        public static implicit operator OperationEmpty<T, T1>(ErrorResult<T> result)
        {
            return new OperationEmpty<T, T1>(result.Error!);
        }

        public static implicit operator OperationEmpty<T, T1>(ErrorResult<T1> result)
        {
            return new OperationEmpty<T, T1>(result.Error!);
        }
    }

    /// <summary>
    /// OperationEmpty of operation (without Result but with different Errors)
    /// </summary>
    /// <typeparam name="T">Type of first Error</typeparam>
    /// <typeparam name="T1">Type of second Error</typeparam>
    /// <typeparam name="T2">Type of third Error</typeparam>
    public readonly struct OperationEmpty<T, T1, T2>
    {
        public readonly object? Error;

        public bool Ok { get; }


        private OperationEmpty(bool ok)
        {
            Ok = ok;
            Error = null;
        }

        private OperationEmpty(object error)
        {
            Ok = false;
            Error = error;
        }

        public static implicit operator bool(OperationEmpty<T, T1, T2> operationEmpty)
        {
            return operationEmpty.Ok;
        }

        private static readonly OperationEmpty<T, T1, T2> Result = new OperationEmpty<T, T1, T2>(true);

        public static implicit operator OperationEmpty<T, T1, T2>(SuccessResult result)
        {
            return Result;
        }

        public static implicit operator OperationEmpty<T, T1, T2>(ErrorResult<T> result)
        {
            return new OperationEmpty<T, T1, T2>(result.Error!);
        }

        public static implicit operator OperationEmpty<T, T1, T2>(ErrorResult<T1> result)
        {
            return new OperationEmpty<T, T1, T2>(result.Error!);
        }

        public static implicit operator OperationEmpty<T, T1, T2>(ErrorResult<T2> result)
        {
            return new OperationEmpty<T, T1, T2>(result.Error!);
        }
    }
}
