using UnityEngine;

public interface IAvoidanceStrategy
{
    Vector3 GetAvoidanceDirection(Transform self, Transform target);
}