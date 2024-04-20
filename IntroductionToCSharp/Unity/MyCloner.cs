using UnityEngine;

[ExecuteAlways]
public class MyCloner : MonoBehaviour
{
    public int NumRows = 5;
    public int NumColumns = 5;

    // Update is called once per frame
    public void Update()
    {
        for (var column = 0; column < NumColumns; column++)
        {
            for (var row = 0; row < NumRows; row++)
            {
                Graphics.DrawMesh(
                    GetComponent<MeshFilter>().sharedMesh,
                    new Vector3(column * 2, row * 2, 0),
                    Quaternion.identity,
                    GetComponent<MeshRenderer>().sharedMaterial,
                    0);
            }
        }
    }
}
