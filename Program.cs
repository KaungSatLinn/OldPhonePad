// See https://aka.ms/new-console-template for more information


Dictionary<string, char> charMap = new()
{
    {"1", '&'},
    {"11", '\''},
    {"111", '('},
    {"2",'a'},
    {"22",'b'},
    {"222", 'c' },
    {"3",'d'},
    {"33",'e'},
    {"333", 'f' },
    {"4",'g'},
    {"44",'h'},
    {"444", 'i' },
    {"5",'j'},
    {"55",'k'},
    {"555", 'l' },
    {"6",'m'},
    {"66",'n'},
    {"666", 'o' },
    {"7",'p'},
    {"77",'q'},
    {"777", 'r' },
    {"7777", 's' },
    {"8",'t'},
    {"88",'u'},
    {"888", 'v' },
    {"9",'w' },
    {"99",'x' },
    {"999",'y' },
    {"9999",'z' },
    {"0",' ' },
    {"#",'#' },
    {"*",'*' }
};

OldPhonePad(charMap);

static void OldPhonePad(Dictionary<string, char> charMap)
{
    Console.WriteLine("Write Value & Enter to see result!");
    string input = Console.ReadLine();
    string result = string.Empty;
    string currentChar = string.Empty;
    string lastChar = string.Empty;
    string tempStr = string.Empty;
    for (int i = 0; i < input.Length; i++)
    {
        currentChar = input[i].ToString();
        if (!charMap.ContainsKey(currentChar) && !string.IsNullOrWhiteSpace(currentChar))
        {
            result = "Invalid Character!";
            break;
        }
        if (i == 0 || string.IsNullOrWhiteSpace(lastChar))
        {
            tempStr = currentChar;
            lastChar = currentChar;
            continue;
        }
        if (currentChar == lastChar && lastChar != "*")
        {
            tempStr += currentChar;
            lastChar = currentChar;
            continue;// Without #, loop will stop here and the last char won't show.
        }
        if (!string.IsNullOrWhiteSpace(tempStr))
        {
            result += charMap[tempStr].ToString();
            tempStr = string.IsNullOrWhiteSpace(currentChar) ? string.Empty : currentChar;
        }
        if (currentChar == "*")
        {
            result = result != string.Empty ? result.Remove(result.Length - 1) : string.Empty;
            tempStr = string.Empty;
        }
        if (lastChar == "*" && currentChar != "*") {
            tempStr = currentChar;
        }
        lastChar = currentChar;
    }
    Console.WriteLine("Result: " + result.ToUpper());
    Console.WriteLine();
    Console.WriteLine("Press Any Key to Restart or 'E' to Quit: ");
    Console.WriteLine();
    var key = Console.ReadKey();
    if (key.KeyChar != 'e' && key.KeyChar != 'E')
    {
        Console.WriteLine();
        OldPhonePad(charMap);
    }
}