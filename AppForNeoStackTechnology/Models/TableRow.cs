using System.ComponentModel;

namespace AppForNeoStackTechnology.Models;

/// <summary>
/// Модель для представления строки таблицы
/// </summary>
public class TableRow : INotifyPropertyChanged
{
    private double _fX;
    
    /// <summary>
    /// Значение функции f(x, y)
    /// </summary>
    public double FX
    {
        get { return _fX; }
        set
        {
            _fX = value;
            OnPropertyChanged(nameof(FX));
        }
    }
    
    /// <summary>
    /// Значение переменной x
    /// </summary>
    private double _x;
    public double X
    {
        get { return _x; }
        set
        {
            _x = value;
            OnPropertyChanged(nameof(X));
        }
    }
    
    /// <summary>
    /// Значение переменной y
    /// </summary>
    private double _y;
    public double Y
    {
        get { return _y; }
        set
        {
            _y = value;
            OnPropertyChanged(nameof(Y));
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}