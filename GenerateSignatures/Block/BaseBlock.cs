namespace GenerateSignatures.Block
{
	/// <summary>
	/// Базовый блок файла
	/// </summary>
	public abstract class BaseBlock
	{
		/// <summary>
		/// Идентификатор блока
		/// </summary>
		public int Id { get; }

		/// <summary>
		// Считанные байты
		/// </summary>
		public byte[] Data { get; }

		/// <summary>
		///  Конструктор
		/// </summary>
		/// <param name="id">Идентификатор блока</param>
		/// <param name="data">Массив байт</param>
		protected BaseBlock(int id, byte[] data)
		{
			Id = id;
			Data = data;
		}
	}
}