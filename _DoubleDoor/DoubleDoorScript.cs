using UnityEngine;
using System.Collections;

public class DoubleDoorScript : MonoBehaviour, IInteractive {

    public Transform LeftDoor;
    public Transform RightDoor;
    public float MoveAmmount;
    public float AnimationTime;

    private bool opened;
    private Vector3 leftDoorClosedPosition;
    private Vector3 rightDoorClosedPosition;
    private Vector3 leftDoorOpenedPosition;
    private Vector3 rightDoorOpenedPosition;
    private AudioSource audioSource;


    public void ResetState() {
        StopAllCoroutines();
        LeftDoor.localPosition = leftDoorClosedPosition;
        RightDoor.localPosition = rightDoorClosedPosition;
        opened = false;
    }

    private void Awake() {
        opened = false;

        leftDoorClosedPosition = LeftDoor.localPosition;
        rightDoorClosedPosition = RightDoor.localPosition;
        leftDoorOpenedPosition = new Vector3(leftDoorClosedPosition.x - MoveAmmount,
                                             leftDoorClosedPosition.y,
                                             leftDoorClosedPosition.z);
        rightDoorOpenedPosition = new Vector3(rightDoorClosedPosition.x + MoveAmmount,
                                              rightDoorClosedPosition.y,
                                              rightDoorClosedPosition.z);
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter() {
        if (!opened) {
            audioSource.Play();
            StopAllCoroutines();
            StartCoroutine(MoveOverTime(leftDoorOpenedPosition, rightDoorOpenedPosition, AnimationTime));
            opened = true;
        }
    }

    private void OnTriggerExit() {
        if (opened) {
            audioSource.Play();
            StopAllCoroutines();
            StartCoroutine(MoveOverTime(leftDoorClosedPosition, rightDoorClosedPosition, AnimationTime));
            opened = false;
        }
    }

    private IEnumerator MoveOverTime(Vector3 leftDoorTargetPosition, Vector3 rightDoorTargetPosition, float time) {
        float p1 = 0.0f;
        float rate = 1.0f / time;
        while (p1 < 1.0f) {
            LeftDoor.localPosition = Vector3.Lerp(LeftDoor.localPosition, leftDoorTargetPosition, p1);
            RightDoor.localPosition = Vector3.Lerp(RightDoor.localPosition, rightDoorTargetPosition, p1);
            p1 += Time.deltaTime * rate;
            yield return null;
        }
    }
}
