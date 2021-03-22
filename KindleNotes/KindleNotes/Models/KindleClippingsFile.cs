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

		public PageStatus PageStatus;
		public IBrowserFile SelectedFile
		{
			get => selectedFile;
			set
			{
				selectedFile = value;
				contentLoadedForCurrentFile = false;
			}
		}
		public string ErrorMessage;
		public ParsedKindleClippingsFile ParsedClippingsFile;

		private IBrowserFile selectedFile;
		private bool contentLoadedForCurrentFile;

		internal async Task ParseFile()
		{
			if (contentLoadedForCurrentFile || SelectedFile is null)
				return;

			Reset();
			PageStatus = PageStatus.Loading;

			try
			{
				var parser = new KindleClippingsStreamReader(SelectedFile.OpenReadStream(maxFileSizeBytes));
				ParsedClippingsFile = await parser.GetParsedFile();
			}
			catch (IOException)
			{
				SetErrorState($"The file exceeded the max length of {numberOfMb}MB.");
				return;
			}
			catch (Exception)
			{
				SetErrorState("An unknown error has occurred while reading the file.");
				return;
			}

			if (ParsedClippingsFile.IsEmpty)
			{
				SetErrorState("The file did not contain any Kindle highlights or notes.");
				return;
			}

			SetLoadedState();
		}

		private void SetLoadedState()
		{
			contentLoadedForCurrentFile = true;
			PageStatus = PageStatus.Loaded;
		}

		private void SetErrorState(string errorMessage)
		{
			ErrorMessage = errorMessage;
			PageStatus = PageStatus.Error;
		}

		private void Reset()
		{
			ErrorMessage = null;
		}
	}
}
