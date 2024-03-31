//1 уровень 3 номер
using System;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;

struct PersonOfTheYear
{
    private string Name;
   
    private double Percentage;
    public PersonOfTheYear(string Name1, double NumberOfResponses1)
    {
        Percentage = 0;
        Name = Name1;
        NumberOfResponses = NumberOfResponses1;
        for (int i = 0; i < 9; i++)
           
            Percentage = NumberOfResponses1 / 27 * 100;

    }
    public double NumberOfResponses { get; }
    public void Print()
    {
        Console.WriteLine($"Имя: {Name} Процент {Percentage} %");
    }
}

class Program
{
    static void Main(string[] args)
    {
        PersonOfTheYear[] cl = new PersonOfTheYear[9];
        cl[0] = new PersonOfTheYear("Vladimir Putin", 4);
        cl[1] = new PersonOfTheYear("Taylor Swift", 6);
        cl[2] = new PersonOfTheYear("Si Tszinpin", 3);
        cl[3] = new PersonOfTheYear("Barbie", 5);
        cl[4] = new PersonOfTheYear("Vladimir Zelenskiy", 1);
        cl[5] = new PersonOfTheYear("Sam Altman", 1);
        cl[6] = new PersonOfTheYear("Mr Beast", 4);
        cl[7] = new PersonOfTheYear("Jeffrie Epstein", 1);
        cl[8] = new PersonOfTheYear("Karl The 3rd", 2);

        for (int i = 0; i < cl.Length; i++)
        {
            cl[i].Print();
        }

        for (int i = 0; i < cl.Length - 1; i++)
        {
            PersonOfTheYear amax = cl[i];
            int imax = i;
            for (int j = i + 1; j < cl.Length; j++)
            {
                if (cl[j].NumberOfResponses > cl[imax].NumberOfResponses)
                {
                    amax = cl[j];
                    imax = j;
                }
            }
            cl[imax] = cl[i];
            cl[i] = amax;
        }

        Console.WriteLine();

        for (int i = 0; i < 5; i++)
        {
            cl[i].Print();
        }
    }
}













//2 уровень 4 номер
using System;

public struct Athlete
{
    private string Surname;
    private double[] Coefficients;
    private double[,] Grades;
    public double FinalMark;

    public Athlete(string surname, double[] coefficients, double[,] grades, double finalMark)
    {
        Surname = surname;
        Coefficients = coefficients;
        Grades = grades;
        FinalMark = CalculateFinalMark();
    }

    private double CalculateFinalMark()
    {
        double[] jumpsTotal = new double[4];

        for (int i = 0; i < 4; i++)
        {
            double sum = 0;
            double max = 0;
            double min = 6;

            for (int j = 0; j < 7; j++)
            {
                sum += Grades[i, j];

                if (Grades[i, j] > max)
                {
                    max = Grades[i, j];
                }

                if (Grades[i, j] < min)
                {
                    min = Grades[i, j];
                }
            }

            jumpsTotal[i] = (sum - max - min) * Coefficients[i];
        }

        return jumpsTotal.Sum();
    }

    public void Print()
    {
        Console.WriteLine($"Фамилия: {Surname}, Итоговая оценка: {FinalMark:F2}");
    }
}

