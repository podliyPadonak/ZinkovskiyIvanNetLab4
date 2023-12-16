using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZinkovskiyTask;
public class Programm
{
    public static void Main()
    {
        DateTime timeStart = DateTime.Now;
        var path = "text.txt";
        var dic = new SortedDictionary<string, int>();
        var signDic = new SortedDictionary<char, int>();
        char[] signs = new char[] { '.', ';', '!', '?',':','(',')', '…', '»', '«', ',' };
        string[] buffer;
        try
        {
            StreamReader sr = new StreamReader(new FileStream(path, FileMode.Open));
            while (!sr.EndOfStream)
            {
                buffer = sr.ReadLine().ToLower().Split(' ');
                foreach (var it in buffer)
                {
                    string item = it;
                    foreach (var s in signs)
                    {
                        int signCount = it.Where(i => i == s).Count();
                        if (signCount > 0)
                        {
                            DictionaryOperations.AddKeyOrUpdate(ref signDic, s, signCount);
                            item = item.Replace(s.ToString(), string.Empty);
                        }
                    }
                    if (item == "")
                    {
                        continue;
                    }
                    if (item == "–" || item == "-")
                    {
                        DictionaryOperations.AddKeyOrUpdate(ref signDic, '-', 1);
                    }
                    else
                    {
                        DictionaryOperations.AddKeyOrUpdate(ref dic, ref item, 1);
                    }
                }
            }
            sr.Close();
            Console.OutputEncoding = Encoding.UTF8;
            // LINQ-запрос
            foreach (var it in dic)
            {
                Console.WriteLine("{0}: {1}", it.Key, it.Value);
            }
            Console.WriteLine("\nРозділові знаки:");
            foreach (var it in signDic)
            {
                Console.WriteLine("{0}: {1}", it.Key, it.Value);
            }
            DateTime timeEnd = DateTime.Now;
            Console.WriteLine($"\nВитрачено часу: {(timeEnd-timeStart).TotalSeconds} секунд");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        Console.ReadKey();
    }
}