namespace GenerateSignatures.Block
{
	/// <summary>
	/// Блок чтения файла
	/// </summary>
	public class ReadBlock : BaseBlock
	{
		/// <summary>
		/// Конструктор 
		/// </summary>
		/// <param name="id">Идентификатор блока</param>
		/// <param name="data">Считанные байт</param>
		public ReadBlock(int id, byte[] data) : base(id, data) { }
	}
}