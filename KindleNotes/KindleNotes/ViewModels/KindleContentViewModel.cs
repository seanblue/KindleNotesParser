using System;

namespace KindleNotes.ViewModels
{
	public abstract class KindleContentViewModel
	{
		public Guid Id { get; protected set; }
		public string Title { get; protected set; }
	}
}
