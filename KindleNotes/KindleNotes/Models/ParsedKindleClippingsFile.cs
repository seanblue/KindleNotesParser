using System.Collections.Generic;

namespace KindleNotes.Models
{
	public class ParsedKindleClippingsFile
	{
		public List<RawKindleClipping> RawClippings;

		public ParsedKindleClippingsFile(List<RawKindleClipping> rawClippings)
		{
			RawClippings = rawClippings;
		}
	}
}
