using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

class Solution
{
    static List<List<string>> liste;

    static void Main(string[] args)
    {
        var list = new List<string>();
        int N = int.Parse(Console.ReadLine());
        for (int i = 0; i < N; i++)
        {
            string subseq = Console.ReadLine();
            list.Add(subseq);
            Console.Error.WriteLine(subseq);
        }
        
        Genome g = new Genome(list);
        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine(g.findShortestSequence());
    }
}
