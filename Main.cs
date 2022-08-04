using UnityEngine;
using UnityModManagerNet;

namespace ArtOfRallyFFFMap
{
    public class Main
    {
        public static UnityModManager.ModEntry mod;
        public static bool enabled;
        static bool Load(UnityModManager.ModEntry modEntry)
        {
            mod = modEntry;
            mod.Logger.Log("Loading...");

            modEntry.OnToggle = OnToggle;

            mod.Logger.Log("Loaded");
            return true;
        }
        static bool OnToggle(UnityModManager.ModEntry modEntry, bool value)
        {
            if (value)
            {
                GameObject plane, terrain;
                plane = GameObject.Find("Plane");
                terrain = GameObject.Find("Static Objects");

                if (plane && terrain)
                {
                    // 1000 times larger Plane
                    plane.transform.localScale = new Vector3(
                        plane.transform.localScale.x * 1000f,
                        plane.transform.localScale.y * 1000f,
                        plane.transform.localScale.z * 1000f
                        );
                    // move static objects / terrain far away
                    terrain.transform.Translate(-50000f, 0f, 0f);

                    // move roads (no problem if not found)
                    for(int i = 0; i < 32; ++i)
                    {
                        GameObject road;
                        road = GameObject.Find("Road Objects/" + (i+1).ToString());
                        if(road)
                        {
                            road.transform.Translate(-50000f, 0f, 0f);
                        }
                    }
                }
                else
                {
                    mod.Logger.Log("GameObject not found");
                    return false;
                }
            }
            else
            {
                // nothing to do for now.
            }

            enabled = value;
            return true;
        }
    }
}
