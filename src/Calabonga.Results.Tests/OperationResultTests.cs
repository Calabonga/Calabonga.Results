using AutoFixture;
using Calabonga.OperationResults;
using Xunit;

namespace Calabonga.Results.Tests;

/// <summary>
/// Operation unit-tests
/// 2024-02-05 01:04:15
/// </summary>
public class OperationResultTests : IClassFixture<ResultFixture>
{
    private readonly ResultFixture _fixture;
    private readonly Fixture _autoFixture = new();

    public OperationResultTests(ResultFixture fixture) => _fixture = fixture;

    [Fact]
    public void Operation_Should_HaveNullResult_When_TypeIsNullablePrimitiveAndDefault()
    {
        // arrange
        var sut = new Operation<int?>();

        // act

        // assert
        Assert.Null(sut.Result);
    }

    [Fact]
    public void Operation_Should_HaveDefaultResult_When_TypeIsPrimitiveAndDefault()
    {
        // arrange
        const int expected = 0;
        var sut = new Operation<int>();

        // act

        // assert
        Assert.Equal(expected, sut.Result);
    }

    [Fact]
    public void Operation_Should_HaveNullResult_When_TypeIsReferenceTypeAndDefault()
    {
        // arrange
        var sut = new Operation<Person>();

        // act

        // assert
        Assert.Null(sut.Result);
    }

    [Fact]
    public void GetIntGreaterThenZeroOrError_Should_ReturnValue_When_ArgumentGreaterThanZero()
    {
        // arrange
        const int expected = 100;

        // act
        var sut = _fixture.GetIntGreaterThenZeroOrError(expected);

        // assert
        Assert.Equal(expected, sut);
    }

    [Fact]
    public void GetIntGreaterThenZeroOrError_Should_ReturnErrorMessage_When_ArgumentLessThanZero()
    {
        // arrange

        // act
        var sut = _fixture.GetIntGreaterThenZeroOrError(-1);

        // assert
        Assert.Equal("Error", sut.Error);
    }

    [Fact]
    public void GetIntGreaterThenZeroOrError_ShouldNot_ReturnErrorMessage_When_ArgumentEqualsZero()
    {
        // arrange
        const int expected = 0;

        // act
        var sut = _fixture.GetIntGreaterThenZeroOrError(expected);

        // assert
        Assert.Equal(expected, sut);
    }

    [Fact]
    public void GetSuccessResultWithPerson_Should_ReturnSuccess_When_PersonIsNotNull()
    {
        // arrange
        var expected = _autoFixture.Create<string>();

        // act
        var sut = _fixture.GetSuccessResultWithPerson(new Person { FirstName = expected });
        var actual = sut.Result.FirstName;

        // assert
        Assert.True(sut.Ok);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetSuccessResultWithPerson_Should_ReturnError_When_PersonIsNull()
    {
        // arrange

        // act
        var sut = _fixture.GetSuccessResultWithPerson(null);

        // assert
        Assert.False(sut.Ok);
        Assert.NotNull(sut.Error);
    }

    [Fact]
    public void GetResultOrMultipleErrors_Should_ReturnValue_When_ArgumentEquals100()
    {
        // arrange
        const int expected = 100;

        // act
        var sut = _fixture.GetResultOrMultipleErrors(expected);

        // assert
        Assert.True(sut.Ok);
        Assert.Equal(expected, sut.Result);
    }

    [Fact]
    public void GetResultOrMultipleErrors_Should_ReturnValue_When_ArgumentEquals200()
    {
        // arrange
        const int expected = 200;

        // act
        var sut = _fixture.GetResultOrMultipleErrors(expected);

        // assert
        Assert.True(sut.Ok);
        Assert.Equal(expected, sut.Result);
    }

    [Fact]
    public void GetResultOrMultipleErrors_Should_ReturnCustomException_When_ArgumentEquals300()
    {
        // arrange

        // act
        var sut = _fixture.GetResultOrMultipleErrors(300);

        // assert
        Assert.False(sut.Ok);
        Assert.IsType<CustomException>(sut.Error);
    }

    [Fact]
    public void GetResultOrMultipleErrors_Should_ReturnStringError_When_ArgumentIsUnmatched()
    {
        // arrange
        const string expected = "Invalid Operation";

        // act
        var sut = _fixture.GetResultOrMultipleErrors(400);

        // assert
        Assert.False(sut.Ok);
        Assert.Equal(expected, sut.Error);
    }

    [Fact]
    public void GetResultOrOneOfThreeErrors_Should_ReturnValue_When_ArgumentEquals100()
    {
        // arrange
        const int expected = 100;

        // act
        var sut = _fixture.GetResultOrOneOfThreeErrors(expected);

        // assert
        Assert.True(sut.Ok);
        Assert.Equal(expected, sut.Result);
    }

    [Fact]
    public void GetResultOrOneOfThreeErrors_Should_ReturnFirstErrorTypeValue_When_ArgumentEquals200()
    {
        // arrange
        const string expected = "Invalid Operation";

        // act
        var sut = _fixture.GetResultOrOneOfThreeErrors(200);

        // assert
        Assert.False(sut.Ok);
        Assert.IsType<string>(sut.Error);
        Assert.Equal(expected, sut.Error);
    }

    [Fact]
    public void GetResultOrOneOfThreeErrors_Should_ReturnSecondErrorTypeValue_When_ArgumentEquals300()
    {
        // arrange

        // act
        var sut = _fixture.GetResultOrOneOfThreeErrors(300);

        // assert
        Assert.False(sut.Ok);
        Assert.IsType<CustomException>(sut.Error);
    }

    [Fact]
    public void GetResultOrOneOfThreeErrors_Should_ReturnThirdErrorTypeValue_When_ArgumentIsUnmatched()
    {
        // arrange

        // act
        var sut = _fixture.GetResultOrOneOfThreeErrors(400);

        // assert
        Assert.False(sut.Ok);
        Assert.IsType<InnerCustomException>(sut.Error);
    }
}
