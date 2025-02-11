using UnityEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

public sealed class PlayerDataMap : ClassMap<PlayerData>
{
    public PlayerDataMap()
    {
        Map(m => m.Player).Name("Player");
        Map(m => m.Team).Name("Team");
        Map(m => m.Position).Name("Position");
        Map(m => m.Salary).Name("Salary");
        Map(m => m.Minutes).Name("Minutes");
        Map(m => m.Max_Minutes).Name("Max Minutes");
        Map(m => m.MIN_CUM_AVG).Name("MIN_CUM_AVG");
        Map(m => m.MIN_LAST_3_AVG).Name("MIN_LAST_3_AVG");
        Map(m => m.MIN_LAST_5_AVG).Name("MIN_LAST_5_AVG");
        Map(m => m.MIN_LAST_10_AVG).Name("MIN_LAST_10_AVG");
        Map(m => m.MIN_TREND).Name("MIN_TREND");
        Map(m => m.MIN_CONSISTENCY).Name("MIN_CONSISTENCY");
        Map(m => m.MIN_CONSISTENCY_SCORE).Name("MIN_CONSISTENCY_SCORE");
        Map(m => m.MIN_ABOVE_20).Name("MIN_ABOVE_20");
        Map(m => m.MIN_ABOVE_25).Name("MIN_ABOVE_25");
        Map(m => m.MIN_ABOVE_30).Name("MIN_ABOVE_30");
        Map(m => m.MIN_ABOVE_AVG_STREAK).Name("MIN_ABOVE_AVG_STREAK");
        Map(m => m.FREQ_ABOVE_20).Name("FREQ_ABOVE_20");
        Map(m => m.FREQ_ABOVE_25).Name("FREQ_ABOVE_25");
        Map(m => m.FREQ_ABOVE_30).Name("FREQ_ABOVE_30");
        Map(m => m.Projected_Pts).Name("Projected Pts");
        Map(m => m.DK).Name("DK");
        Map(m => m.DK_CUM_AVG).Name("DK_CUM_AVG");
        Map(m => m.DK_LAST_3_AVG).Name("DK_LAST_3_AVG");
        Map(m => m.DK_LAST_5_AVG).Name("DK_LAST_5_AVG");
        Map(m => m.DK_LAST_10_AVG).Name("DK_LAST_10_AVG");
        Map(m => m.DK_TREND).Name("DK_TREND");
        Map(m => m.DK_TREND_5).Name("DK_TREND_5");
        Map(m => m.DK_CONSISTENCY).Name("DK_CONSISTENCY");
        Map(m => m.PTS_LAST_3_AVG).Name("PTS_LAST_3_AVG");
        Map(m => m.PTS_LAST_5_AVG).Name("PTS_LAST_5_AVG");
        Map(m => m.PTS_LAST_10_AVG).Name("PTS_LAST_10_AVG");
        Map(m => m.REB_LAST_3_AVG).Name("REB_LAST_3_AVG");
        Map(m => m.REB_LAST_5_AVG).Name("REB_LAST_5_AVG");
        Map(m => m.REB_LAST_10_AVG).Name("REB_LAST_10_AVG");
        Map(m => m.AST_LAST_3_AVG).Name("AST_LAST_3_AVG");
        Map(m => m.AST_LAST_5_AVG).Name("AST_LAST_5_AVG");
        Map(m => m.AST_LAST_10_AVG).Name("AST_LAST_10_AVG");
        Map(m => m.PTS_CUM_AVG).Name("PTS_CUM_AVG");
        Map(m => m.REB_CUM_AVG).Name("REB_CUM_AVG");
        Map(m => m.AST_CUM_AVG).Name("AST_CUM_AVG");
        Map(m => m.PTS_PER_MIN).Name("PTS_PER_MIN");
        Map(m => m.REB_PER_MIN).Name("REB_PER_MIN");
        Map(m => m.AST_PER_MIN).Name("AST_PER_MIN");
        Map(m => m.SCORING_EFFICIENCY).Name("SCORING_EFFICIENCY");
        Map(m => m.RECENT_SCORING_EFF).Name("RECENT_SCORING_EFF");
        Map(m => m.FG_PCT).Name("FG_PCT");
        Map(m => m.FG3_PCT).Name("FG3_PCT");
        Map(m => m.FT_PCT).Name("FT_PCT");
        Map(m => m.FGM).Name("FGM");
        Map(m => m.FGA).Name("FGA");
        Map(m => m.FG3M).Name("FG3M");
        Map(m => m.FG3A).Name("FG3A");
        Map(m => m.FTM).Name("FTM");
        Map(m => m.FTA).Name("FTA");
        Map(m => m.PLUS_MINUS).Name("PLUS_MINUS");
        Map(m => m.PLUS_MINUS_PER_MIN).Name("PLUS_MINUS_PER_MIN");
        Map(m => m.PLUS_MINUS_LAST_3_AVG).Name("PLUS MINUS_LAST_3_AVG");
        Map(m => m.PLUS_MINUS_LAST_5_AVG).Name("PLUS MINUS_LAST_5_AVG");
        Map(m => m.PLUS_MINUS_LAST_10_AVG).Name("PLUS MINUS_LAST_10_AVG");
        Map(m => m.PLUS_MINUS_CUM_AVG).Name("PLUS MINUS_CUM_AVG");
        Map(m => m.PLUS_MINUS_TREND).Name("PLUS MINUS_TREND");
        Map(m => m.PLUS_MINUS_CONSISTENCY).Name("PLUS MINUS_CONSISTENCY");
        Map(m => m.PTS_TREND).Name("PTS_TREND");
        Map(m => m.REB_TREND).Name("REB_TREND");
        Map(m => m.AST_TREND).Name("AST_TREND");
        Map(m => m.PTS_CONSISTENCY).Name("PTS_CONSISTENCY");
        Map(m => m.REB_CONSISTENCY).Name("REB_CONSISTENCY");
        Map(m => m.AST_CONSISTENCY).Name("AST_CONSISTENCY");
        Map(m => m.TEAM_MIN_PERCENTAGE).Name("TEAM_MIN_PERCENTAGE");
        Map(m => m.TEAM_PROJ_RANK).Name("TEAM_PROJ_RANK");
        Map(m => m.PTS_VS_TEAM_AVG).Name("PTS_VS_TEAM_AVG");
        Map(m => m.REB_VS_TEAM_AVG).Name("REB_VS_TEAM_AVG");
        Map(m => m.AST_VS_TEAM_AVG).Name("AST_VS_TEAM_AVG");
        Map(m => m.MIN_VS_TEAM_AVG).Name("MIN_VS_TEAM_AVG");
        Map(m => m.ROLE_CHANGE_3_10).Name("ROLE_CHANGE_3_10");
        Map(m => m.ROLE_CHANGE_5_10).Name("ROLE_CHANGE_5_10");
        Map(m => m.IS_TOP_3_PROJ).Name("IS_TOP_3_PROJ");
        Map(m => m.LOW_MIN_TOP_PLAYER).Name("LOW_MIN_TOP_PLAYER");
        Map(m => m.GAME_DATE)
            .Name("GAME_DATE")
            .Default(new DateTime?());
        Map(m => m.IS_HOME).Name("IS_HOME");
        Map(m => m.IS_B2B).Name("IS_B2B");
        Map(m => m.DAYS_REST).Name("DAYS_REST");
        Map(m => m.MATCHUP).Name("MATCHUP");
        Map(m => m.WL).Name("WL");
        Map(m => m.BLOWOUT_GAME).Name("BLOWOUT_GAME");
        Map(m => m.STL).Name("STL");
        Map(m => m.BLK).Name("BLK");
        Map(m => m.TOV).Name("TOV");
        Map(m => m.OREB).Name("OREB");
        Map(m => m.DREB).Name("DREB");
        Map(m => m.PF).Name("PF");
        Map(m => m.PLAYER_ID).Name("PLAYER_ID");
        Map(m => m.TEAM_ID).Name("TEAM_ID");
        Map(m => m.TEAM_NAME).Name("TEAM_NAME");
        Map(m => m.GAME_ID).Name("GAME_ID");
        Map(m => m.SEASON_ID).Name("SEASON_ID");
        Map(m => m.VIDEO_AVAILABLE).Name("VIDEO_AVAILABLE");
    }
}
public class NBADataManager : MonoBehaviour
{
    private List<PlayerData> _players = new List<PlayerData>();
    public List<string> Columns { get; private set; } = new List<string>();

