﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {
    //HingeJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;


	// Use this for initialization
	void Start () {
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
	}
	
	// Update is called once per frame
	void Update () {
        
        //左矢印キーを押した時左フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTug")
        {
            SetAngle(this.flickAngle);
        }
        //右矢印キーを押した時右フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTug")
        {
            SetAngle(this.flickAngle);
        }
        //左矢印キーを離した時左フリッパーを元に戻す
        if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTug")
        {
            SetAngle(this.defaultAngle);
        }
        //右矢印キーを離した時右フリッパーを元に戻す
        if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTug")
        {
            SetAngle(this.defaultAngle);
        }
        //画面左側をタッチした時左フリッパーを動かす
        Touch[] myTouch = Input.touches;
        for (int i = 0; i <= Input.touchCount-1; i++)
        {
            if (myTouch[i].position.x < Screen.width / 2 && tag == "LeftFripperTug")
            {
                switch (myTouch[i].phase)
                {
                    case TouchPhase.Began:
                        SetAngle(this.flickAngle);
                        break;
                    case TouchPhase.Ended:
                        SetAngle(this.defaultAngle);
                        break;
                }
            }

            //画面右側をタッチした時右フリッパーを動かす
            if (myTouch[i].position.x >= Screen.width / 2 && tag == "RightFripperTug")
            {
                switch (myTouch[i].phase)
                {
                    case TouchPhase.Began:
                        SetAngle(this.flickAngle);
                        break;
                    case TouchPhase.Ended:
                        SetAngle(this.defaultAngle);
                        break;
                }
            }
        }
    }

    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}
