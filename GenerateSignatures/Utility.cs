using System;
using System.Security.Cryptography;
using System.Threading;
using GenerateSignatures.Block;

namespace GenerateSignatures
{
	/// <summary>
	/// Утилиты
	/// </summary>
	public static class Utility
	{
		private static readonly BlockList<HashBlock> HashList = new BlockList<HashBlock>();

		/// <summary>
		/// Чтение блоков файла из очереди для генерации сигнатуры 
		/// </summary>
		/// <param name="queue"></param>
		internal static void Start(BlockQueue<ReadBlock> queue)
		{
			while (true)
			{
				var result = queue.Dequeue();
				if (result == null) break;
				HashList.Add(new HashBlock(result.Id, Sha256Hash(result.Data), Thread.CurrentThread.ManagedThreadId));
			}
		}

		/// <summary>
		/// Генерирование хеша
		/// </summary>
		/// <param name="value">Данные</param>
		/// <returns></returns>
		private static byte[] Sha256Hash(byte[] value)
		{
			using (var hash = SHA256.Create())
			{
				try
				{
					return hash.ComputeHash(value);
				}
				catch (Exception ex)
				{ 
					Exit(ex);
					return new byte[0];
				}
			}
		}

		/// <summary>
		/// Вывод на консоль сигнатуры.
		/// </summary>
		public static void WriteSignature()
		{
			HashList.WriteSignature();
		}

		/// <summary>
		/// Выход из программы
		/// </summary>
		/// <param name="message">Сообщение</param>
		public static void Exit(string message)
		{
			if (!string.IsNullOrEmpty(message))
				Console.WriteLine(message);
			Console.WriteLine("Press any key to continue....");
			Console.ReadKey();
			Environment.Exit(0);
		}

		/// <summary>
		///  Выход из программы
		/// </summary>
		/// <param name="ex">Ошибка</param>
		public static void Exit(Exception ex)
		{
			Console.WriteLine($"Error message: {ex.Message}");
			Console.WriteLine($"Error stack trace: {ex.StackTrace}");
			Console.WriteLine("Press any key to continue....");
			Console.ReadKey();
			Environment.Exit(0);
		}
	}
}
