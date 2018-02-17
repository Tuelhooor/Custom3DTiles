using UnityEngine;

public class Cursor : MonoBehaviour {

    public GameObject cursor;

    public GameObject blockPrefab;

    public bool prefabsLoaded = false;

    public void LoadPrefabs()
    {
        if (!prefabsLoaded)
        {
            prefabsLoaded = true;
            blockPrefab = Resources.Load<GameObject>("Block");
        }
        else
        {
            return;
        }
    }

    public void PlacePrefab()
    {
        Instantiate(blockPrefab, cursor.transform.position, Quaternion.identity);
    }

    public void LoadCursor()
    {
        if(transform.childCount == 0)
        {
            cursor = Resources.Load<GameObject>("Cursor");
            cursor = Instantiate(cursor, Vector3.zero, Quaternion.identity);
            cursor.transform.SetParent(transform);
        }
        else
        {
            cursor = transform.GetChild(0).gameObject;
        }
    }

    private void Update()
    {
        Debug.DrawLine(Vector3.zero, Vector3.zero, Color.blue, 0);
    }

}
