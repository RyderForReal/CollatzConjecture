using System;
using System.Linq;

namespace CollatzConjecture {
	internal static class ProgramMinimal {
		public static void Main(string[] args)
		{
			var count = 0;
			uint n = 0;
			
			
			Console.WriteLine("Welcome to the Collatz Conjecture Calculator!");
			Console.WriteLine();
			Console.WriteLine("Enter a number (n > 1): ");
			n = uint.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
				
			if (n <= 1) { Console.WriteLine("Invalid number! Press any key to exit."); Console.ReadKey(); return; }

			// Actual program logic
			while (n != 1)
			{
				if (n % 2 == 0)
				{
					n /= 2;
				}
				else
				{
					n = 3 * n + 1;
				}

				count++;
			}

			Console.WriteLine();
			Console.WriteLine($"It took {count + 1} steps to reach 1.");
			Console.WriteLine();
			Console.WriteLine("Press enter to close the program.");
			Console.ReadLine();
		}
	}
}