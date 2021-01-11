using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.InputSystem.Users;
using XboxCtrlrInput;

public class Player_To_Tank : MonoBehaviour
{
    public TankMover tankMover;
    PlayerControlls inputActions;
    public TankDrive tank;
    Vector3 move;
    // public Player_Master temp;

    public XboxController playerone;
    public XboxController playertwo;



    public float walkingSpeed = 1.0f;
    private float prevAxisX = 0.0f;
    private float prevAxisY = 0.0f;

    private float axisX = 0.0f;
    private float axisY = 0.0f;
    public int playervalue;
 
    void Start()
    {
        if (XCI.IsPluggedIn(XboxController.First))
        {
            playerone = XboxController.First;
            Debug.Log("player one connected");
        }
        if (XCI.IsPluggedIn(XboxController.Second))
        {
            playertwo = XboxController.Second;
            Debug.Log("player two connected");
        }

        Invoke("get", 0.1f);
    }
    private void get()
    {
        playervalue = PlayerPrefs.GetInt("player");
        if (playervalue == 0)
        {
            playervalue = 2;
              Debug.Log("player two connected");
        }
    }


    public void Update()
    {
        if (XCI.GetButtonDown(XboxButton.RightBumper, playerone) && playervalue == 1 || XCI.GetButtonDown(XboxButton.RightBumper, playertwo) && playervalue == 2)
        {
            Debug.Log("shoot");
            // Shoot();
            tank.shooting = true;
        }

        if (XCI.GetButtonUp(XboxButton.RightBumper, playerone) && playervalue == 1 )
        {
           
            // ShootStop();
            tank.shooting = false;
        }

        if (XCI.GetButtonUp(XboxButton.RightBumper, playertwo) && playervalue == 2)
        {
           
            // ShootStop();
            tank.shooting = false;
        }

        float ass = 0;
        if ( ass < XCI.GetAxis(XboxAxis.RightTrigger, playerone) && playervalue == 1 || ass < XCI.GetAxis(XboxAxis.RightTrigger, playertwo) && playervalue == 2)
        {
            Debug.Log("rightstickshoot");
            //Shoot();
            tank.shootingmissle = true;
        }

        if (ass >= XCI.GetAxis(XboxAxis.RightTrigger, playerone) || ass >= XCI.GetAxis(XboxAxis.RightTrigger, playertwo) && playervalue == 2)
        {
           
            // ShootStop();
            tank.shootingmissle = false;
        }

        
        if (ass < XCI.GetAxis(XboxAxis.LeftTrigger, playerone) && playervalue == 1 || ass < XCI.GetAxis(XboxAxis.LeftTrigger, playertwo) && playervalue == 2)
        {

            // Shoot();
            tank.shootingrico = true;
        }

        if (ass >= XCI.GetAxis(XboxAxis.LeftTrigger, playerone) || ass >= XCI.GetAxis(XboxAxis.LeftTrigger, playertwo) && playervalue == 2)
        {

            // ShootStop();
            tank.shootingrico = false;
        }

          if (XCI.GetButtonDown(XboxButton.Y, playerone) && playervalue == 1 || XCI.GetButtonDown(XboxButton.Y, playertwo) && playervalue == 2)
         {
          //  Debug.Log("ammo");
      //  Ammo();
        // tank.StartCoroutine("canagrainammo", 0.3f);
           tank.Grainammo = true;
         }

       if (XCI.GetButtonUp(XboxButton.Y, playerone) && playervalue == 1 || XCI.GetButtonUp(XboxButton.Y, playertwo) && playervalue == 2)
        {
            //  Debug.Log("ammostop");
         //AmmoStop();
             //tank.StopCoroutine("canagrainammo");
            tank.Grainammo = false;
          }

        if (XCI.GetButtonDown(XboxButton.A, playerone) && playervalue == 1 || XCI.GetButtonDown(XboxButton.A, playertwo) && playervalue == 2)
        {
            Debug.Log("repair");
            //Repair();
            tank.isrepair = true;
        }

        if (XCI.GetButtonUp(XboxButton.A, playerone) && playervalue == 1 || XCI.GetButtonUp(XboxButton.A, playertwo) && playervalue == 2)
        {
            Debug.Log("repairstop");
            // RepairStop();
            tank.isrepair = false;
        }

        if (XCI.GetButtonDown(XboxButton.X, playerone))
        {
            Debug.Log("pickup");
            //Pickup();
            tank.PickupCheck = true;
        }

        if (XCI.GetButtonUp(XboxButton.X, playerone))
        {
            Debug.Log("pickup");
            //Pickup();
            tank.PickupCheck = false;
        }


        if (XCI.GetDPad(XboxDPad.Up, playerone))
        {
            tankMover.forward = true;
            Debug.Log("move");
        }

        if (XCI.GetDPadUp(XboxDPad.Up, playerone))
        {
            tankMover.forward = false;
        }

        if (XCI.GetDPad(XboxDPad.Left, playerone))
        {
            tankMover.left = true;
        }

        if (XCI.GetDPadUp(XboxDPad.Left, playerone))
        {
            tankMover.left = false;
        }

        if (XCI.GetDPad(XboxDPad.Right, playerone))
        {
            tankMover.right = true;
        }

        if (XCI.GetDPadUp(XboxDPad.Right, playerone))
        {
            tankMover.right = false;
        }

        if (XCI.GetDPad(XboxDPad.Down, playerone))
        {
            tankMover.backward = true;
        }

        if (XCI.GetDPadUp(XboxDPad.Down, playerone))
        {
            tankMover.backward = false;
        }
        if (XCI.GetButtonDown(XboxButton.LeftBumper, playerone) && playervalue == 1 || XCI.GetButtonDown(XboxButton.LeftBumper, playertwo) && playervalue == 2)
        {
            tankMover.brake = true;
        }

        if (XCI.GetButtonUp(XboxButton.LeftBumper, playerone) && playervalue == 1 || XCI.GetButtonUp(XboxButton.LeftBumper, playertwo) && playervalue == 2)
        {
            tankMover.brake = false;
        }


        // Move with the left stick
        Vector3 newPosition = tankMover.image.transform.position;

        prevAxisX = axisX;
        prevAxisY = axisY;

        // Get the axis
        if(playervalue == 1)
        {
            axisX = XCI.GetAxis(XboxAxis.RightStickX, playerone);
            axisY = XCI.GetAxis(XboxAxis.RightStickY, playerone);
        }

        if (playervalue == 2)
        {
            axisX = XCI.GetAxis(XboxAxis.RightStickX, playertwo);
            axisY = XCI.GetAxis(XboxAxis.RightStickY, playertwo);
        }


        // Apply new position
        float newPosX = newPosition.x + (axisX * walkingSpeed * Time.deltaTime);
        float newPosZ = newPosition.z + (axisY * walkingSpeed * Time.deltaTime);

        newPosition = new Vector3(newPosX, tankMover.image.transform.position.y, newPosZ);
        tankMover.image.transform.position = newPosition;


    }

  

