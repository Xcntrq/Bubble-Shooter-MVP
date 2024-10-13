using UnityEngine;

public class BubblePresenter : MonoBehaviour
{
    private Bubble _bubble;

    public void Init(Bubble bubble)
    {
        _bubble = bubble;
        _bubble.PositionChanged += Bubble_PositionChanged;
    }

    private void Bubble_PositionChanged(Vector2 newPos)
    {
        transform.position = newPos;
    }

    private void OnDestroy()
    {
        if (_bubble != null)
        {
            _bubble.PositionChanged -= Bubble_PositionChanged;
        }
    }
}