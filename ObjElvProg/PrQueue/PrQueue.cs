using System;
using System.Collections.Generic;

public class PrQueue
{
    private List<Element> seq;

    public PrQueue()
    {
        seq = new List<Element>();
    }

    public void SetEmpty()
    {
        seq.Clear();
    }

    public bool isEmpty()
    {
        return seq.Count == 0;
    }

    public void Add(Element e)
    {
        seq.Add(e);
    }

    public Element GetMax()
    {
        if (isEmpty())
        {
            throw new InvalidOperationException("Queue is empty.");
        }

        var (max, ind) = MaxSelect();
        return seq[ind];
    }

    public Element RemMax()
    {
        if (isEmpty())
        {
            throw new InvalidOperationException("Queue is empty.");
        }

        var (max, ind) = MaxSelect();
        Element e = seq[ind];
        seq.RemoveAt(ind);
        return e;
    }

    private (int max, int ind) MaxSelect()
    {
        if (isEmpty())
        {
            throw new InvalidOperationException("Queue is empty.");
        }

        int max = seq[0].pr;
        int ind = 0;

        for (int i = 1; i < seq.Count; i++)
        {
            if (seq[i].pr > max)
            {
                max = seq[i].pr;
                ind = i;
            }
        }

        return (max, ind);
    }
}

public struct Element
{
    public int pr;
    public string data;
}