using KindleNotes.Models;
using Microsoft.AspNetCore.Components.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KindleNotes.Pages
{
	public partial class Index
	{
		protected readonly Dictionary<string, object> supportedFileTypesAttribute = new()
		{
			{ "accept", ".txt" }
		};

		protected KindleClippingsFile kindleClippingsFile = new();

		protected void SetFile(InputFileChangeEventArgs e)
		{
			kindleClippingsFile.BrowserFile = e.File;
		}

		protected async Task Submit()
		{
			await kindleClippingsFile.ParseFile();
		}
	}
}
