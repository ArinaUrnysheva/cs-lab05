using System;
using System.Collections;

public class MyList<T> :IEnumerable<T>
{ 
    private T[] items;
    private int _count;
    private const int _initialCapacity = 4; // Начальная емкость

    // Конструктор по умолчанию
    public MyList()
    {
        items = new T[_initialCapacity];
        _count = 0;
    }

    // Индексатор для доступа к элементам
    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= _count)
                throw new IndexOutOfRangeException("Индекс находится вне диапазона.");
            return items[index];
        }
        set
        {
            if (index < 0 || index >= _count)
                throw new IndexOutOfRangeException("Индекс находится вне диапазона.");
            items[index] = value;
        }
    }

    // Свойство для получения общего количества элементов
    public int Count => _count;

    // Метод для добавления элемента
    public void Add(T item)
    {
        if (_count == items.Length)
        {
            Resize();
        }
        items[_count++] = item;
    }

    // Метод для изменения размера массива
    private void Resize()
    {
        int newCapacity = items.Length * 2; // Увеличиваем размер в 2 раза
        T[] newItems = new T[newCapacity];
        Array.Copy(items, newItems, _count);
        items = newItems;
    }

    // Метод для инициализации коллекции
    public void Initialize(params T[] items)
    {
        foreach (var item in items)
        {
            Add(item);
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
       return items.ToList().GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Пример использования MyList
        MyList<int> myList = new MyList<int>();

        // Добавляем элементы
        myList.Add(1);
        myList.Add(2);
        myList.Add(3);

        // Вывод количества элементов
        Console.WriteLine("Количество элементов: " + myList.Count);

        // Получаем элемент по индексу
        Console.WriteLine("Элемент по индексу 1: " + myList[1]);

        // Инициализация коллекции
        MyList<string> stringList = new MyList<string>();
        stringList.Initialize("Hello", "World", "!");

        Console.WriteLine("Количество строк в stringList: " + stringList.Count);
        for (int i = 0; i < stringList.Count; i++)
        {
            Console.WriteLine("Элемент по индексу " + i + ": " + stringList[i]);
        }
    }
}