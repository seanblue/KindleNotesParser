using System.Collections.Generic;

namespace KindleNotes.Models
{
	public class ParsedKindleClippingsFile
	{
		public ParsedKindleClippingsFile(List<RawKindleClipping> rawClippings)
		{
			RawClippings = rawClippings;
		}

		public List<RawKindleClipping> RawClippings { get; }
		public bool IsEmpty => RawClippings.Count == 0;
	}
}