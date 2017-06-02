using UnityEngine;

public class PowerUp : MonoBehaviour {

    void Update()
    {
        if (transform.position.y < -2f)
        {
            Destroy(gameObject);
        }
    }
}
