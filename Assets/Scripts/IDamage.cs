using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamage
{
    float HP { get ; set; }
    void TakeDamage(float dmg);
}
