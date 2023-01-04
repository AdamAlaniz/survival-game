using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public int curWeapon = 0;
    [SerializeField] GameObject primary;
    [SerializeField] GameObject second;
    [SerializeField] GameObject third;
    // Start is called before the first frame update
   // void Start()
   // {
    //    SelectWeapon();
    //}

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Mouse ScrollWheel") > 0f){
            if(curWeapon >= transform.childCount - 1)
                curWeapon = 0;
        else
            curWeapon ++;
    }

    if(Input.GetAxis("Mouse ScrollWheel") < 0f){
        if(curWeapon <= transform.childCount - 1)
            curWeapon = transform.childCount - 1;
    else
        curWeapon --;
}
        SelectWeapon(curWeapon);

        if(Input.GetKeyDown(KeyCode.Alpha1))
            curWeapon = 0;
        if(Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
            curWeapon = 1;
        if(Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
            curWeapon = 2;
        if(Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4)
            curWeapon = 3;
    }

    void SelectWeapon(int curWeapon){
        //int i = 0;
        //foreach (Transform weapon in transform){
            //if(i == curWeapon)
             //   weapon.gameObject.SetActive(true);
            //else
             //   weapon.gameObject.SetActive(false);

            //i++;
        //}
        if(curWeapon == 0){
            primary.SetActive(true);
            second.SetActive(false);
            third.SetActive(false);
        }
        if(curWeapon == 1){
            primary.SetActive(false);
            second.SetActive(true);
            third.SetActive(false);
        }
        if(curWeapon == 2){
            primary.SetActive(false);
            second.SetActive(false);
            third.SetActive(true);
        }
    }
}
