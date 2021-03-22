using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace KindleNotes.Models
{
	public class KindleClippingsStreamReader
	{
		private readonly Stream stream;
		
		public KindleClippingsStreamReader(Stream stream)
		{
			this.stream = stream;
		}

		public async Task<ParsedKindleClippingsFile> GetParsedFile()
		{
			using var streamReader = new StreamReader(stream);

			var rawClippings = new List<RawKindleClipping>();
			var currentClipping = new RawKindleClipping();

			string line;
			while ((line = await streamReader.ReadLineAsync()) is not null)
			{
				currentClipping.AddLine(line);
				if (currentClipping.FullyInitialized)
				{
					rawClippings.Add(currentClipping);
					currentClipping = new RawKindleClipping();
				}
			}

			return new ParsedKindleClippingsFile(rawClippings);
		}
	}
}
