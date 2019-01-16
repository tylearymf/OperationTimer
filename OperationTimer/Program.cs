using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace OperationTimer
{
    class Program
    {
        static void Main(string[] args)
        {
            const int cCount = 100000000;

            using (new OperationTimer("List<Int32>"))
            {
                var l = new List<int>();
                for (int i = 0; i < cCount; i++)
                {
                    l.Add(i);
                    var x = l[i];
                }
                l = null;
            }

            using (new OperationTimer("ArrayList"))
            {
                var l = new ArrayList();
                for (Int32 i = 0; i < cCount; i++)
                {
                    l.Add(i);
                    Int32 x = (Int32)l[i];
                }
                l = null;
            }


            Console.ReadLine();
        }
    }
}
