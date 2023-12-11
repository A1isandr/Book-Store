using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Store.src.readable
{
    internal class Magazine : Readable
    {
        /// <summary>
        /// 
        /// </summary>
        public string? Number {  get; set; }

        public override decimal CalculatePrice()
        {
            throw new NotImplementedException();
        }
    }
}
