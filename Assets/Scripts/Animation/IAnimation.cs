using UnityEngine;

public interface IAnimation
{
    float ValueVminThreshold { get; }
    void UpdateAnimData(float inputH, float inputV, WalkMode walkmode);
    void UpdateAnimData(Transform transform, WalkMode walkmode);
}