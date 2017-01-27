using UnityEngine;
using Zenject;

public class SimpleCubeInstaller : MonoInstaller<SimpleCubeInstaller>
{
    public override void InstallBindings()
    {
        Container.InstantiatePrefab(Resources.Load("cubetest"));
    }
}

public class TestRunner
{
    [Inject]
    public TestRunner(string message, IBar bar)
    {
        Debug.Log(message);
        Debug.Log(bar.Msg);
    }
}
public class Bar : IBar
{
    public int name = 2;
    public string msg = "lol";
    public Bar()
    {
        name += 2;
    }
    public string Msg { get { return msg; } }
}