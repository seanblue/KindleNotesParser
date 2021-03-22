using KindleNotes.Models;
using System.Collections.Generic;

namespace KindleNotes.ViewModels
{
	public class ClippingsFileViewModel
	{
		public List<KindleBookmarkViewModel> Bookmarks = new();
		public List<KindleHighlightViewModel> Highlights = new();
		public List<KindleNoteViewModel> Notes = new();

		public ClippingsFileViewModel(ParsedKindleClippingsFile parsedKindleClippingsFile)
		{
			foreach (var clipping in parsedKindleClippingsFile.RawClippings)
			{
				if (clipping.Type == KindleClippingType.Bookmark)
					Bookmarks.Add(new KindleBookmarkViewModel(clipping));
				else if (clipping.Type == KindleClippingType.Highlight)
					Highlights.Add(new KindleHighlightViewModel(clipping));
				else if (clipping.Type == KindleClippingType.Note)
					Notes.Add(new KindleNoteViewModel(clipping));
			}
		}
	}
}
