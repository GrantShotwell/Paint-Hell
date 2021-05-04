using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.InputSystem;
using UnityEngine.U2D.Animation;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteSkin))]
public class PlayerController : MonoBehaviour
{

    [Header("Testing")]
    public GameObject targetEnemy;

    [Header("Lighting")]
    new public Light2D light;

    [Header("Splatter")]
    public GameObject splatterPrefab;
    [Range(0, 50)]
    public int splatterCount = 16;
    [Range(0, 90)]
    public float splatterRange = 45f;
    [Range(0, 25)]
    public float splatterDistance = 10f;

    [Header("Spray")]
    public GameObject sprayPrefab;
    [Range(0, 20)]
    public int sprayCount = 3;
    [Range(0, 90)]
    public float sprayRange = 15f;
    [Range(0, 10)]
    public float sprayDistance = 3f;

    [Header("Arms & Gun Positioning")]
    public Transform rightArm;
    public Transform leftArm;
    public Transform gun;
    public Transform gunPivot;
    [Range(0f, 1f)]
    public float gunLength;

    [Header("Projectile")]
    public GameObject projectilePrefab;
    [Range(0f, 50f)]
    public float projectileSpeed = 10f;
    [Range(0, 10)]
    public int projectileDamage = 1;

    [Header("Ground Movement")]
    [Range(0f, 10f)]
    public float runSpeed = 5.0f;

    [Header("Jumping")]
    [Range(0f, 10f)]
    public float jumpPower = 5.0f;
    [Range(0f, 10f)]
    public float magicFallForce = 1.0f;

    [Header("Airtime Drifting")]
    [Range(0f, 10f)]
    public float driftForce = 1.0f;
    [Range(0f, 10f)]
    public float driftTime = 3.0f;
    public AnimationCurve driftCurve;

    [Header("Wall Movement")]
    public Vector2 wallJumpSpeed = new Vector2(5.0f, 5.0f);
    [Range(0f, 10f)]
    public float slideSpeed0 = 1.5f;
    [Range(0f, 10f)]
    public float slideSpeed1 = 4.0f;
    [Range(0f, 10f)]
    public float slideSpeed2 = 8.0f;

    [HideInInspector]
    public Movement movement;

	[HideInInspector]
	public bool facingRight = true;
	[HideInInspector]
	public bool lastFacingRight = true;
	[HideInInspector]
	public float lastGrounded = 0f;
	public float airtime => Time.fixedTime - lastGrounded;
	[HideInInspector]
	public bool wasGrounded = true;
	[HideInInspector]
	public bool wasRightWalled = false;
	[HideInInspector]
	public bool wasLeftWalled = false;
	[HideInInspector]
	public bool sentAirtimeTrigger = false;
	[HideInInspector]
	public bool sentWalledTrigger = false;

    [HideInInspector]
    public Vector2 mouseWorldPosition;

	[HideInInspector]
    new public Rigidbody2D rigidbody;
	[HideInInspector]
	new public BoxCollider2D collider;
	[HideInInspector]
	new public SpriteRenderer renderer;
	[HideInInspector]
	public Animator animator;
	[HideInInspector]
	public SpriteSkin skin;

    void OnValidate() {

    }

    // Start is called before the first frame update
    public void Start() {

        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        renderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        skin = GetComponent<SpriteSkin>();

    }

	void Update() {
        mouseWorldPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
    }

	public void StandardUpdate() {
		light.color = renderer.color;
	}

	void FixedUpdate() {
		StandardFixedUpdate();
	}

	public void StandardFixedUpdate() {
		ApplyMovementInputs(true);
		PositionGunAndArms();
		UpdateAnimationVariables();
	}

