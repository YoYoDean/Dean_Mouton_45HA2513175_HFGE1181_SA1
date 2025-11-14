using UnityEngine;
    public enum WeaponType
        {
            Pistol,
            Shotgun,
            Sniper
        }       
public class WeaponData : MonoBehaviour
{
    public GameObject pickupPrefab;
    

    [Header("Weapon Animation")]
    public string shootTrigger;
    public string idleTrigger;
    public string sprintTrigger;
    public WeaponType weaponType;


}
