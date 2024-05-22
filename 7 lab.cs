// 1 уровень 3 номер

using System;

abstract class CandidateOfTheYear
{
    protected string Name;
    public double NumberOfVotes { get; }
    protected double Percentage;

    public CandidateOfTheYear(string name, double numberOfVotes)
    {
        Name = name;
        NumberOfVotes = numberOfVotes;
        Percentage = (NumberOfVotes / 45) * 100;
    }

    public abstract void Print();
}

class PersonOfYear : CandidateOfTheYear
{
    public PersonOfYear(string name, double numberOfVotes) : base(name, numberOfVotes)
    {
    }

    public override void Print()
    {
        Console.WriteLine($"Человек года: {Name}, процент голосов: {Percentage}%");
    }
}

class EventOfYear : CandidateOfTheYear
{
    public EventOfYear(string name, double numberOfVotes) : base(name, numberOfVotes)
    {
    }

    public override void Print()
    {
        Console.WriteLine($"Событие года: {Name}, процент голосов: {Percentage}%");
    }
}

class Program
{
    static void Main(string[] args)
    {
        CandidateOfTheYear[] candidates = new CandidateOfTheYear[14];
        candidates[0] = new PersonOfYear("Vladimir Putin", 4);
        candidates[1] = new PersonOfYear("Taylor Swift", 6);
        candidates[2] = new PersonOfYear("Xi Jinping", 3);
        candidates[3] = new PersonOfYear("Barbie", 5);
        candidates[4] = new PersonOfYear("Volodymyr Zelensky", 1);
        candidates[5] = new PersonOfYear("Sam Altman", 1);
        candidates[6] = new PersonOfYear("Mr. Beast", 4);
        candidates[7] = new PersonOfYear("Jeffrey Epstein", 1);
        candidates[8] = new EventOfYear("COVID-19 Pandemic", 2);
        candidates[9] = new EventOfYear("Acceleration Of The Space Race", 2);
        candidates[10] = new EventOfYear("Potential and risks of AI", 6);
        candidates[11] = new EventOfYear("failure of the Ukrainian counteroffensive", 1);
        candidates[12] = new EventOfYear("decline of democracy", 5);
        candidates[13] = new EventOfYear("2023 is the hottest year", 4);

        Console.WriteLine("Все кандидаты:");
        foreach (var candidate in candidates)
        {
            candidate.Print();
        }

        Array.Sort(candidates, (x, y) => y.NumberOfVotes.CompareTo(x.NumberOfVotes));

        Console.WriteLine("\nТоп-5 людей года:");
        int peopleCount = 0;
        foreach (var candidate in candidates)
        {
            if (candidate is PersonOfYear && peopleCount < 5)
            {
                candidate.Print();
                peopleCount++;
            }
        }

        Console.WriteLine("\nТоп-5 событий года:");
        int eventsCount = 0;
        foreach (var candidate in candidates)
        {
            if (candidate is EventOfYear && eventsCount < 5)
            {
                candidate.Print();
                eventsCount++;
            }
        }
    }
}

//2 уровень 4 номер
using System;

public abstract class Diving
{
    public string DisciplineName { get; private set; }

    protected Diving(string disciplineName)
    {
        DisciplineName = disciplineName;
    }
}

public class Diving3m : Diving
{
    public Diving3m() : base("Прыжки в воду с 3 метров") { }
}

public class Diving5m : Diving
{
    public Diving5m() : base("Прыжки в воду с 5 метров") { }
}

public struct Athlete
{
    private string Surname;
    private double[] Coefficients;
    private double[,] Grades;
    public double FinalMark { get; }

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
        Console.WriteLine("Выберите дисциплину:");
        Console.WriteLine("1. Прыжки в воду с 3 метров");
        Console.WriteLine("2. Прыжки в воду с 5 метров");
        Console.Write("Введите номер: ");
        int choice = int.Parse(Console.ReadLine());

