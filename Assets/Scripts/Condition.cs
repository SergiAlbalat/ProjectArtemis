using UnityEngine;

public class Condition
{
    private string _name;
    private bool _check;
    public Condition(string name)
    {
        _name = name;
        _check = false;
    }
    public string GetName() => _name;
    public bool GetCheck() => _check;
    public void SetCheck(bool check) => _check = check;
}
