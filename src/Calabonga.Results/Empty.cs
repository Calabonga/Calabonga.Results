namespace Calabonga.Results
{
    /// <summary>
    /// Empty of operation (without Value and Error fields)
    /// </summary>
    public struct Empty
    {
        public bool Ok { get; }

        private Empty(bool ok)
        {
            Ok = ok;
        }

        public static implicit operator bool(Empty empty)
        {
            return empty.Ok;
        }

        private static readonly Empty EmptySuccess = new Empty(true);

        public static implicit operator Empty(SuccessResult result)
        {
            return EmptySuccess;
        }

        private static readonly Empty EmptyError = new Empty(false);

        public static implicit operator Empty(ErrorResult result)
        {
            return EmptyError;
        }
    }

    /// <summary>
    /// Empty of operation (without Value but with Error field)
    /// </summary>
    /// <typeparam name="TError">Type of Error field</typeparam>
    public struct Empty<TError>
    {
        public readonly TError Error;

        public bool Ok { get; }

        private Empty(bool ok)
        {
            Ok = ok;
            Error = default!;
        }

        private Empty(TError error)
        {
            Ok = false;
            Error = error;
        }

        public static implicit operator bool(Empty<TError> empty)
        {
            return empty.Ok;
        }

        private static readonly Empty<TError> SuccessEmpty = new Empty<TError>(true);

        public static implicit operator Empty<TError>(SuccessResult result)
        {
            return SuccessEmpty;
        }

        public static implicit operator Empty<TError>(ErrorResult<TError> tag)
        {
            return new Empty<TError>(tag.Error);
        }
    }

    /// <summary>
    /// Empty of operation (without Value but with different Errors)
    /// </summary>
    /// <typeparam name="TError1">Type of first Error</typeparam>
    /// <typeparam name="TError2">Type of second Error</typeparam>
    public readonly struct Empty<TError1, TError2>
    {
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

        private Empty(bool ok)
        {
            Ok = ok;
            Error = null;
        }

        private Empty(object error)
        {
            Ok = false;
            Error = error;
        }

        public static implicit operator bool(Empty<TError1, TError2> empty)
        {
            return empty.Ok;
        }

        private static readonly Empty<TError1, TError2> SuccessEmpty = new Empty<TError1, TError2>(true);

        public static implicit operator Empty<TError1, TError2>(SuccessResult result)
        {
            return SuccessEmpty;
        }

        public static implicit operator Empty<TError1, TError2>(ErrorResult<TError1> result)
        {
            return new Empty<TError1, TError2>(result.Error!);
        }

        public static implicit operator Empty<TError1, TError2>(ErrorResult<TError2> result)
        {
            return new Empty<TError1, TError2>(result.Error!);
        }
    }


    /// <summary>
    /// Empty of operation (without Value but with different Errors)
    /// </summary>
    /// <typeparam name="TError1">Type of first Error</typeparam>
    /// <typeparam name="TError2">Type of second Error</typeparam>
    /// <typeparam name="TError3">Type of third Error</typeparam>
    public struct Empty<TError1, TError2, TError3>
    {
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

        private Empty(bool ok)
        {
            Ok = ok;
            Error = null;
        }

        private Empty(object error)
        {
            Ok = false;
            Error = error;
        }

        public static implicit operator bool(Empty<TError1, TError2, TError3> empty)
        {
            return empty.Ok;
        }

        private static readonly Empty<TError1, TError2, TError3> SuccessEmpty = new Empty<TError1, TError2, TError3>(true);

        public static implicit operator Empty<TError1, TError2, TError3>(SuccessResult result)
        {
            return SuccessEmpty;
        }

        public static implicit operator Empty<TError1, TError2, TError3>(ErrorResult<TError1> result)
        {
            return new Empty<TError1, TError2, TError3>(result.Error!);
        }

        public static implicit operator Empty<TError1, TError2, TError3>(ErrorResult<TError2> result)
        {
            return new Empty<TError1, TError2, TError3>(result.Error!);
        }

        public static implicit operator Empty<TError1, TError2, TError3>(ErrorResult<TError3> result)
        {
            return new Empty<TError1, TError2, TError3>(result.Error!);
        }
    }
}
