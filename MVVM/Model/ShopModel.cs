using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Store.MVVM.Model
{
    class Notification
    {
        private static int _lastId = 0;

        public int Id { get; set; }
        public string Text { get; set; }

        public Notification(string text)
        {
            Id = _lastId++;
            Text = text;
        }
    }
}
