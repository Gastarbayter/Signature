namespace GenerateSignatures.Block
{
	/// <summary>
	/// ���� ������ �����
	/// </summary>
	public class ReadBlock : BaseBlock
	{
		/// <summary>
		/// ����������� 
		/// </summary>
		/// <param name="id">������������� �����</param>
		/// <param name="data">��������� ����</param>
		public ReadBlock(int id, byte[] data) : base(id, data) { }
	}
}