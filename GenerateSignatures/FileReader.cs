using System;
using System.IO;
using GenerateSignatures.Block;

namespace GenerateSignatures
{
	/// <summary>
	/// Чтение файла
	/// </summary>
	public class FileReader
	{
		private readonly int _blockSize;
		private readonly string _path;

		/// <summary>
		/// Чтение файла
		/// </summary>
		/// <param name="blockSize">Размер блока</param>
		/// <param name="path">Путь к файлу</param>
		public FileReader(int blockSize, string path)
		{
			_blockSize = blockSize;
			_path = path;
		}

		/// <summary>
		/// Чтение файла по блокам
		/// </summary>
		/// <param name="queue">Очередь для блоков</param>
		public void Read(BlockQueue<ReadBlock> queue)
		{
			using (var reader = new BinaryReader(File.Open(_path, FileMode.Open, FileAccess.Read)))
			{
				try
				{
					var index = 0;
					while (true)
					{
						var result = reader.ReadBytes(_blockSize);

						if (result.Length <= 0) break;

						queue.Enqueue(new ReadBlock(index, result));
						index++;
					}
				}
				catch (Exception ex)
				{
					Utility.Exit(ex);
				}
			}
			queue.Stop();
		}
	}
}