using UnityEngine;
using System.Text;

public class HitCharacterController : MonoBehaviour
{
    private int objNum;
    private void Start()
    {
        StringBuilder sb = new StringBuilder(gameObject.name);
        sb.Replace("Player","");
        objNum = int.Parse(sb.ToString());
        sb.Clear();
        objNum--;
    }

    public void OnCollisionEnter(Collision collison)
    {
        if (collison.gameObject.tag == "Pillow")
        {
            string name = gameObject.name;
            PlayerManager.Instance.charaDatas[objNum].Damage();
        }

        if (collison.gameObject.tag == "Ground")
        {
            PlayerManager.Instance.charaDatas[objNum].canJump = true;
        }
    }
}