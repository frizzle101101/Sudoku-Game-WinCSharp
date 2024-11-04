namespace Sudoku;

using Sudoku.ViewModels;
using System.Windows;

class Program {
    private static char[][] board =
    [['.', '.', '8', '.', '.', '9', '.', '.', '.'],
    ['.', '1', '.', '.', '.', '.', '6', '4', '9'],
    ['3', '.', '9', '.', '.', '.', '.', '.', '.'],
    ['.', '.', '2', '.', '.', '.', '.', '.', '.'],
    ['5', '.', '.', '.', '.', '.', '.', '.', '.'],
    ['1', '.', '.', '.', '.', '.', '.', '.', '8'],
    ['.', '.', '.', '.', '.', '.', '.', '9', '.'],
    ['.', '.', '.', '9', '4', '1', '.', '.', '.'],
    ['9', '.', '.', '.', '.', '.', '.', '7', '.']];

    

    [STAThread]
    public static void Main(string[] args) {
        //try {

            var vm = new MainWindowVM(board);
            var mainWindow = new MainWindow {
                DataContext = vm
            };

            var app = new Application();
            app.Run(mainWindow);

        //} catch (Exception ex) {
            //log.Err(ex);
        //} finally {
            //Log.CloseAndFlush();
        //}
    }
}

