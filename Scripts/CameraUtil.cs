using UnityEngine;

public enum CameraRendererType
{
    Realtime,
    Normal
}

public static class CameraUtil 
{
    public static bool IsCamera(CameraRendererType type, Renderer renderer)
    {
        if (type == CameraRendererType.Realtime)
        {
            Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main.GetComponent<Camera>());
            return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
        }
        else if (type == CameraRendererType.Normal)
        {
            Camera targetCamera = Camera.main.GetComponent<Camera>();
            Bounds bounds = renderer.bounds;

            Vector3[] points = new Vector3[8];
            points[0] = bounds.min;
            points[1] = new Vector3(bounds.min.x, bounds.min.y, bounds.max.z);
            points[2] = new Vector3(bounds.min.x, bounds.max.y, bounds.min.z);
            points[3] = new Vector3(bounds.min.x, bounds.max.y, bounds.max.z);
            points[4] = new Vector3(bounds.max.x, bounds.min.y, bounds.min.z);
            points[5] = new Vector3(bounds.max.x, bounds.min.y, bounds.max.z);
            points[6] = new Vector3(bounds.max.x, bounds.max.y, bounds.min.z);
            points[7] = bounds.max;

            foreach (Vector3 point in points)
                Vector3 viewportPoint = targetCamera.WorldToViewportPoint(point);
                if (viewportPoint.x >= 0 && viewportPoint.x <= 1 && viewportPoint.y >= 0 && viewportPoint.y <= 1 && viewportPoint.z >= 0)
                    return true;
            return false;
        }
        else 
            return false;
    }
}