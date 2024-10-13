using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(LineRenderer))]
public class TrajectoryPresenter : MonoBehaviour
{
    public Vector3[] Trajectory;

    private LineRenderer _lineRenderer;

    private LineRenderer LineRenderer => (_lineRenderer != null) ? _lineRenderer : (_lineRenderer = GetComponent<LineRenderer>());

    public void ShowTrajectory(Vector3[] trajectory)
    {
        Trajectory = trajectory;
        LineRenderer.positionCount = trajectory.Length;
        LineRenderer.SetPositions(trajectory);
    }
}