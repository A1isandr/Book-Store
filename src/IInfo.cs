using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book_Store.MVVM.Model;

namespace Book_Store.src
{
    /// <summary>
    /// 
    /// </summary>
    interface IInfo : INotifyPropertyChanged
    {
        /// <summary>
		/// Item currently being viewed
		/// </summary>
        public Readable? Item { get; set; }
    }
}
