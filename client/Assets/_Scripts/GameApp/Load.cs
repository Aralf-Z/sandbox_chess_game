// using System.Linq;
// using Game.Core.Framework;
// using Game.Core.Interface;
// using Game.Core.Utility;
// using Game.Logic;
// using Game.UI;
// using UnityEngine;
// using UnityEngine.UI;
// using ZToolKit;
//
// public class Load : MonoBehaviour
// {
//     public Text loadingTxt;
//     private float mLoadingTimer;
//
//     private async void Start()
//     {
//         //初始化Toolkit
//         await ToolKit.Init();
//         
//        
//
//         // SceneManager.LoadScene("_Scenes/MainMenu");
//     }
//
//     private float timer = 0;
//     
    // private void Update()
    // {
    //     timer += Time.deltaTime;
    //     
    //     Mod.Battlefield.curLegionBf?.CameraBind?.Update(Time.deltaTime);
    //     
    //     if (timer >= .5f)
    //     {
    //         timer = float.MinValue;
    //         const int elId = 70001;
    //         const int alId = 71001;
    //
    //         var tables = Util.Config.Tables;
    //         var sbf = new SquadBattlefield();
    //         var lbf = new LegionBattlefield();
    //
    //         lbf.CameraBind.Enabled = true;
    //         Sys.Battlefield.InitBattlefield(lbf, sbf);
    //         
    //         var enemyLegion = new Legion();
    //         foreach (var cfg in tables.TbCampaign[elId].Squads)
    //         {
    //             var squad = new Squad(enemyLegion);
    //             squad.Info.Name = cfg.Key;
    //             foreach (var actorCfg in cfg.Value)
    //                 squad.SquadGrid.Set(actorCfg.Row, actorCfg.Column, new Enemy(actorCfg.Id));
    //             
    //             squad.RefreshAttribute(EmAttribute.Initiative);
    //             squad.RefreshAttribute(EmAttribute.Movement);
    //             enemyLegion.Squads.AllSquads.Add(squad, cfg.Key);
    //         }
    //         
    //         var allyLegion = new Legion();
    //         foreach (var cfg in tables.TbCampaign[alId].Squads)
    //         {
    //             var squad = new Squad(allyLegion);
    //             squad.Info.Name = cfg.Key;
    //             foreach (var actorCfg in cfg.Value)
    //                 squad.SquadGrid.Set(actorCfg.Row, actorCfg.Column, actorCfg.Id / 10000 == 1 ? new Adventurer(actorCfg.Id): new Enemy(actorCfg.Id));
    //             
    //             squad.RefreshAttribute(EmAttribute.Initiative);
    //             squad.RefreshAttribute(EmAttribute.Movement);
    //             allyLegion.Squads.AllSquads.Add(squad, cfg.Key);
    //         }
    //         
    //         UITool.OpenUI<BattlefieldUI>();
    //         Sys.Battlefield.EnterLegionBattlefield(allyLegion, enemyLegion);
    //     }
    // }

    // private void Update()
    // {
    //     mLoadingTimer += Time.deltaTime;
    //     
    //     if (mLoadingTimer < .3f)
    //     {
    //         loadingTxt.text = "Loading.";
    //     }
    //     else if (mLoadingTimer < .6f)
    //     {
    //         loadingTxt.text = "Loading..";
    //     }
    //     else if (mLoadingTimer < .9f)
    //     {
    //         loadingTxt.text = "Loading...";
    //     }
    //     else
    //     {
    //         mLoadingTimer = 0;
    //     }
    // }
// }