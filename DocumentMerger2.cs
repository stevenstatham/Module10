using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DocumentMerger
{
	class Program
	{
		static void Main(string[] args)
		{
			if (args.Length <= 2)
			{
				Console.WriteLine("Please enter an appropriate number of arguements(3+)");
				System.Environment.Exit(0);
			}
			string contin = "y";
			bool good = false;
			string line;
			int count = 0;
			string fileName1;
			string fileName2;
			fileName2 = args[args.Length - 1];
			Console.WriteLine("Welcome to the Document Meger!");
			for (int x = 0; x < (args.Length - 1); x++)
			{
				fileName1 = args[x];
				if (!fileName1.Contains(".txt"))
				{
					fileName1 = fileName1 + ".txt";
				}
				while (good == false)
				{
					if (File.Exists(fileName1))
					{
						good = true;
					}
					else
					{
						Console.WriteLine("Invalid file name. Please use a valid file.");
						fileName1 = Console.ReadLine();
					}
				}
				good = false;
				try
				{
					StreamReader file1 = new StreamReader(fileName1);
					StreamWriter file2 = new StreamWriter(fileName2);
					while ((line = file1.ReadLine()) != null)
					{
						file2.WriteLine(line);
						count = count + line.Length;
					}
					file1.Close();
					file2.Close();
				}
				catch (Exception e)
				{
					Console.WriteLine("Error!");
					Console.WriteLine("{0}", e);
				}
			}
			Console.WriteLine("{0} was successfully saved. The document contains {1} characters.", fileName2, count);
		}
	}
}
