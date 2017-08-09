using System;
using System.Collections.Generic;
using System.Threading;
using GenerateSignatures.Block;

namespace GenerateSignatures
{
	/// <summary>
	/// Очередь блоков
	/// </summary>
	/// <typeparam name="T">Блок файла</typeparam>
	public class BlockQueue<T> where T : ReadBlock
	{
		private readonly object _mutex = new object();
		private  readonly Queue<T> _queue = new Queue<T>();
		private bool _isDead;

		/// <summary>
		/// Добавление в очередь
		/// </summary>
		/// <param name="task"></param>
		public void Enqueue(T task)
		{
			if (task == null)
				throw new ArgumentNullException(nameof(task));
			lock (_mutex)
			{
				if (_isDead)
					throw new InvalidOperationException("Queue already stopped");
				_queue.Enqueue(task);
				Monitor.Pulse(_mutex);
			}
		}

		/// <summary>
		/// Извлечение из начала очереди
		/// </summary>
		/// <returns></returns>
		public T Dequeue()
		{
			lock (_mutex)
			{
				while (_queue.Count == 0 && !_isDead)
					Monitor.Wait(_mutex);

				return _queue.Count == 0 ? null : _queue.Dequeue();
			}
		}

		/// <summary>
		/// Остановка работы с очередью
		/// </summary>
		public void Stop()
		{
			lock (_mutex)
			{
				_isDead = true;
				Monitor.PulseAll(_mutex);
			}
		}
	}
}