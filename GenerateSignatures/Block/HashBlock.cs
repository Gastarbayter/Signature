using System.Text;

namespace GenerateSignatures.Block
{
	/// <summary>
	/// Хешированный блок
	/// </summary>
	public class HashBlock : BaseBlock
	{
		/// <summary>
		/// Идентификатор потока
		/// </summary>
		public int ThreadId { get; }

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="id">Идентификатор блока</param>
		/// <param name="data">Хэш</param>
		/// <param name="threadId">Идентификатор потока</param>
		public HashBlock(int id, byte[] data, int threadId) : base(id, data)
		{
			ThreadId = threadId;
		}

		/// <summary>
		/// Конвертирование хэша в строку
		/// </summary>
		public string DataToString()
		{
			var hex = new StringBuilder();
			foreach (var b in Data)
				hex.AppendFormat("{0:X2}", b);
			return hex.ToString();
		}
	}
}