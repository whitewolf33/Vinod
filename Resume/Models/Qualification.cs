using System;
using System.Collections.ObjectModel;

namespace Resume
{
	public class Qualification : IGroupable
	{
		public string Degree { get; set; }

		public string University { get; set; }

		public string Period { get; set; }

		public string Institute { get { return String.Format("{0}.png", University); } }
	}
}
