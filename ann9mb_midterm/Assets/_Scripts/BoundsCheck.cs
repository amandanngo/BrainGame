using UnityEngine;

public class BoundsCheck : MonoBehaviour
{
    [System.Flags]
    public enum eScreenLocs
    {
        onScreen = 0,   // 0000
        offRight = 1,   // 0001
        offLeft = 2,   // 0010
        offUp = 4,   // 0100
        offDown = 8    // 1000
    }

    [Header("Inscribed")]
    public eType boundsType = eType.center;
    public float radius = 1f;
    public bool keepOnScreen = true;

    [Header("Dynamic")]
    public eScreenLocs screenLocs = eScreenLocs.onScreen;
    public float camWidth;
    public float camHeight;

    private float checkRadius;

    public enum eType { center, inset, outset }

    void Awake()
    {
        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;
    }

    void LateUpdate()
    {
        Vector3 pos = transform.position;

        switch (boundsType)
        {
            case eType.inset:
                checkRadius = -radius;
                break;
            case eType.outset:
                checkRadius = radius;
                break;
            default:
                checkRadius = 0;
                break;
        }

        // Reset to onScreen each frame
        screenLocs = eScreenLocs.onScreen;

        // Check right
        if (pos.x > camWidth + checkRadius)
        {
            pos.x = camWidth + checkRadius;
            screenLocs |= eScreenLocs.offRight;
            // isOnScreen = false;
        }

        // Check left
        if (pos.x < -camWidth - checkRadius)
        {
            pos.x = -camWidth - checkRadius;
            screenLocs |= eScreenLocs.offLeft;
            // isOnScreen = false;
        }

        // Check top
        if (pos.y > camHeight + checkRadius)
        {
            pos.y = camHeight + checkRadius;
            screenLocs |= eScreenLocs.offUp;
            // isOnScreen = false;
        }

        // Check bottom
        if (pos.y < -camHeight - checkRadius)
        {
            pos.y = -camHeight - checkRadius;
            screenLocs |= eScreenLocs.offDown;
            // isOnScreen = false;
        }

        // If forcing on-screen, reposition
        if (keepOnScreen && !isOnScreen)
        {
            transform.position = pos;
            screenLocs = eScreenLocs.onScreen;
            // isOnScreen = true;
        }
    }

    // New property replacing the old field (for backward compatibility)
    public bool isOnScreen
    {
        get { return screenLocs == eScreenLocs.onScreen; }
    }

    public bool LocIs(eScreenLocs checkLoc)
    {
        if (checkLoc == eScreenLocs.onScreen) return isOnScreen;    // a
        return ((screenLocs & checkLoc) == checkLoc);               // b
    }

}