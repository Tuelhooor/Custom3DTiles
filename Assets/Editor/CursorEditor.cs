using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Cursor))]
public class CursorEditor : Editor
{
    void OnSceneGUI()
    {
        
        Vector3 mousePosition = Event.current.mousePosition;

        Ray ray = HandleUtility.GUIPointToWorldRay(mousePosition);

        Debug.DrawRay(ray.origin, ray.direction, Color.blue, 1);

        //mousePosition.y = SceneView.currentDrawingSceneView.camera.pixelHeight - mousePosition.y;
        //mousePosition = SceneView.currentDrawingSceneView.camera.ScreenToWorldPoint(mousePosition);
        //mousePosition.y = 0;

        //Debug.DrawLine(ray.origin, ray.direction * 1000, Color.blue, 0.1f);

        ray.origin = new Vector3(ray.origin.x, float.MaxValue, ray.origin.z);
        ray.direction = new Vector3(0, -1, 0);

        Debug.DrawRay(ray.origin, ray.direction, Color.green, 1);

        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            mousePosition = hit.point;
            //Debug.Log("hitou");
        }
        else
        {
            mousePosition.y = 0;
            //Debug.Log("nao hitou");
        }

        var cursor = target as Cursor;

        if(cursor.cursor == null)
        {
            cursor.LoadCursor();
        }
        if (!cursor.prefabsLoaded)
        {
            cursor.LoadPrefabs();
        }

        mousePosition.x = Mathf.Floor(mousePosition.x);
        mousePosition.y = Mathf.Floor(mousePosition.y);
        mousePosition.z = Mathf.Floor(mousePosition.z);
        cursor.cursor.transform.position = mousePosition;

        Event e = Event.current;
        int controlID = GUIUtility.GetControlID(FocusType.Passive);

        EventType evt = e.GetTypeForControl(controlID);
        if (evt == EventType.MouseDown)
        {
            if(e.button == 0)
            {
                cursor.PlacePrefab();
            }
        }

        Debug.Log(mousePosition);
    }
}