using System.Collections.Generic;

public class Folder : Registration
{
    private List<Registration> items;

    public Folder()
    {
        items = new List<Registration>();
    }

    public override int GetSize()
    {
        int totalSize = 0;
        foreach (var item in items)
        {
            totalSize += item.GetSize();
        }
        return totalSize;
    }

    public void Add(Registration r)
    {
        items.Add(r);
    }

    public void Remove(Registration r)
    {
        items.Remove(r);
    }
}