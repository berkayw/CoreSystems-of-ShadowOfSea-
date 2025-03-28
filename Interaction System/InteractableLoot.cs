using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableLoot : Interactable
{
	public override void Start()
	{
		base.Start();
	}
	protected override void Interaction()
	{
		base.Interaction();

		DisableCollider();

		OpenLoot();
	}
	void OpenLoot()
	{
		GetComponent<ItemContainer>().SetLoot();
		Events.ShowLoot(true);

		Events.OnShowLoot += TriggerLoot;
	}
	void TriggerLoot(bool openLoot)
	{
		if (openLoot)
		{
			GetComponent<ItemContainer>().SetLoot();
			Events.ShowLoot(true);
			Destroy(this);
		}
		else
		{
			GetComponent<ItemContainer>().ResetLoot();
			Events.OnShowLoot -= TriggerLoot;
		}
	}

	void DisableCollider()
	{
        if (TryGetComponent(out BoxCollider boxCollider))
        {
			boxCollider.enabled = false;
        }
        else if (TryGetComponent(out CapsuleCollider capsCollider))
        {
            capsCollider.enabled = false;
        }
        else
        {
            print("Error, no collider found!");
        }
    }
}
