namespace GenerateSignatures.Block
{
	/// <summary>
	/// ������� ���� �����
	/// </summary>
	public abstract class BaseBlock
	{
		/// <summary>
		/// ������������� �����
		/// </summary>
		public int Id { get; }

		/// <summary>
		// ��������� �����
		/// </summary>
		public byte[] Data { get; }

		/// <summary>
		///  �����������
		/// </summary>
		/// <param name="id">������������� �����</param>
		/// <param name="data">������ ����</param>
		protected BaseBlock(int id, byte[] data)
		{
			Id = id;
			Data = data;
		}
	}
}