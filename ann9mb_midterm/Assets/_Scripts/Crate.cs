using UnityEngine;

public class Crate : MonoBehaviour
{
    public float fallSpeed = 2f; // lower = slower
    private BoundsCheck bndCheck;
    private int value;

    void Awake()
    {
        bndCheck = GetComponent<BoundsCheck>();
        value = Random.Range(1, 12); 
    }


    void Update()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

        if (bndCheck.LocIs(BoundsCheck.eScreenLocs.offDown))  // a
        {
            Destroy(gameObject);
        }
        
    }

}
