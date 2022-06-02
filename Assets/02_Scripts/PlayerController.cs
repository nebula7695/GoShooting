using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] StageData stageData;
    [SerializeField] KeyCode keyAttackCode = KeyCode.Space;
    Movement movement;
    Weapon weapon;
    Animator animator;
    bool isDead = false;

    int score;
    public int Score
    {
        set => score = Mathf.Max(0, value);
        get => score;
    }

    void Start()
    {
        movement = GetComponent<Movement>();
        weapon = GetComponent<Weapon>();
        animator = GetComponent<Animator>();
    }        
    void Update()
    {
        if (isDead) return;

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        movement.MoveTo(new Vector3(x, y, 0));

        if (Input.GetKeyDown(keyAttackCode))
        {
            weapon.StartFiring();
        }
        else if (Input.GetKeyUp(keyAttackCode))
        {
            weapon.StopFiring();
        }
    }
    private void LateUpdate()
    {
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, stageData.LimitMin.x,stageData.LimitMax.x)
            ,Mathf.Clamp(transform.position.y, stageData.LimitMin.y,stageData.LimitMax.y)
            ,0);
    }
    public void OnDie()
    {
        movement.MoveTo(Vector2.zero);
        animator.SetTrigger("onDie");
        Destroy(GetComponent<CircleCollider2D>());
        isDead = true;
    }
    public void OnDieEvent()
    {
        PlayerPrefs.SetInt("Score", score);
        SceneManager.LoadScene("GameOver");
    }
}
