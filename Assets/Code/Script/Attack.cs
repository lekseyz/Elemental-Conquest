using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] Instantiator instantiator;
    [SerializeField] private MagicSystem ms;
    Dictionary<string, BasicSpell> magics = new Dictionary<string, BasicSpell>();
    public BasicSpell fb;
    public Animator animator;
    private void Start()
    {
        ms = GetComponent<MagicSystem>();

        magics.Add("ff", fb);
        magics.Add("ww", (BasicSpell)ScriptableObject.CreateInstance("Dash"));
        magics.Add("w", (BasicSpell)ScriptableObject.CreateInstance("Wind"));
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

        if (Input.GetKeyDown(KeyCode.Space))
            applyAttack();


    }


    void applyAttack()
    {
        
        
        //Attack handling
        var comb = ms.getFinalCombination();
        if (comb!= "ww")
        {
            animator.SetTrigger("Attack");
        }
        Debug.Log("Attacked: " + comb);
        BasicSpell spell;

        if(magics.TryGetValue(comb, out spell)) {
            instantiator.instatiateMagic(spell);
        }
    }
}
