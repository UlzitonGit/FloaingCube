using UnityEngine;

public class Floating : MonoBehaviour
{
    float vertex;
    bool floating = false;
    float timeToFloat = 0.5f;
    float rotationSpeed = 0.4f;
    string rotationSpeedChange;
    Vector3 targetRotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ChangeSpeed();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (floating == true)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(targetRotation), Time.deltaTime * rotationSpeed);
           
            timeToFloat -= Time.deltaTime;
        }
        if(timeToFloat <= 0) ChangeSpeed();
        if(rotationSpeedChange == "minus")
        {
            rotationSpeed -= Time.deltaTime;
            if (rotationSpeed <= 0.1f)
            {
                ChooseVertex();
                rotationSpeedChange = "plus";
            }
        }
        if (rotationSpeedChange == "plus")
        {
            rotationSpeed += Time.deltaTime;
            if (rotationSpeed >= 0.4f)
            {
                floating = true;
                rotationSpeedChange = "";
                
            }
        }

    }
    private void ChangeSpeed()
    {
        rotationSpeedChange = "minus";
    }
    private void ChooseVertex()
    {

        float oldVertex = vertex;
       
        while (vertex == oldVertex)
        {
            vertex = Random.Range(1, 5);
        }
        if (vertex == 1) targetRotation = new Vector3(0, 0, 15);
        if (vertex == 2) targetRotation = new Vector3(0, 0, -15);
        if (vertex == 3) targetRotation = new Vector3(15, 0, 0);
        if (vertex == 4) targetRotation = new Vector3(-15, 0, 0);
        timeToFloat = 0.5f;
        
        
        print(vertex);
    }
}
