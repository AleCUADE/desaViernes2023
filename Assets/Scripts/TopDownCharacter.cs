using UnityEngine;

public class TopDownCharacter : MonoBehaviour
{
    [SerializeField] private float speed;
    private void Update()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        var moveDir = new Vector3(horizontal, vertical).normalized;
        transform.position += moveDir * Time.deltaTime * speed;
    }
}
