using System;
namespace Resume
{
	public class MenuItem
	{
		public string Title { get; set; }

		public string Icon { get; set; }

		public Type Target { get; set; }
	}

	public class Timeline
	{
		public int Id { get; set; }

		public int Year { get; set; }

		public string Title { get; set; }

		public string SubTitle { get; set; }
	}
}
