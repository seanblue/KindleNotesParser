using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace KindleNotes.Models
{
	public class KindleClippingsFile
	{
		private const int numberOfMb = 10;
		private const long maxFileSizeBytes = numberOfMb * 1_024 * 1_024;

		public IBrowserFile BrowserFile;
		public string ErrorMessage;

		public List<RawKindleClipping> rawClippings = new();
		private RawKindleClipping currentClipping;

		internal async Task ParseFile()
		{
			Reset();

			try
			{
				await ReadFileContent();
			}
			catch (IOException)
			{
				ErrorMessage = $"The file exceeded the max length of {numberOfMb}MB.";
				return;
			}
			catch (Exception)
			{
				ErrorMessage = "An unknown error has occurred while reading the file.";
				return;
			}

			if (rawClippings.Count == 0)
			{
				ErrorMessage = "The file did not contain any Kindle highlights or notes.";
				return;
			}

			ProcessFileContent();
		}

		private void Reset()
		{
			rawClippings.Clear();
			currentClipping = new RawKindleClipping();
			ErrorMessage = null;
		}

		private async Task ReadFileContent()
		{
			string line;
			using var reader = new StreamReader(BrowserFile.OpenReadStream(maxFileSizeBytes));

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
