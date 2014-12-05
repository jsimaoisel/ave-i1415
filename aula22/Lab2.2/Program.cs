using System;
using System.Reflection;

namespace Lab2
{
    public class EventArgsThermostat : EventArgs
    {
        private int prev, curr;
        public EventArgsThermostat(int prev, int curr)
        {
            this.prev = prev;
            this.curr = curr;
        }
        public int PrevTemperature { get { return prev; } }
        public int CurrTemperature { get { return curr; } }
    }

    public class Thermostat
    {
        protected int currTemperature;
        public event EventHandler TemperatureChanged;
        public int Temperature
        {
            get { return currTemperature; }
            set
            {
                if (TemperatureChanged != null) 
                    TemperatureChanged(this, new EventArgsThermostat(currTemperature, value));
                currTemperature = value;
            }
        }

        public static void M(object sender, EventArgs eventArgs)
        {
            EventArgsThermostat arg = eventArgs as EventArgsThermostat;
            Console.WriteLine("Prev={0} Curr={1}", arg.PrevTemperature, arg.CurrTemperature);
        }

        public static void Main(String[] args)
        {
            Thermostat thermo = new Thermostat();

            thermo.TemperatureChanged += M;



            Assembly assembly = Assembly.LoadFrom("Lab2.2.exe");
            foreach(Type t in assembly.GetTypes()) 
            {
                foreach (MethodInfo mi in t.GetMethods())
                {
                    // devia usar IsCompatible(typeof(EventHandler), mi)
                    if (mi.Name == "M")
                    { 
                        EventHandler eh = 
                            (EventHandler)Delegate.CreateDelegate(typeof(EventHandler), mi);

                        // OR

                        EventHandler eh2 =
                            (sender, eargs) =>
                            {
                                mi.Invoke(null,
                                new object[] { 
                                    sender, eargs
                                });
                            };


                        thermo.TemperatureChanged += eh;
                    }
                }
            }

            thermo.Temperature = 10;
        }
    }
}
