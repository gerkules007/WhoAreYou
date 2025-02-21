﻿/*README
Данная программа забирает введеные значение в виде баллов поочередно за каждый отвеченный вопрос.
ВНИМАНИЕ! ЕСЛИ ЗНАЧЕНИЯ БУДУТ ВВЕДЕНЫ ОТЛИЧНЫЕ ОТ ЦИФР, ПРОГРАММА ЗАКРОЕТСЯ, БУДЬТЕ ВНИМАТЕЛЬНЫ!
После последнего вопроса она сравнивает все значения со шаблонными и суммирует не превосходящие:
Если вы ответили 3, а в шаблоне 5, она суммирует 3;
Если вы ответили 5, а в шаблоне 3, она суммирует 3.
Затем считает процент сходства с шаблоном: Сумма ваших баллов / Сумму шаблонных.
В конце выдает результат для каждой профессии и введенные вами значения.
*/

// Массив вопросов
string[] NameQuetion =
{
    "Экстраверт",
    "Интроверт",
    "Способность к монотонной работе",
    "Наставничество",
    "Аналитические навыки",
    "Эмпатия",
    "Любопытство",
    "Ораторское искусство",
    "Организационные способности",
    "Критическое мышление",
    "Многозадачность",
    "Креативность",
    "Стрессоустойчивость",
    "Контроль времени",
    "Работа с большим объемом информации"
};
// Массивы каждой профессии int[] Example = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
int[] Programmer = { 2, 3, 4, 0, 4, 2, 5, 0, 1, 3, 3, 1, 4, 3, 5 };
int[] Tester = { 2, 2, 5, 0, 3, 3, 4, 0, 1, 3, 3, 1, 2, 3, 3 };
int[] Analytic = { 3, 4, 3, 0, 5, 2, 4, 1, 2, 5, 3, 3, 3, 2, 4 };
int[] ProjectManager = { 4, 1, 1, 3, 3, 4, 3, 4, 5, 3, 5, 3, 5, 5, 4 };
int[] ProductManager = { 3, 2, 3, 3, 3, 4, 2, 4, 4, 3, 5, 2, 4, 4, 3 };


int count = NameQuetion.Length;
int[] YourArray = new int[count];
// Выделяем количество чисел из массива, повторяем операции, пока не достигнем конца массива
for (int i = 0; i < count; i++)
{
    // Спрашиваем вопрос
    Console.WriteLine($"Введите баллы с компетенции '{NameQuetion[i]}'");
    // Вводим и заполняем массив с ответом
    YourArray[i] = Convert.ToInt32(Console.ReadLine());
}


// Подсчет суммы результата относительно введенных значений у каждой профессии
void Result(int[] Array, int[] DefaultArray, string Profession)
{
    // Находим сумму шаблонного массива
    double SummDefault = 0;
    for (int i = 0; i < DefaultArray.Length; i++)
    {
        SummDefault += DefaultArray[i];
    }
    // Создаем цикл сравнения нашего балла с баллом шаблона
    double Summ = 0;
    for (int i = 0; i < Array.Length; i++)
    {
        // Если наш балл больше или равен шаблону, то записывается шаблон (макс кол баллов = баллы шаблона, больше не может быть)
        // Если нет, то наш балл суммируется
        if (Array[i] >= DefaultArray[i])
        {
            Summ += DefaultArray[i];
        }
        else
        {
            Summ += Array[i];
        }
    }
    // Процентное соотношение каждой профессии относительно с введенным результатом
    double SummRatio = (Summ / SummDefault) * 100;
    // Консоль пишет полученый результат. Н: Вы "в профессии" на 33,33% (10 из 30)
    Console.WriteLine($"Вы {Profession} на {SummRatio:F2}% ({Summ} из {SummDefault})");
}
Console.WriteLine();
// Выводим введенные значения, чтобы скопировать
for (int i = 0; i < YourArray.Length; i++) Console.WriteLine(NameQuetion[i] + " " + YourArray[i]);
Console.WriteLine();
// Считаем для каждой профессии
Result(YourArray, Programmer, "Программист");
Result(YourArray, Tester, "Тестировщик");
Result(YourArray, Analytic, "Аналитик");
Result(YourArray, ProjectManager, "Проджект-Менеджер");
Result(YourArray, ProductManager, "Продукт-Менеджер");
