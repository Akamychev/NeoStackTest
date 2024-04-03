using AppForNeoStackTechnology.Models;
using AppForNeoStackTechnology.ViewModels;

namespace AppForNeoStackTechnologyTests;

public class UnitTest1
{
    /// <summary>
    /// проверяет добавление новой строки в таблицу
    /// </summary>
    [Fact] public void AddRowCommand_to_TableData()
    {
        // Arrange
        var viewModel = new MainViewModel();
        var initialCount = viewModel.TableData.Count;

        // Act
        viewModel.AddRowCommand.Execute(null);

        // Assert
        Assert.Equal(initialCount + 1, viewModel.TableData.Count);
    }
    
    /// <summary>
    /// Проверяет метод CalculateFX на корректность вычислений
    /// блок Theory содержит данные для вычислений и ожидаемый результат
    /// </summary>
    [Theory]
    [InlineData("Линейная", 2, 3, 4, 5, 6, 32)] 
    [InlineData("Квадратичная", 1, 2, 3, 4, 5, 29)] 
    [InlineData("Кубическая", 3, 4, 5, 6, 7, 849)] 
    [InlineData("4-ой степени", 4, 5, 6, 7, 8, 12170)] 
    [InlineData("5-ой степени", 5, 6, 7, 8, 9, 203213)] 
    public void CalculateFX_Return_Correct_Value(string functionName, double a, double b, double c, double x, double y, double expected)
    {
        // Arrange
        var viewModel = new MainViewModel();
        var row = new TableRow { X = x, Y = y };

        // Act
        var result = viewModel.CalculateFX(a, b, functionName, row, c);

        // Assert
        Assert.Equal(expected, result);
    }
}