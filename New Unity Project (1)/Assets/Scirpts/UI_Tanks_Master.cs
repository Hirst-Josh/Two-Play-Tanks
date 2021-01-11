using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Tanks_Master : MonoBehaviour
{

    public GameObject Ui_wheel;
    public  int RotatePostion;
    bool Postion1active;
    bool Postion2active;
    bool Postion3active;
    bool Postion4active;
    bool Postion5active;

    private void Start()
    {
        RotatePostion = 1;
        InvokeRepeating("MyUpdate", 0.2f, 0.4f);
    }

    public void Move_Left()
    {
        StopAllCoroutines();
        if(RotatePostion > 1)
        {
            RotatePostion -= 1;
            Black();
        }

        else if (RotatePostion == 1)
        {
            RotatePostion = 5;
            Black();
        }

        Debug.Log(RotatePostion);
    }

   public void Move_Right()
   {
        StopAllCoroutines();
        if (RotatePostion < 5)
        {
            RotatePostion += 1;
            Black();
        }

        else if (RotatePostion == 5)
        {
            RotatePostion = 1;
            Black();
        }

        Debug.Log(RotatePostion);
    }

    void Black()
    {
        Postion1active = false;
        Postion2active = false;
        Postion3active = false;
        Postion4active = false;
        Postion5active = false;
    }

    private void MyUpdate()
    {
        if (RotatePostion == 1)
        {
            if(Postion1active == false)
            {
                StartCoroutine(RotateImagePostion1());
                Postion1active = true;
                Debug.Log("RotateImagePostion1");
            }
        }
        else if (RotatePostion == 2)
        {
            if (Postion2active == false)
            {
                StartCoroutine(RotateImagePostion2());
                Postion2active = true;
                Debug.Log("RotateImagePostion2");
            }

        }
        else if (RotatePostion == 3)
        {
            if (Postion3active == false)
            {
                StartCoroutine(RotateImagePostion3());
                Postion3active = true;
                Debug.Log("RotateImagePostion3");
            }
        }
        else if (RotatePostion == 4)
        {
            if (Postion4active == false)
            {
                StartCoroutine(RotateImagePostion4());
                Postion4active = true;
                Debug.Log("RotateImagePostion4");
            }
        }
        else if (RotatePostion == 5)
        {
            if (Postion5active == false)
            {
                StartCoroutine(RotateImagePostion5());
                Postion5active = true;
                Debug.Log("RotateImagePostion5");
            }
        }

    }

    IEnumerator RotateImagePostionexample()
    {
        float moveSpeed = 0.1f;
        float y = 180;
        while (Ui_wheel.transform.rotation.y < 180)
        {
            Ui_wheel.transform.rotation = Quaternion.Slerp(Ui_wheel.transform.rotation, Quaternion.Euler(0, 180, 0), moveSpeed * Time.time);
            yield return null;
        }
        Ui_wheel.transform.rotation = Quaternion.Euler(0, 180, 0);
        yield return null;
    }


    IEnumerator RotateImagePostion1()
    {
        float moveSpeed = 1.1f;
        while (Ui_wheel.transform.rotation.y < 72)
        {
            Ui_wheel.transform.rotation = Quaternion.Slerp(Ui_wheel.transform.rotation, Quaternion.Euler(0, 72, 0), moveSpeed * Time.time);
            yield return null;
        }
        while (Ui_wheel.transform.rotation.y > 72)
        {
            Ui_wheel.transform.rotation = Quaternion.Slerp(Ui_wheel.transform.rotation, Quaternion.Euler(0, 72, 0), moveSpeed * Time.time);
            yield return null;
        }

        Ui_wheel.transform.rotation = Quaternion.Euler(0, 72, 0);
        yield return null;
    }

    IEnumerator RotateImagePostion2()
    {
        float moveSpeed = 1.1f;
        float y = 144;
        while (Ui_wheel.transform.rotation.y < 144)
        {
            Ui_wheel.transform.rotation = Quaternion.Slerp(Ui_wheel.transform.rotation, Quaternion.Euler(0, 144, 0), moveSpeed * Time.time);
            yield return null;
        }
        while (Ui_wheel.transform.rotation.y > 144)
        {
            Ui_wheel.transform.rotation = Quaternion.Slerp(Ui_wheel.transform.rotation, Quaternion.Euler(0, 144, 0), moveSpeed * Time.time);
            yield return null;
        }

        Ui_wheel.transform.rotation = Quaternion.Euler(0, 144, 0);
        yield return null;
    }

    IEnumerator RotateImagePostion3()
    {
        float moveSpeed = 1.1f;
        while (Ui_wheel.transform.rotation.y < 216)
        {
            Ui_wheel.transform.rotation = Quaternion.Slerp(Ui_wheel.transform.rotation, Quaternion.Euler(0, 216, 0), moveSpeed * Time.time);
            yield return null;
        }
        while (Ui_wheel.transform.rotation.y > 216)
        {
            Ui_wheel.transform.rotation = Quaternion.Slerp(Ui_wheel.transform.rotation, Quaternion.Euler(0, 216, 0), moveSpeed * Time.time);
            yield return null;
        }

        Ui_wheel.transform.rotation = Quaternion.Euler(0, 216, 0);
        yield return null;
    }

    IEnumerator RotateImagePostion4()
    {
        float moveSpeed = 1.1f;
        while (Ui_wheel.transform.rotation.y < 288)
        {
            Ui_wheel.transform.rotation = Quaternion.Slerp(Ui_wheel.transform.rotation, Quaternion.Euler(0, 288, 0), moveSpeed * Time.time);
            yield return null;
        }
        while (Ui_wheel.transform.rotation.y > 288)
        {
            Ui_wheel.transform.rotation = Quaternion.Slerp(Ui_wheel.transform.rotation, Quaternion.Euler(0, 288, 0), moveSpeed * Time.time);
            yield return null;
        }

        Ui_wheel.transform.rotation = Quaternion.Euler(0, 288, 0);
        yield return null;
    }

    IEnumerator RotateImagePostion5()
    {
        float moveSpeed = 1.1f;
        while (Ui_wheel.transform.rotation.y < 360)
        {
            Ui_wheel.transform.rotation = Quaternion.Slerp(Ui_wheel.transform.rotation, Quaternion.Euler(0, 360, 0), moveSpeed * Time.time);
            yield return null;
        }
        while (Ui_wheel.transform.rotation.y > 360)
        {
            Ui_wheel.transform.rotation = Quaternion.Slerp(Ui_wheel.transform.rotation, Quaternion.Euler(0, 360, 0), moveSpeed * Time.time);
            yield return null;
        }

        Ui_wheel.transform.rotation = Quaternion.Euler(0, 360, 0);
        yield return null;
    }

    
}
