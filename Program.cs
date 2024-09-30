/*Запрашивать у пользователя числа до тех пор пока пользователь не введёт букву Q
Числа добавляются в массив, в случае переполнения массива (кончилось начальное количество элементов) массив необходимо расширить (сохранив все введённые до этого значения) и продолжить записывать данные пользователя
После ввода буквы Q вывести на экран все введённые данные пользователем

В случае если пользователь ввёл данные неверно, программа не должна прекращать своё выполнение, а должна вывести информацию на экран и продолжить запрашивать данные от пользователя

Запросить что он хочет делать:
Очистить
Продолжить
Выйти

В случае Продолжить: продолжаем принимать данные от пользователя
В случае Очистить: Очищаем массив данных и снова спрашиваем у пользователя, что он хочет делать дальше
В случае Выйти: Завершаем программу, с выводом информации о том сколько пользователь ввёл элементов (количество) и количество совершённых им ошибок*/


int[] arr = new int[5];
do
{
    char c = 'Q'; //символ выхода в меню
    int count = 0; //счетчик кол-ва чисел в массиве
    int warn = 0; //счетчик кол-ва ошибок пользователя
    Console.WriteLine("Введите число:");
    for (int i = 0; i <= arr.Length; i++)
    {
        //Если массив переполнен,
        if (arr.Length >= i)
        {
            //то расширяем его
            Array.Resize(ref arr, i + 10);
        }
        string? input = Console.ReadLine();

        if (!input.StartsWith(c.ToString()) && !int.TryParse(input, out int number))
        {
            Console.WriteLine("Введено не число!");
            //очищаем последний ввод в массиве
            Array.Clear(arr, arr[i], arr[i]);
            i--;//не будем записывать значение в массив
            warn++;            
            continue;
        }
        else
        {
            try
            {
                //Если введено число, запишем его в массив
                if (int.TryParse(input, out int numbers))
                {
                    arr[i] = numbers;
                    count++;
                }
                // Если введен символ Q, то выведем данные из массива и меню
                if (input.StartsWith(c.ToString()))
                {
                    i--;//не будем записывать значение Q в массив
                    Console.WriteLine("----------------------------");
                    Console.WriteLine($"Данные в массиве:");
                    for (int j = 0; j <= count - 1; j++)
                    {
                        Console.WriteLine($"{arr[j]} ");
                    }
                    Console.WriteLine("----------------------------");
                    Console.WriteLine($"МЕНЮ:\nОчистить - 1 \nПродолжить - 2\nВыйти - 3");
                    string? inputNum = Console.ReadLine();
                    if (int.TryParse(inputNum, out int pointMenu))
                    {
                        //Если пользователяь выбрал Очистить,
                        if (inputNum == "1")
                        {
                            //то очистим массив
                            Array.Clear(arr, 0, arr.Length);
                            break;
                        }
                        if (inputNum == "2")
                        {
                            Array.Clear(arr, arr[i], arr[i]);
                            continue;
                        }
                        if (inputNum == "3")
                        {
                            Console.WriteLine("****************************");
                            Console.WriteLine($"Данные в массиве:");
                            for (int k = 0; k <= count - 1; k++)
                            {
                                Console.WriteLine($"{arr[k]} ");
                            }
                            Console.WriteLine($"Количество ошибок ввода: {warn}");
                        }
                        else
                        {
                            Console.WriteLine("Введено не число!");
                            Array.Clear(arr, arr[i], arr[i]);
                            warn++;
                            i--;
                            continue;
                        }
                    }
                }
            }
            //Если массив переполнен,
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Исключение: {ex.Message}");
                continue;
            }
        }
    }
}
while (true);
