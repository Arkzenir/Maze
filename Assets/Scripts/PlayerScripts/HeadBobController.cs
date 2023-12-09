using UnityEngine;

public class HeadBobController : MonoBehaviour
{
    [SerializeField] private float walkingBobbingSpeed = 14f;
    [SerializeField] private float bobbingAmount = 0.05f;
    [SerializeField] private PlayerController controller;

    private float _defaultPosY;
    private float _timer;
    
    void Start()
    {
        _defaultPosY = transform.localPosition.y;
        _timer = 0;
    }
    
    void Update()
    {
        if(Mathf.Abs(controller.MoveDirection.x) > 0.1f || Mathf.Abs(controller.MoveDirection.z) > 0.1f)
        {
            //Player is moving
            _timer += Time.deltaTime * walkingBobbingSpeed;
            transform.localPosition = new Vector3(transform.localPosition.x, _defaultPosY + Mathf.Sin(_timer) * bobbingAmount, transform.localPosition.z);
        }
        else
        {
            //Idle
            _timer = 0;
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Lerp(transform.localPosition.y, _defaultPosY, Time.deltaTime * walkingBobbingSpeed), transform.localPosition.z);
        }
    }
}