using UnityEngine;

public class ActiveBubblePresenter : MonoBehaviour
{
    private ActiveBubble _activeBubble;

    public void Init(ActiveBubble activeBubble)
    {
        _activeBubble = activeBubble;
        _activeBubble.PositionChanged += ActiveBubble_PositionChanged;
    }

    private void ActiveBubble_PositionChanged(Vector2 newPos)
    {
        transform.position = newPos;
    }

    private void OnDestroy()
    {
        if (_activeBubble != null)
        {
            _activeBubble.PositionChanged -= ActiveBubble_PositionChanged;
        }
    }
}