        Diving diving = choice == 1 ? new Diving3m() : new Diving5m();

        Console.WriteLine($"\n{diving.DisciplineName}\n");

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
using System.Collections.Generic;
using System.Linq;

public class Group
{
    public string GroupName { get; }
    public List<Student> Students { get; }
    public string[] CommonSubjects { get; }

    public Group(string groupName, string[] commonSubjects)
    {
        GroupName = groupName;
        CommonSubjects = commonSubjects;
        Students = new List<Student>();
    }

    public virtual double CalculateAverageScore()
    {
        double totalScore = 0;
        foreach (var student in Students)
        {
            totalScore += student.CalculateAverageScore(CommonSubjects); 
        }
        return totalScore / Students.Count;
    }
}

public class Group1 : Group
{
    public string[] AdditionalSubjects { get; }

    public Group1(string[] additionalSubjects) : base("Группа 1", new string[] { "Математика", "Физика", "Химия" })
    {
        AdditionalSubjects = additionalSubjects;
    }

    public override double CalculateAverageScore()
    {
        double totalScore = 0;
        foreach (var student in Students)
        {
            totalScore += student.CalculateAverageScore(CommonSubjects.Concat(AdditionalSubjects).ToArray());
        }
        return totalScore / Students.Count;
    }
}

public class Group2 : Group
{
    public string[] AdditionalSubjects { get; }

    public Group2(string[] additionalSubjects) : base("Группа 2", new string[] { "Математика", "Физика", "Химия" })
    {
        AdditionalSubjects = additionalSubjects;
    }

    public override double CalculateAverageScore()
    {
        double totalScore = 0;
        foreach (var student in Students)
        {
            totalScore += student.CalculateAverageScore(CommonSubjects.Concat(AdditionalSubjects).ToArray());
        }
        return totalScore / Students.Count;
    }
}

public class Group3 : Group
{
    public string[] AdditionalSubjects { get; }

    public Group3(string[] additionalSubjects) : base("Группа 3", new string[] { "Математика", "Физика", "Химия" })
    {
        AdditionalSubjects = additionalSubjects;
    }

    public override double CalculateAverageScore()
    {
        double totalScore = 0;
        foreach (var student in Students)
        {
            totalScore += student.CalculateAverageScore(CommonSubjects.Concat(AdditionalSubjects).ToArray());
        }
        return totalScore / Students.Count;
    }
}

public class Student
{
    public string LastName { get; }
    public Dictionary<string, int> ExamScores { get; }

    public Student(string lastName, Dictionary<string, int> examScores)
    {
        LastName = lastName;
        ExamScores = examScores;
    }

