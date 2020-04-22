using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public interface IBaseEnemy
{
    Roomreveal Room { get; set; }

    void LateStart();
}
