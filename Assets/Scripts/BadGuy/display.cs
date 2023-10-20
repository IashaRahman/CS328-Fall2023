using UnityEngine; using UnityEngine.UI; using System.Collections; 
public class Player : MonoBehaviour { 
    public Text hurtText;  public float hurtDisplayDuration = 2.0f; 
  void Start() { 
    if ( hurtText) 
    hurtText.text = ""; 
    // Ensure the text is empty at the start } 
    public void TakeDamage(int damageAmount) { 
        health -= damageAmount; DisplayHurtMessage(); 
        } void DisplayHurtMessage() { 
            if (hurtText) { hurtText.text = "I'm hit!"; 
            StartCoroutine(HideHurtMessageAfterDelay(hurtDisplayDuration)); }
             } IEnumerator HideHurtMessageAfterDelay(float delay) { 
                yield 
            return new WaitForSeconds(delay); 
            if (hurtText) hurtText.text = ""; }
  }
 }