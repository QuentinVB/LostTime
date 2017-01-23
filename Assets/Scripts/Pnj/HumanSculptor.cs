using UnityEngine;



class HumanSculptor : MonoBehaviour,ISculptor
{

    private Object humanPrefab;
    private Material defaultMaterial;
    public HumanSculptor()
    {
        humanPrefab = Resources.Load("CharacterLowPo/CharacterLowPo");
        defaultMaterial = (Material)Resources.Load("CharacterLowPo/Materials/citizen1");
    }
    public GameObject GetPrefab
    {
        get
        {
            return (GameObject)Instantiate(humanPrefab);
        }
    }
    /// <summary>
    /// Get a Prefabs by sending the job string according to the texture name.
    /// Tip : call the <see cref="jobTranslator.jobStringToEnum(string)"/> and then get the string
    /// </summary>
    /// <param name="characterJob">The character job.</param>
    /// <returns></returns>
    public GameObject PrefabByJob(string characterJob)
    {    
        GameObject humanToSculpt = (GameObject)Instantiate(humanPrefab);
        humanToSculpt.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().material = skinSwitch(characterJob);
        return humanToSculpt;
    }
    public GameObject PrefabByName(string name, Transform initialTransform)
    {
        return (GameObject)Instantiate(humanPrefab, initialTransform);
    }
    private Material skinSwitch(string characterType)
    {
        Material returned = defaultMaterial;       
        string craft = string.Format("CharacterLowPo/Materials/{0}", characterType);       
        returned = (Material)Resources.Load(craft);
        if(returned == null)
        {
            Debug.Log(string.Format("Texture .{0}. does not exist, use default instead", characterType));
            returned = (Material)Resources.Load("CharacterLowPo/Materials/citizen1");
        }
        return returned;
    }
}
