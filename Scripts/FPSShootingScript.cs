using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSShootingScript : MonoBehaviour
{
    [SerializeField] private Transform FPSCam;
    [SerializeField] private GameObject curGun;
    [SerializeField] private float impactForce = 5f;
    private float nextShootTime = 0;
    public int enemyHealth = 3;
    // Start is called before the first frame update
    void Start()
    {
        if(!FPSCam)
            FPSCam = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    // Update is called once per frame
    void Update(){
        Debug.DrawRay(FPSCam.position, FPSCam.forward, Color.red);
        if(Input.GetButton("Fire1") && Time.time > nextShootTime)
        {
            Shoot();
            nextShootTime = Time.time + + 1 / curGun.GetComponent<Gun>().shootRate;
        }
    }

    private void Shoot(){
        AudioSource s = curGun.GetComponent<AudioSource>();
        if(s != null)
            s.Play();
        if(Physics.Raycast(FPSCam.position, FPSCam.forward, out RaycastHit hitInfo, curGun.GetComponent<Gun>().shootRange)){
            Debug.Log(hitInfo.collider.name + Time.time);
            if(hitInfo.transform.gameObject.tag == "Enemy"){
                Destroy(hitInfo.transform.gameObject);
            }
            //hitInfo.point
            Rigidbody rb = hitInfo.rigidbody;
            if(rb != null)
                rb.AddForce((hitInfo.normal - FPSCam.position) * impactForce);
        }
    }//todo
}
