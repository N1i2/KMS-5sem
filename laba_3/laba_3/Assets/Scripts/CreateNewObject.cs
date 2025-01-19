using UnityEngine;

public class CreateNewObject : MonoBehaviour
{
    private const float CONST_Y = 0.5f;
    private const int COUNT_OBJ = 10;
    public GameObject PrefCube;
    public GameObject PrefSher;

    private float max_x;
    private float min_x;
    private float max_z;
    private float min_z;

    private void Start()
    {
        Vector3 PlanPosition = GetComponent<Renderer>().bounds.size;

        max_x = transform.position.x + PlanPosition.x / 2;
        min_x = transform.position.x - PlanPosition.x / 2;
        max_z = transform.position.z + PlanPosition.z / 2;
        min_z = transform.position.z - PlanPosition.z / 2;
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            for (int i = 0; i < COUNT_OBJ; i++)
            {
                float x = Random.Range(max_x, min_x);
                float z = Random.Range(max_z, min_z);

                Vector3 newVector = new Vector3(x, CONST_Y, z);
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = newVector;
                cube.AddComponent<Rigidbody>();
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            for (int i = 0; i < COUNT_OBJ; i++)
            {
                float x = Random.Range(max_x, min_x);
                float z = Random.Range(max_z, min_z);

                Vector3 newVector = new Vector3(x, CONST_Y, z);
                Instantiate(PrefSher, newVector, Quaternion.identity);
            }
        }
    }
    private void FixedUpdate()
    {
        float z = Input.GetAxis("Vertical");

        transform.Rotate((Vector3.forward * z), 1f);
    }
}
