using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.PlayerLoop;
using UnityEngine.SearchService;


// 리소스의 Load, Instantiate, Destroy 를 관리하는 리소스 매니저. 
public class ResourceManager
{
    // path에 있느 파일을 로드하는 함수, 로드되는 조건은 Object 일 때
    public T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }


    // Game Object Loading with prefab paths
    public GameObject Instantiate(string path, Vector3 pos, Transform parent = null)
    {
        GameObject prefab = Load<GameObject>($"Prefabs/{path}");
        if (prefab == null)
        {
            Debug.Log($"Failed to load prefab : {path}");
            return null;
        }
        else
        {
            try
            {
                if(prefab.GetComponent<MonoBehaviorObj>().type == MonoBehaviorObj.types.Object)
                {
                    GameObject obj = Object.Instantiate(prefab, parent);
                    Vector3 scale = prefab.transform.localScale;
                    obj.transform.localScale = new Vector3(1 * scale.x, 2 * scale.y, 1 * scale.z);
                    obj.transform.position = pos;
                    obj.transform.localEulerAngles = new Vector3(-60, 0, 0);
                    return obj;
                }
                else
                {
                    return Object.Instantiate(prefab, parent);
                }
            }
            catch
            {

                return Object.Instantiate(prefab, parent);
            }
        }
    }

    public GameObject Instantiate(string path, Transform parent)
    {
        GameObject prefab = Load<GameObject>($"Prefabs/{path}");
        if (prefab == null)
        {
            Debug.Log($"Failed to load prefab : {path}");
            return null;
        }
        else
        {
            try
            {
                if (prefab.GetComponent<MonoBehaviorObj>().type == MonoBehaviorObj.types.Object)
                {
                    GameObject obj = Object.Instantiate(prefab, parent);
                    Vector3 scale = obj.transform.localScale;
                    obj.transform.localScale = new Vector3(1 * scale.x, 2 * scale.y, 1 * scale.z);
                    obj.transform.localEulerAngles = new Vector3(-60, 0, 0);
                    return obj;
                }
                else
                {
                    return Object.Instantiate (prefab, parent);
                }

            }
            catch
            {
                return Object.Instantiate(prefab, parent);
            }
        }
    }

    public GameObject Instantiate(string path)
    {
        GameObject prefab = Load<GameObject>($"Prefabs/{path}");
        if (prefab == null)
        {
            Debug.Log($"Failed to load prefab : {path}");
            return null;
        }
        else
        {
            try
            {
                if (prefab.GetComponent<MonoBehaviorObj>().type == MonoBehaviorObj.types.Object)
                {
                    GameObject obj = Object.Instantiate(prefab);
                    Vector3 scale = obj.transform.localScale;
                    obj.transform.localScale = new Vector3(1 * scale.x, 2 * scale.y, 1 * scale.z);
                    obj.transform.localEulerAngles = new Vector3(-60, 0, 0);
                    return obj;
                }
                else
                {
                    return Object.Instantiate(prefab);
                }
            }
            catch
            {
                return Object.Instantiate(prefab);
            }
        }
    }

    // Game Object Loading with GameObject Prefabs
    public GameObject Instantiate(GameObject obj, Vector3 pos, Transform parent)
    {
        if(obj == null)
        {
            return null;
        }
        GameObject prefab = Object.Instantiate(obj, parent);
        if (prefab == null)
        {
            Debug.Log($"Failed to laod prefab : {obj.name}");
            return null;
        }
        else
        {
            try
            {
                if (prefab.GetComponent<MonoBehaviorObj>().type == MonoBehaviorObj.types.Object)
                {
                    Vector3 scale = prefab.transform.localScale;
                    prefab.transform.position = pos;
                    prefab.transform.localScale = new Vector3(1 * scale.x, 2 * scale.y, 1 * scale.z);
                    prefab.transform.localEulerAngles = new Vector3(-60, 0, 0);
                }
                return prefab;
            }
            catch
            {

                return prefab;
            }
        }
    }

    public GameObject Instantiate(GameObject obj, Transform parent)
    {
        if (obj == null)
        {
            return null;
        }
        GameObject prefab = Object.Instantiate(obj, parent);
        if (prefab == null)
        {
            Debug.Log($"Failed to laod prefab : {obj.name}");
            return null;
        }
        else
        {
            try
            {
                if (prefab.GetComponent<MonoBehaviorObj>().type == MonoBehaviorObj.types.Object)
                {
                    Vector3 scale = prefab.transform.localScale;
                    prefab.transform.localScale = new Vector3(1 * scale.x, 2 * scale.y, 1 * scale.z);
                    prefab.transform.localEulerAngles = new Vector3(-60, 0, 0);
                }
                return prefab;
            }
            catch
            {

                return prefab;
            }
        }
    }
    public GameObject Instantiate(GameObject obj)
    {
        if (obj == null)
        {
            return null;
        }
        GameObject prefab = Object.Instantiate(obj);
        if (prefab == null)
        {
            Debug.Log($"Failed to laod prefab : {obj.name}");
            return null;
        }

        else
        {
            try
            {
                if (prefab.GetComponent<MonoBehaviorObj>().type == MonoBehaviorObj.types.Object)
                {
                    Vector3 scale = prefab.transform.localScale;
                    prefab.transform.localScale = new Vector3(1 * scale.x, 2 * scale.y, 1 * scale.z);
                    prefab.transform.localEulerAngles = new Vector3(-60, 0, 0);
                }
                return prefab;
            }
            catch
            {

                return prefab;
            }
        }
    }

    // Loading XML Datas in path
    public XmlDocument LoadXML(string path)
    {
        XmlDocument xml = new XmlDocument();
        TextAsset txtAsset = Load<TextAsset>($"XML/{path}");
        xml.LoadXml(txtAsset.text);

        if (xml == null)
        {
            Debug.Log($"Failed to load XML : {path}");
            return null;
        }

        return xml;
    }

    // Loading Sprites in path
    public Sprite LoadSprite(string path)
    {
        Sprite spr;
        spr = Load<Sprite>($"Sprites/{path}");
        if (spr == null)
        {
            Debug.Log($"Failed to load Sprite : {path}");
            spr = Load<Sprite>($"Sprites/default");
            if(spr == null)
            {
                Debug.Log($"Failed to load Sprite : default");
            }
            return spr;
        }

        return spr;
    }

    // Destroy GameObject
    public void Destroy(GameObject go)
    {
        if (go == null) return;
        Object.Destroy(go);
    }

    // Destroy GameObjects
    public void Destroy(GameObject[] go)
    {
        foreach(GameObject g in go)
        {
            if(g != null)
            {
                Object.Destroy(g);
            }
        }
    }

}