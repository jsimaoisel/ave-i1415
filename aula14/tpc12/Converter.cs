using System;


interface ConverterToDouble<T>
{
    double convert(T v);
}

class FromStringToDouble : ConverterToDouble<string>
{
    public double convert(string v)
    {
        return Double.Parse(v);
    }
}

class FromDateTimeToDouble : ConverterToDouble<DateTime>
{
    public double convert(DateTime v)
    {
        DateTime reference = new DateTime(1970, 1, 1, 0, 0, 0);
        TimeSpan span = v - reference;
        return span.TotalSeconds;
    }
}

class ConverterTPC12
{

    private static double[] ConvertAll<T>(T[] values, ConverterToDouble<T> converter)
    {
        double[] ret = new double[values.Length];
        for (int i = 0; i < values.Length; ++i)
            ret[i] = converter.convert(values[i]);
        return ret;
    }


    public static void Main(String[] args)
    {
        string[] strs = { "43,1", "11,2", "323,0" };
        FromStringToDouble doubleConv = new FromStringToDouble();
        foreach (double d in ConvertAll(strs, doubleConv))
            Console.WriteLine(d);

        DateTime[] times = { DateTime.Now, DateTime.Now + TimeSpan.FromDays(1), DateTime.Now + TimeSpan.FromDays(2) };
        FromDateTimeToDouble timeConv = new FromDateTimeToDouble();
        foreach (double d in ConvertAll(times, timeConv))
            Console.WriteLine(d);
    }
}
