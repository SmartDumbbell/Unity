using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class ButtonSceneAssignment : MonoBehaviour
{
    public static List<int> assignedScenes = new List<int>();
    private static int assignedCount = 0;
    private bool isAssigned = false;

    public GameObject listPanel;
    public GameObject chosenPanel;


    void Start()
    {
        listPanel.SetActive(true);
        chosenPanel.SetActive(false);
    }

    public void OnButtonClick()
    {
        if (!isAssigned)
        {
            int sceneIndex = GetSceneIndex();

            if (sceneIndex == -1)
            {
                Debug.Log("Invalid button name.");
                return;
            }

            if (assignedCount < 3)
            {
                if (!IsSceneAssigned(sceneIndex))
                {
                    AssignScene(sceneIndex);

                    if (assignedCount >= 3)
                    {
                        Debug.Log("Scenes have been assigned to 3 buttons.");
                        listPanel.SetActive(false);
                        chosenPanel.SetActive(true);
                        isAssigned = true; // Mark the button as assigned after all assignments are done
                    }
                }
                else
                {
                    Debug.Log("This scene is already assigned to another button.");
                }
            }
            else
            {
                Debug.Log("Scenes have already been assigned to 3 buttons.");
            }
        }
    }

    private int GetSceneIndex()
    {
        string sceneName = gameObject.name;
        return GetSceneIndex(sceneName);
    }

    private int GetSceneIndex(string sceneName)
    {
        int sceneIndex = -1;

        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            string name = SceneUtility.GetScenePathByBuildIndex(i);
            name = System.IO.Path.GetFileNameWithoutExtension(name);
            if (name == sceneName)
            {
                sceneIndex = i;
                break;
            }
        }

        return sceneIndex;
    }

    private bool IsSceneAssigned(int sceneIndex)
    {
        return assignedScenes.Contains(sceneIndex);
    }

    private void AssignScene(int sceneIndex)
    {
        assignedScenes.Add(sceneIndex);
        assignedCount++;
    }
}
