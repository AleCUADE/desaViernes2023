using UnityEngine;
public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float deathTime = 5f;
    private float m_currentTime;
    // Update is called once per frame
    private void Update()
    {
        transform.Translate(transform.right * Time.deltaTime * speed);

        m_currentTime += Time.deltaTime;
        if (m_currentTime >= deathTime)
        {
            Destroy(gameObject);
        }
    }
}
