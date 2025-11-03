using UnityEngine;
using TMPro;

public class Crate : MonoBehaviour
{
    public float fallSpeed = 2f; // lower = slower
    public TextMeshProUGUI crateValueText;
    private BoundsCheck bndCheck;
    private int value;
    private int originalValue;
    private float startTime;


    void Awake()
    {
        bndCheck = GetComponent<BoundsCheck>();
        value = Random.Range(1, 12);
        originalValue = value;
        crateValueText.text = value.ToString(); 
        startTime = Time.time;
    }


    void Update()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
        float swayAngle = Mathf.Sin((Time.time - startTime) * 3f) * 5f;
        transform.rotation = Quaternion.Euler(0, 0, swayAngle);


        if (bndCheck.LocIs(BoundsCheck.eScreenLocs.offDown))  // a
        {
            Destroy(gameObject);
            ScoreCounter.AddPoints(-value);
        }

        if (value <= 0){
            Destroy(gameObject);

            if(value == 0){
                ScoreCounter.AddPoints(originalValue);
                LevelManager.CrateDestroyed();
            }else{
                ScoreCounter.AddPoints(value);
            }
        }
        
    }

    void OnTriggerEnter(Collider col){
        GameObject otherGO = col.gameObject;                             // a

        if(otherGO.CompareTag("Projectile1")){
            Destroy(otherGO);

            this.value = value - 1;
            crateValueText.text = value.ToString();
        }
        if(otherGO.CompareTag("Projectile2")){
            Destroy(otherGO);

            this.value = value - 2;
            crateValueText.text = value.ToString();
        }
        if(otherGO.CompareTag("Projectile3")){
            Destroy(otherGO);

            this.value = value - 3;
            crateValueText.text = value.ToString();
        }


    }

}
