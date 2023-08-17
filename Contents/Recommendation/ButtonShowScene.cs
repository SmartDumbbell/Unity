using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonShowScene : MonoBehaviour
{
    public void OnButtonClick()
    {
        int sceneIndex = GetAssignedSceneIndex();

        if (sceneIndex != -1)
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }

    private int GetAssignedSceneIndex()
    {
        int buttonIndex = int.Parse(gameObject.name);

        if (buttonIndex > ButtonSceneAssignment.assignedScenes.Count || buttonIndex <= 0)
        {
            Debug.LogError("No scene assigned to this button.");
            return -1;
        }

        int sceneIndex = ButtonSceneAssignment.assignedScenes[buttonIndex - 1];

        return sceneIndex;
    }
}
