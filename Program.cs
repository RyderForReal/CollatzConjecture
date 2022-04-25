using System;
using System.Linq;

namespace CollatzConjecture {
	internal static class Program {
		public static void Main(string[] args)
		{
			Console.Clear();
			const string versionString = "V. 1.0.0";
			var count = 0;
			// uint would've been perfectly fine, but some people (including me) love to enter stupidly long numbers.
			ulong n = 0;
			var verbose = false;

			// Check arguments
			if (args.Length >= 1)
			{
				// @formatter:off
				// Switch statement would've looked nicer but was very annoying to work with.
				if (args.Contains("-h") || args.Contains("--help")) {
					Console.WriteLine($"CollatzConjecture {versionString} by RyderForNow / RGN Development. -- HELP MENU");
					Console.WriteLine("https://GitHub.com/RyderForReal // https://GitLab.ryderg.net/RyderForNow");
					Console.WriteLine();
					Console.WriteLine($"Usage: {System.AppDomain.CurrentDomain.FriendlyName} [ARGS] [NUMBER]");
					Console.WriteLine();
					Console.WriteLine("Arguments:");
					Console.WriteLine("-h, --help: Displays this help menu.");
					Console.WriteLine("-v, --verbose: Displays the number of steps taken to reach 1.");
					Console.WriteLine();
					Console.WriteLine("Press enter to continue execution.");
					Console.ReadLine();
					Console.Clear();
				}
				if (args.Contains("-v") || args.Contains("--verbose")) { verbose = true; }
				foreach (var arg in args) { if (ulong.TryParse(arg, out n)) { break; } }
				// @formatter:on
			}

			// Run if no arguments
			if (n == 0)
			{
				Console.WriteLine("Welcome to the Collatz Conjecture Calculator!");
				Console.WriteLine();
				Console.WriteLine("Enter a number (n > 1): ");
				n = ulong.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
			}
			// Run if a number was passed in the arguments
			else { Console.WriteLine($"Program was started with n = {n} passed to it - calculating..."); }

			// @formatter:off
			if (n <= 1) { Console.WriteLine("Invalid number! Press any key to exit."); Console.ReadKey(); return; }
			// @formatter:on

			// Actual program logic
			while (n != 1)
			{
				if (n % 2 == 0)
				{
					if (verbose)
						Console.WriteLine($"Step {count + 1}: {n}/2 = {n / 2}");
					n /= 2;
				}
				else
				{
					if (verbose)
						Console.WriteLine($"Step {count + 1}: 3({n}) + 1 = {n * 3 + 1}");
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