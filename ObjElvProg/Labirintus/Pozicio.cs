using System;

public class Pozicio
{
	private int x, y;
	public Pozicio(int x, int y)
	{
		this.x = x;
		this.y = y;
	}

	public bool Belul(int l, int n, int k, int m)
	{
		return l <= x && x <= n && k <= y && y <= m;
	}

	public bool Irany() 
	{ 
		return Belul(-1, 1, -1, 1) && (x == 0 || y != 0) || (x != 0 || y == 0);
    }

	public static Pozicio Osszeadas(Pozicio a, Pozicio b)
    {
        return new Pozicio(a.x + b.x, a.y + b.y);
    }

	public static Pozicio operator +(Pozicio a, Pozicio b)
    {
        return Osszeadas(a, b);
    }

    public override string ToString()
    {
        return "(" + x + ", " + y + ")";
    }

	public int getX()
    {
        return x;
    }
	public int getY() {
        return y;
    }
}