using UnityEngine;

public class DestinationRotator : MonoBehaviour
{
    private Quaternion[] rotations =
    {
        Quaternion.Euler(new Vector3(87, 62, 51)),
        Quaternion.Euler(new Vector3(22, 68, 47)),
        Quaternion.Euler(new Vector3(52, 18, 57)),
        Quaternion.Euler(new Vector3(67, 79, 36)),
        Quaternion.Euler(new Vector3(16, 11, 47)),
        Quaternion.Euler(new Vector3(8, 31, 39)),
        Quaternion.Euler(new Vector3(44, 59, 24)),
        Quaternion.Euler(new Vector3(13, 41, 26)),
        Quaternion.Euler(new Vector3(53, 63, 21)),
        Quaternion.Euler(new Vector3(46, 37, 46)),
    };

    private int _round = 0;

    /// <summary>
    /// Rotates the Destination Object for the next placement.
    /// The rotation is predetermined by an array of rotations.
    /// Once all rotations have been consumed the Destination Object will no longer be rotated.
    /// </summary>
    /// <returns>
    /// True if the end of available rotations hasn't been reached yet.
    /// False if all rotations have been consumed.
    /// </returns>
    public bool Rotate()
    {
        if(_round < rotations.Length)
        {
            this.transform.rotation = rotations[_round];
            _round += 1;

            return true;
        }
        else
        {
            return false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Rotate();

        Debug.Log("start");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
