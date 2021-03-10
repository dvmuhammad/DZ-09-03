using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    static class MyClass
    {
        public static T[] GetArray<T>(this IEnumerable<T> list)
        {
            T[] result = new T[list.Count()];
            int i = 0;
            foreach (var item in list)
            {
                result[i] = item;
                i++;
            }
            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> list = new MyList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            foreach(var item in list)
            {
                Console.WriteLine(item);
            }
            list.Remove(3);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            int[] array = list.GetArray();

            Console.ReadKey();
        }
    }
    class MyList<T> : IEnumerable<T>
    {
        T[] array;
        int position = -1;

        public MyList()
        {
            array = new T[0];
        }

        public int Size => array.Length;

        public T this[int index]
        {
            get
            {
                if(index >= 0 && index < array.Length)
                {
                    return array[index];
                } else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public void Add(T item)
        {
            T[] temp = new T[array.Length + 1];
            array.CopyTo(temp, 0);
            temp[array.Length] = item;
            array = temp;
        }

        public void Remove(T item)
        {
            if(array.Contains(item))
            {
                int indexItem = Array.FindIndex(array, (i) => i.Equals(item));
                T[] temp = new T[array.Length - 1];
                for (int i = 0, j = 0; i < array.Length; i++)
                {
                    if(indexItem != i)
                    {
                        temp[j] = array[i];
                        j++;
                    }
                }
                array = temp;
            } else
            {
                Console.WriteLine("Заданный элемент не найден");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            while(true)
            {
                if(position < array.Length - 1)
                {
                    position++;
                    yield return array[position];
                } else
                {
                    position = -1;
                    yield break;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
