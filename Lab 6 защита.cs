using System;
using System.Linq;

public struct Student
{
    private string LastName;
    public int[] ExamScores { get; }

    public Student(string lastName, int[] examScores)
    {
        LastName = lastName;
        ExamScores = examScores;
    }
}

public struct StudentGroup
{
    public string GroupName { get; }
    public Student[] Students { get; }

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

        StudentGroup group1 = new StudentGroup("Группа 1", studentsGroup1);
        StudentGroup group2 = new StudentGroup("Группа 2", studentsGroup2);
        StudentGroup group3 = new StudentGroup("Группа 3", studentsGroup3);

        var groups = new[] { group1, group2, group3 };

        ShellSort(groups);

        Console.WriteLine("{0,-10} {1,15}", "Группа", "Средний балл");
        Console.WriteLine("-------------------------");
        foreach (var group in groups)
        {
            Console.WriteLine("{0,-10} {1,15}", group.GroupName, group.CalculateAverageScore().ToString("0.00"));
        }
    }

    private static void ShellSort(StudentGroup[] groups)
    {
        int n = groups.Length;
        int gap = n / 2;
        while (gap > 0)
        {
            for (int i = gap; i < n; i++)
            {
                StudentGroup temp = groups[i];
                int j = i;
                while (j >= gap && groups[j - gap].CalculateAverageScore() < temp.CalculateAverageScore())
                {
                    groups[j] = groups[j - gap];
                    j-= gap;
                }
                groups[j] = temp;
            }
            gap /= 2;
        }
    }
}