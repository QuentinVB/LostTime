using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public interface ISculptor
{
    //GameObject GetPrefab { get; }
    GameObject PrefabByJob(string name);
    //GameObject PrefabByName(string name,Transform initialTransform);
}
