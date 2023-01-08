// See https://aka.ms/new-console-template for more information
int i;
int j;

for (i = 5; i >= 0; --i)
{

	for (j = 0; j <= i; j++)
	{
		if (i == 0 || i == 5 || j == 0 || j == i)
		{
			Console.Write("*");
		}
		else
			Console.Write(" ");
	}
	Console.WriteLine();
}

