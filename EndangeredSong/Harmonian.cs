using System;

public class Harmonian
{
    string musicFile;
    string imageFile;
    bool isHid;
    int X;
    int Y;
	public Harmonian()
	{
        musicFile = "";
        imageFile = "";
	}
    public Harmonian(string mF, string iF)
    {
        musicFile = mF;
        imageFile = iF;
    }
}
