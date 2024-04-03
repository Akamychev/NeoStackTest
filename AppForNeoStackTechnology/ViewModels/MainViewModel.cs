using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using AppForNeoStackTechnology.Models;

namespace AppForNeoStackTechnology.ViewModels;

/// <summary>
/// Модель представления окна
/// </summary>
public class MainViewModel : INotifyPropertyChanged
{
    /// <summary>
    /// Инициализация нового экземпляра класса
    /// </summary>
    public MainViewModel()
    {
        Functions = new ObservableCollection<Function>
        {
            new Function("Линейная", new List<double> { 1.0, 2.0, 3.0, 4.0, 5.0 },
                0, 0, 0),
            new Function("Квадратичная", new List<double> { 10.0, 20.0, 30.0, 40.0, 50.0 },
                0, 0, 0),
            new Function("Кубическая", new List<double> { 100.0, 200.0, 300.0, 400.0, 500.0 },
                0, 0, 0),
            new Function("4-ой степени", new List<double> { 1000.0, 2000.0, 3000.0, 4000.0, 5000.0 },
                0, 0, 0),
            new Function("5-ой степени", new List<double> { 10000.0, 20000.0, 30000.0, 40000.0, 50000.0 },
                0, 0, 0)
        };

        TableData = new ObservableCollection<TableRow>();

        AddRowCommand = new RelayCommand(AddRow);
        CalculateResultCommand = new RelayCommand(CalculateResult);
    }
    
    /// <summary>
    /// Список доступных функций
    /// </summary>
    public ObservableCollection<Function> Functions { get; set; }

    private Function _selectedFunction;
    
    /// <summary>
    /// Выбранная функция
    /// </summary>
    public Function SelectedFunction
    {
        get { return _selectedFunction; }
        set
        {
            _selectedFunction = value;
            OnPropertyChanged(nameof(SelectedFunction));
            
            if (value != null)
            {
                Coefficients = new ObservableCollection<double>(value.Coefficients);
                SelectedCoefficient = value.SelectedCoefficient;
                A = value.A;
                B = value.B;
            }
        }
    }
    
    /// <summary>
    /// Доступные коэффициенты функции
    /// </summary>
    private ObservableCollection<double> _coefficients;

    public ObservableCollection<double> Coefficients
    {
        get { return _coefficients; }
        set
        {
            _coefficients = value;
            OnPropertyChanged(nameof(Coefficients));
        }
    }
    
    /// <summary>
    /// Коэффициент А
    /// </summary>
    private double _a;

    public double A
    {
        get { return _a;}
        set
        {
            _a = value;
            OnPropertyChanged(nameof(A));
            if (SelectedFunction != null)
            {
                SelectedFunction.A = value;
            }
        }
    }
    
    /// <summary>
    /// Коэффициент B
    /// </summary>
    private double _b;

    public double B
    {
        get { return _b;}
        set
        {
            _b = value;
            OnPropertyChanged(nameof(B));
            if (SelectedFunction != null)
            {
                SelectedFunction.B = value;
            }
        }
    }
    
    /// <summary>
    /// Выбранный коэффициент С
    /// </summary>
    private double _selectedCoefficient;

    public double SelectedCoefficient
    {
        get { return _selectedCoefficient; }
        set
        {
            _selectedCoefficient = value;
            OnPropertyChanged(nameof(SelectedCoefficient));
            if (SelectedFunction != null)
                SelectedFunction.SelectedCoefficient = value;

        }
    }

    /// <summary>
    /// Команда для добавления строки
    /// </summary>
    public ICommand AddRowCommand { get; }
    
    /// <summary>
    /// Команда для расчёта результата
    /// </summary>
    public ICommand CalculateResultCommand { get; }
    
    /// <summary>
    /// Табличные данные
    /// </summary>
    public ObservableCollection<TableRow> TableData { get; set; }
    
    /// <summary>
    /// Событие изменения свойств
    /// </summary>
    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    /// <summary>
    /// Добавление строки в таблицу
    /// </summary>
    private void AddRow()
    {
        var newRow = new TableRow
        {
            X = 0,
            Y = 0
        };

        TableData.Add(newRow);
    }

    /// <summary>
    /// Расчет результата
    /// </summary>
    private void CalculateResult()
    {

        if (SelectedFunction != null && Coefficients != null && Coefficients.Count > 0)
        {
            {
                foreach (var row in TableData)
                {
                    row.FX = CalculateFX(SelectedFunction.A, SelectedFunction.B, SelectedFunction.Name, row, SelectedFunction.SelectedCoefficient);
                }
            }
        }
    }
    
    /// <summary>
    /// Рассчет функции
    /// </summary>
    public double CalculateFX(double a, double b, string functionName, TableRow row, double c)
    {
        Console.WriteLine($"a = {a}, b = {b}, functionName = {functionName}, row.X = {row.X}, row.Y = {row.Y}, C = {c}");
        
        switch (functionName)
        {
            case "Линейная":
                return a * row.X + b * row.Y + c;
            case "Квадратичная":
                return a * Math.Pow(row.X, 2) + b * row.Y + c;
            case "Кубическая":
                return a * Math.Pow(row.X, 3) + b * Math.Pow(row.Y, 2) + c;
            case "4-ой степени":
                return a * Math.Pow(row.X, 4) + b * Math.Pow(row.Y, 3) + c;
            case "5-ой степени":
                return a * Math.Pow(row.X, 5) + b * Math.Pow(row.Y, 4) + c;
            default:
                return 0;
        }
    }
}