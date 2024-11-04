namespace Sudoku.ViewModels;

using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections;

public class SudokuBoardVM : ObservableObject {
    // Private Fiels
    private readonly SudokuCellVM[,] _board;
    private readonly List<SudokuBoxVM> _sudokuBoxes = new();

    // Constructor
    public SudokuBoardVM() {
        for (int i = 0; i < 9; i++) {
            _sudokuBoxes.Add(new SudokuBoxVM());
        }
    }
    public SudokuBoardVM(SudokuCellVM[,] board) {
        _board = board;
        for (int i = 0; i < 9; i++) {
            _sudokuBoxes.Add(new SudokuBoxVM(i, board));
        }
    }

    public IEnumerable SudokuBoxes {
        get => _sudokuBoxes;
    }


    public void SetBoard(int[,] boardNums) {
        for (int row = 0; row < 9; row++) {
            for (int col = 0; col < 9; col++) {
                _board[row, col].CellValue = boardNums[row, col];
            }
        }
    }
    public void SetOptions(List<int>[,] boardOptions) {
        for (int row = 0; row < 9; row++) {
            for (int col = 0; col < 9; col++) {
                if (boardOptions[row, col] != null) {
                    _board[row, col].SetPencilMarks(boardOptions[row, col]);
                }
            }
        }
    }

    public IEnumerable<SudokuCellVM> GetRow(int row) {
        for (int col = 0; col < 9; col++) {
            yield return _board[row, col];
        }
    }

    public IEnumerable<SudokuCellVM> GetColumn(int col) {
        for (int row = 0; row < 9; row++) {
            yield return _board[row, col];
        }
    }

    public IEnumerable<SudokuCellVM> GetBox(int boxRow, int boxCol) {
        int startRow = boxRow * 3;
        int startCol = boxCol * 3;

        for (int row = 0; row < 3; row++) {
            for (int col = 0; col < 3; col++) {
                yield return _board[startRow + row, startCol + col];
            }
        }
    }
    public IEnumerable<IEnumerable<SudokuCellVM>> GetRows() {
        for (int row = 0; row < 9; row++) {
            yield return GetRow(row);
        }
    }


    // Properties
    //public string AlarmText {
    //    get => _alarmText;
    //    set => SetProperty(ref _alarmText, value);
    //}
}