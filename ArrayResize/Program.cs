using System;

class MyClass
{
    /// <summary>
    /// method for generate an array
    /// </summary>
    static void GenerateArray(int[] mainArray)
    {
        Random rnd = new Random();

        for (int i = 0; i < mainArray.Length; i++)
        {
            mainArray[i] = rnd.Next(-21, 21);
        }
    }
    
    /// <summary>
    /// method for outputting an array
    /// </summary>
    static void ShowArray(int[] mainArray)
    {
        Console.WriteLine();
        
        for (int i = 0; i < mainArray.Length; i++)
        {
            Console.Write(mainArray[i] + " ");
        }
    }
    
    /// <summary>
    /// method for increasing the size of an array
    /// </summary>
    static void ResizeUp(ref int[] mainArray)
    {
        Console.Write("Enter the number of elements by which you want to increase the array -> ");
        
        if(!int.TryParse(Console.ReadLine(), out int numberForIncrease) || numberForIncrease <= 0 ) { Console.WriteLine("Enter the positive number!"); return;}

        Random rnd = new Random();
        
        // int[] IncreaseArr = new int[numberForIncrease];
        //
        // for (int i = 0; i < numberForIncrease; i++)
        // {
        //     IncreaseArr[i] = rnd.Next(-21, 21);
        // }
        //
        // int tempArraySize = mainArray.Length + IncreaseArr.Length;
        // int[] tempArr = new int[tempArraySize];
        //
        // Array.Copy(mainArray,0,tempArr,0,mainArray.Length);
        // Array.Copy(IncreaseArr,0,tempArr, mainArray.Length, IncreaseArr.Length);
        //
        // mainArray = tempArr;

        int oldLength = mainArray.Length;
        Array.Resize(ref mainArray, mainArray.Length + numberForIncrease);

        for (int i = oldLength; i < mainArray.Length; i++)
        {
            mainArray[i] = rnd.Next(-21, 21);
        }
    }
    
    /// <summary>
    /// method for reducing the size of an array
    /// </summary>
    static void ResizeDown(ref int[] mainArray)
    {
        Console.Write("Enter the number of elements by which you want to reduction the array -> ");
        
        if(!int.TryParse(Console.ReadLine(), out int numberForReduction) || numberForReduction > mainArray.Length || numberForReduction < 0) 
        { Console.WriteLine($"Must be number smaller or similar than length mainArray {mainArray.Length}"); return; }
        
        if (mainArray.Length - numberForReduction < 0) { Console.WriteLine("Array cannot be negative!"); return; }
        
        Array.Resize(ref mainArray, mainArray.Length - numberForReduction);
    }
    
    static void Main()
    {
        int arraySize = 10;
        int[] mainArray = new int[arraySize];
        
        GenerateArray(mainArray);
        
        while (true)
        {
            Console.WriteLine("\n\n1 - for showing full array" +
                              "\n2 - for call ArrayUp function" +
                              "\n3 - for call ArrayDown function" +
                              "\nWrite \"Exit\" for exit the program");
            
            Console.Write("\nEnter your choice -> ");
            
            string userChoice = Console.ReadLine()?.ToLower();
                
            switch (userChoice)
            {
                case "1":
                { ShowArray(mainArray); ShowArray(mainArray); break; }
                
                case "2":
                { ResizeUp(ref mainArray); ShowArray(mainArray); break;}
                
                case "3":
                { ResizeDown(ref mainArray); break;}
                
                case "exit":
                { return; }

                default:
                { Console.WriteLine("Try again..."); break; }
                  
            }
        }
    }
}