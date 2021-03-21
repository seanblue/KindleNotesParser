using System.Collections.Generic;

namespace KindleNotes.Models
{
	public class RawKindleClipping
	{
		private const string clippingDelimiter = "==========";
		private readonly List<string> lines = new();
		
		public bool FullyInitialized;

		public KindleClippingType Type
		{
			get
			{
				if (lines.Count < 2)
					return KindleClippingType.Unknown;

				var contentTypeLine = lines[1];

				if (contentTypeLine.StartsWith(KindleClippingTypeConsts.BookmarkTypeKeyword))
					return KindleClippingType.Bookmark;

				if (contentTypeLine.StartsWith(KindleClippingTypeConsts.HighlightTypeKeyword))
					return KindleClippingType.Highlight;

				if (contentTypeLine.StartsWith(KindleClippingTypeConsts.NoteTypeKeyword))
					return KindleClippingType.Note;

				return KindleClippingType.Unknown;
			}
		}

		public void AddLine(string line)
		{
			if (line == clippingDelimiter)
				FullyInitialized = true;
			else if (!string.IsNullOrWhiteSpace(line))
				lines.Add(line);
		}

		public List<string> Lines => lines;
	}
}
