using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Documents;
using System.Windows.Input;

namespace Sudoku.ViewModels;
public class MainWindowVM : ObservableObject {
    // Private Fiels
    private Solution1 _solution1;
    private Solution _solution;
    private readonly SudokuCellVM[,] _board = new SudokuCellVM[9, 9];
    private char[][] _boardChars;
    private int[,] _boardNums = {
        {5, 3, 0, 0, 7, 0, 0, 0, 0},
        {6, 0, 0, 1, 9, 5, 0, 0, 0},
        {0, 9, 8, 0, 0, 0, 0, 6, 0},
        {8, 0, 0, 0, 6, 0, 0, 0, 3},
        {4, 0, 0, 8, 0, 3, 0, 0, 1},
        {7, 0, 0, 0, 2, 0, 0, 0, 6},
        {0, 6, 0, 0, 0, 0, 2, 8, 0},
        {0, 0, 0, 4, 1, 9, 0, 0, 5},
        {0, 0, 0, 0, 8, 0, 0, 7, 9}
    };
    private List<int>[,] _boardOptions;

    // Constructor
    public MainWindowVM() {
        SudokuBoardVM = new SudokuBoardVM(_board);
        SudokuBoardVM.SetBoard(_boardNums);
    }
    public MainWindowVM(char[][] board) {
        _solution = new Solution();
        _solution1 = new Solution1();
        //_solution.SolveSudoku(board);
        //sol.SolveSudoku(board);

        _boardChars = board;
        _solution1.ConvertBoardCharsToNums(ref _boardNums, board, _boardNums.GetLength(0), _boardNums.GetLength(1));

        SudokuBoardVM = new SudokuBoardVM(_board);
        SudokuBoardVM.SetBoard(_boardNums);
    }

    //private void ConvertBoardCharsToNums(char[][] board) {
    //    for (int i = 0; i < 9; i++) {
    //        for (int j = 0; j < 9; j++) {
    //            if (board[i][j] == '.') {
    //                _boardNums[i, j] = 0;
    //            } else {
    //                _boardNums[i, j] = board[i][j] - 48;
    //            }

    //        }
    //    }
    //}

    //private void ConvertBoardNumsToChars(int[,] board) {
    //    for (int i = 0; i < 9; i++) {
    //        for (int j = 0; j < 9; j++) {
    //            if (board[i,j] == 0) {
    //                _boardChars[i][ j] = '.';
    //            } else {
    //                _boardChars[i][ j] = (char)(board[i, j] + 48);
    //            }

    //        }
    //    }
    //}

    // Properties
    public SudokuBoardVM SudokuBoardVM { get; set; }


    public RelayCommand FillOptionsCommand => new RelayCommand(FillOptionsAction);
    public RelayCommand SolveCommand => new RelayCommand(SolveAction);

    private void FillOptionsAction() {
        _boardOptions = _solution1.GetOptions(_boardNums);
        SudokuBoardVM.SetOptions(_boardOptions);
    }
    private void SolveAction() {
        _solution.SolveSudoku(_boardChars);
        _solution1.ConvertBoardCharsToNums(ref _boardNums, _boardChars, _boardNums.GetLength(0), _boardNums.GetLength(1));
        _boardOptions = _solution1.GetOptions(_boardNums);
        SudokuBoardVM.SetOptions(_boardOptions);
        SudokuBoardVM.SetBoard(_boardNums);
    }

}
