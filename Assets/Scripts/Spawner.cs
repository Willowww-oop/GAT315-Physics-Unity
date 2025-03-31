using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject ragDoll;
    [SerializeField] KeyCode keycode = KeyCode.Space;

    void Update()
    {
        if (Input.GetKeyDown(keycode))
        {
            Instantiate(ragDoll, transform.position, Quaternion.identity);
        }
    }
}
