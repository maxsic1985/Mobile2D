using UnityEngine;

public static class ResourceLoader
{
    public static GameObject LoadPrefab(ResourcePath path)
    {
        return Resources.Load<GameObject>(path.PathResource);
    }
    public static Rigidbody2D LoadRigitBody2D(ResourcePath path)
    {
        return Resources.Load<Rigidbody2D>(path.PathResource);
    }

} 
