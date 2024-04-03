using System.Collections.Generic;

namespace AppForNeoStackTechnology.Models;

/// <summary>
/// Модель для представления функции
/// </summary>
public class Function
{
    /// <summary>
    /// Название функции
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Коэффициенты для списка С
    /// </summary>
    public List<double> Coefficients { get; set; }
    
    /// <summary>
    /// Коэффициент A функции
    /// </summary>
    public double A { get; set; }
    
    /// <summary>
    /// Коэффициент B функции
    /// </summary>
    public double B { get; set; }
    
    /// <summary>
    /// Выбранный коэффициент списка С
    /// </summary>
    public double SelectedCoefficient { get; set; }
    
    /// <summary>
    /// Конструктор класса
    /// </summary>
    public Function(string name, List<double> coefficients, double a, double b, double selectedCoefficient)
    {
        Name = name;
        Coefficients = coefficients;
        A = a;
        B = b;
        SelectedCoefficient = selectedCoefficient;
    }
}