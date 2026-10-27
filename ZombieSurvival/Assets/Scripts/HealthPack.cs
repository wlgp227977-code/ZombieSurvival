using UnityEngine;
using UnityEngine.Events;

public class HealthPack : MonoBehaviour, IItem
{
    public float healAmount = 30f;
    public ItemSpawner itemSpawner;
    public UnityEvent OnUse {get; set;} = new UnityEvent();

    public void Use(GameObject target)
    {
        LivingEntity livingEntity = target.GetComponent<LivingEntity>();

        if (livingEntity != null && !livingEntity.IsDead)
        {
            livingEntity.RestoreHealth(healAmount);
            
        }
        gameObject.SetActive(false);
            OnUse.Invoke();
        
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