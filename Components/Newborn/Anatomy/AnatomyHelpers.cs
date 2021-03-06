using System.Collections.Generic;
using UnityEngine;
using Components.Newborn;
using Components.Generation;


namespace Components.Newborn.Anatomy
{
  public class AnatomyHelpers
  {
    public static List<Vector3> Sides = new List<Vector3> {
      new Vector3 (1f, 0f, 0f),
      new Vector3 (0f, 1f, 0f),
      new Vector3 (0f, 0f, 1f),
      new Vector3 (-1f, 0f, 0f),
      new Vector3 (0f, -1f, 0f),
      new Vector3 (0f, 0f, -1f)
    };

    public static List<Vector3> Rotations = new List<Vector3> {
      new Vector3 (0f, 0f, 0f),
      new Vector3 (0f, 90f, 0f),
      new Vector3 (0f, -90f, 0f),
      new Vector3 (90f, 0f, 0f),
      new Vector3 (-90f, 0f, 0f)
    };

    public static List<Vector3> JointRotation = new List<Vector3> {
      new Vector3 (0f, 0f, 0f),
      new Vector3 (0f, 90f, 0f),
      new Vector3 (0f, -90f, 0f),
      new Vector3 (0f, 0f, 0f),
      new Vector3 (-90f, 0f, 0f)
    };

    public static void InitJoint(GameObject part, GameObject connectedBody, Vector3 jointAnchor, JointConfig jointConfig, bool isInitJoint = false)
    {
      ConfigurableJoint cj = part.transform.gameObject.AddComponent<ConfigurableJoint>();
      cj.xMotion = ConfigurableJointMotion.Locked;
      cj.yMotion = ConfigurableJointMotion.Locked;
      cj.zMotion = ConfigurableJointMotion.Locked;
      cj.angularXMotion = isInitJoint ? ConfigurableJointMotion.Locked : ConfigurableJointMotion.Limited;
      cj.angularYMotion = isInitJoint ? ConfigurableJointMotion.Locked : ConfigurableJointMotion.Limited;
      cj.angularZMotion = isInitJoint ? ConfigurableJointMotion.Locked : ConfigurableJointMotion.Limited;
      cj.anchor = -jointAnchor;
      cj.connectedBody = connectedBody.gameObject.GetComponent<Rigidbody>();
      cj.rotationDriveMode = RotationDriveMode.Slerp;
      cj.angularYLimit = new SoftJointLimit() { limit = jointConfig.yLimit, bounciness = jointConfig.bounciness };
      cj.axis = new Vector3(-1f, 0f, 0f);
      // AnatomyHelpers.HandleAngularLimit(cj, jointAnchor);
      cj.angularZLimit = new SoftJointLimit() { limit = jointConfig.zLimit, bounciness = jointConfig.bounciness };
      part.gameObject.GetComponent<Rigidbody>().useGravity = !isInitJoint;
      part.gameObject.GetComponent<Rigidbody>().mass = 1f;
    }
    public static void InitPosition(List<Vector3> sides, int y, int i, int z, GameObject cell, NewbornAgent newborn)
    {
      cell.transform.parent = newborn.NewBornGenerations[y - 1][i].transform;
      cell.transform.localPosition = sides[z];
    }

    public static bool IsValidPosition(Vector3 Position, Vector3 Spacing)
    {
      return !Physics.CheckBox(Position, Spacing);
    }
    public static void InitRigidBody(GameObject cell)
    {
      cell.GetComponent<Rigidbody>().useGravity = true;
      cell.GetComponent<Rigidbody>().mass = 1f;
    }

    public static List<PositionPostData> ReturnModelPositions(NewbornAgent newborn)
    {
      List<PositionPostData> positions = new List<PositionPostData>();
      for (int i = 0; i < newborn.CelllocalPositions.Count; i++)
      {
        List<float> position = new List<float>();
        position.Add(newborn.CelllocalPositions[i].x);
        position.Add(newborn.CelllocalPositions[i].y);
        position.Add(newborn.CelllocalPositions[i].z);
        positions.Add(new PositionPostData(position));
      }
      return positions;
    }

    public static string ReturnLimbPrefabPath()
    {
      string size = AnatomyTypes.sizes[Random.Range(0, AnatomyTypes.sizes.Length)];
      string type = AnatomyTypes.types[Random.Range(0, AnatomyTypes.types.Length)];
      return "Prefabs/Anatomy/limbs/" + type + "/" + size + "/prefab";
    }
    // public static void HandleAngularLimit(ConfigurableJoint cj, Vector3 jointAnchor)
    // {
    //   if (jointAnchor.y == -1)
    //   {
    //     cj.lowAngularXLimit = new SoftJointLimit() { limit = -AgentConfig.highLimit, bounciness = AgentConfig.bounciness };
    //     cj.highAngularXLimit = new SoftJointLimit() { limit = -AgentConfig.lowLimit, bounciness = AgentConfig.bounciness };
    //     cj.axis = new Vector3(-1f, 0f, 0f);
    //   }
    //   else if (jointAnchor.y == 1)
    //   {
    //     cj.highAngularXLimit = new SoftJointLimit() { limit = AgentConfig.highLimit, bounciness = AgentConfig.bounciness };
    //     cj.lowAngularXLimit = new SoftJointLimit() { limit = AgentConfig.lowLimit, bounciness = AgentConfig.bounciness };
    //     cj.axis = new Vector3(-1f, 0f, 0f);
    //   }
    //   else if (jointAnchor.x == 1)
    //   {
    //     cj.highAngularXLimit = new SoftJointLimit() { limit = AgentConfig.highLimit, bounciness = AgentConfig.bounciness };
    //     cj.lowAngularXLimit = new SoftJointLimit() { limit = AgentConfig.lowLimit, bounciness = AgentConfig.bounciness };
    //     cj.axis = new Vector3(-1f, 0f, 0f);
    //   }
    //   else if (jointAnchor.x == -1)
    //   {
    //     cj.lowAngularXLimit = new SoftJointLimit() { limit = -AgentConfig.highLimit, bounciness = AgentConfig.bounciness };
    //     cj.highAngularXLimit = new SoftJointLimit() { limit = -AgentConfig.highLimit, bounciness = AgentConfig.bounciness };
    //     cj.axis = new Vector3(-1f, 0f, 0f);
    //   }
    //   else if (jointAnchor.z == 1)
    //   {
    //     cj.axis = new Vector3(-1f, 0f, 0f);
    //     cj.highAngularXLimit = new SoftJointLimit() { limit = AgentConfig.lowLimit, bounciness = AgentConfig.bounciness };
    //     cj.lowAngularXLimit = new SoftJointLimit() { limit = -AgentConfig.lowLimit, bounciness = AgentConfig.bounciness };
    //   }
    //   else if (jointAnchor.z == -1)
    //   {
    //     cj.axis = new Vector3(-1f, 0f, 0f);
    //     cj.highAngularXLimit = new SoftJointLimit() { limit = AgentConfig.lowLimit, bounciness = AgentConfig.bounciness };
    //     cj.lowAngularXLimit = new SoftJointLimit() { limit = -AgentConfig.lowLimit, bounciness = AgentConfig.bounciness };
    //   }
    // }
  }
}