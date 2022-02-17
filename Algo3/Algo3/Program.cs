using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;


namespace Hell_Work2._0
{
    class Program
    {
        static void Main(string[] args)
        {
           
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
       
        }
    }
    
    [MemoryDiagnoser]
    [RankColumn]
    

    

public class BenchmarkClass
{
    #region ---- FIELDS ----

    /// <summary>Минимальное возможное значение координат</summary>
    private const int MIN = -10000;
    /// <summary>Максимальное возможное значение координат</summary>
    private const int MAX = 10000;
    /// <summary>Количество элементов в массиве со случайными координатами</summary>
    private const int ELEMENTS = 100000;
    /// <summary>Указатель для перебора кординат в массиве</summary>
    private int pointer = 0;

    
    /// <summary>Массив содержащий случайные double значения координат</summary>
    private double[] randomDoubleCoordinates = new double[ELEMENTS];

    #endregion

    
    

    

    #region ---- CONSTRUCTORS ----

    /// <summary>
    /// Конструктор заполняющий массив координат случайной информацией
    /// </summary>
    public BenchmarkClass()
    {
        ///Заполняем массив случайными числами
        Random rnd = new Random();
        for (int i = 0; i < ELEMENTS; i++)
        {
            
            randomDoubleCoordinates[i] = (rnd.NextDouble() * (MAX - MIN) - MAX);
        }
        pointer = rnd.Next(ELEMENTS); //Рандомизируем указатель в массиве.
    }

    

    


   

    /// <summary>
    /// Выдает два числа из массива float координат и сдвигает его указатель на следующую позицию
    /// </summary>
    /// <returns>Кортеж с двумя float координатами</returns>
    public (double, double) giveMeDoubleCoordinates()
    {
        if (pointer > ELEMENTS - 4)
            pointer = 0;
        else
            pointer += 2;
        return (randomDoubleCoordinates[pointer], randomDoubleCoordinates[pointer + 1]);
    }

    #endregion

    #region ---- DATA TYPES ----

    

    /// <summary>Точка с координатами виде класса со сзначениями X, Y во double</summary>
    public class PointClassDouble
    {
        public double X { get; set; }
        public double Y { get; set; }

        public PointClassDouble((double x, double y) coord)
        {
            X = coord.x;
            Y = coord.y;
        }
    }


    

    /// <summary>Точка с координатами виде структуры со сзначениями X, Y в double</summary>
    public struct PointStructDouble
    {
        public double X;
        public double Y;
        public PointStructDouble((double x, double y) coord)
        {
            X = coord.x;
            Y = coord.y;
        }

    }

    #endregion

    #region ---- TESTED METHODS ----

    /// <summary>Рассчет расстояния между двумя точками реализованными классов в double</summary>
    /// <param name="pointOne">Точка 1</param>
    /// <param name="pointTwo">Точка 2</param>
    /// <returns>Расстояние между точками</returns>
    public double PointDistanceClassDouble(PointClassDouble pointOne, PointClassDouble pointTwo)
    {
        double x = pointOne.X - pointTwo.X;
        double y = pointOne.Y - pointTwo.Y;
        return Math.Sqrt((x * x) + (y * y));
    }



    /// <summary>Рассчет расстояния между двумя точками реализованными структурами в double</summary>
    /// <param name="pointOne">Точка 1</param>
    /// <param name="pointTwo">Точка 2</param>
    /// <returns>Расстояние между точками</returns>
    public double PointDistanceStructDouble(PointStructDouble pointOne, PointStructDouble pointTwo)
    {
        double x = pointOne.X - pointTwo.X;
        double y = pointOne.Y - pointTwo.Y;
        return Math.Sqrt((x * x) + (y * y));
    }

    
    

    /// <summary>Рассчет квадрата расстояния между двумя точками реализованными структурами во double</summary>
    /// <param name="pointOne">Точка 1</param>
    /// <param name="pointTwo">Точка 2</param>
    /// <returns>Квадрат расстояния между точками</returns>
    public double PointDistanceShortStructDouble(PointStructDouble pointOne, PointStructDouble pointTwo)
    {
        double x = pointOne.X - pointTwo.X;
        double y = pointOne.Y - pointTwo.Y;
        return ((x * x) + (y * y));
    }

    

    [Benchmark(Description = "Расстояние через классы double")]
    public void TestPointDistanceClassDouble()
    {
        PointClassDouble pointOne = new PointClassDouble(giveMeDoubleCoordinates());
        PointClassDouble pointTwo = new PointClassDouble(giveMeDoubleCoordinates());
        PointDistanceClassDouble(pointOne, pointTwo);
    }

    

    [Benchmark(Description = "Расстояние через структуры double")]
    public void TestPointDistanceStructDouble()
    {
        PointStructDouble pointOne = new PointStructDouble(giveMeDoubleCoordinates());
        PointStructDouble pointTwo = new PointStructDouble(giveMeDoubleCoordinates());
        PointDistanceStructDouble(pointOne, pointTwo);
    }

    
    
    [Benchmark(Description = "Квадрат расстояния через структуры double")]
    public void TestPointDistanceShortStructDouble()
    {
        PointStructDouble pointOne = new PointStructDouble(giveMeDoubleCoordinates());
        PointStructDouble pointTwo = new PointStructDouble(giveMeDoubleCoordinates());
        PointDistanceShortStructDouble(pointOne, pointTwo);
    }

        #endregion

    }
}





