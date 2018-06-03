using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accuracy : MonoBehaviour {

    public float WalkAccuracy = 75f;
    public float RunAccuracy = 125f;
    public float speed = 12f;
    public float fallofSpeed = 5f;
    public float recoil = 1.25f;
    public float max = 190f;

    [Header("Deafault Accuracy")]
    public float defAccuracy1;
    public float defAccuracy2;
    public float defAccuracy3;
    public float defAccuracy4;

    [Header("Lines")]
    public GameObject line1;
    public GameObject line2;
    public GameObject line3;
    public GameObject line4;

    private Animator anim;

    void Start ()
    {
        anim = GetComponent<Animator>();
	}
	
	void Update ()
    {
        if (anim.GetBool("Walk"))
        {
            line1.transform.localPosition = new Vector3(Mathf.Lerp(line1.transform.localPosition.x, line1.transform.localPosition.x + WalkAccuracy, speed * Time.deltaTime), 0f, 0f);
            line2.transform.localPosition = new Vector3(Mathf.Lerp(line2.transform.localPosition.x, line2.transform.localPosition.x -WalkAccuracy, speed * Time.deltaTime), 0f, 0f);
            line3.transform.localPosition = new Vector3(0f, Mathf.Lerp(line3.transform.localPosition.y, line3.transform.localPosition.y -WalkAccuracy, speed * Time.deltaTime), 0f);
            line4.transform.localPosition = new Vector3(0f, Mathf.Lerp(line4.transform.localPosition.y, line4.transform.localPosition.y + WalkAccuracy, speed * Time.deltaTime), 0f);
        }
        if (anim.GetBool("Run"))
        {
            line1.transform.localPosition = new Vector3(Mathf.Lerp(line1.transform.localPosition.x, RunAccuracy, speed * Time.deltaTime), 0f, 0f);
            line2.transform.localPosition = new Vector3(Mathf.Lerp(line2.transform.localPosition.x, -RunAccuracy, speed * Time.deltaTime), 0f, 0f);
            line3.transform.localPosition = new Vector3(0f, Mathf.Lerp(line3.transform.localPosition.y, -RunAccuracy, speed * Time.deltaTime), 0f);
            line4.transform.localPosition = new Vector3(0f, Mathf.Lerp(line4.transform.localPosition.y, RunAccuracy, speed * Time.deltaTime), 0f);
        }
        else
        {
            line1.transform.localPosition = new Vector3(Mathf.Lerp(line1.transform.localPosition.x, defAccuracy1, fallofSpeed * Time.deltaTime), 0f, 0f);
            line2.transform.localPosition = new Vector3(Mathf.Lerp(line2.transform.localPosition.x, defAccuracy2, fallofSpeed * Time.deltaTime), 0f, 0f);
            line3.transform.localPosition = new Vector3(0f, Mathf.Lerp(line3.transform.localPosition.y, defAccuracy3, fallofSpeed * Time.deltaTime), 0f);
            line4.transform.localPosition = new Vector3(0f, Mathf.Lerp(line4.transform.localPosition.y, defAccuracy4, fallofSpeed * Time.deltaTime), 0f);
        }
        line1.transform.localPosition = new Vector3(Mathf.Clamp(line1.transform.localPosition.x, defAccuracy1, max), 0f, 0f);
        line2.transform.localPosition = new Vector3(Mathf.Clamp(line2.transform.localPosition.x, -max, defAccuracy2), 0f, 0f);
        line3.transform.localPosition = new Vector3(0f, Mathf.Clamp(line3.transform.localPosition.y, -max, defAccuracy3), 0f);
        line4.transform.localPosition = new Vector3(0f, Mathf.Clamp(line4.transform.localPosition.y, defAccuracy4, max), 0f);
    }
    public void jump()
    {
        line1.transform.localPosition = new Vector3(Mathf.Lerp(line1.transform.localPosition.x, line1.transform.localPosition.x * 40f, speed * Time.deltaTime), 0f, 0f);
        line2.transform.localPosition = new Vector3(Mathf.Lerp(line2.transform.localPosition.x, line2.transform.localPosition.x * 40f, speed * Time.deltaTime), 0f, 0f);
        line3.transform.localPosition = new Vector3(0f, Mathf.Lerp(line3.transform.localPosition.y, line3.transform.localPosition.y * 40f, speed * Time.deltaTime), 0f);
        line4.transform.localPosition = new Vector3(0f, Mathf.Lerp(line4.transform.localPosition.y, line4.transform.localPosition.y * 40f, speed * Time.deltaTime), 0f);
    }
    public void Recoil()
    {
        line1.transform.localPosition = new Vector3(Mathf.Lerp(line1.transform.localPosition.x, line1.transform.localPosition.x * recoil, speed * Time.deltaTime), 0f, 0f);
        line2.transform.localPosition = new Vector3(Mathf.Lerp(line2.transform.localPosition.x, line2.transform.localPosition.x * recoil, speed * Time.deltaTime), 0f, 0f);
        line3.transform.localPosition = new Vector3(0f, Mathf.Lerp(line3.transform.localPosition.y, line3.transform.localPosition.y * recoil, speed * Time.deltaTime), 0f);
        line4.transform.localPosition = new Vector3(0f, Mathf.Lerp(line4.transform.localPosition.y, line4.transform.localPosition.y * recoil, speed * Time.deltaTime), 0f);
    }
}
