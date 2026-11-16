using UnityEngine;
using UnityEngine.InputSystem;

public class PlinkoSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject diskPrefab;
    Keyboard kb = Keyboard.current;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (kb == null)
        {
            return;
        }
        if (kb.spaceKey.wasPressedThisFrame)
        {
            Instantiate(diskPrefab, gameObject.transform.position,
                gameObject.transform.rotation);
        }
    }
}
