using System.Collections.Generic;

namespace KindleNotes.Models
{
	public class RawKindleClipping
	{
		private const string clippingDelimiter = "==========";
		private readonly List<string> lines = new();
		
		public bool FullyInitialized;

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
