namespace Calabonga.Results.Tests;

public class ResultFixture
{
    internal Operation<Person, string> GetIntOrError(Person? person)
    {
        if (person is null)
        {
            return Operation.Error("Some error");
        }

        return Operation.Success(person);
    }

    internal Operation<int, string> GetIntGreaterThenZeroOrError(int selectMode)
    {
        if (selectMode >= 0)
        {
            return Operation.Success(selectMode);
        }

        return Operation.Error("Error");
    }

    internal Operation<int, string, CustomException> GetResultOrMultipleErrors(int arg)
    {
        if (arg == 100)
        {
            return arg;
        }
        if (arg == 200)
        {
            return Operation.Success(arg);
        }
        if (arg == 300)
        {
            return Operation.Error(new CustomException("Custom exception"));
        }
        return Operation.Error("Invalid Operation");
    }
}