using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] Instantiator instantiator;
    [SerializeField] private MagicSystem ms;
    Dictionary<string, BasicSpell> magics = new Dictionary<string, BasicSpell>();
    public BasicSpell fb;
    public BasicSpell rck;
    public Animator animator;
    private void Start()
    {
        ms = GetComponent<MagicSystem>();

        magics.Add("ff", fb);
        magics.Add("ww", (BasicSpell)ScriptableObject.CreateInstance("Dash"));
        magics.Add("w", (BasicSpell)ScriptableObject.CreateInstance("Wind"));
        //magics.Add("s", (BasicSpell)ScriptableObject.CreateInstance("IceShield"));
        magics.Add("ss", rck);
    }

    private void Update()
    {
        inputHandle();
    }

    void inputHandle()
    {
        if (Input.GetKeyDown(KeyCode.J))
            ms.addElem(MagicSystem.Elements.Fire);

        if (Input.GetKeyDown(KeyCode.K))
            ms.addElem(MagicSystem.Elements.Wind);

        if (Input.GetKeyDown(KeyCode.L))
            ms.addElem(MagicSystem.Elements.Stone);

        if (Input.GetKeyDown(KeyCode.Space))
            applyAttack();


    }


    void applyAttack()
    {
        
        
        //Attack handling
        var comb = ms.getFinalCombination();
        if (comb!= "ww")
        {
            if (comb == "ss")
                animator.SetTrigger("RockCast");
            else if (comb == "s")
                animator.SetTrigger("Shield");
            else
                animator.SetTrigger("Attack");
        }
        Debug.Log("Attacked: " + comb);
        BasicSpell spell;

        if(magics.TryGetValue(comb, out spell)) 
        {
            instantiator.instatiateMagic(spell);
        }
    }
}
