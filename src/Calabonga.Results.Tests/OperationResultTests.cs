using Xunit;

namespace Calabonga.Results.Tests;

/// <summary>
/// Operation unit-tests
/// 2024-02-05 01:04:15
/// </summary>
public class OperationResultTests : IClassFixture<ResultFixture>
{
    private readonly ResultFixture _fixture;

    public OperationResultTests(ResultFixture fixture) => _fixture = fixture;


    [Fact]
    public void ItShould_create_operation_instance_with_primitive_default_result_nullable()
    {
        // arrange
        var sut = new Operation<int?>();

        // act

        // assert
        Assert.Null(sut.Result);
    }


    [Fact]
    public void ItShould_create_operation_instance_with_primitive_default_result()
    {
        // arrange
        const int expected = 0;
        var sut = new Operation<int>();

        // act

        // assert
        Assert.Equal(expected, sut.Result);
    }

    [Fact]
    public void ItShould_create_operation_instance_with_class_default_result_nullable()
    {
        // arrange
        var sut = new Operation<Person>();

        // act

        // assert
        Assert.Null(sut.Result);
    }

    [Fact]
    public void ItShould_ReturnsValue_WhenParamsGreaterThen0()
    {
        // arrange
        const int expected = 100;
        var sut = _fixture.GetIntGreaterThenZeroOrError(100);

        // act

        // assert
        Assert.Equal(expected, sut);
    }

    [Fact]
    public void ItShould_ReturnsErrorMessage_WhenParamsLessThan0()
    {
        // arrange
        var sut = _fixture.GetIntGreaterThenZeroOrError(-1);

        // act

        // assert
        Assert.Equal("Error", sut.Error);
    }

    [Fact]
    public void ItShouldNot_ReturnsErrorMessage_WhenParamsEqual0()
    {
        // arrange
        const int expected = 0;
        var sut = _fixture.GetIntGreaterThenZeroOrError(0);

        // act

        // assert
        Assert.Equal(expected, sut);
    }
}