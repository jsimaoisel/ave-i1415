using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Delegates
{
    class PrintDecorator
    {
        private String prefix;
        public PrintDecorator(String prefix)
        {
            this.prefix = prefix;
        }
        public void Show(int value)
        {
            Console.WriteLine(prefix + " " + value);
        }
    }

    class FirstDelegate
    {
        public delegate void Display(int value);

        public delegate void OtherDisplay(String value);


        public static void ToConsole(int value)
        {
            Console.WriteLine("Item=" + value);
        }

        public static void ToMsgBox(int value)
        {
            MessageBox.Show("Item=" + value);
        }

        public static void ShowAll(int[] values, Display display)
        {
            foreach (int v in values)
                display(v);
        }

        static void Main(string[] args)
        {

            ShowAll(
                new int[] { 1, 2, 3 },
                new Display(FirstDelegate.ToMsgBox));

            /* 3 outras formas fazer a mesma coisa */
            ShowAll(
                new int[] { 1, 2, 3 }, 
                ToConsole);

            ShowAll(
                new int[] { 1, 2, 3 },
                delegate(int x) { Console.WriteLine(x); });

            ShowAll(
                new int[] { 1, 2, 3 },
                x => Console.WriteLine(x) );
            /* ------------------------------------ */


            #region Instance Delegate
            
            Display d1 = new Display(new PrintDecorator("***").Show);
            Display d2 = new Display(new PrintDecorator("->").Show);
            ShowAll(new int[] { 1, 2, 3 }, d1);
            ShowAll(new int[] { 1, 2, 3 }, d2);
            
            #endregion


            #region Combining Instance Delegates
            
            Display d3 = new Display(new PrintDecorator("*a* ").Show);
            Display d4 = new Display(new PrintDecorator("*b* ").Show);
            //Display multipleDisplay = (Display) Delegate.Combine(d3, d4);
            d3 += d4;
            ShowAll(new int[] { 1, 2, 3 }, d3);

            //Display singleDisplay = (Display) Delegate.Remove(multipleDisplay, d4);
            d3 -= d4;
            ShowAll(new int[] { 1, 2, 3 }, d3);

            #endregion

        }
    }
}



