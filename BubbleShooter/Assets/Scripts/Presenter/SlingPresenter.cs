using UnityEngine;

public class SlingPresenter : MonoBehaviour
{
    public float Rot;

    private Sling _sling;

    public void Init(Sling sling)
    {
        _sling = sling;
        transform.position = _sling.Position;
        _sling.DirectionChanged += Sling_DirectionChanged;
    }

    private void Sling_DirectionChanged(Vector2 newDir)
    {
        transform.up = newDir;
        Rot = _sling.Rotation;
    }

    private void OnDestroy()
    {
        if (_sling != null)
        {
            _sling.DirectionChanged -= Sling_DirectionChanged;
        }
    }
}