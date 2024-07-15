using UnityEngine;

public static class RealtimeCameraUtils 
{
    public static bool IsCamera(Renderer renderer)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main.GetComponent<Camera>());
        return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
    }
}