    void olf()
    {

        //var gamepad = Gamepad.all[0];


        inputActions = new PlayerControlls();

        // var _user = InputUser.PerformPairingWithDevice(Gamepad.all[1]);

        //  var actionMap = new PlayerControlls();

        //   _user.AssociateActionsWithUser(inputActions);
        //  InputUser _user2 = InputUser.PerformPairingWithDevice(Gamepad.all[2]);

        //  var actionMap2 = new PlayerControlls();
        // _user2.AssociateActionsWithUser(inputActions);

        inputActions.Gameplay.Shoot.performed += context => Shoot();


        inputActions.Gameplay.ArmMoveUp.performed += _ => StartMovingUp();
        inputActions.Gameplay.ArmMoveUp.canceled += _ => StopMovingUp();

        inputActions.Gameplay.ArmMoveDown.performed += _ => StartMovingDown();
        inputActions.Gameplay.ArmMoveDown.canceled += _ => StopMovingDown();


        inputActions.Gameplay.ArmMoveLeft.performed += _ => StartMovingLeft();
        inputActions.Gameplay.ArmMoveLeft.canceled += _ => StopMovingLeft();

        inputActions.Gameplay.ArmMoveRight.performed += _ => StartMovingRight();
        inputActions.Gameplay.ArmMoveRight.canceled += _ => StopMovingRight();

        inputActions.Gameplay.Move_Forwards.performed += _ => OnMove_Forwards();
        inputActions.Gameplay.Move_Forwards.canceled += _ => OnStop();

        inputActions.Gameplay.Move_Backwards.performed += _ => OnMove_Backwards();
        inputActions.Gameplay.Move_Backwards.canceled += _ => OnStop();

        inputActions.Gameplay.Move_Left.performed += _ => OnMoveLeft();
        inputActions.Gameplay.Move_Left.canceled += _ => OnStop();

        inputActions.Gameplay.Move_Right.performed += _ => OnMoveRight();
        inputActions.Gameplay.Move_Right.canceled += _ => OnStop();

        inputActions.Gameplay.RightStick.performed += ctx => move = ctx.ReadValue<Vector2>();
        inputActions.Gameplay.RightStick.canceled += ctx => move = Vector3.zero;

        inputActions.Gameplay.Shoot.performed += _ => Shoot();
        inputActions.Gameplay.Shoot.canceled += _ => ShootStop();

        inputActions.Gameplay.Repair.performed += _ => Repair();
        inputActions.Gameplay.Repair.canceled += _ => RepairStop();

        inputActions.Gameplay.Ammo.performed += _ => Ammo();
        inputActions.Gameplay.Ammo.canceled += _ => AmmoStop();

        inputActions.Gameplay.PickUp.performed += _ => Pickup();
    }

