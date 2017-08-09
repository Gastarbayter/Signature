using System;
using System.Collections.Generic;
using System.Linq;
using GenerateSignatures.Block;

namespace GenerateSignatures
{
	/// <summary>
	/// Коллекция блоков файла
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class BlockList<T> where T : HashBlock
	{
		private readonly List<HashBlock> _hashBlocks = new List<HashBlock>();

		/// <summary>
		/// Добавление блока
		/// </summary>
		/// <param name="item"></param>
		public void Add(T item)
		{
			lock (_hashBlocks)
			{
				_hashBlocks.Add(item);
			}
		}

		/// <summary>
		/// Вывод на консоль сигнатуры
		/// </summary>
		public void WriteSignature()
		{
			lock (_hashBlocks)
			{
				foreach (var item in _hashBlocks.OrderBy(b => b.Id))
				{
					Console.WriteLine($"Block: {item.Id} Thread: {item.ThreadId}, hash: {item.DataToString()}");
				}
			}
		}
	}
}