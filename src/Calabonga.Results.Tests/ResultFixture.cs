namespace Calabonga.Results.Tests;

public class ResultFixture
{
    internal Operation<Person, string> GetSuccessResultWithPerson(Person? person)
    {
        if (person is null)
        {
            return Operation.Error("Some error");
        }

        return Operation.Result(person);
    }

    internal Operation<int, string> GetIntGreaterThenZeroOrError(int selectMode)
    {
        if (selectMode >= 0)
        {
            return Operation.Result(selectMode);
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
            return Operation.Result(arg);
        }
        if (arg == 300)
        {
            return Operation.Error(new CustomException("Custom exception"));
        }
        return Operation.Error("Invalid Operation");
    }
}