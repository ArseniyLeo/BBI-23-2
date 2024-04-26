//задание1
//using System;
//using System.Threading.Tasks;

//namespace ArseniyL;

//class Task1
//{
//    static void Taskk1(string[] args)
//    {
//        string text = Console.ReadLine();

//        string[] sentences = text.Split(new char[] { '.', '!' }, StringSplitOptions.RemoveEmptyEntries);

//        foreach (string sentence in sentences)
//        {
//            string[] words = sentence.Split(' ');

//            Console.Write(words[words.Length - 1] + " ");
//        }
//    }
//}










//задание2
    //class Task2
    //{
    //    static void Taskk2(string[] args)
    //    {

            

    //        Console.WriteLine("Введите текст:");
    //        string text = Console.ReadLine();

    //        char[] alphabet = new char[33]
    //        {
    //            'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я'
    //        };

    //        char[] textChars = text.ToCharArray();

    //        for (int i = 0; i < textChars.Length; i++)
    //        {
    //            if (Array.IndexOf(alphabet, textChars[i]) != -1)
    //            {
    //                int index = Array.IndexOf(alphabet, textChars[i]) - 10;

    //                if (index < 0)
    //                {
    //                    index += alphabet.Length;
    //                }
    //                textChars[i] = alphabet[index];
    //            }
    //        }

    //        string shiftedText = new string(textChars);

    //        Console.WriteLine("Сдвинутый текст:");
    //        Console.WriteLine(shiftedText);
    //        Console.ReadKey();
    //    }
    //}



class Program2
{
    static void Main(string[] args)
    {
        string path = @"C:\Users\m2304612\Downloads";
        string newName = "Test";
    }
}
