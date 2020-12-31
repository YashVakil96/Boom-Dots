using UnityEngine;
using UnityEngine.UI;
public class DeathFlash : MonoBehaviour
{
    #region Variables

    public GameObject flashPanel;
    public static Image flashImage;
    private Animator flashAnim;

    #endregion

    #region System Methods
    private void Start()
    {
        flashAnim=flashPanel.GetComponentInChildren<Animator>();
        flashImage=flashPanel.GetComponentInChildren<Image>();
    }
    private void Update()
    {
        if (!Bot.isAlive)
        {
            Flash();
            Bot.isAlive = true;
        }
    }

    #endregion

    #region User Define Methods

    public void Flash()
    {
        flashAnim.SetTrigger("IsDead");
    }

    #endregion
}