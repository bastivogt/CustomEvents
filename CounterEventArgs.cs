using System;
using System.Collections.Generic;
using System.Text;

namespace CustomEvents
{
    public class CounterEventArgs : EventArgs
    {

        private int _Count;

        public int Count
        {
            get
            {
                return _Count;
            }
            private set
            {
                _Count = value;
            }
        }

        public CounterEventArgs(int count)
        {
            Count = count;
        }
    }
}
