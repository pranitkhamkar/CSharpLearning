// See https://aka.ms/new-console-template for more information

int i;
int j;
for (i = 0; i <= 5; i++)
{
	for (j = 0; j <= 5; j++)
	{
		if (i == 0 || i == 5 || j == 0 || j == 5)
		{
			Console.Write("*");
		}
		else if(j==5/2 || j==7/2)
		{
			Console.Write("*");
		}
		else
			Console.Write(" ");
	}
	Console.WriteLine();
}
