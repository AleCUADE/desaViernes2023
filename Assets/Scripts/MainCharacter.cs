using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class MainCharacter : MonoBehaviour
{
	[SerializeField] private GameObject bulletPrefab;
	[SerializeField] private int maxHealth;
	[SerializeField] private int health;
	[SerializeField] private float jumpForce;
	[SerializeField] private float maxSpeed;
	//[SerializeField] private AudioClip jumpAudio;
	//[SerializeField] private AudioClip punchAudio;
	[SerializeField] private string jumpSoundID;
	[SerializeField] private string punchSoundID;

	public float velocity;
	public Vector3 lastPos;
	public int CurrentHealth => health;
	public int MaxHealth => maxHealth;

	public UnityEvent OnDeath;
	public UnityEvent<int> OnDamaged;
	public UnityEvent<int> OnCoinGet;

	private bool isGrounded = true;
	private float horizontalAxis;
    private bool alive = true;
	private Rigidbody2D rb;
	private Animator anim;
	private SpriteRenderer sp;
	private AudioSource audioSource;
	private int _coins;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		sp = GetComponent<SpriteRenderer>();
		audioSource = GetComponent<AudioSource>();
		health = maxHealth;
	}

	[ContextMenu("Take damage test")]
	private void TakeDamageTest()
	{
		GetDamage(10);
	}

    //Funcion para dañar al personaje
    public void GetDamage(int damage)
	{
		health -= damage;
		Debug.Log("Main character received damage: " + damage);
		alive = health > 0;
		OnDamaged.Invoke(health);
		if (!alive)
		{
			OnDeath.Invoke();
		}
	}

	public void GetHeal(int healAmount) 
	{
		health += healAmount;
    }

    private void Move()
	{
		horizontalAxis = Input.GetAxis("Horizontal");
		//transform.Translate(transform.right * horizontalAxis * Time.deltaTime * velocity);
		////float verticalAxis = Input.GetAxis("Vertical");
		//transform.Translate(transform.up * verticalAxis * Time.deltaTime * velocity);

		if(horizontalAxis!= 0)
		{
			anim.SetBool("IsRunning", true);
			if(horizontalAxis>0) sp.flipX = false;
			else if (horizontalAxis < 0) sp.flipX = true;
		}
		else if(horizontalAxis == 0) 
		{
			anim.SetBool("IsRunning", false);
		}
    }

    private void FixedUpdate()
    {
		//rb.AddForce(transform.right * horizontalAxis * velocity, ForceMode2D.Force);   
		float newVelocity = (horizontalAxis * velocity) + rb.velocity.x;
		newVelocity = Mathf.Clamp(newVelocity, -maxSpeed, maxSpeed);
		rb.velocity = new Vector2(newVelocity, rb.velocity.y);
    }
    private void Shoot()
	{
		Instantiate(bulletPrefab, transform.position, transform.rotation);
	}

	public void GetItem(Item item)
	{
		Debug.Log($"received item {item.name}");
	}

	public void GetCoin(Coin coin)
	{
		_coins += coin.CoinsToGive;
		OnCoinGet?.Invoke(_coins);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.layer == 9)
		{
			isGrounded = true;
			anim.SetBool("IsJumping", false);

		}
	}
    private void Update()
	{
		if (Input.GetButtonDown("Curar"))
		{
			GetHeal(10);
		}

		Move();

		if (Input.GetButtonDown("Jump") && isGrounded)
		{
			Jump();
		}

		//if (Input.GetKeyDown(KeyCode.J))
		if (Input.GetButtonDown("Fire1"))
		{
			Punch();
		}

		if (!alive)
		{
			gameObject.SetActive(false);
		}
	}

	private void Punch()
	{
		//Shoot();
		anim.SetTrigger("Punch");
		//audioSource.clip = punchAudio;
		//audioSource.Play();
		//PlayOneShotAudio(punchAudio);
		SoundManager.Instance.PlayClipFromID(punchSoundID);
	}

	private void Jump()
	{
		isGrounded = false;
		rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
		anim.SetBool("IsJumping", true);
		//audioSource.clip = jumpAudio;
		//audioSource.Play();
		//PlayOneShotAudio(jumpAudio);
		SoundManager.Instance.PlayClipFromID(jumpSoundID);
	}

	//private void PlayOneShotAudio(AudioClip clipToPlay)
	//{
	//	audioSource.PlayOneShot(clipToPlay);
	//}
}
