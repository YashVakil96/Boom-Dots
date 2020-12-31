using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    void Update()
    {
        Invoke("Destroyer",2f);
    }

    void Destroyer(){
     Destroy(this.gameObject);   
    }
}
