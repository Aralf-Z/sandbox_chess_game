using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace ConsoleTerminal.GameUI
{
    public class ConsoleTerminal : MonoBehaviour
    {
        [SerializeField] private GameObject root;
        
        [SerializeField] private CheatPanel cheatPanel;
        private RectTransform mCheatRectTransf;
        
        [SerializeField] private Button cheatBtn;
        [SerializeField] private RectTransform cheatBtnRectTransf;

        private void Awake()
        {
            root.SetActive(false);
            
            mCheatRectTransf = (RectTransform)cheatPanel.transform;
            
            cheatBtnRectTransf.localScale = new Vector3(cheatPanel.gameObject.activeInHierarchy ? 1 : -1, 1, 1);
            cheatBtn.onClick.AddListener(OnClickCheatBtn);
        }
        
        private void OnClickCheatBtn()
        {
            if (cheatPanel.gameObject.activeInHierarchy)
            {
                cheatBtnRectTransf.localScale = new Vector3(-1, 1, 1);
                mCheatRectTransf.DOKill();
                mCheatRectTransf.anchoredPosition = new Vector2(1600, 0);
                mCheatRectTransf.DOAnchorPosX(810, .5f)
                    .OnComplete(() => cheatPanel.gameObject.SetActive(false));
                
                cheatPanel.Hide();
            }
            else
            {
                cheatBtnRectTransf.localScale = new Vector3(1, 1, 1);
                mCheatRectTransf.DOKill();
                mCheatRectTransf.anchoredPosition = new Vector2(810, 0);
                cheatPanel.gameObject.SetActive(true);
                mCheatRectTransf.DOAnchorPosX(1600, .5f);
                cheatPanel.Open();
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.BackQuote))
            {
                root.SetActive(!root.activeSelf);
            }
        }
    }
}
