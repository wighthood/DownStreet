using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private Rigidbody2D Rigidbody2D;
    [SerializeField] private TMP_Text m_score;
    [SerializeField] private GameObject m_GameOver;
    [SerializeField] private TMP_Text m_finalScore;
    [SerializeField] private TMP_Text m_life;
    [SerializeField] private GameObject m_bullet;
    [SerializeField] private int m_speed;
    [SerializeField] private int m_maxAmmo;
    [SerializeField] private Image m_ammoBar;
    private int m_ammo;
    private int score =0;
    private bool IsReloading = false;
    public int life = 5;
    public bool isgrounded = false;

    public void LeftRight(InputAction.CallbackContext context)
    {
        Rigidbody2D.velocity = (context.ReadValue<Vector2>() * m_speed);
    }

    public void shoot(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (m_ammo > 0)
            {
                m_ammo--;
                Vector2 BulletStartPos = new Vector2(transform.position.x, transform.position.y - 1.5f);
                GameObject Bullet = Instantiate(m_bullet, BulletStartPos, Quaternion.identity);
                RectTransform RT =  m_ammoBar.GetComponent<RectTransform>();
                RT.sizeDelta = new Vector2(RT.sizeDelta.x, RT.sizeDelta.y*(m_ammo / m_maxAmmo));
                if (IsReloading == false)
                {
                    StartCoroutine(reload());
                }
            }  
        }
    }

    IEnumerator reload()
    {
        yield return new WaitForSeconds(5f);
        if (m_ammo < m_maxAmmo)
        {
            IsReloading = true;
            m_ammo++;
            RectTransform RT = m_ammoBar.GetComponent<RectTransform>();
            RT.sizeDelta = new Vector2(RT.sizeDelta.x, RT.sizeDelta.y * (m_ammo / m_maxAmmo));
            StartCoroutine(reload());
        }
        else
        {
            IsReloading = false;
        }
    }       

    private void Start()
    {
        Time.timeScale = 1;
        m_ammo = m_maxAmmo;
    }

    private void Update()
    {
        m_life.SetText("life : " + life);
        if (!isgrounded && life > 0)
        {
            score += 100;
            m_score.SetText("score : " + score);
        }
        if (life <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        Time.timeScale = 0;
        m_GameOver.SetActive(true);
        m_finalScore.SetText("score = " + score);
    }
}

