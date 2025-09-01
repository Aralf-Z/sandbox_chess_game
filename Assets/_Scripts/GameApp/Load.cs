using System.Linq;
using Game.Core.Framework;
using Game.Core.Interface;
using Game.Logic;
using Game.UI;
using UnityEngine;
using UnityEngine.UI;
using ZToolKit;

public class Load : MonoBehaviour
{
    public Text loadingTxt;
    private float mLoadingTimer;

    private async void Start()
    {
        //初始化Toolkit
        await ToolKit.Init();
        
       

        // SceneManager.LoadScene("_Scenes/MainMenu");
    }

    private float timer = 0;
    
    private void Update()
    {
        timer += Time.deltaTime;
        
        Mod.Battlefield.curLegionBf?.CameraBind?.Update(Time.deltaTime);
        
        if (timer >= .5f)
        {
            timer = float.MinValue;
            const int elId = 70001;
            const int alId = 71001;

            var tables = CfgTool.Tables;
            var sbf = new SquadBattlefield();
            var lbf = new LegionBattlefield();

            lbf.CameraBind.Enabled = true;
            Sys.Battlefield.InitBattlefield(lbf, sbf);
            
            var enemyLegion = new Legion();
            foreach (var cfg in tables.TbCampaign[elId].Squads)
            {
                var squad = new Squad();
                foreach (var actorCfg in cfg.Value)
                    squad.SquadGrid.Set(actorCfg.Row, actorCfg.Column, new Enemy(actorCfg.Id));
                
                squad.RefreshInitiative();
                enemyLegion.Squads.AllSquads.Add(squad, cfg.Key);
            }
            
            var allyLegion = new Legion();
            foreach (var cfg in tables.TbCampaign[alId].Squads)
            {
                var squad = new Squad();
                foreach (var actorCfg in cfg.Value)
                    squad.SquadGrid.Set(actorCfg.Row, actorCfg.Column, actorCfg.Id / 10000 == 1 ? new Adventurer(actorCfg.Id): new Enemy(actorCfg.Id));
                
                squad.RefreshInitiative();
                allyLegion.Squads.AllSquads.Add(squad, cfg.Key);
            }
            
            UITool.OpenUI<BattlefieldUI>();
            Sys.Battlefield.EnterLegionBattlefield(allyLegion, enemyLegion);

            // var alMap = new SquadBattlefield();
            // var enMap = new SquadBattlefield();
            // var alList = new List<Ally>();
            // var enList = new List<Enemy>();
            //
            // //敌人固定在左，我方固定在右
            // Sys.Battlefield.SetGrid(alMap, enMap);
            // alMap.ObjectBind.Positon =  (4, 1.5f);
            // alMap.ObjectBind.Rotation = 90;
            // enMap.ObjectBind.Positon =  (-4, 1.5f);
            // enMap.ObjectBind.Rotation = -90;
            //
            // var ui = UITool.OpenUI<SquadBattleUI>();
            // var squad = CfgTool.Tables.TbCampaign[70001].Squad;
            //
            // foreach (var stance in squad[0])
            // {
            //     var a = Entity<Ally>.Get();
            //     a.Reset(stance.Id);
            //     a.ObjectBind.Scale = (-1, 1);
            //     alList.Add(a);
            //
            //     alMap.Actors.Set(stance.Row, stance.Column, a);
            //     ui.SetInfo(a);
            // }
            //
            // foreach (var stance in squad[1])
            // {
            //     var e = Entity<Enemy>.Get();
            //     e.Reset(stance.Id);
            //     enList.Add(e);
            //
            //     enMap.Actors.Set(stance.Row, stance.Column, e);
            //     ui.SetInfo(e);
            // }
        }
    }

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
}
