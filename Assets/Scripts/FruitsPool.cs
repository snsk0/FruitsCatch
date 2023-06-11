using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx.Toolkit;

public class FruitsPool : ObjectPool<Fruit>
{
    private readonly Fruit prefab;      //プール対象のオブジェクト(コンポーネント)
    private readonly Transform parent;      //オブジェクトプールの親


    public FruitsPool(Fruit prefab, Transform parent)
    {
        this.prefab = prefab;
        this.parent = parent;
    }


    protected override Fruit CreateInstance()
    {
        //prefabの生成
        Fruit ca = GameObject.Instantiate(prefab);
        ca.transform.SetParent(parent);
        ca.callback = () => this.Return(ca);

        return ca;
    }
}
