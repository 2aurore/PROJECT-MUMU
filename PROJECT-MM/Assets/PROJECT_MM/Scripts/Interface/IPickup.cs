using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickup 
{

    public string Name { get; }
    
    public void Pickup();
}
