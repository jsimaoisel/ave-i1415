using System;
using System.Windows.Forms;

namespace ObserversMaxCalls
{
    public class C
    {

        [ObserverHandler(MaxCalls = 1)]
        public static void MboxHandler(int value)
        {
            MessageBox.Show("Item = " + value);
        }

        [ObserverHandler(MaxCalls = 10)]
        public static void MboxHandler2(int value)
        {
            MessageBox.Show("Item = " + value);
        }

    }

    public class B
    {

        [ObserverHandler(MaxCalls = 4)]
        public static void ConsoleHandler(int value)
        {
            Console.WriteLine("ConsoleHandler = " + value);
        }

    }

}
