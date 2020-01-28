using System;
using DataBank;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class Pickup : MonoBehaviour
{
    [Tooltip("Frequency at which the item will move up and down")]
    public float verticalBobFrequency = 1f;
    [Tooltip("Distance the item will move up and down")]
    public float bobbingAmount = 1f;
    [Tooltip("Rotation angle per second")]
    public float rotatingSpeed = 360f;

    [Tooltip("Sound played on pickup")]
    public AudioClip pickupSFX;
    [Tooltip("VFX spawned on pickup")]
    public GameObject pickupVFXPrefab;

    public UnityAction<PlayerCharacterController> onPick;
    public Rigidbody pickupRigidbody { get; private set; }

    Collider m_Collider;
    Vector3 m_StartPosition;
    bool m_HasPlayedFeedback;

    private void Start()
    {
        pickupRigidbody = GetComponent<Rigidbody>();
        DebugUtility.HandleErrorIfNullGetComponent<Rigidbody, Pickup>(pickupRigidbody, this, gameObject);
        m_Collider = GetComponent<Collider>();
        DebugUtility.HandleErrorIfNullGetComponent<Collider, Pickup>(m_Collider, this, gameObject);

        // ensure the physics setup is a kinematic rigidbody trigger
        pickupRigidbody.isKinematic = true;
        m_Collider.isTrigger = true;

        // Remember start position for animation
        m_StartPosition = transform.position;
    }

    private void Update()
    {
        // Handle bobbing
        float bobbingAnimationPhase = ((Mathf.Sin(Time.time * verticalBobFrequency) * 0.5f) + 0.5f) * bobbingAmount;
        transform.position = m_StartPosition + Vector3.up * bobbingAnimationPhase;

        // Handle rotating
        transform.Rotate(Vector3.up, rotatingSpeed * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Level")
        {
            GameObject gameManager = GameObject.Find("GameManager");
            PlayerDB playerDB = new PlayerDB();
            PlayerEntity playerEntity;
            GameEntity gameEntity;
            System.Data.IDataReader readerPlayer = playerDB.getDataById(1);
            while (readerPlayer.Read())
            {
                playerEntity = new PlayerEntity(Int32.Parse(readerPlayer[0].ToString()),
                    Int32.Parse(readerPlayer[1].ToString()),
                    new Vector3(Int32.Parse(readerPlayer[3].ToString()), Int32.Parse(readerPlayer[4].ToString()), Int32.Parse(readerPlayer[5].ToString())),
                    Int32.Parse(readerPlayer[2].ToString()));

            }
            GameDB gameDB = new GameDB();
            System.Data.IDataReader readerGame = gameDB.getDataById(1);
            while (readerGame.Read())
            {
                gameEntity = new GameEntity(
                    Int32.Parse(readerPlayer[0].ToString()),
                    Int32.Parse(readerPlayer[1].ToString()),
                    Int32.Parse(readerPlayer[2].ToString()),
                    Int32.Parse(readerPlayer[3].ToString()));

            }


        }
        PlayerCharacterController pickingPlayer = other.GetComponent<PlayerCharacterController>();

        if (pickingPlayer != null)
        {
            if (onPick != null)
            {
                onPick.Invoke(pickingPlayer);
            }
        }
    }

    public void PlayPickupFeedback()
    {
        if (m_HasPlayedFeedback)
            return;

        if (pickupSFX)
        {
            AudioUtility.CreateSFX(pickupSFX, transform.position, AudioUtility.AudioGroups.Pickup, 0f);
        }

        if (pickupVFXPrefab)
        {
            var pickupVFXInstance = Instantiate(pickupVFXPrefab, transform.position, Quaternion.identity);
        }

        m_HasPlayedFeedback = true;
    }
}
