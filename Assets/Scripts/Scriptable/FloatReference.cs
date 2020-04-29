using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Float Reference", menuName = "Float Reference", order = 51)]
public class FloatReference : ScriptableObject, ISerializationCallbackReceiver
{
    //Editable value
    public float initialValue;
    //Real current value
    [NonSerialized]
    private float value;

    //Properties to set and get the value
    public float Value
    {
        get { return value; }
        set
        {
            if (this.value > initialValue)
            {
                this.value = initialValue;
            }
            else
            {
                this.value = value;
            }
        }
    }
    //When Unity deserializes this scriptable object load the initial value into de value to interact with
    public void OnAfterDeserialize()
    {
        value = initialValue;
    }

    public void OnBeforeSerialize() { }
}
