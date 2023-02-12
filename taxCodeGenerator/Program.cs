using System.Text.RegularExpressions;

public partial class TaxCodeGenerator
{
    // Global Var
    static char[] vowelsArr = new char[5] {'A', 'E', 'I', 'O', 'U'};
    static char[] consArr = new char[21] {'B', 'C', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'V', 'W', 'X', 'Y', 'Z'};
    static string vowels, cons, year, month, day, municipal, supControlChar, controlChar;
    static int genderSum;
    static string mainP = "Enter your last name: ";
    static void Main(string[] args)
    {
        // Data Model
        string lastName, Name, Year, Month, Day, cadastralCode;

        GetVowelsnCons(); // Last Name
        lastName = GetLastname();
        GetVowelsnCons(); // Name
        Name = GetName();
        GetBioGender(); // Gender
        GetDate(); // Date of Birth
        Year = GetYear();
        Month = GetMonth();
        Day = GetDay();
        GetMunicipal(); // Municipal
        cadastralCode = GetCadastralCode();
        supControlChar = lastName + Name + Year + Month + Day + cadastralCode;
        controlChar = GetControlChar(); // Control Chat
        supControlChar += controlChar;
        Console.WriteLine($"Your Tax Number is: {supControlChar}");
    }
    static void GetVowelsnCons()
    {
        // Data Model
        string obj;
        bool isNumeric;

        // Allocation
        vowels = "";
        cons = "";

        // Elaboration
        Console.Write(mainP);

        // Get and Verify Surname
        obj = Console.ReadLine();
        isNumeric = float.TryParse(obj, out float value);
        while (isNumeric)
        {
            Console.Write($"Error! {mainP}");
            obj = Console.ReadLine();
            isNumeric = float.TryParse(obj, out value);
        }// End While

        // Convert lastname toUpper
        obj = obj.ToUpper();

        // Devide Cowels and Consonant of the Lastname
        for (int i = 0; i < obj.Length; i++)
        {
            if (vowelsArr.Contains(obj[i])) vowels += obj[i];
            if (consArr.Contains(obj[i])) cons += obj[i];
        }// End for
        mainP = "Enter your name: ";
    }// End GetNameVowelsnCons()
    static string GetLastname()
    {
        // Data Model
        string result;

        // Elaboration
        // Get a Return
        if (cons.Length + vowels.Length == 2) 
        {
            result = cons + vowels + "X";
            return result;
        }// End if
        if(cons.Length >= 3)
        {
            result = cons.Substring(0, 3);
            return result;
        }// End if
        if (cons.Length < 3)
        {
            if(cons.Length < 2) 
            {
                if(cons.Length == 1)
                {
                    result = cons + "X" + "X";
                    return result;
                }
                else
                {
                    if (vowels.Length < 2)
                    {
                        result = vowels + "X" + "X";
                        return result;
                    }
                    else
                    {
                        result = cons + vowels.Substring(0, 2);
                        return result;
                    }// End Nested if
                }// End Nested if
            }
            else
            {
                result = cons + vowels.Substring(0,1);
                return result;
            }// End Nested if
        }// End if

        return "ErrMsg";

    }// End Surname()
    static string GetName()
    {
        // Data Model
        string result;

        // Elaboration
        // Get a Return
        if(cons.Length + vowels.Length == 3)
        {
            result = cons + vowels;
            return result;
        }// End if
        if(cons.Length == 3)
        {
            result = cons;
            return result;
        }// End if
        if(cons.Length + vowels.Length == 2)
        {
            result = cons + vowels + "X";
            return result;
        }// End if
        if(cons.Length > 3)
        {
            result = cons.Substring(0, 1) + cons.Substring(2, 2);
            return result;
        }// End if
        if(cons.Length < 3)
        {
            if(cons.Length < 2) 
            {
                if (cons.Length == 1)
                {
                    result = cons + "X" + "X";
                    return result;
                }
                else
                {
                    if (vowels.Length < 2)
                    {
                        result = vowels + "X" + "X";
                        return result;
                    }
                    else
                    {
                        result = cons + vowels.Substring(0, 2);
                        return result;
                    }// End Nested if
                }// End Nested if
            }// End if
            result = cons + vowels.Substring(0, 1);
            return result;
        }// End if
        return "ErrMsg";
    }// End GetName()
    static int GetBioGender()
    {
        // Data model
        string gender;

        // Elaboration
        Console.Write("Enter your Biogical Gender: [m/f] ");
        gender = Console.ReadLine();

        // Check Lenght of Gender
        while(gender.Length > 1) 
        { 
            Console.WriteLine("Error, Enter your Biogical Gender: [m/f]");
            gender = Console.ReadLine();
        }

        // Universal Gender Case
        gender = gender.ToUpper();

        switch (gender)
        {
            case "M":   genderSum = 0;  return genderSum;
            case "F":   genderSum = 40; return genderSum;
            default:    GetBioGender(); break;
        }// End Switch
        return 0;
    }// End GetBioGender()
    static void GetDate()
    {
        // Data Model
        string date;
        DateTime now = DateTime.Now;
        Regex validationDate = new Regex("^[0-9]{1,2}\\/[0-9]{1,2}\\/[0-9]{4}$");

        // Elaboration
        Console.Write("Enter your date of Birth: (ex. 01/01/1900) ");
        date = Console.ReadLine();

        // Is the Format Valid?
        while(!validationDate.IsMatch(date))
        {
            Console.WriteLine("Error, Enter your date of Birth: (ex. 01/01/1900) ");
            date = Console.ReadLine();
        }// End while
        
        // Is a Valid Date?
        try
        {
            DateTime.Parse(date);
        }catch (System.FormatException) 
        {
            Console.WriteLine("Error, Date not valid!");
            GetDate();
            return;
        }// End try

        // Is it in the Future?
        if(now.Date < DateTime.Parse(date))
        {
            Console.WriteLine("Error, Date not valid!");
            GetDate();
        }// End if

        // Get Year, Month and Day
        day = date.Split("/")[0];
        month = date.Split("/")[1];
        year = date.Split("/")[2];
    }// End GetDate()
    static string GetYear()
    {
        return year.Substring(2, 2);
    }// End GetYear()
    static string GetMonth()
    {
        // Date Model
        const int NumberOfDate = 2;
        const int NumberOfArray = 12;
        bool isNumeric;
        object[,] letterByMonth = new object[NumberOfArray, NumberOfDate]{ 
            { 01, 'A' },
            { 02, 'B' }, 
            { 03, 'C' },
            { 04, 'D' }, 
            { 05, 'E' }, 
            { 06, 'H' }, 
            { 07, 'L' }, 
            { 08, 'M' }, 
            { 09, 'P' }, 
            { 10, 'R' }, 
            { 11, 'S' }, 
            { 12, 'T' } 
        };

        // Elaboration
        isNumeric = int.TryParse(month, out int monthNumber);
        if (isNumeric) 
            for (int i = 0; i < NumberOfArray; i++)
                return Convert.ToString(letterByMonth[monthNumber - 1, 1]);
        return "ErrMsg";
    }// End GetMonth()
    static string GetDay()
    {
        // Date Model
        bool isNumeric;
        string result;

        // Elaboration
        isNumeric = int.TryParse(day, out int dayNumber);
        result = Convert.ToString(dayNumber + genderSum);
        if (result.Length != 1) return result;
        else return result.Insert(0, "0");
    }// End GetDay()
    static void GetMunicipal()
    {
        // Data Model
        bool isNumeric;
        List<string> listA = new List<string>();
        List<string> listB = new List<string>();

        // Elaboration
        Console.Write("Enter a Common Italian: ");
        municipal = Console.ReadLine();
        isNumeric = int.TryParse(municipal, out int val);

        // Is a String
        while (isNumeric)
        {
            Console.Write("Error! Enter a Common Italian: ");
            isNumeric = int.TryParse(municipal, out val);
        }// End while

        // Universal Municipal Case
        municipal = municipal.ToUpper();

        // Is a Common
        using (var reader = new StreamReader("cadastralCode.csv"))
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                listA.Add(values[0]);
                listB.Add(values[1]);
            }// End while

