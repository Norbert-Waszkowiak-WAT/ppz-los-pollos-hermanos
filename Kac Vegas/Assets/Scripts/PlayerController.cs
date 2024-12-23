using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private DialogueUI dialogueUI;

    private PlayerControls playerControls;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator myAnimator;
    private SpriteRenderer mySpriteRender;
    public DialogueUI DialogueUI => dialogueUI;
    public IInteractable interactable;
    ContactFilter2D filter;
    public GameObject weapon;
    public EquiptScript equiptScript;
   
    private GameObject weaponPicked;

    public bool canControl = true;

    private void Awake()
    {
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        mySpriteRender = GetComponent<SpriteRenderer>();
        equiptScript = GetComponent<EquiptScript>();
        filter = new ContactFilter2D();
        filter.SetLayerMask(LayerMask.GetMask("DialogueAble") | LayerMask.GetMask("Weapons"));
        filter.useLayerMask = true;



    }

    private void OnEnable()
    {
        playerControls.Enable();

    }

    private void Update()
    {
        if(canControl) PlayerInput();
        // Debug.Log(canControl);
        if (Input.GetKeyDown(KeyCode.E))
        {
            FindInteractable();
            FindWeapons();
            if (interactable!= null)
            {
                
                StartDialogue();
                
            }
            if(weapon !=null)
            {
                PickUp();
            }
        }
        
        if(Input.GetKeyDown(KeyCode.G))
        {
            if(weaponPicked!=null)
            {
                equiptScript.UnequipObject(weaponPicked);
            }
            
        }
        if(Input.GetMouseButton(0))
        {
            if(weaponPicked!=null)
            {
                Weapons weapon = weaponPicked.GetComponent<Weapons>();

                weapon.Attacking();
            }
        }

    }

    private void FixedUpdate()
    {
        AdjustPlayerFacingDirection();
        Move();

    }

    private void PlayerInput()
    {
        movement = playerControls.Movement.Move.ReadValue<Vector2>();
        myAnimator.SetFloat("moveX", movement.x);
        myAnimator.SetFloat("moveY", movement.y);
    }

  

    private void Move()
    {
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }

    private void AdjustPlayerFacingDirection()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);

        if (mousePos.x < playerScreenPoint.x)
        {
            mySpriteRender.flipX = true;

        }
        else
        {
            mySpriteRender.flipX = false;
        }

    }
  
    void FindInteractable()
    {
        interactable = null;
        Collider2D collider2D = Physics2D.OverlapCircle(gameObject.transform.position, 1.5f, filter.layerMask);
        Debug.Log(collider2D);
        if(collider2D != null && collider2D.GetComponent<IInteractable>()!=null)
        {
            interactable = collider2D.GetComponent<IInteractable>();
            return;
        }
        else if(collider2D==null)
        {
            Debug.Log("Brak");
        }
        else if(collider2D.GetComponent<IInteractable>()==null)
        {
            Debug.Log("getcomponent ");
        }


    }

    void StartDialogue()
    {
         if(interactable.dialogueObject!=null)
         {
            canControl = false;
            dialogueUI.ShowDialogue(interactable.dialogueObject);
         }
    }

    void FindWeapons()
    {
        weapon = null;
        Collider2D collider2D = Physics2D.OverlapCircle(gameObject.transform.position, 1.5f,filter.layerMask);
        Debug.Log(collider2D);
        if(collider2D != null && collider2D.GetComponent<Weapons>()!=null)
        {
            weapon = collider2D.gameObject;
            return;
        }
        else if(collider2D==null)
        {
            Debug.Log("Brak weapons");
        }
        else if(collider2D.gameObject.GetComponent<Weapons>() ==null)
        {
            Debug.Log("getcomponent weapons ");
        }


    }

    void PickUp()
    {
         if(weapon!=null)
         {
            Debug.Log(equiptScript +"equipt");

           equiptScript.EquipObject(weapon);
           weaponPicked=weapon;
         }
         
    }

 


}
