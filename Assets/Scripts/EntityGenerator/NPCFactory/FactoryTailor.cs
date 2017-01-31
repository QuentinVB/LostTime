using UnityEngine;

public class FactoryTailor
{
    public FactoryTailor()
    {

    }
    public ITailor Create(NPCData data)
    {
        Debug.Log("craft NPCTailor");

        return new NPCTailor(data);
    }
}