class Program
{
    static void Main()
    {
        Athlete[] athletes = new Athlete[5];
        athletes[0] = new Athlete("Иванов", new double[] { 2.7, 3.1, 2.5, 3.3 },
            new double[,] { { 3, 4, 4, 5, 4, 6, 5 }, { 3, 3, 4, 5, 3, 3, 3 },
            { 6, 6, 5, 6, 4, 5, 5 }, { 3, 4, 5, 6, 3, 3, 3 } }, 0);

        athletes[1] = new Athlete("Петров", new double[] { 2.7, 2.7, 3.1, 3.1 },
            new double[,] { { 6, 5, 4, 5, 4, 6, 5 }, { 2, 3, 4, 1, 3, 3, 3 },
            { 5, 6, 3, 4, 4, 5, 5 }, { 3, 4, 2, 5, 2, 3, 3 } }, 0);

        athletes[2] = new Athlete("Сидоров", new double[] { 3.1, 3.3, 2.7, 3.5 },
            new double[,] { { 3, 4, 6, 6, 4, 6, 5 }, { 5, 3, 5, 5, 5, 3, 3 },
            { 3, 3, 5, 4, 4, 4, 5 }, { 6, 4, 5, 6, 5, 6, 3 } }, 0);

        athletes[3] = new Athlete("Павлов", new double[] { 3.1, 3.1, 2.7, 3.1 },
            new double[,] { { 2, 2, 4, 1, 3, 3, 3 }, { 3, 4, 4, 5, 5, 5, 3 },
            { 4, 4, 5, 4, 4, 5, 5 }, { 5, 4, 5, 6, 3, 3, 3 } }, 0);

        athletes[4] = new Athlete("Свердлов", new double[] { 2.5, 2.9, 2.7, 2.9 },
            new double[,] { { 5, 5, 5, 5, 4, 6, 5 }, { 2, 3, 3, 4, 3, 3, 3 },
            { 6, 3, 5, 5, 4, 5, 5 }, { 3, 4, 5, 2, 3, 3, 3 } }, 0);

        // Сортировка спортсменов по итоговой оценке и вывод результатов
        Array.Sort(athletes, (a1, a2) => a2.FinalMark.CompareTo(a1.FinalMark));

        Console.WriteLine("Итоговая таблица:");
        Console.WriteLine("-----------------");
        foreach (var athlete in athletes)
        {
            athlete.Print();
        }
    }
}











//3 уровень 1 номер
using System;


// Структура для представления информации о студентах
public struct Student
{
    public string LastName;
    public int[] ExamScores;

    public Student(string lastName, int[] examScores)
    {
        LastName = lastName;
        ExamScores = examScores;
    }
}

// Структура для представления группы студентов
public struct StudentGroup
{
    public string GroupName;
    public Student[] Students;

    public StudentGroup(string groupName, Student[] students)
    {
        GroupName = groupName;
        Students = students;
    }

    public double CalculateAverageScore()
    {
        double totalScore = 0;
        foreach (var student in Students)
        {
            totalScore += student.ExamScores.Average();
        }
        return totalScore / Students.Length;
    }
}

class Program
{
    static void Main()
    {
        
        Student[] studentsGroup1 = new Student[]
        {
            new Student("Иванов", new int[] { 4, 3, 5, 4, 3 }),
            new Student("Петров", new int[] { 3, 4, 4, 3, 5 }),
            new Student("Сидоров", new int[] { 5, 3, 3, 4, 4 }),
            new Student("Козлов", new int[] { 4, 5, 3, 5, 4 })
        };

        Student[] studentsGroup2 = new Student[]
        {
            new Student("Морозов", new int[] { 4, 4, 3, 4, 5 }),
            new Student("Никитин", new int[] { 3, 5, 4, 5, 4 }),
            new Student("Карпов", new int[] { 5, 3, 4, 3, 5 }),
            new Student("Зайцев", new int[] { 4, 4, 5, 3, 4 })
        };

        Student[] studentsGroup3 = new Student[]
        {
            new Student("Беляев", new int[] { 3, 5, 4, 3, 3 }),
            new Student("Исаев", new int[] { 4, 4, 3, 5, 4 }),
            new Student("Григорьев", new int[] { 5, 3, 3, 5, 4 }),
            new Student("Тихонов", new int[] { 3, 4, 5, 3, 4 })
        };

        // Создаем группы студентов
        StudentGroup group1 = new StudentGroup("Группа 1", studentsGroup1);
        StudentGroup group2 = new StudentGroup("Группа 2", studentsGroup2);
        StudentGroup group3 = new StudentGroup("Группа 3", studentsGroup3);

        // Вычисляем средние баллы для каждой группы
        var groups = new[] { group1, group2, group3 };
        var sortedGroups = groups.OrderByDescending(x => x.CalculateAverageScore());

        
        Console.WriteLine("{0,-10} {1,15}", "Группа", "Средний балл");
        Console.WriteLine("-------------------------");
        foreach (var group in sortedGroups)
        {
            Console.WriteLine("{0,-10} {1,15}", group.GroupName, group.CalculateAverageScore().ToString("0.00"));
        }
    }
}