    void OnEnable()
    {
        //inputActions.Gameplay.Enable();
       
    }

    private void ff()
    {
        
            float temp = move.z;
            Vector3 m = new Vector3(move.x, 0.0f, move.y) * 1;
            tankMover.image.transform.Translate(m, Space.World);
        
    }


    // Start is called before the first frame update
    public void OnMove_Forwards()
    {
       
            //tankMover.MoveForwards();
          
        
    }
    //175, -175 lmits
    // Update is called once per frame
    public void OnMove_Backwards()
    {
       
          //  tankMover.MoveBackwards();
        
    }

    public void OnMoveLeft()
    {
        
          //  tankMover.MoveLeft();
        
    }

    public void OnMoveRight()
    {
       
          //  tankMover.MoveRight();
        
    }

    public void OnStop()
    {
        
           // tankMover.Stop();
        
    }

    public void StartMovingUp()
    {
       // if (isother == true)
       // {
         //   StopMovingUp();
         //   StopMovingDown();
        ////    StopMovingRight();
         //   StopMovingLeft();
         //   tankMover.InvokeRepeating("ArmMoveupMovement", 0.0f, 0.02f);
            
        //}
      // // Debug.Log("upstart");
    }

    public void StopMovingUp()
    {
        //if (isother == true)
      ///  {

         //   tankMover.CancelInvoke("ArmMoveupMovement");
          //  Debug.Log("upstop");
      //  }
    }

    public void StartMovingDown()
    {
        //if (isother == true)
       // {
       //     StopMovingUp();
       //     StopMovingDown();
       //     StopMovingRight();
       //     StopMovingLeft();
        //    tankMover.InvokeRepeating("ArmMoveDownMovement", 0.0f, 0.02f);
       // }
    }

    public void StopMovingDown()
    {
       // if (isother == true)
       // {
       ////   tankMover.CancelInvoke("ArmMoveDownMovement");
       // }
    }
    public void StartMovingRight()
    {
        //if (isother == true)
        //{
          //  StopMovingUp();
           // StopMovingDown();
           // StopMovingRight();
            //StopMovingLeft();
            //tankMover.InvokeRepeating("ArmMoveRightMovement", 0.0f, 0.02f);
        //}
    }

    public void StopMovingRight()
    {
        //if (isother == true)
        //{
         //tankMover.CancelInvoke("ArmMoveRightMovement");
        //}
    }
    public void StartMovingLeft()
    {
        //if (isother == true)
       // {
         //   StopMovingUp();
           // StopMovingDown();
          //  StopMovingRight();
         //   StopMovingLeft();
        //    tankMover.InvokeRepeating("ArmMoveLeftMovement", 0.0f, 0.02f);
       // }
    }

    public void StopMovingLeft()
    {
        // if (isother == true)
         //{
          // tankMover.CancelInvoke("ArmMoveLeftMovement");
        // }
    }

    public void Repair()
    {
        tank.StartCoroutine("repair", 0.4f);
    }
    public void RepairStop()
    {
        tank.StopCoroutine("repair");
    }

    public void Ammo()
    {
        tank.StartCoroutine("canagrainammo", 0.3f);
    }

    public void AmmoStop()
    {
        tank.StopCoroutine("canagrainammo");
        tank.Grainammo = false;
    }

    public void Shoot()
    {
        tank.shooting = true;
    }

    public void ShootStop()
    {
        tank.shooting = false;
    }

    public void Pickup()
    {
       // tank.PickupCheck();
    }
}
