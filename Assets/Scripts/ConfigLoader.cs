using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ModestTree;
using Newtonsoft.Json;
using UnityEngine;

namespace WordAlgorithm
{
    public class ConfigLoader
    {
        public async  Task<GridConfig> LoadConfigByName(string filename)
        {
            //TODO: Add async operation
            var jsonText =  Resources.LoadAsync<TextAsset>($"JSONConfigs/{filename}");
            while (!jsonText.isDone)
            {
                await Task.Yield();
            }
            return JsonConvert.DeserializeObject<GridConfig>(jsonText.asset.ToString());
        }
    }
    
    
    [Serializable]
    public class GridConfig
    {
        public List<List<string>> grid;
        public string failReaction;
    }
}
