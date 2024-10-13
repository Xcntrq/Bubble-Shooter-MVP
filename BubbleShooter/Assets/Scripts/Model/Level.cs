using System;
using UnityEngine;

public class Level
{
    public Sling Sling;

    private readonly float _width;
    private readonly float _gravity;
    private readonly float _bubbleRadius;

    private Wall[] _walls;
    private Trajectory _trajectory;
    private ActiveBubble _activeBubble;
    private CustomPhysics _customPhysics;

    public event Action<ActiveBubble> ActiveBubbleCreated;
    public event Action<Wall> WallCreated;

    public Level(float bubbleRadius, float gravity, float slingForce, float width)
    {
        _width = width;
        _gravity = gravity;
        _bubbleRadius = bubbleRadius;
        _customPhysics = new();
        Sling = new Sling(slingForce);
    }

    public SlingState SlingState => Sling.State;

    public Trajectory GetTrajectory()
    {
        Vector3[] trajectory = new Vector3[500];
        ActiveBubble invisibleBubble = new(_activeBubble);

        for (int i = 0; i < trajectory.Length; i++)
        {
            trajectory[i] = invisibleBubble.Position;
            invisibleBubble.Update(0.005f);
            _customPhysics.CheckCollisions(invisibleBubble);
        }

        return _trajectory;
    }

    public void Start(Vector2 mousePos)
    {
        _walls = new Wall[2];
        _walls[0] = new Wall(_width / -2f);
        _walls[1] = new Wall(_width / 2f);
        _customPhysics.AddWalls(_walls);
        foreach (Wall wall in _walls)
        {
            WallCreated?.Invoke(wall);
        }

        _activeBubble = new ActiveBubble(_bubbleRadius, _gravity);
        ActiveBubbleCreated?.Invoke(_activeBubble);

        Sling.Update(mousePos);
        Sling.LoadBubble(_activeBubble);
    }

    public void Update(Vector2 mousePos, float deltaTime)
    {
        Sling.Update(mousePos);
    }
}