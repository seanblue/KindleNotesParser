using KindleNotes.Models;
using System.Collections.Generic;

namespace KindleNotes.ViewModels
{
	public class ClippingsFileViewModel
	{
		public List<KindleContentViewModel> KindleContent = new();

		public ClippingsFileViewModel(ParsedKindleClippingsFile parsedKindleClippingsFile)
		{
			foreach (var clipping in parsedKindleClippingsFile.RawClippings)
				KindleContent.Add(new KindleContentViewModel(clipping));
		}
	}
}
