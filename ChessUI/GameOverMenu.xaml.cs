using ChessLogic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChessUI
{
    /// <summary>
    /// Lógica de interacción para GameOverMenu.xaml
    /// </summary>
    public partial class GameOverMenu : UserControl
    {

        public event Action<Option> OptionSelected;

        public GameOverMenu(GameState gameState)
        {
            InitializeComponent();

            Result result = gameState.Result;
            WinnerText.Text = GetWinnerText(result.Winner);
            ReasonText.Text = GetReasonText(result.Reason, gameState.CurrentPlayer);
        }

        private static string GetWinnerText(Player winner)
        {
            return winner switch
            {
                Player.White => "Gano las blancas",
                Player.Black => "Ganan los negros",
                _ => "Empate",
            };
        }

        private static string PlayerString(Player player)
        {
            return player switch
            {
                Player.White => "Blancas",
                Player.Black => "Negras",
                _ => "",
            };
        }

        private static string GetReasonText(EndReason reason, Player currentPlayer)
        {
            return reason switch
            {
                EndReason.Checkmate => $"El jugador {PlayerString(currentPlayer)} ha dado jaque mate",
                EndReason.Stalemate => "Empate por ahogado",
                EndReason.FiftyMoveRule => "Empate por regla de los 50 movimientos",
                EndReason.ThreefoldRepetition => "Empate por triple repetición",
                EndReason.InsufficientMaterial => "Empate por material insuficiente",
                _ => "",
            };
        }

        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            OptionSelected?.Invoke(Option.Restart);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            OptionSelected.Invoke(Option.Exit);
        }
    }
}
