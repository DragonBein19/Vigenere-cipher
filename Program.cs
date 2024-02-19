using System;

namespace InformationSecurity_1stpractive
{
    class Program : Text_Enter
    {
        static private char[] array = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', ' '};
        static private string text, KeyWord;

        static public int number = 'a';

        static void Main()
        {
            KeyWord = Key_Word_Enter();
            text = New_text();

            Coding();

        }

        static public void Coding()
        {
            char[] Tarray = text.ToCharArray();
            char[] KWarray = KeyWord.ToCharArray();

            int[] TextIndexArray = new int[Tarray.Length];
            int[] KeyWordIndexArray = new int[KWarray.Length];

            for (int i = 0; i < KWarray.Length; i++)
            {
                for(int j = 0; j < array.Length; j++)
                {
                    if(KWarray[i] == array[j])
                    {
                        KeyWordIndexArray[i] = j;
                    }
                }
            }

            for(int i = 0; i < Tarray.Length; i++)
            {
                for(int j = 0; j < array.Length; j++)
                {
                    if(Tarray[i] == array[j])
                    {
                        TextIndexArray[i] = j;
                    }
                }
            }

            for(int i = 0; i < Tarray.Length; i++)
            {
                if(TextIndexArray[i] == 26)
                {
                    TextIndexArray[i] = 26;
                }
                else if(TextIndexArray[i] + KeyWordIndexArray[i % KeyWordIndexArray.Length] >= 26)
                {
                    TextIndexArray[i] = (TextIndexArray[i] + KeyWordIndexArray[i % KeyWordIndexArray.Length]) - 26;
                }
                else
                {
                    TextIndexArray[i] = TextIndexArray[i] + KeyWordIndexArray[i % KeyWordIndexArray.Length];
                }
            }

            for (int i = 0; i < Tarray.Length; i++)
            {
                Console.Write(array[TextIndexArray[i]] + " ");
            }
            Console.WriteLine();

            for(int i = 0; i < Tarray.Length; i++)
            {
                if(TextIndexArray[i] == 26)
                {
                    TextIndexArray[i] = 26;
                }
                else if(TextIndexArray[i] - KeyWordIndexArray[i % KeyWordIndexArray.Length] < 0)
                {
                    TextIndexArray[i] = (TextIndexArray[i] - KeyWordIndexArray[i % KeyWordIndexArray.Length]) + 26;
                }
                else
                {
                    TextIndexArray[i] = TextIndexArray[i] - KeyWordIndexArray[i % KeyWordIndexArray.Length];
                }
            }

            for (int i = 0; i < Tarray.Length; i++)
            {
                Console.Write(array[TextIndexArray[i]] + " ");
            }

            Console.WriteLine();
            exercise_2nd();
        }

        static private void exercise_2nd()
        {
            text = New_text();
            KeyWord = Key_Word_Enter();

            char[] Tarray = text.ToCharArray();
            char[] KWarray = KeyWord.ToCharArray();

            int[] TextIndexArray = new int[Tarray.Length];
            int[] KeyWordIndexArray = new int[KWarray.Length];
            
            for(int i = 0; i < Tarray.Length; i++)
            {
                TextIndexArray[i] = Tarray[i];
                Console.Write(TextIndexArray[i] + " ");
            }

            Console.WriteLine();

            for(int j = 0; j < KWarray.Length; j++)
            {
                KeyWordIndexArray[j] = KWarray[j];
                Console.Write(KeyWordIndexArray[j] + " ");
            }

            Console.WriteLine();
            Console.WriteLine("1. Encrypt text\n2. Decipher text\n 3. Enithing for exit");

            string choice;
            bool cicle = true;

            while (cicle)
            {
                choice = Console.ReadLine();
                if (choice == "1")
                {
                    choice_1st(TextIndexArray, KeyWordIndexArray);
                    Console.WriteLine("\nResult: ");
                    for (int i = 0; i < TextIndexArray.Length; i++)
                    {
                        Console.Write(Convert.ToChar(TextIndexArray[i]) + " ");
                    }
                    Console.Write("\nWhat do you want to do?: ");
                }
                else if (choice == "2")
                {
                    choice_2nd(TextIndexArray, KeyWordIndexArray);
                    Console.WriteLine("\nResult: ");
                    for (int i = 0; i < TextIndexArray.Length; i++)
                    {
                        Console.Write(Convert.ToChar(TextIndexArray[i]) + " ");
                    }
                    Console.Write("\nWhat do you want to do?: ");
                }
                else
                {
                    cicle = false;
                }
            }
        }

        static public void choice_1st(int [] array, int [] Key)
        {
            for(int i = 0; i < array.Length; i++)
            {
                if(array[i] + Key[i % Key.Length] == 127)
                {
                    array[i] = 0;
                }
                else if(array[i] + Key[i % Key.Length] > 127)
                {
                    array[i] = (array[i] + Key[i % Key.Length]) - 127;
                }
                else
                {
                    array[i] = array[i] + Key[i % Key.Length];
                }
            }
        }

        static public void choice_2nd(int[] array, int[] Key)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] - Key[i % Key.Length] == 0)
                {
                    array[i] = 127;
                }
                else if (array[i] - Key[i % Key.Length] < 0)
                {
                    array[i] = (array[i] - Key[i % Key.Length]) + 127;
                }
                else
                {
                    array[i] = array[i] - Key[i % Key.Length];
                }
            }
        }
    }
    
    class Text_Enter
    {
        static public string Key_Word_Enter()
        {
            string Key_word;
            Console.Write("Enter key word: ");
            Key_word = Console.ReadLine();
            Console.WriteLine();
            return Key_word;
        }
        
        static public string New_text()
        {
            string text;
            
            Console.Write("Enter the text: ");
            text = Console.ReadLine();

            return text;
        }
    }
}
