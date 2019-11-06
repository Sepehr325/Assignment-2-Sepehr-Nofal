using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Bonus - make this class a Singleton!

[System.Serializable]


public class BulletClass
{
    public int Tag;
    public GameObject obj;
    public bool Active;

    public BulletClass(int tempid, GameObject tempobj, bool active)
    {
        Tag = tempid;
        obj = tempobj;
        obj.SetActive(active);
    }
    public void Activate()
    {
        Active = true;
        obj.SetActive(true);
    }
    public void Deactivate()
    {
        Active = false;
        obj.SetActive(false);
    }
}
public class BulletPoolManager
{
    GameObject bullet;

    private static int bulletamount = 10;
    private static int currentbullets = 0;





    //TODO: create a structure to contain a collection of bullets
    List<BulletClass> Bullets = new List<BulletClass>();


    // Start is called before the first frame update
    public BulletPoolManager(GameObject bulletprefab)
    {
        bullet = bulletprefab;
        for (int i = 0; i < bulletamount; i++)
        {
            BulletClass temp = new BulletClass(currentbullets, MonoBehaviour.Instantiate(bullet), false);
            currentbullets++;
            temp.obj.name = temp.Tag.ToString();
            Bullets.Add(temp);

        }

        // TODO: add a series of bullets to the Bullet Pool
    }

    // Update is called once per frame


    //TODO: modify this function to return a bullet from the Pool
    public GameObject GetBullet(Vector3 spawn, Quaternion rotation)
    {
        for (int i = 0; i < bulletamount; i++)
        {
            if (Bullets[i].Active == false)
            {
                GameObject newobj = Bullets[i].obj;
                newobj.transform.position = spawn;
                newobj.transform.rotation = rotation;
                Bullets[i].Activate();
                return newobj;
            }
        }
        return null;
    }

    //TODO: modify this function to reset/return a bullet back to the Pool 
    public void ResetBullet(int id)
    {

        for (int i = 0; i < bulletamount; i++)
        {
            if (Bullets[i].Active == true)
            {
                if (Bullets[i].Tag == id)
                {

                    Bullets[i].Deactivate();
                }

            }
        }
    }


}
