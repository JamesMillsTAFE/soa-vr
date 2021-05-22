using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is the start of a class, the class is the blueprint for any
// object within any Object-Oriented programming (OOP) language. This is
// shown by the 'class' keyword, followed by the name. In this case,
// the name is 'Shape', shown in green. Within C# all classes start with a 
// capital letter. This is called PascalCasing.
public class Shape : MonoBehaviour
{
    // An int is a whole number, no decimal places.
    // This is a field for the class. Public means anything that has access
    // to this class, can access the field. Here we are 'initialising' the
    // field with a number already. This is not always necessary.
    public int width = 5;
    public int height = 6;

    // Start is called before the first frame update
    // This is almost the same as a constructor, but Unity's version of it.
    void Start()
    {
        // Here we are changing the scale of the object, to the size we 
        // specified in the fields above. We use a Vector3, which is just
        // a class that contains 3 floats (decimal numbers).
        transform.localScale = new Vector3(width, height, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
