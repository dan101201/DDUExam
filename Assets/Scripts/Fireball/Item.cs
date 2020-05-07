using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public FireballStats stats;
    public float movementSpeedUp;
    public float healthUp;
    public float maxHealthUp;
    public AudioClip clip;
    public Text upgradeText;
    public float PickUpTimer;
    private void Awake() {
        upgradeText = GameObject.FindGameObjectWithTag("PickUpText").GetComponent<Text>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerShootManager player = other.GetComponent<PlayerShootManager>();
            if (stats != null)
            {
                player.AddStats(stats);
            }
            if (gameObject.name != "Health") {
                StartCoroutine(PickUpObject());
            }
            PlayerController playerC = other.GetComponent<PlayerController>();
            PlayerHealth playerH = other.GetComponent<PlayerHealth>();
            PlayAudio();

            playerC.movementSpeed += movementSpeedUp;
            playerH.Heal(healthUp);
            playerH.maxHealth += maxHealthUp;
            Destroy(gameObject);
        }
    }

    IEnumerator PickUpObject() {
        upgradeText.text =  $@"You have picked up {gameObject.name}";
        yield return new WaitForSeconds(PickUpTimer);
        upgradeText.text = "";
        yield return null;
    }

    void PlayAudio()
    {
        Instantiate(GameObject.FindGameObjectWithTag("GameController").GetComponent<ReferenceContainer>().PostMortemSoundObject, transform.position, transform.rotation).GetComponent<IndependentAudioPlayer>().PlaySound(clip);
    }
}
