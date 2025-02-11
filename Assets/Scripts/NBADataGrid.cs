using System;
using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;
using System.Linq;

public class NBADataGrid : MonoBehaviour
{
    private NBADataManager dataManager;
    private VisualElement root;
    private ListView listView;
    private const float ROW_HEIGHT = 30f;
    private const float COLUMN_WIDTH = 120f;
    private Dictionary<string, bool> sortDirections = new Dictionary<string, bool>();

    void Start()
    {
        dataManager = GetComponent<NBADataManager>();
        dataManager.LoadCSVData("nba_daily_combined.csv");
        
        root = GetComponent<UIDocument>().rootVisualElement;
        CreateUI();
    }

    private void CreateUI()
    {
        // Create scroll view for horizontal scrolling
        var scrollView = new ScrollView(ScrollViewMode.VerticalAndHorizontal);
        scrollView.style.flexGrow = 1;
        root.Add(scrollView);

        // Create main container
        var container = new VisualElement();
        container.style.flexGrow = 1;
        container.style.width = new Length(COLUMN_WIDTH * dataManager.Columns.Count, LengthUnit.Pixel);
        scrollView.Add(container);

        // Create header
        var headerRow = CreateHeaderRow();
        container.Add(headerRow);

        // Create ListView for data
        listView = new ListView();
        listView.fixedItemHeight = ROW_HEIGHT;
        listView.makeItem = MakeItem;
        listView.bindItem = BindItem;
        listView.itemsSource = dataManager.GetPlayers();
        
        container.Add(listView);

        // Apply styles
        ApplyStyles(container, headerRow);
    }

    private VisualElement CreateHeaderRow()
    {
        var headerRow = new VisualElement();
        headerRow.style.flexDirection = FlexDirection.Row;

        foreach (var column in dataManager.Columns)
        {
            var headerCell = new Button(() => SortByColumn(column)) { text = column };
            headerCell.AddToClassList("header-cell");
            headerCell.style.width = COLUMN_WIDTH;
            headerRow.Add(headerCell);
        }

        return headerRow;
    }

    private void SortByColumn(string columnName)
    {
        // Toggle sort direction
        if (!sortDirections.ContainsKey(columnName))
            sortDirections[columnName] = true;
        else
            sortDirections[columnName] = !sortDirections[columnName];

        bool ascending = sortDirections[columnName];

        // Get and sort the data
        var players = dataManager.GetPlayers().ToList();
        players.Sort((a, b) =>
        {
            var valueA = dataManager.GetPlayerValue(a, columnName);
            var valueB = dataManager.GetPlayerValue(b, columnName);

            if (valueA == null && valueB == null) return 0;
            if (valueA == null) return ascending ? -1 : 1;
            if (valueB == null) return ascending ? 1 : -1;

            int comparison = 0;
            if (valueA is IComparable comparableA && valueB is IComparable comparableB)
            {
                comparison = comparableA.CompareTo(comparableB);
            }
            else
            {
                comparison = valueA.ToString().CompareTo(valueB.ToString());
            }

            return ascending ? comparison : -comparison;
        });

        // Update ListView
        listView.itemsSource = players;
        listView.Rebuild();
    }

    private VisualElement MakeItem()
    {
        var row = new VisualElement();
        row.style.flexDirection = FlexDirection.Row;

        foreach (var column in dataManager.Columns)
        {
            var cell = new Label();
            cell.AddToClassList("grid-cell");
            cell.style.width = COLUMN_WIDTH;
            row.Add(cell);
        }

        return row;
    }

    private void BindItem(VisualElement row, int index)
    {
        var players = listView.itemsSource as List<PlayerData>;
        if (players != null && index < players.Count)
        {
            var player = players[index];
            var cells = row.Children();
            var cellIndex = 0;

            foreach (var column in dataManager.Columns)
            {
                var cellValue = dataManager.GetPlayerValue(player, column);
                var formattedValue = FormatValue(cellValue);
                ((Label)cells.ElementAt(cellIndex)).text = formattedValue;
                cellIndex++;
            }
        }
    }

    private string FormatValue(object value)
    {
        if (value == null) return "";
        
        if (value is double doubleValue)
            return doubleValue.ToString("F2");
        if (value is int intValue)
            return intValue.ToString("N0");
        if (value is DateTime dateTime)
            return dateTime.ToShortDateString();
        
        return value.ToString();
    }

    private void ApplyStyles(VisualElement container, VisualElement headerRow)
    {
        // Container styles
        container.style.backgroundColor = new StyleColor(new Color(0.2f, 0.2f, 0.2f));
        
        // Header styles
        headerRow.AddToClassList("header-row");
        
        // Add USS (UI Toolkit StyleSheet)
        var styleSheet = Resources.Load<StyleSheet>("NBADataGrid");
        root.styleSheets.Add(styleSheet);
    }
}