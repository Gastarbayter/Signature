using System;
using System.IO;
using System.Threading;
using GenerateSignatures.Block;

namespace GenerateSignatures
{
	internal static class Program
	{
		private static void Main(string[] args)
		{
			if (args.Length < 2)
				Utility.Exit("You must specify the file and block length");

			var path = args[0];
			if (!File.Exists(path))
				Utility.Exit("Invalid file name");

			int blockSize;
			if (!int.TryParse(args[1], out blockSize))
				Utility.Exit("Incorrectly block size");

			Console.WriteLine("Read file");

			var processors = Environment.ProcessorCount;
			var queue = new BlockQueue<ReadBlock>();

			var reader = new FileReader(blockSize, path);
			var readThread = new Thread(() => reader.Read(queue));
			readThread.Start();

			var hashThreads = new Thread[processors];
			for (var i = 0; i < hashThreads.Length; i++)
			{
				var thread = new Thread(() => Utility.Start(queue));
				thread.Start();
				hashThreads[i] = thread;
			}

			foreach (var hashThread in hashThreads)
			{
				hashThread.Join();
			}

			Utility.WriteSignature();
			Utility.Exit(string.Empty);
		}
	}
}