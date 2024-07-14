using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGroup
{
    void Join(GameObject newMember);
    void SetLeader(GameObject newLeader);
    void Leave(GameObject newMember);
}