            // Is a Common
            while (!listB.Contains(municipal))
            {
                Console.WriteLine("Error! Common not valid! Reinsert it: ");
                municipal = Console.ReadLine();
                // Universal Municipal Case
                municipal = municipal.ToUpper();
            }// End while

            if (listB.Contains(municipal))
                return;

        }// End Reading CSV
    }// End GetMunicipal
    static string GetCadastralCode() 
    {
        // Data Model
        bool isNumeric;
        List<string> listA = new List<string>();
        List<string> listB = new List<string>();
        

        // Elaboration
        using (var reader = new StreamReader("cadastralCode.csv"))
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                listA.Add(values[0]);
                listB.Add(values[1]);
            }// End while

            for (int i = 0; i < listA.Count; i++)
                if (municipal == listB[i]) return listA[i];
                
        }// End Reading CSV
        return "ErrMsg";
    }// End CadastrialCode()
    static string GetControlChar()
    {
        // Data Model
        int sumVer, k;
        string oddChar, evenChar;
        object[,] charToEven = new object[36, 2] {
            {'0', 0 },
            {'1', 1 },
            {'2', 2 },
            {'3', 3 },
            {'4', 4 },
            {'5', 5 },
            {'6', 6 },
            {'7', 7 },
            {'8', 8 },
            {'9', 9 },
            {'A', 0 },
            {'B', 1 },
            {'C', 2 },
            {'D', 3 },
            {'E', 4 },
            {'F', 5 },
            {'G', 6 },
            {'H', 7 },
            {'I', 8 },
            {'J', 9 },
            {'K', 10 },
            {'L', 11 },
            {'M', 12 },
            {'N', 13 },
            {'O', 14 },
            {'P', 15 },
            {'Q', 16 },
            {'R', 17 },
            {'S', 18 },
            {'T', 19 },
            {'U', 20 },
            {'V', 21 },
            {'W', 22 },
            {'X', 23 },
            {'Y', 24 },
            {'Z', 25 },
        };

        object[,] charToOdd = new object[36, 2] {
            {'0', 1 },
            {'1', 0 },
            {'2', 5 },
            {'3', 7 },
            {'4', 9 },
            {'5', 13 },
            {'6', 15 },
            {'7', 17 },
            {'8', 19 },
            {'9', 21 },
            {'A', 1 },
            {'B', 0 },
            {'C', 5 },
            {'D', 7 },
            {'E', 9 },
            {'F', 13 },
            {'G', 15 },
            {'H', 17 },
            {'I', 19 },
            {'J', 21 },
            {'K', 2 },
            {'L', 4 },
            {'M', 18 },
            {'N', 20 },
            {'O', 11 },
            {'P', 3 },
            {'Q', 6 },
            {'R', 8 },
            {'S', 12 },
            {'T', 14 },
            {'U', 16 },
            {'V', 10 },
            {'W', 22 },
            {'X', 25 },
            {'Y', 24 },
            {'Z', 23 },
        };
        object[,] resultTable = new object[26, 2]
        {
            {0, 'A'},
            {1, 'B'},
            {2, 'C'},
            {3, 'D'},
            {4, 'E'},
            {5, 'F'},
            {6, 'G'},
            {7, 'H'},
            {8, 'I'},
            {9, 'J'},
            {10, 'K'},
            {11, 'L'},
            {12, 'M'},
            {13, 'N'},
            {14, 'O'},
            {15, 'P'},
            {16, 'Q'},
            {17, 'R'},
            {18, 'S'},
            {19, 'T'},
            {20, 'U'},
            {21, 'V'},
            {22, 'W'},
            {23, 'X'},
            {24, 'Y'},
            {25, 'Z'},
        };

        // Allocation
        sumVer = 0;
        k = 0;
        oddChar = "";
        evenChar = "";

        // Elaboration

        // Devide Odd Char and Even Char
        for (int i = 0; i < supControlChar.Length; i++)
            if(i % 2 != 0) evenChar += supControlChar[i];
            else oddChar += supControlChar[i];

        // Sum for the Verification
        for (int i = 0; i < charToEven.Length; i++)
            if (Convert.ToChar(charToEven[i, 0]) == evenChar[k])
            {
                sumVer += Convert.ToInt32(charToEven[i, 1]);
                if (k < evenChar.Length - 1) k++;
                else break;
                i = -1;
            }// End if

        k = 0;
        for (int i = 0; i < charToOdd.Length; i++)
            if (Convert.ToChar(charToOdd[i, 0]) == oddChar[k])
            {
                sumVer += Convert.ToInt32(charToOdd[i, 1]);
                if (k < oddChar.Length - 1) k++;
                else break;
                i = -1;
            }// End if

        // Get the MOD of Sum and 26
        sumVer %= 26;

        for (int i = 0; i < resultTable.Length; i++)
            if ((int)resultTable[i,0] == sumVer) return resultTable[i, 1].ToString();

        return "ErrMsg";

    }// End ControlChar() // The problem is: Im Searching for all the word, so it will never find it
 }// End TaxCodeGenerator