	private void ApplyMovementInputs(bool validate) {

		if(validate) movement.Validate();

		#region Movement

		float contactOffset = Physics2D.defaultContactOffset + 0.01f;
		var footBox = new Vector2(collider.size.x + collider.edgeRadius, (collider.size.y + collider.edgeRadius) / 2);
		var sideBox = new Vector2((collider.size.x + collider.edgeRadius) / 2, collider.size.y + collider.edgeRadius);

		// Detect floor below the player with box cast.
		var groundcast = Physics2D.BoxCast(transform.position + (Vector3)collider.offset, footBox, 0f, Vector2.down, collider.size.y + contactOffset);
		bool grounded = groundcast && transform.position.y - groundcast.point.y <= contactOffset;
		if(grounded) Debug.DrawLine(transform.position + Vector3.up * 0.5f, groundcast.point, Color.red);

		// Detect wall on the left with box cast.
		var leftcast = Physics2D.BoxCast(transform.position + (Vector3)collider.offset, sideBox, 0f, Vector2.left, collider.size.x + contactOffset);
		bool leftwall = leftcast && (transform.position.x - sideBox.x) - leftcast.point.x <= contactOffset;
		if(leftwall) Debug.DrawLine(transform.position + Vector3.up * 0.5f, leftcast.point, Color.red);

		// Detect wall on the right with box cast.
		var rightcast = Physics2D.BoxCast(transform.position + (Vector3)collider.offset, sideBox, 0f, Vector2.right, collider.size.x + contactOffset);
		bool rightwall = rightcast && rightcast.point.x - (transform.position.x + sideBox.x) <= contactOffset;
		if(rightwall) Debug.DrawLine(transform.position + Vector3.up * 0.5f, rightcast.point, Color.red);

		bool walled = !grounded && (leftwall || rightwall);

		if(grounded) {

			if(wasGrounded == false) animator.SetTrigger("Ground");
			lastGrounded = Time.fixedTime;

			wasGrounded = true;
			wasRightWalled = false;
			wasLeftWalled = false;
			sentAirtimeTrigger = false;
			sentWalledTrigger = false;

		} else if(walled) {

			if(!sentWalledTrigger) animator.SetTrigger("Wall");

			wasGrounded = false;
			wasRightWalled = rightwall;
			wasLeftWalled = leftwall;
			sentAirtimeTrigger = false;
			sentWalledTrigger = true;

		} else {

			if(!sentAirtimeTrigger) animator.SetTrigger("Fall");

			wasGrounded = false;
			wasRightWalled = false;
			wasLeftWalled = false;
			sentAirtimeTrigger = true;
			sentWalledTrigger = false;

		}

		Vector2 velocity;

		if(walled) {

			// Base velocity when sliding.
			if(rigidbody.velocity.y > 0.0f) velocity = rigidbody.velocity * Vector2.up;
			else velocity = Vector2.zero;

			// Jump off wall.
			if(movement.vertical > 0.0f) {
				if(leftwall) velocity = new Vector2(+wallJumpSpeed.x, wallJumpSpeed.y);
				else if(rightwall) velocity = new Vector2(-wallJumpSpeed.x, wallJumpSpeed.y);
			}

			// Slide down wall.
			{
				int speed = 1;
				if(movement.vertical < -0.3f) speed += 1;
				//if(Mathf.Sign(movement.horizontal) == (leftwall ? -1 : +1)) speed -= 1;

				if(speed <= 0) velocity.y -= slideSpeed0;
				else if(speed == 1) velocity.y -= slideSpeed1;
				else velocity.y -= slideSpeed2;
			}

		} else if(grounded) {

			// Base velocity when grounded.
			velocity = Vector2.zero;

			// Move across floor.
			{
				velocity.x += movement.horizontal * runSpeed;
			}

			// Jump off floor.
			if(movement.vertical >= 0.05f) {
				velocity.y += movement.vertical * jumpPower;
				animator.SetTrigger("Jump");
				sentAirtimeTrigger = true;
			}

		} else {

			// Base velocity when in air.
			velocity = rigidbody.velocity;

			// Fall faster.
			{
				velocity.y += magicFallForce * movement.vertical * Time.fixedDeltaTime;
			}

			// Accelerate left/right.
			{
				velocity.x += driftCurve.Evaluate(airtime / driftTime) * driftForce * movement.horizontal * Time.fixedDeltaTime;
			}

		}

		#endregion

		rigidbody.velocity = velocity;

	}

