using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textWiggle : MonoBehaviour
{
    public float rotationSpeed = 10f; // Adjust the rotation speed as desired
    public float hoverHeight = 1f; // Adjust the height of hovering as desired
    public float hoverSpeed = 1f; // Adjust the speed of hovering as desired

    public float rotationRangeX = 30f; // Adjust the range of rotation on the X-axis
    public float rotationRangeY = 30f; // Adjust the range of rotation on the Y-axis
    public float rotationRangeZ = 30f; // Adjust the range of rotation on the Z-axis

    private Vector3 initialPosition;
    private Quaternion initialRotation;

    public Mesh start;
    public Mesh settings;
    public Mesh quit;
    public Mesh title;

    public bool spinnin = false;

    private void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    private void Update()
    {
		if (!spinnin)
		{
            float rotationOffsetX = Mathf.Sin(Time.time * rotationSpeed) * rotationRangeX;
            float rotationOffsetY = Mathf.Cos(Time.time * rotationSpeed) * rotationRangeY;
            float rotationOffsetZ = Mathf.Sin(Time.time * rotationSpeed) * rotationRangeZ;
            Quaternion targetRotation = Quaternion.Euler(rotationOffsetX, rotationOffsetY, rotationOffsetZ);
            transform.rotation = initialRotation * targetRotation;

            // Hovering
            float hoverOffset = Mathf.Sin(Time.time * hoverSpeed) * hoverHeight;
            Vector3 targetPosition = initialPosition + Vector3.up * hoverOffset;
            transform.position = targetPosition;
		}
        // Rotation
        
    }

    public void spinNchange(string text)
	{
        spinnin = true;
        StartCoroutine(spinnies(text));
    }

    public IEnumerator spinnies(string text)
	{
        LeanTween.rotate(this.gameObject, new Vector3(0, -90, -96), 0.1f);

        yield return new WaitForSeconds(0.1f);

        switch (text)
        {
            case "Quit":
                this.GetComponent<MeshFilter>().mesh = quit;
                break;
            case "Start":
                this.GetComponent<MeshFilter>().mesh = start;
                break;
            case "Settings":
                this.GetComponent<MeshFilter>().mesh = settings;
                break;

        }

        this.gameObject.transform.eulerAngles = new Vector3(0, 90, -96);

        LeanTween.rotate(this.gameObject, new Vector3(0, 180, -90), 0.1f);

        yield return new WaitForSeconds(0.1f);
        spinnin = false;
    }
}
