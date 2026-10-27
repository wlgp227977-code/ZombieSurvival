using UnityEngine;
using UnityEngine.Events;

public class AmmoPack : MonoBehaviour, IItem
{
    public int ammoAmount = 30;
    public ItemSpawner itemSpawner;
    public UnityEvent OnUse {get; set;} = new UnityEvent();

    public void Use(GameObject target)
    {
        PlayerShooter playerShooter = target.GetComponent<PlayerShooter>();

        if (playerShooter != null)
        {
            playerShooter.gun.RestoreAmmo(ammoAmount);
            gameObject.SetActive(false);
            OnUse.Invoke();
            
        }
        
    } 
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        IItem item = GetComponent<IItem>();

        if (item != null)
        {
            item.Use(other.gameObject);
        }
    }    
   
}