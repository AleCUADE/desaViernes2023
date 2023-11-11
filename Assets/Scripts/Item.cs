using UnityEngine;

public enum ItemType
{
    Speed,
    Strength
}
[RequireComponent(typeof(BoxCollider2D))]
public class Item : MonoBehaviour
{

    [SerializeField] private ItemType itemType;
    [SerializeField] private float itemValue;
    [SerializeField] private LayerMask layerToCollide;

    public ItemType ItemType => ItemType;
    public float ItemValue => itemValue;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("This is starting a collision");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("This is colliding");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Collision resolved");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Pickup item");
        Debug.Log($"Item is now from {collision.gameObject.name}");
        //MainCharacter character = collision.gameObject.GetComponent<MainCharacter>();
        
        //if (character != null)
        //if (collision.TryGetComponent<MainCharacter>(out MainCharacter character))
        //{
        //    character.GetItem(this);
        //    Destroy(gameObject);
        //}

        //if (collision.TryGetComponent<Spidermancito>(out Spidermancito spidermancity))
        //{
        //    Debug.Log("Obtuve spidermancito");
        //}

        if (collision.CompareTag("Mainplayer"))
        {
            Debug.Log("Es spiderman");
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("This is triggering");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("This is resolving a trigger");
    }

   
}
