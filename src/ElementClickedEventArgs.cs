using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Store.src
{
	/// <summary>
	/// Class for providing event data.
	/// </summary>
	public class ElementClickedEventArgs : EventArgs
	{
		public object EventInfo { get; }

		public ElementClickedEventArgs(object info)
		{
			EventInfo = info;
		}
	}
}
