using Microsoft.AspNetCore.Components.Forms;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace KindleNotes.Models
{

	public class KindleClippingsFile
	{

		public IBrowserFile BrowserFile;
		public bool FileHasBeenParsed;

		public List<RawKindleClipping> rawClippings = new();
		private RawKindleClipping currentClipping;

		internal async Task ParseFile()
		{
			await ReadFileContent();
			ProcessFileContent();

			FileHasBeenParsed = true;
		}

		private async Task ReadFileContent()
		{
			rawClippings.Clear();

			currentClipping = new RawKindleClipping();
			string line;
			var reader = new StreamReader(BrowserFile.OpenReadStream());

			while ((line = await reader.ReadLineAsync()) is not null)
			{
				currentClipping.AddLine(line);
				if (currentClipping.FullyInitialized)
				{
					rawClippings.Add(currentClipping);
					currentClipping = new RawKindleClipping();
				}
			}
		}

		private void ProcessFileContent()
		{

		}
	}
}
