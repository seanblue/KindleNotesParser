using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace KindleNotes.Models
{
	public class KindleHighlight
	{
		public string Title;
		public int StartPosition;
		public int EndPosition;
		public string DateAdded;
		public string Content;
	}
	
	public class KindleNote
	{
		public string Title;
		public int Position;
		public string DateAdded;
		public string Content;
	}

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