    void Start()
    {
        LoadCSVData("nba_daily_combined.csv");
    }

    public void LoadCSVData(string fileName)
    {
        try
        {
            string filePath = Path.Combine(Application.dataPath, "Import", fileName);
            Debug.Log($"Loading CSV from: {filePath}");

            if (!File.Exists(filePath))
            {
                Debug.LogError($"File not found: {filePath}");
                return;
            }

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                MissingFieldFound = null,
                HeaderValidated = null
            };

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, config))
            {
                // Register the class map
                csv.Context.RegisterClassMap<PlayerDataMap>();

                try
                {
                    // Read headers
                    csv.Read();
                    csv.ReadHeader();
                    Columns = csv.HeaderRecord.ToList();
                    Debug.Log($"Found {Columns.Count} columns: {string.Join(", ", Columns)}");

                    // Read all records
                    _players = csv.GetRecords<PlayerData>().ToList();
                    Debug.Log($"Successfully loaded {_players.Count} players");

                    // Log first player for debugging
                    if (_players.Any())
                    {
                        var firstPlayer = _players.First();
                        Debug.Log($"First player: {firstPlayer.Player}, Team: {firstPlayer.Team}");
                    }
                }
                catch (Exception ex)
                {
                    Debug.LogError($"Error reading CSV data: {ex.Message}\n{ex.StackTrace}");
                }
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"Error loading CSV: {ex.Message}");
        }
    }

    public List<PlayerData> GetPlayers() => _players;

    public object GetPlayerValue(PlayerData player, string columnName)
    {
        try
        {
            var prop = typeof(PlayerData).GetProperty(columnName.Replace(" ", "_"));
            if (prop != null)
            {
                return prop.GetValue(player);
            }
            Debug.LogWarning($"Property {columnName} not found in PlayerData");
            return null;
        }
        catch (Exception ex)
        {
            Debug.LogError($"Error getting value for column {columnName}: {ex.Message}");
            return null;
        }
    }
}