	private void PositionGunAndArms() {

		#region Gun Positioning

		// Pivot side.
		Vector3 pivotPos = gunPivot.localPosition;
		if(facingRight != lastFacingRight) pivotPos.x = -pivotPos.x;
		gunPivot.localPosition = pivotPos;

		// Pivot direction.
		Vector3 pivotRot = gunPivot.localRotation.eulerAngles;
		Vector2 mousePos = (Vector2)transform.position - mouseWorldPosition;
		pivotRot.z = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg + 180f;
		gunPivot.rotation = Quaternion.Euler(pivotRot);

		float pivotAngle = pivotRot.z % 360f * Mathf.Sign(pivotRot.z);
		bool gunFacingRight = 90f > pivotAngle || pivotAngle > 270f;
		lastFacingRight = facingRight;

		#endregion

		#region Arm Positioning

		void SetAngles(Transform segment1, Transform segment2, Vector2 target) {

			// Find triangle lenths.
			target += (Vector2)transform.position;
			Vector2 root = segment1.position;
			float estLength = (root - (Vector2)segment2.position).magnitude;
			Vector2 vectorTo = target - root;
			float distance = vectorTo.magnitude;

			// Check if distance is too long.
			bool tooLong = estLength * 2 <= distance;
			float angle1, angle2;

			if(tooLong) {

				// Angle arms straight toward target.
				Vector3 seg1Euler = segment1.rotation.eulerAngles;
				Vector3 seg2Euler = segment2.rotation.eulerAngles;
				float angleTo = Mathf.Atan2(vectorTo.y, vectorTo.x) * Mathf.Rad2Deg;
				seg1Euler.z = angleTo;
				seg2Euler.z = angleTo;
				segment1.rotation = Quaternion.Euler(seg1Euler);
				segment2.rotation = Quaternion.Euler(seg2Euler);

			} else {

				// Find triangle angles using the Law of Cosines.
				float distance_sqrd = distance * distance;
				float estLength_sqrd = estLength * estLength;
				angle1 = Mathf.Acos(distance_sqrd / (2 * estLength * distance));
				if(float.IsNaN(angle1)) angle1 = 0;
				angle2 = Mathf.Acos((2 * estLength_sqrd - distance_sqrd) / (2 * estLength_sqrd));
				if(float.IsNaN(angle2)) angle2 = 0;

				// Set angles.
				Vector3 seg1Euler = segment1.rotation.eulerAngles;
				Vector3 seg2Euler = segment2.rotation.eulerAngles;
				float angleTo = Mathf.Atan2(vectorTo.y, vectorTo.x);
				if(gunFacingRight) {
					seg1Euler.z = (angleTo - angle1) * Mathf.Rad2Deg;
					seg2Euler.z = seg1Euler.z - angle2 * Mathf.Rad2Deg + 180f;
				} else {
					seg1Euler.z = (angleTo + angle1) * Mathf.Rad2Deg;
					seg2Euler.z = seg1Euler.z + angle2 * Mathf.Rad2Deg + 180f;
				}
				segment1.rotation = Quaternion.Euler(seg1Euler);
				segment2.rotation = Quaternion.Euler(seg2Euler);

			}

			// Draw debug lines.
			Debug.DrawLine(root, target, tooLong ? Color.red : Color.green);

		}

		Vector2 rightTarget = gun.localToWorldMatrix.MultiplyPoint((gunFacingRight ? Vector2.right : Vector2.left) * gunLength / 2) - transform.position;
		SetAngles(rightArm, rightArm.GetChild(0), rightTarget);

		Vector2 leftTarget = gun.localToWorldMatrix.MultiplyPoint((gunFacingRight ? Vector2.left : Vector2.right) * gunLength / 2) - transform.position;
		SetAngles(leftArm, leftArm.GetChild(0), leftTarget);

		#endregion

	}

