using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmManager : MonoBehaviour
{
    public GameObject player;
    public GameObject antiGravityZone;
    public int alarmState = 0;
    // Start is called before the first frame update
    void Start()
    {
        antiGravityZone.transform.position = transform.position;
    }

    void OnEnable()
    {
        ReactPlayer.SetAlarm += CapturePlayer;
        ReactPlayer.StopAlarm += ReleasePlayer;
    }


    void OnDisable()
    {
        ReactPlayer.SetAlarm -= CapturePlayer;
        ReactPlayer.StopAlarm -= ReleasePlayer;
    }

    void Update() {
        
    }

    void CapturePlayer() {
        alarmState++;
        if(alarmState >= 3) {
            antiGravityZone.transform.position = player.transform.position;
        }
        
    }

    void ReleasePlayer() {
        alarmState--;
        if(alarmState < 3) {
            antiGravityZone.transform.position = transform.position;
        }
    }
}
