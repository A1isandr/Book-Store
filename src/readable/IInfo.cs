using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Store.src.book
{
    interface IInfo : INotifyPropertyChanged
    {
        /// <summary>
		/// Book currently being viewed
		/// </summary>
        public Readable? Book { get; set; }
    }
}
