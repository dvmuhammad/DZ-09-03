using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;

namespace Dict
{
    
    class Program
    {
        class MyDictionary<TKey, TValue>  
        {
            
            int count = 0;   
            public object[] dictionary;
            TKey[] massiveTKey;    
            TValue[] massiveTValue;   
            public TKey[] massiveAddElementTKey;   
            public TValue[] massiveAddElementTValue; 
            public IEnumerable<TKey> CurrentTKey { get; }    
            public IEnumerable<TValue> CurrentTValue { get; }    
            int countCollection = 0;
            public IEnumerable CurrentDictionary { get; }

            
            public MyDictionary()
            {
                massiveTKey = new TKey[0];
                massiveTValue = new TValue[0];
                this.CurrentTKey = GetCollectionTKey();   
                this.CurrentTValue = GetCollectionTValue();   
                this.CurrentDictionary = GetCollectionDictionary();
            }

            public int Count
            {
                get
                {
                    count = massiveAddElementTKey.Length;
                    return count;
                }
            }

            public void Add(TKey paramKey, TValue paramValue)
            {
                massiveAddElementTKey = new TKey[massiveTKey.Length + 1];
                massiveAddElementTValue = new TValue[massiveTValue.Length + 1];
                for (int i = 0; i < massiveAddElementTKey.Length; i++)
                {
                    if (i < massiveAddElementTKey.Length - 1 && massiveTKey.Length != 0)
                    {
                        massiveAddElementTKey[i] = massiveTKey[i];
                        massiveAddElementTValue[i] = massiveTValue[i];
                    }
                    else
                    {
                        massiveAddElementTKey[i] = paramKey;
                        massiveTKey = massiveAddElementTKey;
                        massiveAddElementTValue[i] = paramValue;
                        massiveTValue = massiveAddElementTValue;
                    }
                }
            }

            public object this[int index]
            {
                get
                {
                    object elementCollection = null;
                    foreach (object element in this.CurrentDictionary)
                    {
                        if (index != countCollection++)
                        {
                            continue;
                        }
                        else
                        {
                            elementCollection = element;
                        }
                    }
                    countCollection = 0;             
                    return elementCollection;
                }
            }


            public object this[string index]
            {
                get
                {
                    object elementCollection = null;
                    foreach (object element in this.CurrentDictionary)
                    {
                        if (!(element.ToString().Contains(index)))
                        {
                            continue;
                        }
                        else
                        {
                            elementCollection = element;
                        }
                    }
                    countCollection = 0;             
                    return elementCollection;
                }
            }

            
            public IEnumerable<TKey> GetCollectionTKey()
            {
                foreach (TKey element in massiveAddElementTKey)
                {
                    yield return element;
                }
            }
            
            public IEnumerable<TValue> GetCollectionTValue()
            {
                foreach (TValue element in massiveAddElementTValue)
                {
                    yield return element;
                }
            }
            
            public IEnumerable GetCollectionDictionary()
            {
                string words = null;
                dictionary = new object[massiveAddElementTKey.Length];
                for (int i = 0; i < massiveAddElementTKey.Length; i++)
                {
                    words = massiveAddElementTKey[i].ToString() + " - " + massiveAddElementTValue[i].ToString();
                    dictionary[i] = words;
                }
                foreach (object element in dictionary)
                {
                    yield return element;
                }

            }

        }

        static void Main(string[] args)
        {
            Random random = new Random();  
            MyDictionary<string, string> myCollection = new MyDictionary<string, string>();  
            int count = 0;
            while (true)
            {
                Again:
                switch (count)
                {
                    case 0:
                        {
                            myCollection.Add("hello", "привет");         
                            break;
                        }
                    case 1:
                        {
                            myCollection.Add("Welcome", "Добро пожаловать");         
                            break;
                        }
                    case 2:
                        {
                            myCollection.Add("World", "Мир");         
                            break;
                        }
                    case 3:
                        {
                            myCollection.Add("Bread", "Хлеб");         
                            break;
                        }
                    case 4:
                        {
                            myCollection.Add("Spring", "Весна");         
                            break;
                        }
                    case 5:
                        {
                            myCollection.Add("Table", "Стол");         
                            break;
                        }
                    case 6:
                        {
                            myCollection.Add("Shame", "Стыд");         
                            break;
                        }
                    case 7:
                        {
                            myCollection.Add("Moon", "Луна");         
                            break;
                        }
                    case 8:
                        {
                            myCollection.Add("Star", "Звезда");         
                            break;
                        }
                    case 9:
                        {
                            myCollection.Add("Sky", "Небо");         
                            break;
                        }
                    default:
                        {
                            count = 0;
                            goto Again;
                        }
                }
                int countTwo = 0;
                foreach (string dictionary in myCollection.CurrentDictionary)      
                {
                    Console.WriteLine("index[{0}]: " + dictionary, countTwo++);       
                    if (myCollection.Count == countTwo)
                    {
                        Console.WriteLine(new string('-', 50));
                        Thread.Sleep(1000);                          
                        int index = random.Next(0, myCollection.Count);
                        Console.WriteLine("Item by index[{0}] - " + myCollection[index], index);      
                        int indexTwo = random.Next(0, myCollection.Count);
                        string indexword = null;
                        if (indexTwo % 2 == 0)
                        {
                            indexword = myCollection.massiveAddElementTValue[indexTwo];   
                        }
                        else
                        {
                            indexword = myCollection.massiveAddElementTKey[indexTwo];     
                        }
                        Console.WriteLine("Item by index[{0}] - " + myCollection[indexword], indexword);      


                        Console.WriteLine("Count all elements collection: " + myCollection.Count);    
                        Thread.Sleep(3000);
                        break;                                            
                    }
                    Thread.Sleep(100);
                }
                count++;
                Console.WriteLine(new string('*', 50));                      
                Console.WriteLine(new string('*', 50));
                
            }
        }
    }
}