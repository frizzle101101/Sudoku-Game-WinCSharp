namespace Sudoku.ViewModels;

using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections;

public class SudokuBoxVM : ObservableObject {
    // Private Fiels
    private readonly List<SudokuCellVM> _sudokuCells = new();

    // Constructor
    public SudokuBoxVM() {
        for (int i = 0; i < 9; i++) {
            _sudokuCells.Add(new SudokuCellVM());
        }
    }
    public SudokuBoxVM(int id, SudokuCellVM[,] board) {
        int boxRow = id / 3;
        int boxCol = id % 3;
        for (int i = 0; i < 9; i++) {
            int row = (i / 3) + (boxRow * 3);
            int col = (i % 3) + (boxCol * 3);
            board[row, col] = new SudokuCellVM(boxRow, boxCol, row, col);
            _sudokuCells.Add(board[row, col]);
        }
    }

    public IEnumerable SudokuCells {
        get => _sudokuCells;
    }

    // Properties
    //public string AlarmText {
    //    get => _alarmText;
    //    set => SetProperty(ref _alarmText, value);
    //}
}