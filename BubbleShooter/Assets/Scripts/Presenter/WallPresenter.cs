using UnityEngine;

public class WallPresenter : MonoBehaviour
{
    [SerializeField] private Transform _sr;

    private Wall _wall;

    public void Init(Wall wall)
    {
        _wall = wall;
        transform.position = Vector2.zero;
        _sr.position = Vector2.zero;

        float sign = Mathf.Sign(_wall.X);
        float width = GetComponentInChildren<SpriteRenderer>(true).bounds.size.x;
        _sr.position = new(sign * width / 2, 0f);
        transform.position = new Vector2(_wall.X, 0f);
    }
}