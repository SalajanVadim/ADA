using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
namespace Lab1
{
   public static class Fibonacci
   {
       public static long IsSleepy(long n)
       {
           Sleep();
           return GetFibonacci(n);
       }
   
       public static long IsBusy(long n)
       {
           Busy();
           return GetFibonacci(n);
       }
   
       private void Sleep()
       {
           var sleep_ms = 250;
           Thread.Sleep(sleep_ms);
       }
   
       private int Busy()
       {
           int it_count = 15000;
           int k = 0;
           for (int i = 0; i < it_count; i++)
           {
               for (int j = 0; j < it_count; j++)
               {
                   k++;
               }
           }
           return k;
       }
       private long GetFibonacci(long n)
       {
          
           if (n == 1)
               return 0;
           if (n == 2)
               return 1;
   
           long n = 0, n = 1;
           long fib = 0;
   
           for (int i = 3; i <= n; i++)
           {
               fib = n + n2;
               n1 = n2;
               n2 = fib;
           }
   
           return fib;
       }
   
       public static long[] ReadFile(string fileName)
       {
           string fileData = File.ReadAllText(fileName);
           var n = fileData.Split('\n').Select(x => Int64.Parse(x)).ToArray();
           return n;
       }
   
       public static void WriteFile(string fileName, long[] n)
       {
           if (n != null)
           {
               string text = string.Join('\n', n);
               File.WriteAllText(fileName, text);
           }
       }

       public static void Add(string fileName, long n)
       {
           using (StreamWriter sw = File.AppendText(fileName))
           {
               sw.WriteLine(n);
           }
       }

       public static void Clear(string file)
       {
           FileInfo data = new FileInfo(file);

           if (data.Exists)
           {
               data.Delete();
           }

           using (FileStream data1 = data.Create())
           {
           }
       }
    }
}