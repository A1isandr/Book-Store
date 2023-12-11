using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Store.src.book
{
    interface IBookInfo<T> : INotifyPropertyChanged
    {
        /// <summary>
		/// Book currently being viewed
		/// </summary>
        public T? Book { get; set; }
    }
}
