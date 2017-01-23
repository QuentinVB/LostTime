using UnityEngine;



class HumanSculptor : MonoBehaviour, ISculptor
{

    private Object humanPrefab;
    private Material defaultMaterial;
    public HumanSculptor()
    {
        humanPrefab = Resources.Load("CharacterLowPo/CharacterLowPo");
        defaultMaterial = (Material)Resources.Load("CharacterLowPo/CharacterLowPo/Materials/jazz");
    }
    public GameObject GetPrefab
    {
        get
        {
            return (GameObject)Instantiate(humanPrefab);
        }
    }
    public GameObject PrefabByName(string characterType)
    {    
        GameObject humanToSculpt = (GameObject)Instantiate(humanPrefab);
        humanToSculpt.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().material = skinSwitch(characterType);
        return humanToSculpt;
    }
    public GameObject PrefabByName(string name, Transform initialTransform)
    {
        return (GameObject)Instantiate(humanPrefab, initialTransform);
    }
    private Material skinSwitch(string characterType)
    {
        return defaultMaterial;
    }
}
