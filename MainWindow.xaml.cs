using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
namespace GeradorCasosdeTestes
{
    public partial class MainWindow : Window
    {
        #region Componentes
        class WrapPanelEntrada : WrapPanel
        {
            public Entrada entrada { get; set; }
        }
        class WrapPanelEntradaValor : WrapPanel
        {
            public EntradaValores entValor { get; set; }
        }
        class TextBoxEntrada : TextBox
        {
            public Entrada entrada { get; set; }
        }
        class TextBoxEntradaValor : TextBox
        {
            public EntradaValores entValor { get; set; }
        }
        class Entrada
        {
            public int id { get; set; }
            public string valor { get; set; }
            public List<EntradaValores> listaEntradaValor { get; set; }
            public Entrada()
            {
                listaEntradaValor = new List<EntradaValores>();
            }
        }
        class EntradaValores
        {
            public int id { get; set; }
            public string valor { get; set; }
            public Entrada entrada { get; set; }
        }
        #endregion

        #region Variaveis
        int idEntrada = 0;
        int idValor = 0;
        List<Entrada> listaEntrada = new List<Entrada>();
        #endregion

        public MainWindow()
        {
            InitializeComponent();
        }
        void BtnNovaEntrada_Click(object sender, RoutedEventArgs e)
        {
            #region Cria Novo Objeto
            Entrada entrada = new Entrada()
            {
                id = ++idEntrada
            };
            #endregion

            #region Cria Novo WrapPanel Entrada
            WrapPanelEntrada wpEntrada = new WrapPanelEntrada();
            //wpEntrada.Background = Brushes.Aqua;
            wpEntrada.Orientation = Orientation.Horizontal;
            wpEntrada.Margin = new Thickness(10, 10, 10, 10);
            #endregion

            #region Cria Novo Botão 'Remover Entrada'
            Button btnRemoverEntrada = new Button();
            btnRemoverEntrada.Height = 20;
            btnRemoverEntrada.Width = 85;
            btnRemoverEntrada.Content = "- Remover";
            btnRemoverEntrada.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            btnRemoverEntrada.Margin = new Thickness(5, 5, 5, 5);
            #endregion

            #region Cria Campo Valor Entrada
            TextBoxEntrada edtTextEntrada = new TextBoxEntrada();
            edtTextEntrada.Height = 20;
            edtTextEntrada.Width = 85;
            edtTextEntrada.Margin = new Thickness(5, 5, 5, 5);
            #endregion

            #region Cria Novo Botão Incluir Valores
            Button btnIncluir = new Button();
            btnIncluir.Height = 20;
            btnIncluir.Width = 30;
            btnIncluir.Content = '+';
            btnIncluir.Margin = new Thickness(5, 5, 5, 5);
            #endregion

            #region Inclui Componentes Ao WrapPanel
            pnEntradas.Children.Add(wpEntrada);
            wpEntrada.Children.Add(btnRemoverEntrada);
            wpEntrada.Children.Add(edtTextEntrada);
            wpEntrada.Children.Add(btnIncluir);
            #endregion

            #region Eventos dos botões
            edtTextEntrada.TextChanged += edtTextEntrada_TextChanged;
            btnRemoverEntrada.Click += BtnRemoverEntrada_Click;
            btnIncluir.Click += BtnIncluirValor_Click;
            #endregion

            #region Adiciona Valores de Entrada na Lista
            wpEntrada.entrada = entrada;
            edtTextEntrada.entrada = entrada;
            listaEntrada.Add(entrada);
            #endregion
        }
        void BtnRemoverEntrada_Click(object sender, RoutedEventArgs e)
        {
            #region Identificação do componente
            Button btn = sender as Button;
            WrapPanelEntrada panel = btn.Parent as WrapPanelEntrada;
            #endregion

            #region Remove WrapPanel e Valores da Entrada
            pnEntradas.Children.Remove(panel);
            listaEntrada.Remove(panel.entrada);
            #endregion
        }
        void BtnIncluirValor_Click(object sender, RoutedEventArgs e)
        {
            #region Identificação do componente
            Button btn = sender as Button;
            WrapPanelEntrada wpPanel = btn.Parent as WrapPanelEntrada;
            #endregion

            #region Cria Novo Objeto(Lista) de Valores
            EntradaValores entValores = new EntradaValores()
            {
                id = ++idValor
            };
            #endregion

            #region Cria Novo WrapPanel de Valores
            WrapPanelEntradaValor wpEntradaValor = new WrapPanelEntradaValor();
            wpEntradaValor.Orientation = Orientation.Horizontal;
            wpEntradaValor.Margin = new Thickness(5, 5, 5, 5);
            //wpEntradaValor.Background = Brushes.Red;
            #endregion

            #region Cria Novo Campo de Valores
            TextBoxEntradaValor edtTextIncluirValor = new TextBoxEntradaValor();
            edtTextIncluirValor.Height = 20;
            edtTextIncluirValor.Width = 85;
            edtTextIncluirValor.Margin = new Thickness(5, 5, 5, 5);
            #endregion

            #region Cria Novo Botão Excluir Valor
            Button btnExcluirValor = new Button();
            btnExcluirValor.Height = 20;
            btnExcluirValor.Width = 30;
            btnExcluirValor.Content = '-';
            btnExcluirValor.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            btnExcluirValor.Margin = new Thickness(5, 5, 0, 5);
            #endregion

            #region Objeto Recebe Valores
            wpEntradaValor.entValor = entValores;
            edtTextIncluirValor.entValor = entValores;
            #endregion

            #region Inclui Os Componentes no WrapPanel
            wpPanel.Children.Add(wpEntradaValor);
            wpEntradaValor.Children.Add(btnExcluirValor);
            wpEntradaValor.Children.Add(edtTextIncluirValor);
            #endregion

            #region Eventos dos componentes
            btnExcluirValor.Click += BtnExcluirValor_Click;
            edtTextIncluirValor.TextChanged += edtTextIncluirValor_TextChanged;
            #endregion

            #region Adiciona Valores de Entrada na Lista
            wpEntradaValor.entValor = entValores;
            wpPanel.entrada.listaEntradaValor.Add(entValores);
            #endregion
        }
        void edtTextIncluirValor_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBoxEntradaValor edtTextValor = sender as TextBoxEntradaValor;
            edtTextValor.entValor.valor = edtTextValor.Text;
        }
        void BtnExcluirValor_Click(object sender, RoutedEventArgs e)
        {
            #region Identifica o Componente
            Button btn = sender as Button;
            WrapPanelEntradaValor wpEntradaValor = btn.Parent as WrapPanelEntradaValor;
            WrapPanelEntrada wpEntrada = wpEntradaValor.Parent as WrapPanelEntrada;
            #endregion

            #region Remove WrapPanel e Valores da Entrada
            wpEntrada.Children.Remove(wpEntradaValor);
            wpEntrada.entrada.listaEntradaValor.Remove(wpEntradaValor.entValor);
            #endregion
        }
        void edtTextEntrada_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBoxEntrada campoentrada = sender as TextBoxEntrada;
            campoentrada.entrada.valor = campoentrada.Text;
        }
        void BtnGeradorDeCasos_Click(object sender, RoutedEventArgs e)
        {
            #region Verificador de Valores
            string teste = "";
            foreach (Entrada spteste in listaEntrada)
            {
                teste += "\n" + spteste.valor + ":";
                foreach (EntradaValores sp in spteste.listaEntradaValor)
                {
                    teste += " Valor: " + sp.valor;
                }
            }
            MessageBox.Show(teste);
            #endregion



        }
        static IEnumerable<IEnumerable<T>> CartesianProduct<T>(this IEnumerable<IEnumerable<T>> lista)
        {
            IEnumerable<IEnumerable<T>> emptyProduct = new[] { Enumerable.Empty<T>() };
            return lista.Aggregate(
                emptyProduct,
                (accumulator, sequence) =>
                from acc in accumulator
                from item in sequence
                select acc.Concat(new[] { item }));
        }
        static IEnumerable<IEnumerable<T>> CartesianProduct1<T>(this IEnumerable<IEnumerable<T>> lista)
        {
            IEnumerable<IEnumerable<T>> emptyProduct = new[] { Enumerable.Empty<T>() };
            return lista.Aggregate(
                emptyProduct,
                (accumulator, sequence) =>
                from acc in accumulator
                from item in sequence
                select acc.Concat(new[] { item }));
        }
    }
}
