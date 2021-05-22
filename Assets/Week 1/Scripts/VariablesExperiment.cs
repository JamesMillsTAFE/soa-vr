using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Every word has a capital first letter, this is called Pascal Casing
// This is how we can interpret phrases as a single word with no
// spaces in it - For class names or method names like this
public class VariablesExperiment : MonoBehaviour
{ // This is where the code we can create for this component starts - Scope
    // public <- The access modifier - Who can see it?
    // int <- The data type - what type of information am I storing?
    // score <- the name - how we can access the data
    // = 5 <- the value - What the data is currently
    // This is using camelCase <- where the first letter isn't capital and
    // every other word starts with a capital
    public int score = 5;

    public float height = 1.8f;

    // How fast the object is going to move
    public float speed = 1;

    // Will the cube move? <- Name the variable in a question format
    public bool moveCube = false;
    public bool scaleCube = false;

    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log makes the text appear in the console in Unity
        Debug.Log("Score is: " + score);

        // Changing the score by 10
        score = score + 10;
        Debug.Log("Score is: " + score);

        // Make the height show in the console
        Debug.Log("Person's height is: " + height);

        // Change the height by 1.5, using the shorthand method
        // This is the same as height = height + 1.5f;
        height += 1.5f;

        // Make the new height show in the console
        Debug.Log("Person's height is now: " + height);
    }

    // Update is called once per frame
    void Update()
    {
        // (direction * speed) + position = newPosition
        // Copy the position of the object into this variable
        //Vector3 position = transform.position;

        // Calculate speed vector by multiplying up by speed
        //Vector3 speedVector = Vector3.up * speed * Time.deltaTime;

        // Apply the new position to the transform
        //transform.position = position + speedVector;

        if(moveCube)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        // if the first condition failed, try to do this one instead
        else if(scaleCube)
        {
            // Vector3.one = (1, 1, 1) -- this is scaling the object
            transform.localScale += Vector3.one * speed * Time.deltaTime;
        }
    }
}
