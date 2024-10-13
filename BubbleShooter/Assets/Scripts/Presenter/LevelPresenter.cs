using UnityEngine;

public class LevelPresenter : MonoBehaviour
{
    [SerializeField] private float _bubbleRadius;
    [SerializeField] private float _levelWidth;
    [SerializeField] private float _slingForce;
    [SerializeField] private float _gravity;
    [SerializeField] private Camera _camera;
    [SerializeField] private SlingPresenter _slingPresenterPf;
    [SerializeField] private TrajectoryPresenter _trajectoryPresenter;
    [SerializeField] private ActiveBubblePresenter _activeBubblePresenterPf;
    [SerializeField] private WallPresenter _wallPresenterPf;

    private Level _level;
    private SlingPresenter _slingPresenter;
    private ActiveBubblePresenter _activeBubblePresenter;

    private void Start()
    {
        _level = new(_bubbleRadius, _gravity, _slingForce, _levelWidth);

        _slingPresenter = Instantiate(_slingPresenterPf, transform);
        _slingPresenter.Init(_level.Sling);

        _level.ActiveBubbleCreated += Level_ActiveBubbleCreated;
        _level.WallCreated += Level_WallCreated;

        Vector2 mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
        _level.Start(mousePos);
    }

    private void Level_WallCreated(Wall wall)
    {
        Instantiate(_wallPresenterPf, transform).Init(wall);
    }

    private void Level_ActiveBubbleCreated(ActiveBubble activeBubble)
    {
        _activeBubblePresenter = Instantiate(_activeBubblePresenterPf, transform);
        _activeBubblePresenter.Init(activeBubble);
    }

    private void Update()
    {
        Vector2 mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
        _level.Update(mousePos, Time.deltaTime);

        if (_level.SlingState == SlingState.Aiming)
        {
            // _trajectoryPresenter.ShowTrajectory(_level.GetTrajectory());
        }
    }
}