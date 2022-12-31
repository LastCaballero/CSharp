using System.Diagnostics;

class AffinityBooster
{
    string firefox = "firefox";
    string msedge = "msedge";
    int StandardAffinity;
    List<Process>? BrowserProcesses = new List<Process>();
    public AffinityBooster() : this(1 + 2 + 4 + 8) { }
    public AffinityBooster(int affinity)
    {
        StandardAffinity = affinity;
        FindBrowssers();
        SetAffinity();
    }
    void FindBrowssers()
    {
        BrowserProcesses = Process.GetProcessesByName(firefox).ToList();
        BrowserProcesses.AddRange(Process.GetProcessesByName(msedge).ToList());
    }
    void SetAffinity()
    {
        BrowserProcesses?.ForEach(
            browser =>
            {
                browser.ProcessorAffinity = StandardAffinity;
            }
        );
    }
}



class Start
{
    public static void Main(string[] args)
    {
        if (args.Length == 1)
        {
            int affi = int.Parse(args[0]);
            new AffinityBooster(affi);
        }
        else
        {
            new AffinityBooster();
        }

    }
}
