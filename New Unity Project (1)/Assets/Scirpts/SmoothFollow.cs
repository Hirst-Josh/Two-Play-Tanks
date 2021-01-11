using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UIElements;
using XboxCtrlrInput;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SmoothFollow : MonoBehaviour
{
    // Start is called before the first frame update
    // The target we are following
    public Transform target;
    public Transform spawn;
    public GameObject playermenu;
    public GameObject DeathmatchMenu;
    public bool Deathmatch;
    public GameObject FlagMenu;
    public bool flagmenu;
    public bool zonemenu;
    public GameObject Zonemenu;
    public GameObject tank1;
    public GameObject tank2;
    public GameObject tank3;
    public GameObject tank4;
    public GameObject tank5;
    // The distance in the x-z plane to the target
    public float distance = 10.0f;
    // the height we want the camera to be above the target
    public float height = 5.0f;
    public GameObject button;
    public GameObject image;
    public GameObject quitbutton;
    public Vector3 imagespawned;
    public float heightDamping = 2.0f;
    public float rotationDamping = 3.0f;
    public XboxController playerone; 
    public float movingspeed = 1.0f;
    private float prevAxisX = 0.0f;
    private float prevAxisY = 0.0f;
    private float axisX = 0.0f;
    private float axisY = 0.0f;
    public bool spawed;
    public int Maxkills;
    public Text Kills;
    public int killkscount;
    public Text maxklls;
    public Text enmeykills;
    public int Enemykillscount;
    public GameObject Map;
    public bool isMoveToSpawnActive;
    public GameObject rawimage;
    public GameObject text;
    public bool ismoveingtospawn;
    public GameObject empty;
    GameObject Spawn;
    public UI_Tanks_Master UI_Tanks_Master;
    public GameObject CameraOutput;

    [AddComponentMenu("Camera-Control/Smooth Follow")]


     void Start()
    {
        target = spawn;
        Invoke("checker", 0.3f);
        killkscount = 0;
        InvokeRepeating("Texthandler", 0.5f, 0.5f);
        
        if (zonemenu == true)
        {
            Zonemenu.SetActive(true);
        }
        if (Deathmatch == true)
        {
           // DeathmatchMenu.SetActive(true);
           // maxklls.text = Maxkills.ToString();
           // //Kills.text = killkscount.ToString();
           // enmeykills.text = Enemykillscount.ToString();

        }
        if (flagmenu == true)
        {
            FlagMenu.SetActive(true);
        }
        if (XCI.IsPluggedIn(XboxController.First))
        {
            playerone = XboxController.First;
            Debug.Log(" controller is link to first controller");
        }
        if (XCI.IsPluggedIn(XboxController.Second))
        {
            
            Debug.Log(" 2nd controller");
        }

        // image.transform.position = rawimage.transform.position;
        //image.transform.position = new Vector3(0f, 0f, 0.0f);
    }

    void Texthandler()
    {
        if (killkscount == Maxkills)
        {

        }
    }


   public  void checker()
    {
        if (target == null)
        {
            // playermenu.SetActive(true);
          //  image.SetActive(true);
          //  button.SetActive(true);
          //  text.SetActive(true);
          //  rawimage.SetActive(true);
          //  Map.SetActive(false);
          //  quitbutton.SetActive(true);
          //  target = spawn;
          //  spawed = false;
        }

    }

    void spawnTankOne()
    {
        if (spawed == false)
        {
            isMoveToSpawnActive = false;
            image.transform.position = imagespawned;
            GameObject tank = Instantiate(tank1, spawn.position, Quaternion.Euler(0, 0, 0));
            target = tank.transform;
            tank.GetComponent<TankDrive>().spawn = spawn.gameObject;
            //playermenu.SetActive(false);
            image.SetActive(false);
            button.SetActive(false);
            text.SetActive(false);
            rawimage.SetActive(false);
            Map.SetActive(true);
            CameraOutput.SetActive(false);
            spawed = true;
            quitbutton.SetActive(false);
        }
    }

    void spawnTankTwo()
    {
        if (spawed == false)
        {
            isMoveToSpawnActive = false;
            image.transform.position = imagespawned;
            GameObject tank = Instantiate(tank2, spawn.position, Quaternion.Euler(0, 0, 0));
            target = tank.transform;
            tank.GetComponent<TankDrive>().spawn = spawn.gameObject;
            //playermenu.SetActive(false);
            image.SetActive(false);
            button.SetActive(false);
            text.SetActive(false);
            rawimage.SetActive(false);
            Map.SetActive(true);
            CameraOutput.SetActive(false);
            spawed = true;
            quitbutton.SetActive(false);
        }
    }

    void spawnTankThree()
    {
        if (spawed == false)
        {
            isMoveToSpawnActive = false;
            image.transform.position = imagespawned;
            GameObject tank = Instantiate(tank3, spawn.position, Quaternion.Euler(0, 0, 0));
            target = tank.transform;
            tank.GetComponent<TankDrive>().spawn = spawn.gameObject;
            //playermenu.SetActive(false);
            image.SetActive(false);
            button.SetActive(false);
            text.SetActive(false);
            rawimage.SetActive(false);
            Map.SetActive(true);
            CameraOutput.SetActive(false);
            spawed = true;
            quitbutton.SetActive(false);
            
        }
    }

    void spawnTankFour()
    {
        if (spawed == false)
        {
            isMoveToSpawnActive = false;
            image.transform.position = imagespawned;
            GameObject tank = Instantiate(tank4, spawn.position, Quaternion.Euler(0, 0, 0));
            target = tank.transform;
            tank.GetComponent<TankDrive>().spawn = spawn.gameObject;
            //playermenu.SetActive(false);
            image.SetActive(false);
            button.SetActive(false);
            text.SetActive(false);
            rawimage.SetActive(false);
            Map.SetActive(true);
            CameraOutput.SetActive(false);
            spawed = true;
            quitbutton.SetActive(false);
        }
    }

    void spawnTankFive()
    {
        if (spawed == false)
        {

            isMoveToSpawnActive = false;
            image.transform.position = imagespawned;
            GameObject tank = Instantiate(tank5, spawn.position, Quaternion.Euler(0, 0, 0));
            target = tank.transform;
            tank.GetComponent<TankDrive>().spawn = spawn.gameObject;
            //playermenu.SetActive(false);
            image.SetActive(false);
            button.SetActive(false);
            text.SetActive(false);
            rawimage.SetActive(false);
            Map.SetActive(true);
            CameraOutput.SetActive(false);
            spawed = true;
            quitbutton.SetActive(false);
        }
    }

    void LateUpdate()
    {
        // Early out if we don't have a target
        if (target == null)
        {
           // playermenu.SetActive(true);
           // spawed = false;


           // target = spawn;// temp here remove later
            
           // return;
        }

        
    }

    IEnumerator MoveTowards(Transform objectToMove, Vector3 toPosition, float duration)
    {
        float counter = 0;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            Vector3 currentPos = objectToMove.position;

            float time = Vector3.Distance(currentPos, toPosition) / (duration - counter) * Time.deltaTime;

            objectToMove.position = Vector3.MoveTowards(currentPos, toPosition, time);

            Debug.Log(counter + " / " + duration);
            yield return null;
        }
        if(counter >= 5)
        {
            Debug.Log("end");
            isMoveToSpawnActive = false;
            image.SetActive(true);
            button.SetActive(true);
            text.SetActive(true);
            rawimage.SetActive(true);
            Map.SetActive(false);
            CameraOutput.SetActive(true);
            spawed = false;
            target = spawn;
            quitbutton.SetActive(true);
            StopAllCoroutines();
           
        }
    }

    public void Update()
    {

        if(isMoveToSpawnActive == true)
        {
            if(ismoveingtospawn == false)
            {
                if(Spawn != null)
                {
                    Destroy(Spawn);
                }
                 Spawn = Instantiate(empty, target.position, Quaternion.Euler(0, 0, 0));
                 StartCoroutine(MoveTowards(Spawn.transform, spawn.position, 5f));
                 ismoveingtospawn = true;
            }
            
            target = Spawn.transform;
          
            

            // this will be used to move the camera bac to spawn 
        }
        if(isMoveToSpawnActive == false && spawed == false)
        {
            //insert setactivea for meunu this will be trigger than camera has moved back to spawned
           
            

        }


        if (XCI.GetButtonUp(XboxButton.RightBumper, playerone))
        {
            //Debug.Log("rightbumper");
            if(image.GetComponent<Playerimage>().button == true && UI_Tanks_Master.RotatePostion == 1)
            {
                spawnTankOne();
            }
            if (image.GetComponent<Playerimage>().button == true && UI_Tanks_Master.RotatePostion == 2)
            {
                spawnTankTwo();
            }

            if (image.GetComponent<Playerimage>().button == true && UI_Tanks_Master.RotatePostion == 3)
            {
                spawnTankThree();
            }
            if (image.GetComponent<Playerimage>().button == true && UI_Tanks_Master.RotatePostion == 4)
            {
                spawnTankFour();
            }
            if (image.GetComponent<Playerimage>().button == true && UI_Tanks_Master.RotatePostion == 5)
            {
                spawnTankFive();
            }

            if (image.GetComponent<Playerimage>().Left == true)
            {
                UI_Tanks_Master.Move_Left();
            }
            if (image.GetComponent<Playerimage>().Right == true)
            {
                UI_Tanks_Master.Move_Right();
            }

            if (image.GetComponent<Playerimage>().quit == true)
            {
                SceneManager.LoadScene("UI Menu");
            }
        }

        if(spawed == false)
        {

        }
        
        float wantedRotationAngle = target.eulerAngles.y;
        float wantedHeight = target.position.y + height;

        float currentRotationAngle = transform.eulerAngles.y;
        float currentHeight = transform.position.y;

        // Damp the rotation around the y-axis
        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

        // Damp the height
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

        // Convert the angle into a rotation
        var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

        // Set the position of the camera on the x-z plane to:
        // distance meters behind the target
        transform.position = target.position;
        transform.position -= currentRotation * Vector3.forward * distance;

        // Set the height of the camera
        transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

        // Always look at the target
        transform.LookAt(target);
        // based of https://gist.github.com/Hamcha/6096905

        if (spawed == false)
        {
            Vector3 newPosition = image.transform.position;

            prevAxisX = axisX;
            prevAxisY = axisY;
            float zz = -15f;

            // Get the axis
            axisX = XCI.GetAxis(XboxAxis.LeftStickX, playerone);
            axisY = XCI.GetAxis(XboxAxis.LeftStickY, playerone);

            // Apply new position
            float newPosX = newPosition.x + (axisX * movingspeed * Time.deltaTime);
            float newPosY = newPosition.y + (axisY * movingspeed * Time.deltaTime);

            newPosition = new Vector3(newPosX, newPosY, image.transform.position.z);
            image.transform.position = newPosition;
        }
    }
}
