using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpc_13
{
    public struct TemperatureChangedEventArgs
    {
        private int _OldTemperature, _NewTemperature;
        public int OldTemperature
        {
            get { return _OldTemperature; }
        }
        public int NewTemperature
        {
            get { return _NewTemperature; }
        }
        public TemperatureChangedEventArgs(int oldT, int newT)
        {
            _NewTemperature = newT; _OldTemperature = oldT;
        }
    }

    public delegate void TemperatureChangeHandler(TemperatureChangedEventArgs args);

    public class Thermostat
    {
        private int currTemperature;
        public event TemperatureChangeHandler TemperatureChanged;
        virtual protected void OnTemperatureChanged(TemperatureChangedEventArgs args)
        {
            if (TemperatureChanged != null)
                TemperatureChanged(args);
        }
        public int Temperature
        {
            set {
                TemperatureChangedEventArgs args = new TemperatureChangedEventArgs(currTemperature, value);
                currTemperature = value;
                OnTemperatureChanged(args);
            }
        }
    }

    class TestForThermostat
    {
        static void Main(string[] args)
        {
            int maxDiff = 5;
            Thermostat thermo=new Thermostat();
            thermo.TemperatureChanged += t =>
            {
                Console.WriteLine("Temperature changed from {0} to {1}", t.OldTemperature, t.NewTemperature); 
                int diff = Math.Abs(t.NewTemperature-t.OldTemperature);
                if (diff < maxDiff)
                    Console.WriteLine("Thermostat seems to be working fine."); 
                else
                    Console.WriteLine("Humm... Temperature changed to fast!"); 
            };
            thermo.Temperature = 2;
            thermo.Temperature = 10;
            thermo.Temperature = 11;
        }
    }
}
 