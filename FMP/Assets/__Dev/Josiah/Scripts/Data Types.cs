using UnityEngine;

public class DataTypes : MonoBehaviour
{

    void Start()
    {
        Vector3 pos = transform.position;
        pos = new Vector3(0,2,0);

        Transform tran = transform;
        tran.position = new Vector3(0, 2, 0);


    }

}
