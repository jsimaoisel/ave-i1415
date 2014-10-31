using System;
using System.Collections;
using System.Windows.Forms;

namespace ObjectFunctions
{

    public interface IDisplay
    {
        void show(int value);
    }

    public class ToConsole : IDisplay
    {
        public void show(int value)
        {
            Console.WriteLine("Item="+value);
        }
    }

    public class ToMsgBox: IDisplay
    {
        public void show(int value)
        {
            MessageBox.Show("Item="+value);
        }
    }


    public class Program
    {
        public static void ShowAll(int[] values, IDisplay display)
        {
            foreach (int v in values)
                display.show(v);
        }

        static void Main(string[] args)
        {
            ShowAll(new int[] { 1, 2, 3 }, new ToConsole());
            ShowAll(new int[] { 1, 2, 3 }, new ToMsgBox());
        }
    }
}
