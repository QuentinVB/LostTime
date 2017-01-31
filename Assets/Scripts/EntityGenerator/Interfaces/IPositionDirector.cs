using UnityEngine;

public interface IPositionDirector
{
    Vector3 Position { get; }
    Quaternion Rotation { get; }
}