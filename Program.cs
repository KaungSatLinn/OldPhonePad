// See https://aka.ms/new-console-template for more information


Dictionary<string, char> charMap = new()
{
    {"1", 'a'},
    {"11", 'b'},
    {"111", 'c'},
    {"2",'d'},
    {"22",'e'},
    {"222", 'f' },
    {"3",'g'},
    {"33",'h'},
    {"333", 'i' },
    {"4",'j'},
    {"44",'k'},
    {"444", 'l' },
    {"5",'m'},
    {"55",'n'},
    {"555", 'o' },
    {"6",'p'},
    {"66",'q'},
    {"666", 'r' },
    {"6666", 's' },
    {"7",'t'},
    {"77",'u'},
    {"777", 'v' },
    {"8",'w'},
    {"88",'x'},
    {"888", 'y' },
    {"8888", 'z' },
    {"9",' ' }
};

Operation(charMap);


static void Operation(Dictionary<string, char> charMap)
{
    Console.WriteLine("Write Value & Enter to see result!");
    string input = Console.ReadLine();
    string[] words = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
    string result = "";
    foreach (string word in words)
    {
        string currentChar = string.Empty;
        string lastChar = string.Empty;
        string tempVal = string.Empty;
        for (int i = 0; i < word.Length; i++) {
            currentChar = word.ElementAt(i).ToString();
            if (i != 0 && currentChar != lastChar)
            {
                if (!charMap.ContainsKey(tempVal) && currentChar != "#")
                {
                    result = "Invalid Character!";
                    break;
                }
                result += charMap[tempVal];
                tempVal = currentChar;
                if (i == word.Length - 1 && currentChar != "#") {
                    result += charMap[tempVal];
                }
            }
            else
            {
                tempVal += currentChar;
                if (i == word.Length - 1 && currentChar != "#")
                {
                    result += charMap[tempVal];
                }
            }
            lastChar = currentChar;
        }
    }
    Console.WriteLine("Result: " + result);
    Console.WriteLine();
    Console.WriteLine("Press Any Key to Start or E to Quit: ");
    Console.WriteLine();
    var key = Console.ReadKey();
    if (key.KeyChar != 'e')
    {
        Operation(charMap);
    }
}

