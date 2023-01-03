## Prefab ##
* Allow to store game objects for __reuse__ without putting them in a scene
* Allow to recreate element that appear in `multiple scene` or `multiple times` in a scene without rewrite our code repeatedly

1. __How to make a prefabs__
__Step1__: Create a prefab in Unity
  1. Create a gameobject in the Hierarchy window and make the necessary customization.
  2. Drag and drop the gameobject to the project window.
  3. That’s it, you have your prefab. Now you can delete the gameobject from the hierarchy window.

__Step2__: Adding script to your scene
* Create an empty gameobject.
* Add a script component and call it “Instantiate_example” (you can give it any name of your choice).
* Copy and paste the code below.

```csharp
using UnityEngine;
using System.Collections;

public class Instantiate_example : MonoBehaviour 
{ 
  public Transform prefab;
  void Start() 
  { 
     Instantiate(prefab, new Vector3(2.0F, 0, 0), Quaternion.identity);
  } 
}
```
> If we deleted that game object, we can see the prefab of it is still in our project folder, still gave all property that we have set before and the script is still attached to it
> If we need it in our scene => drag the prefab to our scene
> If we need to change the prefab => change it in our project folder, it will change in our scene too

__Step3__: Assign prefab or Gameobject to the script
* Select the script object in hierarchy view.
* Drag and drop the prefab to the prefab variable in the inspector window.
![](https://vionixstudio.com/wp-content/uploads/2021/10/Assign-prefab-for-instantiating.jpg)
Now if you hit play, the prefab will be instantiated on to your game scene at start. Unity by default names the gameobject as a clone of your prefab. So if your prefab name is Friend Cube then Unity will name it Friend Cube(Clone).

## Instantiate prefab as a child of another object ##
You can do this by instantiating your prefab as a Gameobject and then assigning the parent. This method can be used to instantiate an UI prefab also. You just need to make sure that the parent is inside the canvas.

```csharp
using UnityEngine;
using System.Collections;

public class Instantiate_example : MonoBehaviour 
{ 
  public Transform prefab;
  void Start() 
  { 
     Gameobject childprefab=Instantiate(prefab, new Vector3(2.0F, 0, 0), Quaternion.identity) as Gameobject;
     childprefab.transform.parent = GameObject.Find("parent object").transform;
  } 
}
```


2. __Advantage of prefabs__
* We can drag multiple prefabs to our scene
* If we made a new scene, we could add these to our new scene without completely remake our object
* We can make change to all of them at once by editing the prefab file, _either_ with the script file
> We can use code to instantiate a prefabs at runtime by using 

```csharp
`Instantiate(prefab, position, rotation);`
`// position and rotation are optional`
```