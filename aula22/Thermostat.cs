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
    }
}
