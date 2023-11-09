
var produkter = new List<string>();

//  ett regex som matchar en eller flera bokstäver följt av bindestreck och ett nummer
var regex = new System.Text.RegularExpressions.Regex("^([a-zA-Z]+)-([0-9]+)$");


while (true)
{
    Console.ForegroundColor = ConsoleColor.Gray;
    Console.Write("Mata in ett produktnamn ('exit' för att avsluta): ");
    var prod = Console.ReadLine().Trim();

    //  avsluta på 'exit', fråga igen på tom rad

    if (prod.ToLower() == "exit")    break;
    if (prod.ToLower() == "")        continue;

    //  ge felmeddelande om produktnamnet inte stämmer med formatet

    if (!regex.IsMatch(prod))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Produktnamnet måste ha formatet 'ABC-123'");
        continue;
    }

    //  om formatet stämmer kollar vi om den numeriska delen är mellan 200 och 500

    var nummer = Convert.ToInt32(regex.Match(prod).Groups[2].ToString());

    if (nummer >= 200  &&  nummer <= 500)
    {
        produkter.Add(prod);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(prod+" har lagts till i listan");

    } else {

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Den numeriska delen måste vara mellan 200 och 500");
    }
}


//  skriv ut produktlistan

Console.ForegroundColor = ConsoleColor.Gray;
Console.WriteLine();

if (produkter.Count >= 1)
{
    produkter.Sort();
    Console.WriteLine("Din sorterade produktlista:");

    foreach (var prod in produkter)    Console.WriteLine("  "+prod);

} else {

    Console.WriteLine("Din produktlista är tom");
}
