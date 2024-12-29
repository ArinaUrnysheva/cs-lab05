using System;
using System.Globalization;

public class MyMatrix
{
    private int m; //строки
    private int n; //столбцы
    private int[,] Matrix;
    private int d1;
    private int d2;
    private Random rand;


    public MyMatrix(int M, int N, int D1, int D2) //конструктор
    {
        if (M <= 0 || N <= 0)
        {
            throw new ArgumentException("Количество строк и столбцов должны быть положительными");
        }

        if(D1 > D2)
        {
            throw new ArgumentException("Минимальное значение не должно быть больше максимального");
        }

        m = M;
        n = N;
        Matrix = new int[M, N];
        rand = new Random();
        d1 = D1;
        d2 = D2;

        for(int i = 0; i < M; ++i) //заполнение матрицы случайными числами из диапазона d1 - d2
        {
            for(int j = 0; j < N; ++j)
            {
                Matrix[i, j] = rand.Next(D1, D2);
            }
        }
    }

    public int this[int m, int n] //индексатор
    {
        get => Matrix[m, n]; //аксессор
        set => Matrix[m, n] = value; //мутатор
    }

    public void Fill() //перезаполнение матрицы случайными числами
    {
        for(int i = 0; i < m; ++i)
        {
            for(int j = 0; j < n; ++j)
            {
                Matrix[i, j] = rand.Next();
            }
        }
    }

    public void ChangeSize(int NewM, int NewN) //изменение размера матрицы
    {
        if(NewM <= 0 || NewN <= 0)
        {
            throw new ArgumentException("Новое количество строк и столбцов должно быть положительным");
        }

        int[,] newMatrix = new int[NewM, NewN]; //создание новой матрицы

        //копирование старой матрицы в новую
        for(int i = 0; i < Math.Min(NewM, m); ++i)
        {
            for(int j = 0; j < Math.Min(NewN, n); ++j)
            {
                newMatrix[i, j] = Matrix[i, j];
            }
        }
        Matrix = newMatrix;

        //если новая матрица больше старой
        if(NewM > m || NewN > n)
        {
            m = NewM;
            n = NewN;
            Fill();
        }

        m = NewM;
        n = NewN;
    }

    public void ShowPartial(int startn, int endn, int startm, int endm) //вывод частичной матрицы
    {
        if(endn > n || endm > m)
        {
            throw new AbandonedMutexException("Число выводимых строк и столбцов не должно превышать m и n");
        }
        for(int i = startm; i < endm; ++i)
        {
            for(int j = startn; j < endn; ++j)
            {
                Console.Write(Matrix[i, j] + '\t');
            }
            Console.WriteLine();
        }
    }
    public void Show() //печать матрицы
    {
        for(int i = 0; i < m; ++i)
        {
            for(int j = 0; j < m; ++j)
            {
                Console.Write(Matrix[i, j] + ' ' + '\t');
            }
            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите число строк матрицы: ");
        int m = int.Parse(Console.ReadLine());
        Console.WriteLine();
        Console.Write("Введите число столбцов матрицы: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Введите минимальное число диапазона: ");
        int d1 = int.Parse(Console.ReadLine());
        Console.WriteLine();
        Console.Write("Введите максимальное число диапазона: ");
        int d2 = int.Parse(Console.ReadLine());
        Console.WriteLine();
        MyMatrix matrix = new MyMatrix(m, n, d1, d2); 
        Console.WriteLine("Матрица:");
        matrix.Show();
        Console.WriteLine("Введите номер минимально выводимой строки: ");
        int startm = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите номер минимально выводимого столбца: ");
        int startn = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите номер максимально выводимой строки: ");
        int endm = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите номер максимально выводимого столбца: ");
        int endn = int.Parse(Console.ReadLine());
        Console.WriteLine("Частично выведенная матрица: ");
        matrix.ShowPartial(startm, startn, endm, endn);
        Console.WriteLine("Введите новое количество строк матрицы: ");
        int newm = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите новое количество столбцов матрицы: ");
        int newn = int.Parse(Console.ReadLine());
        matrix.ChangeSize(newm, newn);
        Console.WriteLine("Новая матрица: ");
        matrix.Show();
    }
}