using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour, IItem
{
    public int scoreAmount = 10;
    private GameManager gameManager;   
    public ItemSpawner itemSpawner; 
    public UnityEvent OnUse {get; set;} = new UnityEvent();

    private void Start()
    {
        GameObject findGo = GameObject.FindWithTag("GameController");
        gameManager = findGo.GetComponent<GameManager>();
    }

    public void Use(GameObject target)
    {
        // uiManager.AddScore(scoreAmount);
        gameManager.AddScore(scoreAmount);
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