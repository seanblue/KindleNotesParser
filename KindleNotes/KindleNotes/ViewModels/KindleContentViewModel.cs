using KindleNotes.Extensions;
using KindleNotes.Models;
using System;

namespace KindleNotes.ViewModels
{
	public class KindleContentViewModel
	{
		public Guid Id { get; }
		public string Type { get; }
		public string Title { get; }
		public string Location { get; }
		public string Content { get; }

		public KindleContentViewModel(RawKindleClipping clipping)
		{
			Id = clipping.Id;
			Type = clipping.Type.ToString();

			var (titleLine, locationAndDateLine, contentLines) = clipping.Lines;

			Title = titleLine;

			if (clipping.Type == KindleClippingType.Unknown)
				return;

			Location = GetLocation(Type, locationAndDateLine);
			Content = string.Join('\n', contentLines);
		}

		private static string GetLocation(string type, string locationAndDateLine)
		{
			var locationLine = locationAndDateLine.Split('|')[0];
			var locationStringSplit = locationLine.Remove(0, KindleClippingTypeConsts.GetKeyword(type).Length).Trim().Split('-');

			var startLocation = FormatNumber(locationStringSplit[0]);
			if (locationStringSplit.Length == 1)
				return startLocation;

			var endLocation = FormatNumber(locationStringSplit[1]);

			return $"{startLocation} - {endLocation}";
		}

		private static string FormatNumber(string num)
		{
			return string.Format("{0:N0}", int.Parse(num));
		}
	}
}
