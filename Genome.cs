using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;


class Genome
{
    public List<string> genome { get; set; }

    public Genome(List<string> list)
    {
        this.genome = list;
    }


    public int findShortestSequence()
    {
        var list_sequence = new List<List<string>>();
        allPermutation(0, ref list_sequence);
        var list = new List<string>();
        foreach (var v in list_sequence)
        {
            list.Add(getSequence(v));
            foreach (var c in v)
            {
                Console.Error.Write(c + "  ");
            }
            Console.Error.WriteLine("");
            Console.Error.WriteLine(getSequence(v));
        }

        return list.Min(x => x.Length);
    }

    private void echange(int a, int b)
    {
        if (genome[a] == genome[b]) return;
        string temp = genome[a];
        genome[a] = genome[b];
        genome[b] = temp;
    }


    private void allPermutation(int current, ref List<List<string>> all_sequence)
    {
        int i;
        if (current == genome.Count - 1)
        {
            all_sequence.Add(new List<string>(genome));
        }
        else
            for (i = current; i < genome.Count; i++)
            {

                echange(current, i);
                allPermutation(current + 1, ref all_sequence); // on descend
                echange(current, i);
            }
    }

    public string fusionnerChaine(string s1, string s2)
    {
        string sequence = "";
        //On compare deux chaine cractère par caractère
        for (int i = 0; i < s1.Length; i++)
        {
            if (s1[i] != s2[0] || s1.Substring(i).Length > s2.Length)
            {
                sequence += s1[i];
                //Console.Error.WriteLine(sequence);
            }
            else
            {
                bool sousSequence = true;
                int pos = 1;
                while (sousSequence && i + pos < s1.Length)
                {
                    if (s1[i + pos] != s2[pos])
                    {
                        sousSequence = false;
                        break;
                    }
                    else
                    {
                        pos++;
                    }
                }
                if (sousSequence)
                {
                    sequence += s1.Substring(i, pos);
                    s2 = s2.Substring(pos);
                    break;
                }
                else
                {
                    sequence += s1[i];
                }
            }
        }
        sequence += s2;

        return sequence;

    }

    public string getSequence(List<string> list)
    {
        string sequence = list[0];
        for (int i = 1; i < list.Count; i++)
        {
            if (list[i].Contains(sequence))
                sequence = list[i];
            else if (!sequence.Contains(list[i]))
                 sequence = fusionnerChaine(sequence, list[i]);
        }
        return sequence;
    }

}
