using System;
using System.Collections.Generic;
using System.Text;

namespace CustomEvents
{

    // Delegate
    public delegate void CounterEventHandler(Object sender, CounterEventArgs e);

    public class Counter
    {


        // Events
        public event CounterEventHandler CounterStart = null;
        public event CounterEventHandler CounterChange = null;
        public event CounterEventHandler CounterFinish = null;

        public virtual int Start { get; set; } = 0;
        public virtual int End { get; set; } = 10;
        public virtual int Step { get; set; } = 1;

        protected int _Count = 0;

        public virtual int Count
        {
            get
            {
                return _Count;
            }

            protected set
            {
                _Count = value;
            }
        }

        protected virtual void OnCounterStart(CounterEventArgs e)
        {
            if(CounterStart != null)
            {
                CounterStart(this, e);
            }
        }


        protected virtual void OnCounterChange(CounterEventArgs e)
        {
            CounterChange?.Invoke(this, e);
        }



        protected virtual void OnCounterFinish(CounterEventArgs e)
        {
            if (CounterFinish != null)
            {
                CounterFinish(this, e);
            }
        }

        public Counter(int start = 0, int end = 10, int step = 1)
        {
            Reset(start, end, step);
        }


        public virtual void Run()
        {
            OnCounterStart(new CounterEventArgs(Count));

            for(; Count < End; Count += Step)
            {
                OnCounterChange(new CounterEventArgs(Count));
                
            }

            OnCounterFinish(new CounterEventArgs(Count));
        }

        public virtual void Reset(int start = 0, int end = 10, int step = 1)
        {
            Start = start;
            End = end;
            Step = step;
            Count = Start;
        }


    }
}
