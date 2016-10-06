using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
	[SerializeField]
	private float maxHealth = 100f;

	public float currentHealth;

	public float maxSpeed = 10f;

	public float jumpForce = 500f;

	private Rigidbody2D rgBody;

	private Animator playerAnimator;

	bool grounded = true;

	public GameObject lifeBar;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;

	bool facingRight = true;

	// Use this for initialization
	void Start () {
		rgBody = GetComponent<Rigidbody2D> ();
		playerAnimator = GetComponent<Animator> ();

		currentHealth = maxHealth;
		InvokeRepeating ("decreaseHealth", 1f, 1f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		playerAnimator.SetBool ("Ground", grounded);

		float move = Input.GetAxis ("Horizontal");

		playerAnimator.SetFloat ("Speed", Mathf.Abs (move));

		rgBody.velocity = new Vector2 (move * maxSpeed, rgBody.velocity.y);
		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();
	}

	void Update(){
		if (grounded && Input.GetButtonDown ("Jump")) {
			rgBody.AddForce (new Vector2 (0, jumpForce));
		}
	}

	void decreaseHealth(){
		currentHealth -= 5f;
		float calculatedHealth = currentHealth / maxHealth;
		SetHealthBar (calculatedHealth);
	}

	void SetHealthBar(float myHealth) {
		if (myHealth <= 0) {
			Destroy (this.gameObject);
			//SceneManager.LoadScene ("GameOverScene");
		}
		Vector3 currentScale = lifeBar.transform.localScale;
		lifeBar.transform.localScale = new Vector3 (myHealth, currentScale.y, currentScale.z);
	}

	void Flip() {
		facingRight = !facingRight;

		Vector3 currentScale = transform.localScale;
		currentScale.x *= -1;

		transform.localScale = currentScale;
	}
}
