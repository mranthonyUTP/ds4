class ClaseBase
{
    public void test()
    {
    }

    public virtual void masTests()
    {
    }
}

class ClaseHijo : ClaseBase
{
    public override void masTests()
    {
        Console.WriteLine("masTests sobrescrito en ClaseHijo");
    }
}