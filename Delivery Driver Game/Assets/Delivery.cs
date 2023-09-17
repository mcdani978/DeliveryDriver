using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);

    [SerializeField] float Flt_destroyDelay = 0.5f;
    bool Bool_hasPackage;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Bang");
    }
    void OnTriggerEnter2D(Collider2D other)
   {
        if (other.tag == "Package" && !Bool_hasPackage)
        {
            Debug.Log("Package picked up");
            Bool_hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, Flt_destroyDelay);
        }

        if (other.tag == "Customer" && Bool_hasPackage)
        {
           Debug.Log("Package Delivered");
           Bool_hasPackage = false;
           spriteRenderer.color = noPackageColor;
        }
   }
}
