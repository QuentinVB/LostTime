using UnityEngine;
using Zenject;

public class SimpleCubeInstaller : MonoInstaller<SimpleCubeInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<bool>().FromInstance(true);
        Container.Bind<IBar>().FromInstance(new Bar());
        Container.InstantiatePrefab(Resources.Load("cubetest"));
        Container.InstantiateComponent
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
    public string msg = "yup !";
    public Bar()
    {
        name += 2;
    }
    public string Msg { get { return msg; } }
}