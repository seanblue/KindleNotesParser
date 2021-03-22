using KindleNotes.Models;
using System;
using System.Linq;

namespace KindleNotes.ViewModels
{
	public class KindleNoteViewModel : KindleContentViewModel
	{
		public int Location;
		public string Content;

		public KindleNoteViewModel(RawKindleClipping clipping)
		{
			Id = clipping.Id;

			var lines = clipping.Lines;
			if (lines.Count < 2)
				throw new ArgumentException("A bookmark must be at least 2 lines", nameof(clipping));

			Title = lines[0];

			var locationLine = lines[1].Split('|')[0];
			var locationString = locationLine.Remove(0, KindleClippingTypeConsts.NoteTypeKeyword.Length).Trim();

			Location = int.Parse(locationString);

			Content = string.Join('\n', lines.Skip(2));
		}
	}
}