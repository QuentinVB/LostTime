using UnityEngine;

public interface IPathfinding:INPCComponent
{
    Vector3 Direction { get; }
    Quaternion Orientation { get; }
    void collide(Collider other);
}