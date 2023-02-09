public partial class TaxCodeGenerator
{
    // Global Var
    static char[] vowelsArr = new char[5] {'A', 'E', 'I', 'O', 'U'};
    static char[] consArr = new char[21] {'B', 'C', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'V', 'W', 'X', 'Y', 'Z'};
    static void Main(string[] args)
    {
        Lastname();
    }

    static string Lastname()
    {
        // Data Model
        string lastname, vowels, cons;
        bool isNumeric;

        // Allocation
        vowels = "";
        cons = "";

        // Elaboration
        Console.Write("Enter your last name: ");

        // Get and Verify Surname
        lastname = Console.ReadLine();
        isNumeric = int.TryParse(lastname, out int value);
        while (isNumeric)
        {
            Console.Write("Error! Enter your last name: ");
            lastname = Console.ReadLine();
            isNumeric = int.TryParse(lastname, out value);
        }// End While

        // Convert lastname toUpper
        lastname = lastname.ToUpper();

        // Devide Cowels and Consonant of the Lastname
        for (int i = 0; i < lastname.Length; i++)
        {
            if (vowelsArr.Contains(lastname[i])) vowels += lastname[i];
            if (consArr.Contains(lastname[i])) cons += lastname[i];
        }

        return "ErrMsg";

    }// End Surname()
}