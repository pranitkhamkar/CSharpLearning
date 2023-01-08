// See https://aka.ms/new-console-template for more information
Console.Write(" Select the Genders from following \n press 1 for Male \n press 2 for Female \n : ");
int Gender = Convert.ToInt32(Console.ReadLine());

	if (Gender == 1 && Gender != 2)
	{
		Console.WriteLine("You selected male and Male should be marry after 21 years");
	}
	else if (Gender == 2 && Gender != 1)
	{
		Console.WriteLine("You selected Female and Female should be marry after 18 years");
	}
	else
	{
		Console.WriteLine("try again with pressing 1 or 2 ");
	}