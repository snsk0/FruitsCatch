using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx.Toolkit;

public class FruitsPool : ObjectPool<Fruit>
{
    private readonly Fruit prefab;      //�v�[���Ώۂ̃I�u�W�F�N�g(�R���|�[�l���g)
    private readonly Transform parent;      //�I�u�W�F�N�g�v�[���̐e


    public FruitsPool(Fruit prefab, Transform parent)
    {
        this.prefab = prefab;
        this.parent = parent;
    }


    protected override Fruit CreateInstance()
    {
        //prefab�̐���
        Fruit ca = GameObject.Instantiate(prefab);
        ca.transform.SetParent(parent);
        ca.callback = () => this.Return(ca);

        return ca;
    }
}
