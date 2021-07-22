using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace CodewarsCSharpSolutions
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { -4, 0, 14, -8, 4, -2, 14, 3, 15, -5, 8, -1, 15, 0, -15, -1, -3, -8, 1, -1 };
            String students = "Tadashi Takahiro Takao Takashi Takayuki Takehiko Takeo Takeshi Takeshi";
            Console.WriteLine(IQ.Test("2 4 7 8 10"));
            //int[] newArrayASC = InsertionSortASC(array);
            //int[] newArrayDESC = InsertionSortDESC(array);
            int a = MostFrequentItemCount(array);

            //Console.WriteLine("встречается раз: " + a);

            //foreach (int i in newArrayASC)
            //{
            //    Console.WriteLine(i);
            //}

            //String[] correctList = LineupStudents(students);

            //foreach (string i in correctList)
            //{
            //    Console.WriteLine(i + " Длина этой строки: " + i.Length.ToString());
            //}

        }
        // СОРТИРОВКА ВСТАВКАМИ

        public static int[] InsertionSortASC(int[] array)
        {
            for(int j = 1; j < array.Length; j++) //начинаем сортировку со 2го элемента
            {
                int key = array[j]; //ключ - текущий элемент | 3
                int i = j; //индекс текущего элемента | 2

                while(i > 0 && array[i-1] > key) // если сосед стоит перед ключом и меньше 0, | то 9 > 3
                {
                    var temp = array[i - 1]; //запоминаем его | 9
                    array[i - 1] = array[i]; //заменяем его на текущий | 3
                    array[i] = temp; // а текущий на тот, что был перед ним | 9
                    i--; //повторяем пока i не равно 0 и больше ключа | 1
                }

                array[i] = key; //перезаписываем ключ на новое место или оставляем на своем | 1 = 3
            }

            return array;
        }

        public static int[] InsertionSortDESC(int[] array)
        {
            for (int j = 1; j < array.Length; j++) //начинаем сортировку со 2го элемента
            {
                int key = array[j]; //ключ - текущий элемент | 4
                int i = j; //индекс текущего элемента | 3

                while (i > 0 && array[i - 1] < key) // если сосед стоит перед ключом и меньше 0, | то 3 < 4
                {
                    var temp = array[i]; //запоминаем его | 4
                    array[i] = array[i-1]; //заменяем его на текущий | 4 -> 3
                    array[i-1] = temp; // а текущий на тот, что был перед ним | 3 -> 4
                    i--; //повторяем пока i не равно 0 и больше ключа | 1
                }

                array[i] = key; //перезаписываем ключ на новое место или оставляем на своем 
            }

            return array;
        }

        //codewars SUZUKI SOLUTION
//        Suzuki needs help lining up his students!

//Today Suzuki will be interviewing his students to ensure they are progressing in their training.He decided to schedule the interviews based on the length of the students name in descending order. The students will line up and wait for their turn.

//You will be given a string of student names. Sort them and return a list of names in descending order.

//Here is an example input:

//string = 'Tadashi Takahiro Takao Takashi Takayuki Takehiko Takeo Takeshi Takeshi'
//Here is an example return from your function:

// lst = ['Takehiko',
//        'Takayuki',
//        'Takahiro',
//        'Takeshi',
//        'Takeshi',
//        'Takashi',
//        'Tadashi',
//        'Takeo',
//        'Takao']
//Names of equal length will be returned in reverse alphabetical order (Z->A) such that:

//string = "xxa xxb xxc xxd xa xb xc xd"
//Returns

//['xxd', 'xxc', 'xxb', 'xxa', 'xd', 'xc', 'xb', 'xa']
        public static string[] LineupStudents(string a)
        {
            string[] names = a.Split(" ");

            for (int i = 1; i < names.Length; i++)
            {
                string key = names[i]; 

                int j = i;

                while (j > 0 && names[j-1].Length < key.Length)
                {
                    var temp = names[j - 1];
                    names[j - 1] = names[j];
                    names[j] = temp;
                    j--;
                }

                names[j] = key;

            }
            for (int j = 0; j < names.Length; j++)
            {
                for (int i = 0; i < names.Length - 1; i++)
                {
                    if (String.Compare(names[i + 1], names[i]) > 0 && names[i + 1].Length == names[i].Length)
                    {
                        var temp = names[i + 1];
                        names[i + 1] = names[i];
                        names[i] = temp;
                    }
                }
            }

            return names;
        }

        // можно еще так

        public static string[] LineupStudentsLINQ(string a)
        {
            return a.Split().OrderBy(s => -s.Length).ThenByDescending(s => s).ToArray();
        }

        //__________________

//        Description:
//Complete the function to find the count of the most frequent item of an array.You can assume that input is an array of integers.For an empty array return 0


//Example
//input array: [3, -1, -1, -1, 2, 3, -1, 3, -1, 2, 4, 9, 3]
//ouptut: 5 
//The most frequent number in the array is -1 and it occurs 5 times.
        public static int MostFrequentItemCount(int[] collection)
        {

            Dictionary<int, int> items = new Dictionary<int, int>(collection.Length);
            int maxCount = 0;
          

            foreach (int i in collection)
            {
                int count = items.GetValueOrDefault(i, 0);
                count++;
                if(count > maxCount)
                {
                    maxCount = count;
                }
                items[i] = count;
            }

            return maxCount;

        }

    }
}