    public double CalculateAverageScore(string[] subjects)
    {
        double totalScore = 0;
        foreach (var subject in subjects)
        {
            if (ExamScores.ContainsKey(subject))
            {
                totalScore += ExamScores[subject];
            }
        }
        return totalScore / subjects.Length;
    }
}

class Program
{
    static void Main()
    {
        Group1 group1 = new Group1(new string[] { "Информатика", "Экономика" });
        Group2 group2 = new Group2(new string[] { "Астрономия", "Материаловедение" });
        Group3 group3 = new Group3(new string[] { "История", "Литература" });

        group1.Students.Add(new Student("Иванов", new Dictionary<string, int> { { "Математика", 4 }, { "Физика", 3 }, { "Химия", 5 }, { "Информатика", 4 }, { "Экономика", 3 } }));
        group1.Students.Add(new Student("Петров", new Dictionary<string, int> { { "Математика", 3 }, { "Физика", 4 }, { "Химия", 4 }, { "Информатика", 3 }, { "Экономика", 5 } }));
        group1.Students.Add(new Student("Зайцев", new Dictionary<string, int> { { "Математика", 4 }, { "Физика", 3 }, { "Химия", 5 }, { "Информатика", 4 }, { "Экономика", 3 } }));
        group1.Students.Add(new Student("Лодкин", new Dictionary<string, int> { { "Математика", 3 }, { "Физика", 4 }, { "Химия", 4 }, { "Информатика", 3 }, { "Экономика", 5 } }));
        group1.Students.Add(new Student("Кузнецов", new Dictionary<string, int> { { "Математика", 4 }, { "Физика", 3 }, { "Химия", 5 }, { "Информатика", 4 }, { "Экономика", 3 } }));
        group2.Students.Add(new Student("Попов", new Dictionary<string, int> { { "Математика", 3 }, { "Физика", 4 }, { "Химия", 5 }, { "Астрономия", 4 }, { "Материаловедение", 4 } }));
        group2.Students.Add(new Student("Ногин", new Dictionary<string, int> { { "Математика", 5 }, { "Физика", 5 }, { "Химия", 4 }, { "Астрономия", 4 }, { "Материаловедение", 4 } }));
        group2.Students.Add(new Student("Морозов", new Dictionary<string, int> { { "Математика", 3 }, { "Физика", 5 }, { "Химия", 3 }, { "Астрономия", 5 }, { "Материаловедение", 5 } }));
        group2.Students.Add(new Student("Паровозов", new Dictionary<string, int> { { "Математика", 5 }, { "Физика", 4 }, { "Химия", 4 }, { "Астрономия", 3 }, { "Материаловедение", 3 } }));
        group2.Students.Add(new Student("Голубин", new Dictionary<string, int> { { "Математика", 5 }, { "Физика", 3 }, { "Химия", 4 }, { "Астрономия", 3 }, { "Материаловедение", 5 } }));
        group2.Students.Add(new Student("Тимофеев", new Dictionary<string, int> { { "Математика", 3 }, { "Физика", 3 }, { "Химия", 5 }, { "Астрономия", 4 }, { "Материаловедение", 5 } }));
        group3.Students.Add(new Student("Коренков", new Dictionary<string, int> { { "Математика", 3 }, { "Физика", 4 }, { "Химия", 4 }, { "История", 4 }, { "Литература", 5 } }));
        group3.Students.Add(new Student("Бунин", new Dictionary<string, int> { { "Математика", 3 }, { "Физика", 4 }, { "Химия", 5 }, { "История", 3 }, { "Литература", 4 } }));
        group3.Students.Add(new Student("Воронцов", new Dictionary<string, int> { { "Математика", 4 }, { "Физика", 4 }, { "Химия", 5 }, { "История", 5 }, { "Литература", 3 } }));
        group3.Students.Add(new Student("Тришин", new Dictionary<string, int> { { "Математика", 3 }, { "Физика", 5 }, { "Химия", 5 }, { "История", 5 }, { "Литература", 4 } }));
        group3.Students.Add(new Student("Джавадов", new Dictionary<string, int> { { "Математика", 5 }, { "Физика", 3 }, { "Химия", 3 }, { "История", 3 }, { "Литература", 3 } }));
        group3.Students.Add(new Student("Гладков", new Dictionary<string, int> { { "Математика", 5 }, { "Физика", 4 }, { "Химия", 4 }, { "История", 4 }, { "Литература", 3 } }));
        group3.Students.Add(new Student("Комиссаров", new Dictionary<string, int> { { "Математика", 5 }, { "Физика", 3 }, { "Химия", 5 }, { "История", 3 }, { "Литература", 4 } }));



        var groups = new List<Group> { group1, group2, group3 };
        Console.WriteLine("{0,-10} {1,15}", "Группа", "Средний балл");
        Console.WriteLine("-------------------------");
        foreach (var group in groups)
        {
            Console.WriteLine("{0,-10} {1,15:0.00}", group.GroupName, group.CalculateAverageScore());
        }

        Console.WriteLine("\nСписок всех студентов:");
        foreach (var group in groups)
        {
            foreach (var student in group.Students)
            {
                Console.WriteLine($"{student.LastName} ({group.GroupName})");
            }
        }
    }
}
