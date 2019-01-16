using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace OperationTimer
{
    class OperationTimer : IDisposable
    {
        Stopwatch mStopWatch;
        string mText;
        int mCollectionCount;

        public OperationTimer(string pText)
        {
            PrepareForOperation();

            mText = pText;
            mCollectionCount = GC.CollectionCount(0);
            mStopWatch = Stopwatch.StartNew();
        }

        public void Dispose()
        {
            Console.WriteLine("{0} (GCs={1,3}) {2}", mStopWatch.Elapsed, GC.CollectionCount(0) - mCollectionCount, mText);
        }

        static void PrepareForOperation()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }
}
