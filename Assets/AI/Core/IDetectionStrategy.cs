using UnityEngine;

public interface IDetectionStrategy
{
    bool DetectTarget(Transform self, Transform target);
}