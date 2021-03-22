using KindleNotes.Models;
using System;
using System.Linq;

namespace KindleNotes.ViewModels
{
	public class KindleHighlightViewModel : KindleContentViewModel
	{
		public int StartLocation;
		public int EndLocation;
		public string Content;

		public KindleHighlightViewModel(RawKindleClipping clipping)
		{
			Id = clipping.Id;

			var lines = clipping.Lines;
			if (lines.Count < 2)
				throw new ArgumentException("A bookmark must be at least 2 lines", nameof(clipping));

			Title = lines[0];

			var locationLine = lines[1].Split('|')[0];
			var locationStringSplit = locationLine.Remove(0, KindleClippingTypeConsts.HighlightTypeKeyword.Length).Trim().Split('-');

			StartLocation = int.Parse(locationStringSplit[0]);
			EndLocation = int.Parse(locationStringSplit[1]);

			Content = string.Join('\n', lines.Skip(2));
		}
	}
}
