using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SnapToGrid))]//自动挂载吸附网格组件

public abstract class AbstractGrid: MonoBehaviour {

	public bool freezed = false;   //是否冰冻
	public bool destructable = false; //是否可破坏
	public bool antiGravity = false;  //是否处于反重力状态
	public bool antiGable = false;//是否可以被反重力作用
	public bool woodFriendly = false;//旁边是否可以放木块
	public bool flammable = false; //是否可燃
	public bool onFireNow = false; // 现在在燃烧么

	public abstract void OnFired();   //被燃烧时调用
	public abstract void OnFreezed(); //被冰冻
	public abstract void OnAntiGravity(); //实施反重力
	public abstract void InteractWithPrince();//和王子相互作用

}
