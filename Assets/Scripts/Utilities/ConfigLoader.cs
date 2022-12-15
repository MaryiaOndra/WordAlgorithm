using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;
using WordAlgorithm.Interfaces;

namespace WordAlgorithm.Utilities
{
    public class ConfigLoader : ILoadConfig
    {
        public async  Task<GridConfig> Load(string filename)
        {
            var jsonText =  Resources.LoadAsync<TextAsset>($"JSONConfigs/{filename}");
            while (!jsonText.isDone)
            {
                await Task.Yield();
            }
            GridConfigFromEnum configFromEnum =
                JsonConvert.DeserializeObject<GridConfigFromEnum>(jsonText.asset.ToString());
            
            if(configFromEnum == null) Debug.LogException(new Exception(
                $"Config file with name [{filename}] can't be loaded!"));

            FailReactionType reactionType = (FailReactionType)Enum.Parse(typeof(FailReactionType),
                configFromEnum.failReaction);
            return new GridConfig(configFromEnum.grid, reactionType);
        }
    }
    
    public class GridConfig
    {
        public List<List<string>> Grid { get; }
        public FailReactionType ReactionType { get; }

        public GridConfig (List<List<string>> grid, FailReactionType reactionType )
        {
            Grid = grid;
            ReactionType = reactionType;
        }
    }
    
    [Serializable]
    public class GridConfigFromEnum
    {
        public List<List<string>> grid;
        public string failReaction;
    }

    public enum FailReactionType
    {
        Sound = 1,
        Shake = 2
    }
}
