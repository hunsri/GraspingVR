using UnityEngine;

public class DestinationRotator : MonoBehaviour
{
    private Quaternion[] rotations =
    {
        Quaternion.Euler(new Vector3(37, 19, 34)),
        Quaternion.Euler(new Vector3(3, 0, 35)),
        Quaternion.Euler(new Vector3(2, 29, 41)),
        Quaternion.Euler(new Vector3(34, 19, 4)),
        Quaternion.Euler(new Vector3(38, 26, 11)),
        Quaternion.Euler(new Vector3(20, 32, 26)),
        Quaternion.Euler(new Vector3(44, 12, 1)),
        Quaternion.Euler(new Vector3(38, 35, 41)),
        Quaternion.Euler(new Vector3(9, 1, 28)),
        Quaternion.Euler(new Vector3(42, 40, 6)),
        Quaternion.Euler(new Vector3(7, 13, 35)),
        Quaternion.Euler(new Vector3(2, 4, 6)),
        Quaternion.Euler(new Vector3(32, 26, 8)),
        Quaternion.Euler(new Vector3(36, 30, 5)),
        Quaternion.Euler(new Vector3(9, 1, 2)),
        Quaternion.Euler(new Vector3(3, 39, 14)),
        Quaternion.Euler(new Vector3(2, 0, 25)),
        Quaternion.Euler(new Vector3(40, 23, 3)),
        Quaternion.Euler(new Vector3(1, 27, 24)),
        Quaternion.Euler(new Vector3(42, 17, 9)),
        Quaternion.Euler(new Vector3(42, 17, 19)),
        Quaternion.Euler(new Vector3(16, 35, 42)),
        Quaternion.Euler(new Vector3(20, 42, 40)),
        Quaternion.Euler(new Vector3(30, 7, 40)),
        Quaternion.Euler(new Vector3(13, 24, 18)),
        Quaternion.Euler(new Vector3(20, 42, 26)),
        Quaternion.Euler(new Vector3(6, 39, 44)),
        Quaternion.Euler(new Vector3(27, 30, 28)),
        Quaternion.Euler(new Vector3(13, 18, 22)),
        Quaternion.Euler(new Vector3(6, 33, 22))
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
    }
}