	private void UpdateAnimationVariables() {

		Vector2 velocity = rigidbody.velocity;

		#region Continuous Animator Variables

		if(velocity.x > 0.0f) {
			facingRight = true;
		} else if(velocity.x < 0.0f) {
			facingRight = false;
		}

		animator.SetBool("Facing Right", facingRight);
		animator.SetFloat("Ground Speed", Mathf.Abs(rigidbody.velocity.x));
		animator.SetFloat("Air Speed", Mathf.Abs(rigidbody.velocity.y));
		animator.SetFloat("Air Velocity", rigidbody.velocity.y);

		#endregion

	}

	private GameObject CreateProjectile() {

        GameObject projectile = Instantiate(projectilePrefab);
        projectile.name = $"{gameObject.name} {projectilePrefab.name}";
        projectile.transform.position = gun.position;
        projectile.transform.rotation = gun.rotation;

        Projectile projectileComponent = projectile.GetComponent<Projectile>();
        if(projectileComponent) {
            float angle = gun.rotation.eulerAngles.z * Mathf.Deg2Rad;
            projectileComponent.creator = GetComponent<Collider2D>();
            projectileComponent.velocity = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * projectileSpeed;
            projectileComponent.OnBreak.AddListener((GameObject go, Vector2 point) => {
				var splatter = CreateSplatter();
                splatter.sendForward = false;
				splatter.direction = projectileComponent.velocity;
                splatter.transform.position = point;
                splatter.transform.rotation = projectile.transform.rotation;
            });
        }

		SpriteRenderer projectileRenderer = projectile.GetComponent<SpriteRenderer>();
        if(projectileRenderer) {
            projectileRenderer.color = renderer.color;
        }
        return projectile;

	}

    private ColoredSplatter CreateSplatter() {

        GameObject splatter = Instantiate(splatterPrefab);
        splatter.name = $"{gameObject.name} {splatterPrefab.name}";
        splatter.transform.position = transform.position;
        ColoredSplatter component = splatter.GetComponent<ColoredSplatter>();
        component.color = renderer.color;
        return component;

	}

    private ColoredSpray CreateSpray() {

        GameObject spray = Instantiate(sprayPrefab);
        spray.name = $"{gameObject.name} {sprayPrefab.name}";
        spray.transform.position = transform.position;
        ColoredSpray component = spray.GetComponent<ColoredSpray>();
        component.color = renderer.color;
        component.distance = sprayDistance;
        return component;

	}

    public void OnDamage(int amount, Vector2 force) {

        var splatter = CreateSplatter();
        splatter.direction = force;

        if(GetComponent<Healthbar>().current == 0) {

            foreach(Vector2 randForce in Vector2Random.AngledOffsetArray(force, -splatterRange, +splatterRange, splatterCount)) {
                var randSplatter = CreateSplatter();
                randSplatter.direction = randForce;
            }

            foreach(Vector2 randForce in Vector2Random.AngledOffsetArray(force, -sprayRange, +sprayRange, sprayCount)) {
                var randSpray = CreateSpray();
                randSpray.direction = randForce;
			}

            Destroy(gameObject);

        }

	}

    public void FirePrimary() {
        CreateProjectile();
	}

    public void FireSecondary() {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mousePos = new Vector2(mousePos.x, mousePos.y);
        GameObject enemy = Instantiate(targetEnemy);
        enemy.transform.position = (Vector3)mousePos + enemy.transform.position.z * Vector3.forward;
    }

    public void OnHorizontalMovement(InputAction.CallbackContext context) {
        movement.horizontal = context.ReadValue<float>();
	}

    public void OnVerticalMovement(InputAction.CallbackContext context) {
        movement.vertical = context.ReadValue<float>();
	}

    public void OnPrimaryTrigger(InputAction.CallbackContext context) {
        if(context.phase == InputActionPhase.Started) FirePrimary();
	}

    public void OnSecondaryTrigger(InputAction.CallbackContext context) {
        if(context.phase == InputActionPhase.Started) FireSecondary();
	}

    public struct Movement {
        public float horizontal;
        public float vertical;

		public void Validate() {
			if(horizontal > +1.0f) horizontal = +1.0f;
			else if(horizontal < -1.0f) horizontal = -1.0f;
			if(vertical > +1.0f) vertical = +1.0f;
			else if(vertical < -1.0f) vertical = -1.0f;
		}

    }

}
