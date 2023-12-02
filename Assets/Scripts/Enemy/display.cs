using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class display : MonoBehaviour
{
    public Text hurtText;
    public float hurtDisplayDuration = 2.0f;

    private Player player;  // Reference to the Player component

    void Start()
    {
        // Get the Player component attached to the same GameObject
        player = GetComponent<Player>();

        if (hurtText)
            hurtText.text = "";
    }

    public void TakeDamage(int damageAmount)
    {
        // Ensure we have a valid reference to the Player component
        if (player != null)
        {
            player.currentHealth -= damageAmount;
            DisplayHurtMessage();
        }
    }

    void DisplayHurtMessage()
    {
        if (hurtText)
        {
            hurtText.text = "I'm hit!";
            StartCoroutine(HideHurtMessageAfterDelay(hurtDisplayDuration));
        }
    }

    IEnumerator HideHurtMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (hurtText)
            hurtText.text = "";
    }
}
