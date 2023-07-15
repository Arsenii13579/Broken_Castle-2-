using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject bullet;
    //public float offset;

    public enum Weapon {Pistol, Sword} 
    Weapon weapon; 
    [SerializeField] GameObject pistol; 
    [SerializeField] GameObject sword;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Alpha2)) 
        { 
            ChooseWeapon(Weapon.Pistol); 
        } 
        //Допишите код самостоятельно 
        if(Input.GetKey(KeyCode.Alpha1)) 
        { 
            ChooseWeapon(Weapon.Sword); 
        } 

        //if(Input.GetMouseButtonDown(1)) 
        //{ 
        //    ChooseWeapon(Weapon.Pistol); 
        //} 
        //Допишите код самостоятельно 
        //else
        //{ 
        //    ChooseWeapon(Weapon.Sword); 
        //}
        
    }

    public void ChooseWeapon(Weapon weapon) 
    { 
        this.weapon = weapon;
        switch (weapon)
        {
            case Weapon.Pistol: 
                pistol.SetActive(true); 
                sword.SetActive(false);
                break; 
            case Weapon.Sword: 
                pistol.SetActive(false); 
                sword.SetActive(true);
                break;
        }
    }
}
