using System;
using System.Collections.Generic;
using System.Reflection;

namespace Reflection_intro
{
    class Program
    {
        static void M() { }
        static void Main()
        {
            Probe.Inspect("Reflection-intro.exe");
        }
    }

    class Probe
    {
        public void M(int a)
        {
            Console.WriteLine(a);
        }
        public static void Inspect(string path)
        {
            Assembly a = Assembly.LoadFrom(path);
            foreach (Module module in a.GetModules())
                foreach (Type t in module.GetTypes()) 
                    foreach (MethodInfo m in t.GetMethods(
                                            BindingFlags.DeclaredOnly | 
                                            BindingFlags.Static | 
                                            BindingFlags.NonPublic | 
                                            BindingFlags.Public))
                    {
                        Console.WriteLine(t.Name + "::" + m.Name);
                        if (t.Equals(typeof(Probe))) {
                            if (m.Name == "M")
                                m.Invoke(new Probe(), new object[]{ 12 });
                                m.Invoke(Activator.CreateInstance(t), new object[] { 12 });
                        }
                    }
        }
    }
}
