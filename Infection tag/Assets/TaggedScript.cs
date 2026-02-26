using StarterAssets;
using UnityEngine;
using Unity.Netcode;
using Unity.VisualScripting;

public class TaggedScript : NetworkBehaviour
{
    public NetworkVariable<bool> isTagged = new NetworkVariable<bool>(false);

    // Update is called once per frame
    void Update()
    {
        if (isTagged.Value == true)
        {
            GetComponent<ThirdPersonController>().enabled = false;
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!IsServer) return;

        if (collision.gameObject.CompareTag("Runner"))
        {
            TaggedScript Player = collision.gameObject.GetComponent<TaggedScript>();

            if (Player != null )
            {
                Player.isTagged.Value = true;
            }

        }
    }
}
