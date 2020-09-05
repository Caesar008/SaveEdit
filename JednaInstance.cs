using System.Diagnostics;
using System.Threading;
using System;

namespace SaveEdit
{
    class JednaInstance
    {
        static Mutex mutex = new Mutex(false, "Caesaruv SaveEdit");
        public static bool Bezi(TimeSpan cekaciDoba, bool update = false)
        {
            if (!update && !mutex.WaitOne(cekaciDoba, false))
            {
                return true;
            }
            return false;
        }

        public static void UvolniProstredek()
        {
            mutex.ReleaseMutex();
        }
    }
}
