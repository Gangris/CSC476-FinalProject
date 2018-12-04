using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestructablePewPewTankObject : PewPewTankObject
{
    public int health = 100; // Default
    public int maxHealth = 100; // Default
    public Image healthBar;

    void Start()
    {
        Bootstrap();
    }

    public void TakeDamage(int amount)
    {
        Debug.Log("Taking " + amount + " Damage");
        health -= amount;
        healthBar.fillAmount = (float)health / (float)maxHealth;

        if (health <= 0)
        {
            Die();
        }
    }

    // Default behavior is to just... disappear. This should be overwritten by every class.
    public virtual void Die()
    {
        Destroy(this.gameObject);
    }

    public virtual void Bootstrap()
    {
        healthBar = FindHealthBarRecursive(
            new List<Transform>()
            {
                this.transform
            }
        );
    }

    Image FindHealthBarRecursive(List<Transform> parents)
    {
        string _tag = "Healthbar";
        List<Transform> nextRound = new List<Transform>();

        // Go through the entire list of parents
        for (int p = 0; p < parents.Count; p++)
        {
            var parent = parents[p];

            // For every child a parent has, inspect it for the tag
            for (int i = 0; i < parent.childCount; i++)
            {
                Transform child = parent.GetChild(i);

                if (child.tag == _tag)
                {
                    return child.GetComponent<Image>();
                }

                // If there are grandchild and we have not found the tag, add the child to the next round
                if (child.childCount > 0)
                {
                    nextRound.Add(child);
                }
            }
        }

        // Test to see if there are children to inspect
        if (nextRound.Count > 0)
        {
            return FindHealthBarRecursive(nextRound);
        }

        // No child found
        return null;
    }
}
