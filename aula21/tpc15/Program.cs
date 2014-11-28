using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpc15
{
    public delegate double PipelineStep(int step, double value);

    public class Pipeline
    {
        PipelineStep steps;

        public void Register(PipelineStep p)
        {
            steps += p;
        }
        public void Unregister(PipelineStep p)
        {
            steps -= p;
        }
        public double Process(double initial)
        {
            Delegate[] list = steps.GetInvocationList();
            for (int i = 0; i < list.Length; ++i)
                initial = ((PipelineStep)list[i]).Invoke(i + 1, initial);
            return initial;
        }
        public static void Main(String[] args) {
            Pipeline pipeline = new Pipeline();
            pipeline.Register((n, x) 
                => {Console.WriteLine("passo " + n); return x / 2;});
            pipeline.Register((n, x) 
                => { Console.WriteLine("passo " + n); return x * 2; });
            Console.WriteLine(pipeline.Process(12));
        }
    }
}
