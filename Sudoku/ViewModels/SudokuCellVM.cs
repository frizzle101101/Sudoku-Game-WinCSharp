namespace Sudoku.ViewModels;

using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections;

public class SudokuCellVM : ObservableObject {
    private class PencilMark : ObservableObject {
        private bool _visibility;

        public PencilMark(int num, bool visibility) {
            Num = num;
            Visibility = visibility;
        }

        public int Num { get; }
        public bool Visibility { get => _visibility; set => SetProperty(ref _visibility, value); }
    }

    // Private Fiels
    private readonly List<PencilMark> _pencilMarks = new();
    private bool _cellValueVisibility = false;
    private int _cellValue;
    private List<int> _cellOptions;

    // Constructor
    public SudokuCellVM() {
        CellValue = 0;
        for (int i = 0; i < 9; i++) {
            _pencilMarks.Add(new PencilMark(i + 1, false));
        }
    }

    public SudokuCellVM(int boxRow, int boxCol, int row, int col) : this() {
        BoxRow = boxRow;
        BoxCol = boxCol;
        Row = row;
        Col = col;
    }


    // Properties
    public IEnumerable PencilMarks {
        get => _pencilMarks;
    }
    public int BoxRow { get; set; }
    public int BoxCol { get; set; }
    public int Row { get; set; }
    public int Col { get; set; }

    public bool CellValueVisibility {
        get => _cellValueVisibility;
        private set => SetProperty(ref _cellValueVisibility, value);
    }

    public int CellValue {
        get => _cellValue;
        set {
            if (value == 0) {
                CellValueVisibility = false;
            } else {
                CellValueVisibility = true;
            }
            SetProperty(ref _cellValue, value);
        }
    }

    public List<int> CellOptions {
        get => _cellOptions;
        set {
            SetProperty(ref _cellOptions, value);
        }
    }

    //Helpers
    public void SetPencilMarks(List<int> marks) {
        bool[] visibilityBools = new bool[9];
        foreach (var mark in marks) {
            visibilityBools[mark - 1] = true;
        }
        for(int i = 0; i < visibilityBools.Length; i++) {
            _pencilMarks[i].Visibility = visibilityBools[i];
        }
        OnPropertyChanged(nameof(PencilMarks));
    }
}